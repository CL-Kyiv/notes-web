import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SharedService {
  
  config = require('./config/host.config.json');

  readonly APIUrl = this.config.host.endpoint;
  
  constructor(private http: HttpClient) {}

  getNotes(): Observable<any> {
    return this.http.get(this.APIUrl, {responseType: 'json'});
  }
}
