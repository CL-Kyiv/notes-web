import { Injectable } from '@angular/core';
import { HttpParams, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Note } from './note.type';
 
@Injectable({
  providedIn: 'root',
})
export class NoteService {
  
  config = require('./config/host.config.json');

  readonly APIUrl = this.config.host.endpoint + 'notes';
  
  constructor(private http: HttpClient) {}

  getNotes(): Observable<Note[]> {
    return this.http.get<Note[]>(this.APIUrl, {responseType: 'json'});
  }
  
  updateNote(id: number, title: string, Body: string){
    let params = new HttpParams();
    params = params.append('id', id);

    const body = { Title : title, 
      Body : Body };
                   
    return this.http.put(this.APIUrl, body, {params : params});
  }

  deleteNote(id: number){
    let params = new HttpParams();
    params = params.append('id', id);

    return this.http.delete(this.APIUrl, {params : params});
  }

  createNote(title: string, Body: string){
    const body = { Title : title, 
      Body : Body };
      
   return this.http.post(this.APIUrl, body);
  }
}