import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { constants } from '../../constants/constants';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class TokenService {
  isAuthentication: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  constructor() { }

  setToken(token: string) {
    this.updateToken(true);
    localStorage.setItem(constants.ACCESS_TOKNE, token);
  }

  getToken(): string | null {
    return localStorage.getItem(constants.ACCESS_TOKNE) || null;
  }

  updateToken(status: boolean) {
    this.isAuthentication.next(status);
  }

  removeToken() {
    this.updateToken(false);
    return localStorage.removeItem(constants.ACCESS_TOKNE);
  }

  isTokenExpired(): boolean {
    const token = this.getToken();
    if (token) {
      const decodedToken: any = jwtDecode(token);
      const expirationDate = new Date(decodedToken.exp * 1000);
      return expirationDate < new Date(); 
    } else {
      return true; 
    }
  }
}
