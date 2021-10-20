import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SharedService {
  readonly APIUrl = 'https://localhost:5001/weatherforecast';

  constructor(private http: HttpClient) {}

  getWheather(): Observable<string> {
    return this.http.get(this.APIUrl, {responseType: 'text'});
  }
}
