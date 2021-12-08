import { Component, Inject } from "@angular/core";
import { NoteService } from '../note.service';


import {
  MAT_DIALOG_DATA,
  MatDialogRef
} from "@angular/material/dialog";

@Component({
  selector: 'app-note-dialog',
  templateUrl: './note-add-dialog.component.html',
  styleUrls: ['./note-add-dialog.component.css']
})
export class NoteAddDialogComponent {
  constructor(private dialogRef: MatDialogRef<NoteAddDialogComponent>,
  private service: NoteService) {}

  onCreateNode(title : string, body : string){
    this.service.createNote(title, body)
      .subscribe(_ => 
        {
          this.dialogRef.close({ isAdded: true});
        });
  }

  onClose(){
    this.dialogRef.close({ isAdded: false});
  }
}