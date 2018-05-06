import { Component } from '@angular/core';
import { Teacher } from '../../models/teacher.model';
import { TitleService } from '../../services/title.service';
import { Title } from '@angular/platform-browser';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Bachelor } from '../../models/bachelor-degree.model';

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

  detailsBody: {    
    Email: string,
    NoOfAvailableSpots: number,
    Requirement: string,
    ThemeTitle: string,
    ThemeDescription: string
  }

  themesBody:{

  }

  teacherThemes: Teacher = new Teacher("Vlad", "Simion", "vlad.simion@info.uaic.ro", 3, 2, null,
   "Discipline1", "", "No requirement.");
  

  titleService: TitleService;

  constructor(private title: Title, private http: HttpClient, private router: Router) {
    this.titleService = new TitleService(title);
    this.titleService.setTitle("BDMApp Teacher Add Details");
  }

  addComment(themeContent: string) {
    var bachelor = themeContent.split("-");
    console.log(bachelor);
    this.teacherThemes.Theme = new Bachelor(bachelor[0], bachelor[1]);
    this.commentValue = ' ';
  };

  addTeacherDetails(numberOfStudents: number, requirement: string, themeTitle: string, themeDesrc: string) {
    this.detailsBody = {
      Email: this.teacherThemes.Email,
      NoOfAvailableSpots: numberOfStudents,
      Requirement: requirement,
      ThemeTitle: themeTitle,
      ThemeDescription: themeDesrc
    };

    const resp = this.http.post('http://localhost:64250/api/teacher/addDetails', this.detailsBody, { responseType: 'text' });

    resp.subscribe(
      data => {
        console.log(data);
        console.log("Succes");
        this.router.navigateByUrl('/teacherWall');
      },
      err => {
        console.log("Error");
        console.log(err)
        //if (err.status == 400)
      });
  }
}


