import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TimestampService {
  private apiUrl = 'https://localhost:7052/Api/timestamp';

  constructor(private http: HttpClient) { }

  // getTimestamp(): Observable<any> {
  //   return this.http.get(this.apiUrl);
  // }

  getTimestamp(): Observable<any> {
    return this.http.get<any>(this.apiUrl); // Expecting a JSON object
  }
}
