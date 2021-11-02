import { Component } from '@angular/core';
import { SharedService } from './shared.service';
import { ColDef } from 'ag-grid-community';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'NotesApp';

  constructor(private service: SharedService) {}

  rowData$: any = this.service.getNotes();
  
  onGridReady(params: any) {
    params.api.sizeColumnsToFit();
  }

  rowHeight = 50;

  columnDefs: ColDef[] = [
    { 
      field: 'id',
      width: 1
    },
    { 
      field: 'title',
      width: 30
    },
    { 
      field: 'body',
      width: 60
    },
    { 
      field: 'createdDate',
      width: 9
    }
  ];
  
}
