import { Component, Inject } from "@angular/core";
import { NoteService } from '../note.service';


import {
  MAT_DIALOG_DATA,
  MatDialogRef
} from "@angular/material/dialog";

@Component({
  selector: 'app-note-dialog',
  templateUrl: './note-dialog.component.html',
  styleUrls: ['./note-dialog.component.css']
})
export class NoteDialogComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public data: any, 
  private dialogRef: MatDialogRef<NoteDialogComponent>,
  private service: NoteService) {}

  onUpdateNode(title : string, body : string){
    this.service.updateNote(this.data.id, title, body);
    this.dialogRef.close();
  }

  onClose(){
    this.dialogRef.close();
  }
}
