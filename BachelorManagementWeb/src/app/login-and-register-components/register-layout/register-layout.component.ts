import { Component } from '@angular/core';
import { MenuItem } from '../../models/menu-items';
import { TitleService } from '../../services/title.service';
import { Title } from '@angular/platform-browser';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'register-layout',
  templateUrl: './register-layout.component.html',
  styleUrls: ['../../app.component.scss', '../login-and-register-layout.component.scss']
})

export class RegisterLayoutComponent {

  private invalidError = false;
  private alreadyExistingAccount = false;
  private invalidModelState = false;
  private invalidEmailError = false;
  private matchError = false;
  private buttonText: string = 'Register';
  emailRegex: RegExp = /^.+\b@info\.uaic\.ro\b$/;
  passRegex: RegExp = /^(?=.*[0-9])(?=.*[A-Z])(?=.*[@#$%^&+=!*()\-_{}\\ |:;\,<>?`~\[\]\.\'])(?=\S+$).{6,32}$/;

  titleService: TitleService;

  body: {
    Username: string;
    Password: string;
  };

  registerCheckBody: {
    Email: string;
  }

  constructor(private http: HttpClient, private router: Router, private title: Title) {
    this.titleService = new TitleService(title);
    this.titleService.setTitle("BDMApp Register");
  }

  isValidPassword(pass: string) {
    if (pass.length < 6 || !this.passRegex.test(pass) || pass.length > 32)
      return false;

    return true;
  }

  validatePass(password: HTMLInputElement) {
    this.invalidError = !this.passRegex.test(password.value);

    if (this.invalidError)
      password.classList.add('invalidPass');
    else
      password.classList.remove('invalidPass');
  }

  deleteError() {
    this.invalidError = false;
    this.matchError = false;
  }

  confirmPass(password: HTMLInputElement, Password: string) {
    if (password.value !== Password) {
      password.classList.add('invalidPass');
      this.matchError = true;
      return false;
    }
    else {
      password.classList.remove('invalidPass');
      this.deleteError();
      return true;
    }
  }

  submit(email: string, pass: string) {
    this.body = {
      Username: email,
      Password: pass
    };

    const resp = this.http.post('http://localhost:64250/api/account/register', this.body, { observe: 'response' });

    resp.subscribe(
      data => {
        this.router.navigateByUrl('/welcome');
        this.getUserToken(email, "false");
      },
      err => {
        if (err.status == 400)
          if (err.error == "Username exists") {
            this.alreadyExistingAccount = true;
          } if (err.error == "Invalid model state") {
            this.invalidModelState = true;
          }
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

    console.log(localStorage);
  }

  validateEmail(email: HTMLInputElement) {
    this.alreadyExistingAccount = false;
    this.invalidEmailError = !this.emailRegex.test(email.value);

    if (this.invalidEmailError)
      email.classList.add('invalidEmail');
    else
      email.classList.remove('invalidEmail');
  }

  checkIfUsernameExists(email: string) {
    this.registerCheckBody = {
      Email: email
    };

    const resp = this.http.post('http://localhost:64250/api/account/register/check', this.registerCheckBody, { observe: 'response' });

    resp.subscribe(
      data => {
        console.log("welcome");
      },
      err => {
        if (err.status == 400)
          if (err.error == "Username exists") {
            this.alreadyExistingAccount = true;
          }
      }
    );
  }
}