import { Injectable } from '@angular/core';
import { TokenService } from '../token/token.service';
import { HttpClient } from '@angular/common/http';
import { apiEndpoint } from '../../constants/constants';
import { ILogin, ILoginResponse, IRegister } from '../../models/auth.models';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private tokenService: TokenService, private http: HttpClient) { }

  onLogin(data: ILogin) {
    return this.http
    .post<ILoginResponse>(`${apiEndpoint.AuthEndpoint.login}`, data)
    .pipe(
      map((response) => {
        if (response) {
          this.tokenService.setToken(response.item)
        }
        return response;
      })
    );
  }

  onRegister(data: IRegister) {
    return this.http
    .post<ILoginResponse>(`${apiEndpoint.AuthEndpoint.register}`, data)
    .pipe(
      map((response) => {
        if (response) {
          this.tokenService.setToken(response.item)
        }
        return response;
      })
    );
  }

  onLogout(): void {
    this.tokenService.removeToken();
  }

  isAuthenticated(): boolean {
    return !!this.tokenService.getToken() && !this.tokenService.isTokenExpired();
  }
}
