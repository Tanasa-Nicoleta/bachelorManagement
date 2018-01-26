import { Component } from '@angular/core';
import { Student } from '../../models/student.model';
import { Bachelor } from '../../models/bachelor-degree.model';
import { Achievement } from '../../models/achievement.model';

@Component({
  selector: 'teacher-students-requests',
  templateUrl: './teacher-students-requests.component.html',
  styleUrls: ['../../app.component.scss', '../teacher.component.scss']
})


export class TeacherStudentsRequestsComponent {
   studentList: [[Student, Achievement]] = [
    [new Student("Ana", "Maria", "A.M@info.uaic.ro",
      new Bachelor("Title1", "Descripiton1 and some random extra text")), 
      new Achievement("My achievement 1")],
    [new Student("Anita", "Mona", "A.M@info.uaic.ro",
      new Bachelor("Title2", "Descripiton2")), 
      new Achievement("My achievement and some other text")],
    [new Student("Adriana", "Mihaela", "A.M@info.uaic.ro",
      new Bachelor("Title3", "Descripiton3 and more words just to see how it looks on front")), 
      new Achievement("My achievement and some other text too, just an example")]]

    acceptStudentsRequest: string = "Accept";
    denyStudentsRequest: string = "Deny";

    acceptStudent(){

    }

    denyStudent(){

    }
}
