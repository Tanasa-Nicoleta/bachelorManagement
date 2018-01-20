import { Component } from '@angular/core';

@Component({
  selector: 'teacher-add-details',
  templateUrl: './teacher-add-details.component.html',
  styleUrls: ['../../app.component.scss', '../teacher.component.scss']
})


export class TeacherAddDetailsComponent {
    maxNumberOfStudents: number = 15;
    saveButtonText: string = "Save details";
    addThemeButtonText: string = "Add a theme";
}
