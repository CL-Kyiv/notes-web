import { Component } from '@angular/core';
import { NoteService } from './note.service';
import { ColDef } from 'ag-grid-community';
import { Note } from './note.type';
import { Observable } from 'rxjs';
import { NoteUpdateRequest } from './note.update.request';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  private gridApi : any;
  rowHeight = 50;
  updateRequest : NoteUpdateRequest;

  constructor(private service: NoteService) {}

  rowData$: Observable<Note[]> = this.service.getNotes();
  
  onGridReady(params: any) {
    this.gridApi = params.api;
    this.gridApi.sizeColumnsToFit();
  }
 
  columnDefs: ColDef[] = [
    { 
      field: 'title',
      editable: true,
      cellEditor: 'agLargeTextCellEditor',
      width: 30
    },
    { 
      field: 'body',
      editable: true,
      cellEditor: 'agLargeTextCellEditor',
      width: 35
    },
    { 
      field: 'createdDate',
      width: 35
    }
  ];

  getSelectedRowData() {
    let selectedNodes = this.gridApi.getSelectedNodes();
    let selectedData = selectedNodes.map((node : any) => node.data);
    return selectedData[0];
  }

  OnClickCallbackUpdateNode(){
    var selectedData = this.getSelectedRowData();
    this.service.updateNote(selectedData.id, selectedData.title, selectedData.body);
  }

  OnClickCallbackDeleteNode(){
    var selectedData = this.getSelectedRowData();
    this.service.deleteNote(selectedData.id);
  }

  OnClickCallbackCreateNode(){
    this.service.createNote();
  }

  // onCellEditingStopped(params : any) {
  //   var data = params.data;

  //   this.service.updateNote(data.id, data.title, data.body);
  // }
  
}
