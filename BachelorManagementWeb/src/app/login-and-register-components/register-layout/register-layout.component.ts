import { Component } from '@angular/core';
import { MenuItem } from '../../models/menu-items';

@Component({
  selector: 'register-layout',
  templateUrl: './register-layout.component.html',
  styleUrls: ['../../app.component.scss', '../login-and-register-layout.component.scss']
})

export class RegisterLayoutComponent {

  private invalidError = false;
  private matchError = false;
  menuItems: [MenuItem] = [
    new MenuItem("Register", "/welcome")
  ];

  passRegex: RegExp = /^(?=.*[0-9])(?=.*[A-Z])(?=.*[@#$%^&+=!*()\-_{}\\ |:;\,<>?`~\[\]\.\'])(?=\S+$).{6,32}$/;

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
    if (password.value !== Password){     
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
}