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
    return this.http.get<Note[]>(this.APIUrl, {responseType: 'json'});
  }
}
