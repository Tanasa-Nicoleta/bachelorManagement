import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { LoginLayoutComponent } from './login-and-register-components/login-layout/login-layout.component';
import { RegisterLayoutComponent } from './login-and-register-components/register-layout/register-layout.component';
import { HttpClientModule } from '@angular/common/http';
import { StudentHeaderComponent } from './student-components/student-header/student-header.component';
import { StudentRegisterToTeacherComponent } from './student-components/student-register-to-teacher/student-register-to-teacher.component';
import { StudentRegisterToTeacherDetailsComponent } from './student-components/student-register-with-details/student-register-details.component';
import { TeacherAddDetailsComponent } from './teacher-components/teacher-add-details/teacher-add-details.component';
import { TeacherWallComponent } from './teacher-components/teacher-wall/teacher-wall.component';
import { TeacherStudentsRequestsComponent } from './teacher-components/teacher-students-requests/teacher-students-requests.component';
import { TeacherSidebarComponent } from './teacher-components/teacher-sidebar/teacher-sidebar.component';
import { ErrorComponent } from './error/error.component';
import { WelcomeComponent } from './welcome/welcome.component';
import {TeacherGitDetailsPerStudentComponent} from './teacher-components/teacher-git-details-per-student/teacher-git-details-per-student.component';

const appName = 'Bachelor Degree Management'

@NgModule({
  declarations: [
    AppComponent,
    LoginLayoutComponent,
    RegisterLayoutComponent,
    StudentHeaderComponent,
    StudentRegisterToTeacherComponent,
    StudentRegisterToTeacherDetailsComponent,
    TeacherAddDetailsComponent,
    TeacherWallComponent,
    TeacherStudentsRequestsComponent,
    TeacherSidebarComponent ,
    ErrorComponent,
    WelcomeComponent,
    TeacherGitDetailsPerStudentComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: 'login', component: LoginLayoutComponent, pathMatch: 'full', data: { title: appName + 'Login' } },
      { path: 'register', component: RegisterLayoutComponent, pathMatch: 'full', data: { title: appName + 'Register' } },      
      { path: 'studentHeader', component: StudentHeaderComponent, pathMatch: 'full', data: { title: appName + 'Register' } }, // delete when tested
      { path: 'studentRegisterToTeacher', component: StudentRegisterToTeacherComponent, pathMatch: 'full', data: { title: appName + 'Register' } },      
      { path: 'studentRegisterToTeacherDetails', component: StudentRegisterToTeacherDetailsComponent, pathMatch: 'full', data: { title: appName + 'Register' } },
      { path: 'teacherAddDetails', component: TeacherAddDetailsComponent, pathMatch: 'full', data: { title: appName + 'Register' } },
      { path: 'teacherWall', component: TeacherWallComponent, pathMatch: 'full', data: { title: appName + 'Register' } },
      { path: 'teacherStudentsRequests', component: TeacherStudentsRequestsComponent, pathMatch: 'full', data: { title: appName + 'Register' } },
      { path: 'teacherSidebar', component: TeacherSidebarComponent, pathMatch: 'full', data: { title: appName + 'Register' } },
      { path: 'error', component: ErrorComponent, pathMatch: 'full', data: { title: appName + 'Register' } },
      { path: 'welcome', component: WelcomeComponent, pathMatch: 'full', data: { title: appName + 'Register' } },
      { path: 'gitDetails', component: TeacherGitDetailsPerStudentComponent, pathMatch: 'full', data: { title: appName + 'Register' } },
      { path: '', redirectTo: 'login', pathMatch: 'full' },
      { path: '**', redirectTo: 'login', pathMatch: 'full' }
    ]),        
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { 
}
