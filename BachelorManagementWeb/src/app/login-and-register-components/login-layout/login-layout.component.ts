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
  titleService: TitleService;
  emailRegex: RegExp = /^.+\b@info\.uaic\.ro\b$/;

  body: {
    Username: string;
    Password: string;
  };

  constructor(private http: HttpClient, private router: Router, private title: Title) {
    this.titleService = new TitleService(title);
    this.titleService.setTitle("BDMApp Login");
  }

  public submit(email: string, pass: string) {
    this.body = {
      Username: email,
      Password: pass
    };

    const resp = this.http.post('http://localhost:64250/api/account/login', this.body, { responseType: 'text' });

    resp.subscribe(
      data => {
        this.router.navigateByUrl('/welcome');
      },
      err => {
        if (err.status == 400)
          this.invalidError = true;
      }
    );
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