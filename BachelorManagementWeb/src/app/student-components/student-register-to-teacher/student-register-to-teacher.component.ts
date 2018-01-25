import { Component } from '@angular/core';
import { Teacher } from '../../models/teacher.model';
import { Bachelor } from '../../models/bachelor-degree.model';

@Component({
  selector: 'student-register-to-teacher',
  templateUrl: './student-register-to-teacher.component.html',
  styleUrls: ['../../app.component.scss', '../student.component.scss']
})


export class StudentRegisterToTeacherComponent {

    optionText: string = "Next step";

    //api  call for the teachers list
    teacherList: Array<Teacher>;
    teacher1: Teacher;
    teacher2: Teacher;
    theme1: Bachelor;
    theme2: Bachelor;
    theme3: Bachelor;

    ngOnInit(){
        this.theme1 = new Bachelor("Theme1", "Description1 for Theme1");        
        this.theme2 = new Bachelor("Theme2", "Description2 for Theme 2 and some random extra text");        
        this.theme3 = new Bachelor("Theme3", "Description3 and other random text just for the text to align");

        this.teacher1 = new Teacher("Ana", "Maria", "", 3, 2, "", [this.theme1, this.theme2], "Discipline1", "Prof");
        this.teacher2 = new Teacher("Ioana", "Pascu", "", 12, 11, "", [this.theme3], "Discipline2", "Prof Doctor");

        this.teacherList = [this.teacher1, this.teacher2];
    }

    applyToTeacher(teacherFirstName: string, teacherLastName: string){
        console.log(teacherFirstName + " " + teacherLastName);
        //send those to the next file
    }
}