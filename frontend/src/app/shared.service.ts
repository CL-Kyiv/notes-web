import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl = "https://localhost:44326/weatherforecast";


  constructor(private http:HttpClient) { }

  getWheather():Observable<any>{
    return this.http.get<any>(this.APIUrl);
  }
}
