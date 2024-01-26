import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginModel } from '../Models/login';
import { AuthenticatedResponse } from '../Models/AuthenticatedResponse';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent implements OnInit {
  invalidLogin!: boolean;
  credentials=new  LoginModel();
  constructor(private router: Router, private http: HttpClient) { }
  ngOnInit() {
    this.credentials = new LoginModel();

  }
  login = (form: NgForm) => {
    if (form.valid) {
      this.http.post<AuthenticatedResponse>("https://localhost:5001/api/Login/login", this.credentials, {
        headers: new HttpHeaders({ "Content-Type": "application/json" })
      })
        .subscribe({
          next: (response: AuthenticatedResponse) => {
            const token = response.token;
            localStorage.setItem("jwt", token);
            const refreshToken = response.refreshToken;
            localStorage.setItem("refreshToken", refreshToken);
            this.invalidLogin = false;
            this.router.navigate(["/"]);
          },
          error: (err: HttpErrorResponse) => this.invalidLogin = true
        })
    }
  }
}
