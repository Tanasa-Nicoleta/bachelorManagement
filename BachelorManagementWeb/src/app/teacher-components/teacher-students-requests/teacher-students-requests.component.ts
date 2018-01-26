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
    numberOfSpots: number = 12;
    numberOfAvailableSpots: number = 10;
    studentAccepted: boolean = false;

   studentList: [[Student, Achievement, boolean]] = [
    [new Student("Ana", "Maria", "An.Ma@info.uaic.ro",
      new Bachelor("Title1", "Descripiton1 and some random extra text")), 
      new Achievement("My achievement 1"),
    this.studentAccepted],
    [new Student("Anita", "Mona", "An.Mo@info.uaic.ro",
      new Bachelor("Title2", "Descripiton2")), 
      new Achievement("My achievement and some other text"),
      this.studentAccepted],
    [new Student("Adriana", "Mihaela", "Ad.Mi@info.uaic.ro",
      new Bachelor("Title3", "Descripiton3 and more words just to see how it looks on front")), 
      new Achievement("My achievement and some other text too, just an example"),
      this.studentAccepted]]

    acceptStudentsRequest: string = "Accept";
    denyStudentsRequest: string = "Deny";

    acceptStudent(student: Student){
      this.numberOfAvailableSpots--; 
      this.studentList.forEach(stud => {
        console.log(stud[0].Email, student.Email)
        if(stud[0].Email == student.Email){
          stud[2] = stud[2] == true ? false : true;
        }
      });
    }

    denyStudent(){

    }
}
