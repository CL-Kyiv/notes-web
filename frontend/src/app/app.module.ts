import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import {MatDialogModule} from '@angular/material/dialog';
import { AppComponent } from './app.component';
import { NoteService } from './note.service';
import { AgGridModule } from 'ag-grid-angular';
import { BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {HttpClientModule} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NoteDialogComponent } from './note-dialog/note-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    NoteDialogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AgGridModule.withComponents([]),
    MatDialogModule,
    BrowserAnimationsModule
  ],
  providers: [NoteService],
  bootstrap: [AppComponent],
  entryComponents: [NoteDialogComponent]
})
export class AppModule { }
