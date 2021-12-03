import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
 
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
        const blob = new Blob([result], { type: 'text/plain' }); // you can change the type
        const url= window.URL.createObjectURL(blob);
        window.open(url);
        console.log("Success");
        });
    }
}