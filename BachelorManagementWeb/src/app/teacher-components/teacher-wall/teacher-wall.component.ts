import { Component } from '@angular/core';

@Component({
  selector: 'teacher-wall',
  templateUrl: './teacher-wall.component.html',
  styleUrls: ['../../app.component.scss', '../teacher.component.scss']
})

export class TeacherWallComponent {
  teacherName: string = "Teacher Name" // to be taken from api
}