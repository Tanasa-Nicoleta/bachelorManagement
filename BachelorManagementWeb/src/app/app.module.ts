import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { LoginLayoutComponent } from './login-and-register-components/login-layout/login-layout.component';
import { RegisterLayoutComponent } from './login-and-register-components/register-layout/register-layout.component';


const appName = 'Bachelor Degree Management'

@NgModule({
  declarations: [
    AppComponent,
    LoginLayoutComponent,
    RegisterLayoutComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      { path: 'login', component: LoginLayoutComponent, pathMatch: 'full', data: { title: appName + 'Login' } },
      { path: 'register', component: RegisterLayoutComponent, pathMatch: 'full', data: { title: appName + 'Register' } },
      { path: '', redirectTo: 'login', pathMatch: 'full' },
      { path: '**', redirectTo: 'login', pathMatch: 'full' }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { 
}
