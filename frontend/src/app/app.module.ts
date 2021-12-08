import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { MatDialogModule } from '@angular/material/dialog';
import { AppComponent } from './app.component';
import { NoteService } from './note.service';
import { AgGridModule } from 'ag-grid-angular';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NoteEditDialogComponent } from './note-edit-dialog/note-edit-dialog.component';
import { NoteAddDialogComponent } from './note-add-dialog/note-add-dialog.component';
import { LogsService } from './logs.service';

@NgModule({
  declarations: [
    AppComponent,
    NoteEditDialogComponent,
    NoteAddDialogComponent
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
  providers: [
    NoteService,
    LogsService
  ],
  bootstrap: [AppComponent],
  entryComponents: [NoteEditDialogComponent]
})
export class AppModule { }
