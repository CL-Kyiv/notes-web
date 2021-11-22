import { Component } from '@angular/core';
import { NoteService } from './note.service';
import { ColDef } from 'ag-grid-community';
import { Note } from './note.type';
import { Subject } from 'rxjs';
import { switchMap, tap} from 'rxjs/operators';
import { MatDialog } from '@angular/material/dialog';
import { NoteEditDialogComponent } from './note-edit-dialog/note-edit-dialog.component';
import { NoteAddDialogComponent } from './note-add-dialog/note-add-dialog.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  private gridApi: any;
  rowHeight = 50;

  constructor(private service: NoteService, private matDialog: MatDialog) {}

  refreshData$: Subject<void> = new Subject<void>();
  notesData: Note[] = [];

  rowIsSelected: boolean = false;

  selectedData: Note;
  selectedNodes : any;

  onGridReady(params: any) {
    this.gridApi = params.api;
    this.gridApi.sizeColumnsToFit();
    const api$ = this.refreshData$.pipe(
      switchMap(() => this.service.getNotes()),
      tap((notes) => (this.notesData = notes))
    );
    api$.subscribe(() => {});
    this.refreshGridData();
    this.refreshData$.subscribe(_ => this.rowIsSelected = false)
  }

  refreshGridData(){
    this.refreshData$.next();
  }

  openAddDialog(){
    const dialogRef = this.matDialog.open(NoteAddDialogComponent, { data: 
      {
        RefreshData : this.refreshData$
      }});
  }

  openEditDialog() {
    const dialogRef = this.matDialog.open(NoteEditDialogComponent, { data: 
      { 
        SelectedData : this.selectedData, 
        RefreshData : this.refreshData$
      }});
  }

  columnDefs: ColDef[] = [
    {
      field: 'title',
      editable: false,
      cellEditor: 'agLargeTextCellEditor',
      width: 30,
      
    },
  ];

  onRowClick() {
    this.selectedNodes = this.gridApi.getSelectedNodes();
    this.selectedData = this.selectedNodes.map((node: any) => node.data)[0];
    this.rowIsSelected = true;
  }

  onDeleteNode() {
    this.service.deleteNote(this.selectedData.id).subscribe(_ => this.refreshGridData());
    this.rowIsSelected = false;
  }
}
