import { Injectable } from '@angular/core';
import { LocalStorageService } from '../local-storage.service';
import { Router } from '@angular/router';
import { LoginRequest } from 'src/app/models/login/login-request.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

const urlLogin = 'https://www.mocky.io/v2/5d4f87863000002b071099c3';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(protected http: HttpClient,
              private localStorageService: LocalStorageService,
              private router: Router) { }

  autenticacao(request: LoginRequest): Observable<any> {
    return this.http.post<any>(urlLogin, {
      email: request.email,
      password: request.password,
    });
  }

  logout(): void {
    this.localStorageService.remove('userToken');
    this.router.navigate(['login']);
  }
}
