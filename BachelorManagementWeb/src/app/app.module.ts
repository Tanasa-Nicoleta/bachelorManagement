import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ClickOutsideModule } from 'ng4-click-outside';

import { AppComponent } from './app.component';
import { LoginLayoutComponent } from './login-and-register-components/login-layout/login-layout.component';
import { RegisterLayoutComponent } from './login-and-register-components/register-layout/register-layout.component';
import { HttpClientModule } from '@angular/common/http';
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
import { InformationComponent } from './information/information.component';
import { ProfileHeaderComponent } from './headers/profile-header/profile-header.component';
import { NoProfileHeaderComponent } from './headers/no-profile-header/no-profile-header.component';
import { StudentWorkComponent } from './student-components/student-work/student-work.component';
import { AdminWallComponent } from './admin-components/admin-wall/admin-wall.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginLayoutComponent,
    RegisterLayoutComponent,
    ProfileHeaderComponent,
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
    ForgotPasswordComponent,
    InformationComponent,
    NoProfileHeaderComponent,
    StudentWorkComponent,
    AdminWallComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ClickOutsideModule,
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
      { path: 'information', component: InformationComponent, pathMatch: 'full' },
      { path: 'studentWork', component: StudentWorkComponent, pathMatch: 'full' },      
      { path: 'adminWall', component: AdminWallComponent, pathMatch: 'full' }, 
      { path: '', redirectTo: 'login', pathMatch: 'full' },
      { path: '**', redirectTo: 'login', pathMatch: 'full' }
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule {
}
