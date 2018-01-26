import { Component } from '@angular/core';

@Component({
  selector: 'teacher-sidebar',
  templateUrl: './teacher-sidebar.component.html',
  styleUrls: ['../../app.component.scss', '../teacher.component.scss']
})

export class TeacherSidebarComponent {
    menuItems: [string] = ["Home", "Students Requests", "Your Wall"];
}