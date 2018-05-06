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
  numberOfSpots: number = 12;
  numberOfAvailableSpots: number = 10;
  studentAccepted: boolean = false;
  studentDenied: boolean = false;
  email: string = "vlad.simion@info.uaic.ro";

  studentList: Array<Student> = new Array<Student>();

  acceptStudentsRequest: string = "Accept";
  denyStudentsRequest: string = "Deny";

  titleService: TitleService;

  constructor(private title: Title, private http: HttpClient, private router: Router) {
    this.titleService = new TitleService(title);
    this.titleService.setTitle("BDMApp Teacher Students Requests");
  }

  ngOnInit() {
    this.getTeacherStudents();
  }

  getTeacherStudents() {
    const theacherResponse = this.http.get('http://localhost:64250/api/teacher/students/' + this.email, { observe: 'response' });

    theacherResponse.subscribe(
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
    const theacherResponse = this.http.get('http://localhost:64250/api/student/themes/' + email, { observe: 'response' });
    theacherResponse.subscribe(
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
          Email: stud.Email,
          Accepted: stud.Accepted,
          Denied: stud.Denied,
        };
        console.log(body);
        const resp = this.http.post('http://localhost:64250/api/student/teacherRequestStatus', body, { responseType: 'text' });

        resp.subscribe(
          data => {
            console.log("Succes");
          },
          err => {
            console.log("Error");
            console.log(err)
            //if (err.status == 400)
          });
      }
    });
  }

  denyStudent(student: Student) {
    this.studentList.forEach(stud => {
      if (stud.Email == student.Email) {
        if (stud.Email == student.Email) {          
          stud.Denied = stud.Denied == true ? false : true;
          var body = {
            Email: stud.Email,
            Accepted: stud.Accepted,
            Denied: stud.Denied,
          };
          const resp = this.http.post('http://localhost:64250/api/student/teacherRequestStatus', body, { responseType: 'text' });

          resp.subscribe(
            data => {
              console.log("Succes");
            },
            err => {
              console.log("Error");
              console.log(err)
              //if (err.status == 400)
            });
        }
      }});
  }
}
