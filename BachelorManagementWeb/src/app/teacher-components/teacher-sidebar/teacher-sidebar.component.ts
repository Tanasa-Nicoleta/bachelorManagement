import { Component } from '@angular/core';
import { MenuItem } from '../../models/menu-items';

@Component({
  selector: 'teacher-sidebar',
  templateUrl: './teacher-sidebar.component.html',
  styleUrls: ['../../app.component.scss', '../teacher.component.scss']
})

export class TeacherSidebarComponent {
  menuItems: MenuItem[] = [
    new MenuItem("Home", "/login"), 
    new MenuItem("Students Requests", "/register"), 
    new MenuItem("Your Wall", "/teacherEditWall")
  ];
}