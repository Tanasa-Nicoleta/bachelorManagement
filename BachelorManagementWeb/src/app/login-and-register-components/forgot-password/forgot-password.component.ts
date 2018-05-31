import { Component } from '@angular/core';
import { TitleService } from '../../services/title.service';
import { Title } from '@angular/platform-browser';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['../../app.component.scss', '../login-and-register-layout.component.scss']
})

export class ForgotPasswordComponent {
  forgotPasswordButtonText: string = "Send email";
  emailRegex: RegExp = /^.+\b@info\.uaic\.ro\b$/;
  private invalidEmailError = false;
  private alreadyExistingAccount = false;

  titleService: TitleService;

  registerCheckBody: {
    Email: string;
  }

  constructor(private http: HttpClient, private title: Title) {
    this.titleService = new TitleService(title);
    this.titleService.setTitle("BDMApp Forgot Password");
  }

  sendForgotPasswordEmail(email: string) {
    console.log("send email");
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
        this.alreadyExistingAccount = true;
      },
      err => {
        console.log("error");
      }
    );
  }
}
