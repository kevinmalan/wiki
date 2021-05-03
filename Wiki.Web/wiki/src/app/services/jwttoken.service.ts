import { Injectable } from '@angular/core';
import jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class JWTTokenService {

  jwtToken: string = "";
  decodedToken: {[key: string]: string} = {};

  constructor() { }

  setToken(token: string) {
    if (token)
      this.jwtToken = token;
  }

  decodeToken() {
    if (this.jwtToken) {
    this.decodedToken = jwt_decode(this.jwtToken);
    }
  }

  getUserId() {
    this.decodeToken();
    return this.decodedToken.uniqueUserId;
  }

  getCompanyId() {
    this.decodeToken();
    return this.decodedToken.uniqueCompanyId;
  }

  getRole() {
    this.decodeToken();
    return this.decodedToken.role;
  }

  getExpiryTime(): number {
    this.decodeToken();
    return +this.decodedToken.exp;
  }

  isTokenExpired(): boolean {
    const expiryTime: number = this.getExpiryTime();
    if (expiryTime) {
      return ((1000 * expiryTime) - (new Date()).getTime()) < 5000;
    } else {
      return false;
    }
  }
}