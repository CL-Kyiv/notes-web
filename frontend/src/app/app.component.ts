import { Component } from '@angular/core';
import { SharedService } from './shared.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'NotesApp';
  
  constructor(private service: SharedService) {}

  notesData: any;

  ngOnInit(): void {
    this.refreshNotesData();
  }

  refreshNotesData() {
    this.service.getNotes().subscribe((data) => {
      this.notesData = data;
    });
  }
}
