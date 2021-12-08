import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { saveAs } from 'file-saver';
 
@Injectable({
  providedIn: 'root',
})
export class LogsService {
  
  config = require('./config/host.config.json');

  readonly APIUrl = this.config.host.endpoint + 'logs';
  
  constructor(private http: HttpClient) {}

  downloadFileWithLogs()
  {
    return this.http.get(this.APIUrl, {responseType: 'blob'})
    .subscribe((result: Blob) => {
        const blob = new Blob([result], { type: 'text/plain' }); 
        const fileName = 'logs.txt'
        saveAs(blob, fileName);
        });
    }
}