import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SharedService {
  readonly APIUrl = 'https://localhost:5001/notes';

  constructor(private http: HttpClient) {}

  getNotes(): Observable<any> {
    return this.http.get(this.APIUrl, {responseType: 'json'});
  }
}
