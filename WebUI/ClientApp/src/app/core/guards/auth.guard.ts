import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private router: Router, private jwtHelper: JwtHelperService) {

  }
  canActivate() {
    const localStorageToken = localStorage.getItem("atk");
    const sessionStorageToken = sessionStorage.getItem("atk");
    const _localStorageTokenCourt = localStorage.getItem("atkC");
    const _sessionStorageTokenCourt = sessionStorage.getItem("atkC");
    if (localStorageToken && !this.jwtHelper.isTokenExpired(localStorageToken) || _localStorageTokenCourt && !this.jwtHelper.isTokenExpired(_localStorageTokenCourt)) {
      return true;
    } else {
      if (sessionStorageToken && !this.jwtHelper.isTokenExpired(sessionStorageToken) || _sessionStorageTokenCourt && !this.jwtHelper.isTokenExpired(_sessionStorageTokenCourt)) {
        return true;
      }
      this.router.navigate(['auth/login'])
      return false;
    }
    
  }
  
}
