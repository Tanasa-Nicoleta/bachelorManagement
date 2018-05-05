import { Component } from '@angular/core';
import { TitleService } from '../services/title.service';
import { Title } from '@angular/platform-browser';
import { Mean } from '../models/mean.model';
import { HttpClient } from '@angular/common/http';
import { Student } from '../models/student.model';
import { Bachelor } from '../models/bachelor-degree.model';

@Component({
  selector: 'profile',
  templateUrl: './profile.component.html',
  styleUrls: ['../app.component.scss']
})

export class ProfileComponent {

  email: string = "mihai.ursache@info.uaic.ro";
  student: Student;

  titleService: TitleService;

  constructor(private title: Title, private http: HttpClient) {
    this.titleService = new TitleService(title);
    this.titleService.setTitle("BDMApp Profile");
  }

  ngOnInit() {
    this.getStudentsDetails(this.email)
  }

  private getStudentsDetails(email: string) {
    const theacherResponse = this.http.get('http://localhost:64250/api/student/' + this.email, { observe: 'response' });

    theacherResponse.subscribe(
      data => {
        this.student = new Student(data.body['firstName'], data.body['lastName'], data.body['email'], null,
          data.body['gitUrl'], data.body['startYear'], data.body['serialNumber'], null);
        this.setThemesToStudent();
        this.setTeacherToStudent();
        this.setMeansToStudent();
      },
      err => {
        console.log("Error");
        console.log(err)
      }
    );
  }

  setThemesToStudent() {
    let themeResponse = this.http.get('http://localhost:64250/api/student/themes/' + this.student.Email, { observe: 'response' });

    themeResponse.subscribe(data => {
      if (data.body) {
        this.student.Theme = new Bachelor(data.body['title'], data.body['description']);
      }
    },
      err => {
        console.log("Error");
        console.log(err)
      });
  }

  setTeacherToStudent() {
    let themeResponse = this.http.get('http://localhost:64250/api/student/teacher/' + this.student.Email, { observe: 'response' });

    themeResponse.subscribe(data => {
      if (data.body) {
        this.student.TeacherName = data.body['firstName'] + " " + data.body['lastName'];
      }
    },
      err => {
        console.log("Error");
        console.log(err)
      });
  }

  setMeansToStudent() {
    let themeResponse = this.http.get('http://localhost:64250/api/student/means/' + this.student.Email, { observe: 'response' });

    themeResponse.subscribe(data => {
      if (data.body) {
        this.student.Means = new Mean(data.body['firstSemester'], data.body['secondSemester'], data.body['thirdSemester'], 
        data.body['fourthSemester'], data.body['fifthSemester'], data.body['sixthSemester'])

      }
    },
      err => {
        console.log("Error");
        console.log(err)
      });
  }
}

