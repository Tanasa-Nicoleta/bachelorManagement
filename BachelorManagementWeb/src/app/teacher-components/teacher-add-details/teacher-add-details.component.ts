import { Component } from '@angular/core';
import { Teacher } from '../../models/teacher.model';
import { TitleService } from '../../services/title.service';
import { Title } from '@angular/platform-browser';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Bachelor } from '../../models/bachelor-degree.model';
import { DayOfWeek } from '../../models/day-of-week.model';
import { TokenService } from '../../services/token.service';

@Component({
  selector: 'teacher-add-details',
  templateUrl: './teacher-add-details.component.html',
  styleUrls: ['../../app.component.scss', '../teacher.component.scss']
})

export class TeacherAddDetailsComponent {
  maxNumberOfStudents: number = 15;
  saveButtonText: string = "Save details";
  addThemeText: string = "Add a theme";
  teacherThemes: Teacher = new Teacher("Vlad", "Simion", "vlad.simion@info.uaic.ro", 3, 2, null,
    "Discipline1", "", "No requirement.");

  commentValue: string;
  titleService: TitleService;
  tokenService: TokenService;
  token: string;

  detailsBody: {
    Email: string,
    NoOfAvailableSpots: number,
    Requirement: string,
    ThemeTitle: string,
    ThemeDescription: string,
    Token: string;
  }

  consultationBody: {
    TeacherEmail: string,
    Day: DayOfWeek,
    Interval: string;
    Token: string;
  }

  constructor(private title: Title, private http: HttpClient, private router: Router) {
    this.titleService = new TitleService(title);
    this.titleService.setTitle("BDMApp Teacher Add Details");
    this.tokenService = new TokenService();   
    this.token = this.tokenService.buildToken();
  }

  addComment(themeContent: string) {
    var bachelor = themeContent.split("-");
    this.teacherThemes.Theme = new Bachelor(bachelor[0], bachelor[1]);
    this.commentValue = ' ';
  };

  addTeacherDetails(numberOfStudents: number, requirement: string, themeTitle: string, themeDesrc: string, consultationDay: string, consultationInterval: string) {
    this.detailsBody = {
      Email: this.teacherThemes.Email,
      NoOfAvailableSpots: numberOfStudents,
      Requirement: requirement,
      ThemeTitle: themeTitle,
      ThemeDescription: themeDesrc,
      Token: this.token
    };

    const resp = this.http.post('http://localhost:64250/api/teacher/addDetails', this.detailsBody, { responseType: 'text' });

    resp.subscribe(
      data => {
        this.addTeacherConsultationDay(this.teacherThemes.Email, consultationDay, consultationInterval);
      },
      err => {
        console.log("Error");
        console.log(err)
      });
  }

  addTeacherConsultationDay(email: string, day: string, interval: string){
    this.consultationBody = {
      TeacherEmail: email,
      Day: DayOfWeek[day],
      Interval: interval,
      Token: this.token
    };

    const resp = this.http.post('http://localhost:64250/api/teacher/addConsultation', this.consultationBody, { responseType: 'text' });

    resp.subscribe(
      data => {
        this.router.navigateByUrl('/teacherWall');
      },
      err => {
        console.log("Error");
        console.log(err)
      });
  }
}


