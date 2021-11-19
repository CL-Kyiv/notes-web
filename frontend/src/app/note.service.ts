import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Note } from './note.type';
 
@Injectable({
  providedIn: 'root',
})
export class NoteService {
  
  config = require('./config/host.config.json');

  readonly APIUrl = this.config.host.endpoint;
  
  constructor(private http: HttpClient) {}

  getNotes(): Observable<Note[]> {
    return this.http.get<Note[]>(this.APIUrl + 'notes', {responseType: 'json'});
  }
  
  updateNote(id: number, title: string, Body: string): any{
    const body = { Title : title, 
      Body : Body };
                   
    this.http.put(this.APIUrl + `notes?id=${id}`, body).subscribe();
  }

  deleteNote(id: number){
    this.http.delete(this.APIUrl + `notes?id=${id}`).subscribe();
  }

  createNote(){
    this.http.post(this.APIUrl + 'notes', null).subscribe();
  }
}
