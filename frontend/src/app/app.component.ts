import { Component } from '@angular/core';
import { NoteService } from './note.service';
import { ColDef } from 'ag-grid-community';
import { Note } from './note.type';
import { Observable, Subject } from 'rxjs';
import { switchMap, tap } from 'rxjs/operators';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { NoteDialogComponent } from './note-dialog/note-dialog.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  private gridApi : any;
  rowHeight = 50;

  constructor(private service: NoteService,
    private matDialog : MatDialog) {}

  refreshData$: Subject<void> = new Subject<void>();
  notesData:  Note[] = [];

  rowIsSelected : boolean = false;

  selectedData : any;
  
  onGridReady(params: any) {
    this.gridApi = params.api;
    this.gridApi.sizeColumnsToFit();
    const api$ = this.refreshData$
    .pipe(
      switchMap(() => {
        return this.service.getNotes();
      },
      tap(notes=> this.notesData = notes ))
    );
    api$.subscribe(()=>{});
    this.fetchNotes();
  }

  private fetchNotes(): void {
    this.refreshData$.next();
  }

  openEditDialog(){
    this.matDialog.open(NoteDialogComponent, {data : this.selectedData});
  }
 
  columnDefs: ColDef[] = [
    { 
      field: 'title',
      editable: true,
      cellEditor: 'agLargeTextCellEditor',
      width: 30
    }
  ];

  onRowClick() {
    let selectedNodes = this.gridApi.getSelectedNodes();
    this.selectedData = selectedNodes.map((node : any) => node.data)[0];
    this.rowIsSelected = true;
  }

  onDeleteNode(){
    this.service.deleteNote(this.selectedData.id);
  }

  onCreateNode(){
    this.service.createNote();
  }
}
