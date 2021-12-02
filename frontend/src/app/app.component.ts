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

  onGridReady(params: any) {
    this.gridApi = params.api;
    this.gridApi.sizeColumnsToFit();
    const api$ = this.refreshData$.pipe(
      switchMap(() => this.service.getNotes())
    );
    api$.subscribe(notes => {this.notesData = notes;});
    this.refreshGridData();
  }

  refreshGridData(){
    this.refreshData$.next();
  }

  onRowDataChanged(){
    if(this.rowIsSelected)
      this.setSelected();
  }

  setSelected() {
    const selectedRows = JSON.parse(localStorage.getItem("selectedRows")!);

    this.gridApi.forEachNode((node : any, index: number) => {
      
       // adapt with you own unique role-id rule
       const selectNode = selectedRows.some((row : any) => {
          return row.id === node.data.id;
       });
 
       if (selectNode) {
        this.gridApi.getRowNode(node.id).selectThisNode(true);
        this.selectedData.title = node.data.title;
        this.selectedData.body = node.data.body;
       }
    });
  }
  openAddDialog(){
    const dialogRef = this.matDialog.open(NoteAddDialogComponent);
      dialogRef.afterClosed().subscribe((result : any) => {
        if(result.isAdded){
          this.refreshGridData();
          this.rowIsSelected = false;
        }
      });
  }

  openEditDialog() {
    const dialogRef = this.matDialog.open(NoteEditDialogComponent, { data: 
      { 
        SelectedData : this.selectedData
      }});
    dialogRef.afterClosed().subscribe((result : any) => {
      if(result.isUpdated)
      this.refreshGridData();
    });
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
    let selectedNodes = this.gridApi.getSelectedNodes();
    this.selectedData = selectedNodes.map((node: any) => node.data)[0];
    localStorage.setItem("selectedRows", JSON.stringify(this.gridApi.getSelectedRows()));
    this.rowIsSelected = true;
  }

  onDeleteNode() {
    this.service.deleteNote(this.selectedData.id).subscribe(_ => this.refreshGridData());
    this.rowIsSelected = false;
  }
}
