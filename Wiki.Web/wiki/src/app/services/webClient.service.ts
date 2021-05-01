import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RegisterRequest } from '../models/register-request';
import { RegisterResponse } from '../models/register-response';

@Injectable({
  providedIn: 'root'
})
export class WebClient {

  constructor(private http: HttpClient) { }

  registerUri: string = `https://localhost:5001/api/auth/register`;
  registerRequest: RegisterRequest = {
    userName: 'Jesse',
    password: 'YoMrWhite!'
  };

  register() {
    this.http.post<RegisterResponse>(
      this.registerUri,
      this.registerRequest
    ).subscribe(data => {
      console.log('response from register');
      console.log(data);
    });
  }
}
