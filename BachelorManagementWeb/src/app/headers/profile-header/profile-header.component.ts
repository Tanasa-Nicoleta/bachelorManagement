import { Component } from '@angular/core';

@Component({
  selector: 'profile-header',
  templateUrl: './profile-header.component.html',
  styleUrls: ['../../app.component.scss']
})

export class ProfileHeaderComponent {
  Username: string;

  ngOnInit(){
    if(localStorage.getItem('isTeacher') == 'true' || localStorage.getItem('isTeacher') == 'True'){
      this.Username= localStorage.getItem('teacherEmail')
    }
    if(localStorage.getItem('isTeacher') == 'false' || localStorage.getItem('isTeacher') == 'False'){
      this.Username= localStorage.getItem('studentEmail')
    }
  }

  logOut(){
    localStorage.clear();
  }
}