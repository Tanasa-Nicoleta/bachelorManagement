import { Component } from '@angular/core';
import { Teacher } from '../../models/teacher.model';
import { Bachelor } from '../../models/bachelor-degree.model';

@Component({
  selector: 'student-register-details-layout',
  templateUrl: './student-register-details.component.html',
  styleUrls: ['../../app.component.scss', '../student.component.scss', './student-register-details.component.scss']
})


export class StudentRegisterToTeacherDetailsLayoutComponent {

    //api  call for the teachers list
    teacherList: Array<Teacher>;
    teacher1: Teacher;
    teacher2: Teacher;
    theme1: Bachelor;
    theme2: Bachelor;
    theme3: Bachelor;

    ngOnInit(){
        this.theme1 = new Bachelor();
        this.theme1.Title = "Theme1";
        this.theme1.Description = "Description1 for Theme1";
        
        this.theme2 = new Bachelor();
        this.theme2.Title = "Theme2";
        this.theme2.Description = "Description2 for Theme 2 and some random extra text";
        
        this.theme3 = new Bachelor();
        this.theme3.Title = "Theme3";
        this.theme3.Description = "Description3 and other random text just for the text to align";

        this.teacher1 = new Teacher();
        this.teacher1.Grade = "Prof."
        this.teacher1.FirstName = "Ana";
        this.teacher1.LastName = "Maria";
        this.teacher1.Discipline = "Discipline1";
        this.teacher1.NoOfSpots = 3;
        this.teacher1.NoOfAvailableSpots = 2;
        this.teacher1.Themes = [this.theme1, this.theme2];

        this.teacher2 = new Teacher();
        this.teacher1.Grade = "Prof. Doctor"
        this.teacher2.FirstName = "Ioana";
        this.teacher2.LastName = "Pascu";
        this.teacher2.Discipline = "Discipline2";
        this.teacher2.NoOfSpots = 12;
        this.teacher2.NoOfAvailableSpots = 11;
        this.teacher2.Themes = [this.theme3];

        this.teacherList = [this.teacher1, this.teacher2];
    }
}
