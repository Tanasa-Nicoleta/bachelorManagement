import { Component } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'login-layout',
  templateUrl: './login-layout.component.html',
  styleUrls: ['../../app.component.scss', '../login-and-register-layout.component.scss']
})

export class LoginLayoutComponent {

  private invalidError = false;
 
  body: {
    Username: string;
    Password: string;
  };

  constructor(private http: HttpClient, private router: Router){}

  public submit(email: string, pass: string) {
    
    this.body = {
      Username: email,
      Password: pass
    };

    const resp = this.http.post('http://localhost:64251/api/Login', this.body, { observe: 'response' });

    console.log(this.body.Username, this.body.Password);

    resp.subscribe(
      data => {
        console.log(data);
        if (data.status === 200) {        
          this.router.navigateByUrl('/register');
        }
      },
      err => {
        console.log("Login error + error", err.status)
        if (err.status === 400)
          this.invalidError = true;
      }
    );

  }
  
}