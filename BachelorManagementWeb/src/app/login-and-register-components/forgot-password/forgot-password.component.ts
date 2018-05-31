import { Component } from '@angular/core';
import { TitleService } from '../../services/title.service';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['../../app.component.scss', '../login-and-register-layout.component.scss']
})

export class ForgotPasswordComponent {
  forgotPasswordButtonText: string = "Send email";
  emailRegex: RegExp = /^.+\b@info\.uaic\.ro\b$/;
  
  titleService: TitleService;
  private invalidEmailError = false;

  constructor(private title: Title) {
    this.titleService = new TitleService(title);
    this.titleService.setTitle("BDMApp Forgot Password");
  }

  sendForgotPasswordEmail(email: string) {
    console.log("send email");
  }

  private validateEmail(email: HTMLInputElement) {
    this.invalidEmailError = !this.emailRegex.test(email.value);
    console.log(this.invalidEmailError);
    if (this.invalidEmailError)
      email.classList.add('invalidEmail');
    else
      email.classList.remove('invalidEmail');
  }
}
