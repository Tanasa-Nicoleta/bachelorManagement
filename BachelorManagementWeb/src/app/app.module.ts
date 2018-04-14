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
import { TeacherGitDetailsPerStudentComponent } from './teacher-components/teacher-git-details-per-student/teacher-git-details-per-student.component';
import { ProfileComponent } from './profile/profile.component';
import { ForgotPasswordComponent } from './login-and-register-components/forgot-password/forgot-password.component';

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
    TeacherSidebarComponent,
    ErrorComponent,
    WelcomeComponent,
    TeacherGitDetailsPerStudentComponent,
    ProfileComponent,
    ForgotPasswordComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: 'login', component: LoginLayoutComponent, pathMatch: 'full' },
      { path: 'register', component: RegisterLayoutComponent, pathMatch: 'full' },
      { path: 'studentRegisterToTeacher', component: StudentRegisterToTeacherComponent, pathMatch: 'full' },
      { path: 'studentRegisterToTeacherDetails', component: StudentRegisterToTeacherDetailsComponent, pathMatch: 'full' },
      { path: 'teacherAddDetails', component: TeacherAddDetailsComponent, pathMatch: 'full' },
      { path: 'teacherWall', component: TeacherWallComponent, pathMatch: 'full' },
      { path: 'teacherStudentsRequests', component: TeacherStudentsRequestsComponent, pathMatch: 'full' },
      { path: 'teacherSidebar', component: TeacherSidebarComponent, pathMatch: 'full' },
      { path: 'error', component: ErrorComponent, pathMatch: 'full' },
      { path: 'welcome', component: WelcomeComponent, pathMatch: 'full' },
      { path: 'gitDetails', component: TeacherGitDetailsPerStudentComponent, pathMatch: 'full' },
      { path: 'profile', component: ProfileComponent, pathMatch: 'full' },
      { path: 'forgotPassword', component: ForgotPasswordComponent, pathMatch: 'full' },
      { path: '', redirectTo: 'login', pathMatch: 'full' },
      { path: '**', redirectTo: 'login', pathMatch: 'full' }
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
