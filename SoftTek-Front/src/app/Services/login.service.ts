import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IResponse } from '../models/iresponse';
import { IUser } from '../models/iuser';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  BaseUrl = 'http://localhost:32771/';
  apiUrl = 'login';
  constructor(private http: HttpClient) { }
  
  IniciaSesion(user : IUser ): Observable<IResponse>{
    return this.http.post<IResponse>(this.BaseUrl + this.apiUrl, user);
  }

}
