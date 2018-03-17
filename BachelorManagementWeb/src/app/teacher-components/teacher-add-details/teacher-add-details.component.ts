import { Component } from '@angular/core';
import { Teacher } from '../../models/teacher.model';

@Component({
  selector: 'teacher-add-details',
  templateUrl: './teacher-add-details.component.html',
  styleUrls: ['../../app.component.scss', '../teacher.component.scss']
})


export class TeacherAddDetailsComponent {
  commentValue: string;
  maxNumberOfStudents: number = 15;
  saveButtonText: string = "Save details";
  addThemeText: string = "Add a theme";
  teacherThemes: [Teacher, [string | null]] = [
    new Teacher("Ana", "Maria", "", 3, 2, "", ["this.theme1", "this.theme2"], "Discipline1", "Prof", "No requirement."),
    [null]
  ]

  addComment(themeContent: string) {
    this.teacherThemes[1].push(themeContent);
    this.commentValue = ' ';
  };
}


