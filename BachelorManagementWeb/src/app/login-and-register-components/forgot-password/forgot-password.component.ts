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
  titleService: TitleService;

  constructor(private title: Title) {
    this.titleService = new TitleService(title);
    this.titleService.setTitle("BDMApp Forgot Password");
  }

  sendForgotPasswordEmail(email: string) {
    console.log("send email");
  }
}
