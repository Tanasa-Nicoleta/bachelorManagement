import { Component } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { MenuItem } from '../../models/menu-items';
import { TitleService } from '../../services/title.service';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'login-layout',
  templateUrl: './login-layout.component.html',
  styleUrls: ['../../app.component.scss', '../login-and-register-layout.component.scss']
})

export class LoginLayoutComponent {

  private invalidError = false;
  private invalidEmailError = false;
  emailRegex: RegExp = /^.+\b@info\.uaic\.ro\b$/;

  titleService: TitleService;

  body: {
    Username: string;
    Password: string;
  };

  constructor(private http: HttpClient, private router: Router, private title: Title) {
    this.titleService = new TitleService(title);
    this.titleService.setTitle("BDMApp Login");
  }

  submit(email: string, pass: string) {
    this.body = {
      Username: email,
      Password: pass
    };

    const resp = this.http.post('http://localhost:64250/api/account/login', this.body, { responseType: 'text' });

    resp.subscribe(
      data => {
        this.router.navigateByUrl('/welcome');
        this.getUserType(email);
      },
      err => {
        if (err.status == 400)
          this.invalidError = true;
      }
    );
  }

  getUserType(email: string){
    this.body = {
      Username: email,
      Password: null
    };

    const resp = this.http.post('http://localhost:64250/api/account/checkUserType', this.body, { responseType: 'text' });

    resp.subscribe(
      data => {
        this.getUserToken(email, data);
      },
      err => {
        console.log("Error");
        console.log(err);
      }
    );
  }

  getUserToken(email: string, isTeacher: string){
    this.body = {
      Username: email,
      Password: null
    };

    const resp = this.http.put('http://localhost:64250/api/account/addAccessToken', this.body, { responseType: 'text' });

    resp.subscribe(
      data => {
        this.setLocalStorage(email, isTeacher, data)
        console.log(localStorage);
      },
      err => {
        console.log("Error");
        console.log(err);
      }
    );
  }

  setLocalStorage(email: string, isTeacher: string, token: string){    
    localStorage.setItem('email', email);
    localStorage.setItem('isTeacher', isTeacher);
    localStorage.setItem('token', token);
  }

  validateEmail(email: HTMLInputElement) {
    this.invalidError = false;
    this.invalidEmailError = !this.emailRegex.test(email.value);

    if (this.invalidEmailError)
      email.classList.add('invalidEmail');
    else
      email.classList.remove('invalidEmail');
  }

  deleteErrors() {
    this.invalidError = false;
  }
}