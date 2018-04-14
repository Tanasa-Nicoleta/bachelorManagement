import { Component } from '@angular/core';
import { MenuItem } from '../../models/menu-items';

@Component({
  selector: 'teacher-sidebar',
  templateUrl: './teacher-sidebar.component.html',
  styleUrls: ['../../app.component.scss', '../teacher.component.scss']
})

export class TeacherSidebarComponent {
  menuItems: MenuItem[] = [
    new MenuItem("Home", "/welcome"), 
    new MenuItem("Students Requests", "/teacherStudentsRequests"), 
    new MenuItem("Wall", "/teacherWall"), 
    new MenuItem("Profile", "/profile")
  ];
}