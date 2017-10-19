import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { LoginLayoutComponent } from './login-components/login-layout/login-layout.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginLayoutComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
