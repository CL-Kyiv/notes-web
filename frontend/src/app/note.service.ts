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
  
  updateNote(id: number, title: string, Body: string){
    const body = { Title : title,
      Body : Body };
                   
    return this.http.put(this.APIUrl + `notes?id=${id}`, body);
  }

  deleteNote(id: number){
    return this.http.delete(this.APIUrl + `notes?id=${id}`);
  }

  createNote(title: string, Body: string){
    const body = { Title : title, 
      Body : Body };
   return this.http.post(this.APIUrl + 'notes', body);
  }
}