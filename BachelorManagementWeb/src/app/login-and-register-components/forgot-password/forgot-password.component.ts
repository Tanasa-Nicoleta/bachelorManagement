import { Component } from '@angular/core';

@Component({
  selector: 'forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['../../app.component.scss',  '../login-and-register-layout.component.scss']
})

export class ForgotPasswordComponent {
  forgotPasswordButtonText: string = "Send email";

  sendForgotPasswordEmail(email: string){
    console.log("send email");
  }
}
