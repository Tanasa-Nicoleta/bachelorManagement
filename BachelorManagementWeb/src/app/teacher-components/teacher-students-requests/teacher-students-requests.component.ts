import { Component } from '@angular/core';
import { Student } from '../../models/student.model';
import { Bachelor } from '../../models/bachelor-degree.model';
import { Achievement } from '../../models/achievement.model';
import { TitleService } from '../../services/title.service';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'teacher-students-requests',
  templateUrl: './teacher-students-requests.component.html',
  styleUrls: ['../../app.component.scss', '../teacher.component.scss']
})

export class TeacherStudentsRequestsComponent {
  numberOfSpots: number;
  numberOfAvailableSpots: number;
  studentList: Array<Student> = new Array<Student>();
  titleService: TitleService;

  limitDate: Date = new Date(2018, 6, 15);
  today: Date = new Date();
  email: string = "vlad.simion@info.uaic.ro";
  acceptStudentsRequest: string = "Accept";
  denyStudentsRequest: string = "Deny";
  dueDatePassed: boolean = true; //this.limitDate < this.today;

  constructor(private title: Title, private http: HttpClient, private router: Router) {
    this.titleService = new TitleService(title);
    this.titleService.setTitle("BDMApp Teacher Students Requests");
  }

  ngOnInit() {
    this.getTeacherDetails(this.email);
    this.getTeacherStudents(this.email);
  }

  getTeacherDetails(email: string){
    const teacherResponse = this.http.get('http://localhost:64250/api/teacher/' + email, { observe: 'response' });
    teacherResponse.subscribe(
      data => {
        this.numberOfAvailableSpots = data.body["numberOfAvailableSpots"];
        this.numberOfSpots = data.body["numberOfSpots"];
      },
      err => {
        console.log("Error");
        console.log(err)
      }
    );
  }

  getTeacherStudents(email: string) {
    const studentResponse = this.http.get('http://localhost:64250/api/teacher/students/' + email, { observe: 'response' });

    studentResponse.subscribe(
      data => {
        for (let key in data.body) {
          if (data.body[key]) {
            this.studentList.push(new Student(data.body[key]['firstName'], data.body[key]['lastName'],
              data.body[key]['email'], null, data.body[key]['gitUrl'],
              data.body[key]['startYear'], data.body[key]['serialNumber'], null, data.body[key]['achievements'],
              data.body[key]['accepted'], data.body[key]['denied']));
          }
          this.setBachelorThemeToStudents(data.body[key]['email'], key);
        }
      },
      err => {
        console.log("Error");
        console.log(err)
      }
    );
  }

  setBachelorThemeToStudents(email: string, key: string) {
    const themeResponse = this.http.get('http://localhost:64250/api/student/themes/' + email, { observe: 'response' });
    themeResponse.subscribe(
      data => {
        this.studentList[key]['Theme'] = new Bachelor(data.body['title'], data.body['description']);
      },
      err => {
        console.log("Error");
        console.log(err)
      }
    );
  }

  acceptStudent(student: Student) {
    this.numberOfAvailableSpots--;

    this.studentList.forEach(stud => {
      if (stud.Email == student.Email) {
        stud.Accepted = stud.Accepted == true ? false : true;

        var body = {
          TeacherEmail: this.email,
          StudentEmail: stud.Email,
          Accepted: stud.Accepted,
          Denied: stud.Denied,
        };

        const resp = this.http.post('http://localhost:64250/api/student/teacherRequestStatus', body, { responseType: 'text' });

        resp.subscribe(
          data => {
          },
          err => {
            console.log("Error");
            console.log(err)
          });
      }
    });
  }

  denyStudent(student: Student) {
    this.studentList.forEach(stud => {
      if (stud.Email == student.Email) {
        stud.Denied = stud.Denied == true ? false : true;

        var body = {
          TeacherEmail: this.email,
          StudentEmail: stud.Email,
          Accepted: stud.Accepted,
          Denied: stud.Denied,
        };

        const resp = this.http.post('http://localhost:64250/api/student/teacherRequestStatus', body, { responseType: 'text' });

        resp.subscribe(
          data => {
          },
          err => {
            console.log("Error");
            console.log(err)
          });
      }
    });
  }
}
