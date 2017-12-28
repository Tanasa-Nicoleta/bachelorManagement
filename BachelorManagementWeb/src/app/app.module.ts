import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { LoginLayoutComponent } from './login-and-register-components/login-layout/login-layout.component';
import { RegisterLayoutComponent } from './login-and-register-components/register-layout/register-layout.component';
import { HttpClientModule } from '@angular/common/http';
import { StudentHeaderComponent } from './student-components/student-header/student-header.component';
import { StudentRegisterToTeacherLayoutComponent } from './student-components/student-register-to-teacher/student-register-to-teacher.component';

const appName = 'Bachelor Degree Management'

@NgModule({
  declarations: [
    AppComponent,
    LoginLayoutComponent,
    RegisterLayoutComponent,
    StudentHeaderComponent,
    StudentRegisterToTeacherLayoutComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: 'login', component: LoginLayoutComponent, pathMatch: 'full', data: { title: appName + 'Login' } },
      { path: 'register', component: RegisterLayoutComponent, pathMatch: 'full', data: { title: appName + 'Register' } },      
      { path: 'studentHeader', component: StudentHeaderComponent, pathMatch: 'full', data: { title: appName + 'Register' } }, // delete when tested
      { path: 'studentRegisterToTeacher', component: StudentRegisterToTeacherLayoutComponent, pathMatch: 'full', data: { title: appName + 'Register' } },
      { path: '', redirectTo: 'login', pathMatch: 'full' },
      { path: '**', redirectTo: 'login', pathMatch: 'full' }
    ]),        
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { 
}
