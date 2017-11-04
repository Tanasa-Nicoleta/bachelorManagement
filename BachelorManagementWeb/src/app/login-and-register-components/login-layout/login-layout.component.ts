import { Component } from '@angular/core';

@Component({
  selector: 'login-layout',
  templateUrl: './login-layout.component.html',
  styleUrls: ['../../app.component.scss', '../login-and-register-layout.component.scss']
})

export class LoginLayoutComponent {

  private invalidError = false;

  passRegex: RegExp = /^(?=.*[0-9])(?=.*[A-Z])(?=.*[@#$%^&+=!*()\-_{}\\ |:;\,<>?`~\[\]\.\'])(?=\S+$).{6,32}$/;

  private validatePass(password: HTMLInputElement) {
    this.invalidError = !this.passRegex.test(password.value);
    if (this.invalidError)
      password.classList.add('invalidPass');
    else
      password.classList.remove('invalidPass');
  }
}