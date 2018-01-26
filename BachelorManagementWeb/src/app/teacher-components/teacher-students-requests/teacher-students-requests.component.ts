import { Component } from '@angular/core';
import { Student } from '../../models/student.model';
import { Bachelor } from '../../models/bachelor-degree.model';

@Component({
  selector: 'teacher-students-requests',
  templateUrl: './teacher-students-requests.component.html',
  styleUrls: ['../../app.component.scss', '../teacher.component.scss']
})


export class TeacherStudentsRequestsComponent {
  requests: [[Student]] = [[new Student("Ana", "Maria", "A.M@info.uaic.ro",
    [new Bachelor("Title1", "Descripiton1"),
    new Bachelor("Title2", "Descripiton2")])]]
}
