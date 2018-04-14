import { Component } from '@angular/core';
import { Teacher } from '../../models/teacher.model';
import { TitleService } from '../../services/title.service';
import { Title } from '@angular/platform-browser';

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
    [null]]

  titleService: TitleService;

  constructor(private title: Title) {
    this.titleService = new TitleService(title);
    this.titleService.setTitle("BDMApp Teacher Add Details");
  }
  
  addComment(themeContent: string) {
    this.teacherThemes[1].push(themeContent);
    this.commentValue = ' ';
  };
}


