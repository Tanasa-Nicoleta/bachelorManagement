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
  private matchError = false;
  private buttonText: string = 'Register';
  titleService: TitleService;
  passRegex: RegExp = /^(?=.*[0-9])(?=.*[A-Z])(?=.*[@#$%^&+=!*()\-_{}\\ |:;\,<>?`~\[\]\.\'])(?=\S+$).{6,32}$/;

  body: {
    Username: string;
    Password: string;
  };

  constructor(private http: HttpClient, private router: Router, private title: Title) {
    this.titleService = new TitleService(title);
    this.titleService.setTitle("BDMApp Register");
  }

  private isValidPassword(pass: string) {
    if (pass.length < 6 || !this.passRegex.test(pass) || pass.length > 32) {
      return false;
    }
    return true;
  }

  private validatePass(password: HTMLInputElement) {
    this.invalidError = !this.passRegex.test(password.value);
    if (this.invalidError)
      password.classList.add('invalidPass');
    else
      password.classList.remove('invalidPass');
  }

  DeleteError() {
    this.invalidError = false;
    this.matchError = false;
  }

  public confirmPass(password: HTMLInputElement, Password: string) {
    if (password.value !== Password) {
      password.classList.add('invalidPass');
      this.matchError = true;
      return false;
    }
    else {
      password.classList.remove('invalidPass');
      this.DeleteError();
      return true;
    }
  }

  public submit(email: string, pass: string) {
    this.body = {
      Username: email,
      Password: pass
    };

    const resp = this.http.post('http://localhost:64250/api/account/register', this.body, { observe: 'response' });

    resp.subscribe(
      data => {
        this.router.navigateByUrl('/welcome');
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
}