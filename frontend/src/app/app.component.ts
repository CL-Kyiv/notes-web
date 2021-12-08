import { Component } from '@angular/core';
import { NoteService } from './note.service';
import { LogsService } from './logs.service';
import { ColDef } from 'ag-grid-community';
import { Note } from './note.type';
import { Subject } from 'rxjs';
import { switchMap, filter } from 'rxjs/operators';
import { MatDialog } from '@angular/material/dialog';
import { GridApi } from 'ag-grid-community';
import { NoteEditDialogComponent } from './note-edit-dialog/note-edit-dialog.component';
import { NoteAddDialogComponent } from './note-add-dialog/note-add-dialog.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  private gridApi: GridApi;
  refreshData$: Subject<void> = new Subject<void>();
  selectedData: Note | undefined;

  constructor(
    private noteService: NoteService, 
    private logsService: LogsService,
    private matDialog: MatDialog
  ) {}

  get rowIsSelected(): boolean {
    return this.gridApi && this.gridApi?.getSelectedNodes().length > 0;
  }

  onGridReady(params: any) {
    this.gridApi = params.api;
    this.gridApi.sizeColumnsToFit();
    const api$ = this.refreshData$.pipe(
      switchMap(() => this.noteService.getNotes())
    );
    api$.subscribe((notes) => {
      this.gridApi.setRowData(notes);
    });
    this.refreshGridData();
  }

  refreshGridData() {
    this.refreshData$.next();
  }

  onRowDataChanged() {
    if (this.selectedData) {
      let selectedNode = this.gridApi
        .getRenderedNodes()
        .filter((n) => n.data.id === this.selectedData!.id)[0];
      this.selectedData = selectedNode.data;
      selectedNode.selectThisNode(true);
    }
  }

  openAddDialog() {
    const dialogRef = this.matDialog.open(NoteAddDialogComponent);
    dialogRef.afterClosed().pipe(filter(r => r.isAdded)).subscribe(() => {
      this.refreshGridData();
    });
  }

  openEditDialog() {
    const dialogRef = this.matDialog.open(NoteEditDialogComponent, {
      data: {
        SelectedData: this.selectedData,
      },
    });
    dialogRef.afterClosed().pipe(filter(r => r.isUpdated)).subscribe(() => {
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
  }

  onDeleteNode = () =>
    this.noteService.deleteNote(this.selectedData!.id).subscribe((_) => {
      this.selectedData = undefined;
      this.refreshGridData();
    });

  downloadFileWithLogs = () => this.logsService.downloadFileWithLogs();
}
