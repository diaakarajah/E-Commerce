import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthenticatedResponse } from '../Models/AuthenticatedResponse';
@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private router: Router, private jwtHelper: JwtHelperService, private http: HttpClient) { }

  async canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    const tokens = localStorage.getItem("jwt");
    if (tokens && !this.jwtHelper.isTokenExpired(tokens)) {
      console.log(this.jwtHelper.decodeToken(tokens))
      return true;
    }
    const isRefreshSuccess = await this.tryRefreshingTokens(tokens);
    if (!isRefreshSuccess) {
      this.router.navigate(["login"]);
    }
    return isRefreshSuccess;
  }

  private async tryRefreshingTokens(token: string | null): Promise<boolean> {
    const refreshTokens = localStorage.getItem("refreshToken");
    if (!token || !refreshTokens) {
      return false;
    }

    const credentials = JSON.stringify({ accessToken: token, refreshToken: refreshTokens });
    let isRefreshSuccess: boolean;

    const refreshRes = await new Promise<AuthenticatedResponse>((resolve, reject) => {
      this.http.post<AuthenticatedResponse>("https://localhost:5001/api/token/refresh", credentials, {
        headers: new HttpHeaders({
          "Content-Type": "application/json"
        })
      }).subscribe({
        next: (res: AuthenticatedResponse) => resolve(res),
        error: (_) => { reject; isRefreshSuccess = false; }
      });
    });

    localStorage.setItem("jwt", refreshRes.token);
    localStorage.setItem("refreshToken", refreshRes.refreshToken);
    isRefreshSuccess = true;

    return isRefreshSuccess;
  }
}
