import { Component } from '@angular/core';
import { MenuItem } from '../../models/menu-items';

@Component({
  selector: 'teacher-sidebar',
  templateUrl: './teacher-sidebar.component.html',
  styleUrls: ['../../app.component.scss', '../teacher.component.scss']
})

export class TeacherSidebarComponent {
  isTeacher: boolean = localStorage.getItem('isTeacher') == 'True';
  menuItems: MenuItem[] = [];  

  ngOnInit(){
    this.buildMenuItems();
  }

  buildMenuItems(){
    this.menuItems.push(new MenuItem("Home", "/welcome"));
    this.menuItems.push(new MenuItem("Wall", "/teacherWall"));
    this.menuItems.push(new MenuItem("Profile", "/profile"));
    this.menuItems.push(new MenuItem("Student's work", "/studentWork"));
    this.menuItems.push(new MenuItem("Information", "/information"));

    if(this.isTeacher){
      this.menuItems.push(new MenuItem("Student Requests", "/teacherStudentsRequests"));
    }
  }

}