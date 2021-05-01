import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RegisterRequest } from '../models/register-request';
import { RegisterResponse } from '../models/register-response';
import { WikiApiRoutes } from '../constants/wiki-api-routes';

@Injectable({
  providedIn: 'root'
})
export class WebClient {

  constructor(private http: HttpClient) { }

  register(request: RegisterRequest) {
    this.http.post<RegisterResponse>(
      WikiApiRoutes.register,
      request
    ).subscribe(data => {
      console.log(data);
    });
  }
}
