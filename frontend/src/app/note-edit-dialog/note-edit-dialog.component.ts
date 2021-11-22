import { Component, Inject } from "@angular/core";
import { NoteService } from '../note.service';


import {
  MAT_DIALOG_DATA,
  MatDialogRef
} from "@angular/material/dialog";

@Component({
  selector: 'app-note-dialog',
  templateUrl: './note-edit-dialog.component.html',
  styleUrls: ['./note-edit-dialog.component.css']
})
export class NoteEditDialogComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public data: any, 
  private dialogRef: MatDialogRef<NoteEditDialogComponent>,
  private service: NoteService) {}

  onUpdateNode(title : string, body : string){
    this.service.updateNote(this.data.SelectedData.id, title, body)
      .subscribe(_ => 
        {
          this.refreshGridData();
          this.dialogRef.close();
        });
  }

  refreshGridData(): void {
    this.data.RefreshData.next();
  }

  onClose(){
    this.dialogRef.close();
  }
}
