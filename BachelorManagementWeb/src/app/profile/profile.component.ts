import { Component } from '@angular/core';
import { TitleService } from '../services/title.service';
import { Title } from '@angular/platform-browser';
import { Mean } from '../models/mean.model';
import { HttpClient } from '@angular/common/http';
import { Student } from '../models/student.model';
import { Bachelor } from '../models/bachelor-degree.model';
import { TeacherProfile } from '../models/teacher-profile.model';

@Component({
  selector: 'profile',
  templateUrl: './profile.component.html',
  styleUrls: ['../app.component.scss']
})

export class ProfileComponent {

  email: string = "mihai.ursache@info.uaic.ro";
  teacherEmail: string = "vlad.simion@info.uaic.ro";
  student: Student;
  teacher: TeacherProfile;
  titleService: TitleService;
  isTeacher: boolean = true;

  constructor(private title: Title, private http: HttpClient) {
    this.titleService = new TitleService(title);
    this.titleService.setTitle("BDMApp Profile");
  }

  ngOnInit() {
    if (this.isTeacher) {
      this.getTeacherDetails(this.email);
    } else {
      this.getStudentsDetails(this.email)
    }
  }

  private getTeacherDetails(email: string) {
    const theacherResponse = this.http.get('http://localhost:64250/api/teacher/' + this.teacherEmail, { observe: 'response' });

    theacherResponse.subscribe(
      data => {
        this.teacher = new TeacherProfile(data.body["firstName"], data.body["lastName"], data.body["email"], null, data.body["jobTitle"], data.body["requirement"], null)
        this.setThemesToTeacher();
        this.setStudentsToTeacher();
        console.log(this.teacher);
        
      },
      err => {
        console.log("Error");
        console.log(err)
      }
    );
  }


  private getStudentsDetails(email: string) {
    const studentResponse = this.http.get('http://localhost:64250/api/student/' + this.email, { observe: 'response' });

    studentResponse.subscribe(
      data => {
        this.student = new Student(data.body['firstName'], data.body['lastName'], data.body['email'], null,
          data.body['gitUrl'], data.body['startYear'], data.body['serialNumber'], null, data.body['achievements'], data.body['accepted'], data.body['denied']);
        this.setThemesToStudent(data.body['email'], this.student);
        this.setTeacherToStudent();
        this.setMeansToStudent();
      },
      err => {
        console.log("Error");
        console.log(err)
      }
    );
  }

  setThemesToStudent(email: string, student: Student) {
    let themeResponse = this.http.get('http://localhost:64250/api/student/themes/' + email, { observe: 'response' });

    themeResponse.subscribe(data => {
      if (data.body) {
        student.Theme = new Bachelor(data.body['title'], data.body['description']);
      }
    },
      err => {
        console.log("Error");
        console.log(err)
      }
    );
  }

  setTeacherToStudent() {
    let theacherRespose = this.http.get('http://localhost:64250/api/student/teacher/' + this.student.Email, { observe: 'response' });

    theacherRespose.subscribe(data => {
      if (data.body) {
        this.student.TeacherName = data.body['firstName'] + " " + data.body['lastName'];
      }
    },
      err => {
        console.log("Error");
        console.log(err)
      }
    );
  }

  setMeansToStudent() {
    let meansResponse = this.http.get('http://localhost:64250/api/student/means/' + this.student.Email, { observe: 'response' });

    meansResponse.subscribe(data => {
      if (data.body) {
        this.student.Means = new Mean(data.body['firstSemester'], data.body['secondSemester'], data.body['thirdSemester'],
          data.body['fourthSemester'], data.body['fifthSemester'], data.body['sixthSemester'])

      }
    },
      err => {
        console.log("Error");
        console.log(err)
      }
    );
  }

  private setThemesToTeacher() {
    this.teacher.Theme = new Array<Bachelor>();
    let themeResponse = this.http.get('http://localhost:64250/api/teacher/themes/' + this.teacher.Email, { observe: 'response' });

    themeResponse.subscribe(data => {
      if (data.body) {
        for (let key in data.body) {
          if (data.body.hasOwnProperty(key)) {
            this.teacher.Theme.push(new Bachelor(data.body[key]["title"], data.body[key]["description"]));
          }
        }
      }
    },
      err => {
        console.log("Error");
        console.log(err)
      }
    );
  };

  private setStudentsToTeacher() {
    this.teacher.Student = new Array<Student>();
    let themeResponse = this.http.get('http://localhost:64250/api/teacher/students/' + this.teacher.Email, { observe: 'response' });

    themeResponse.subscribe(data => {
      if (data.body) {
        for (let key in data.body) {
          if (data.body.hasOwnProperty(key)) {
            this.teacher.Student.push(new Student(data.body[key]["firstName"], data.body[key]["lastName"], data.body[key]["email"], null, data.body[key]["gitUrl"], data.body[key]["startYear"], data.body[key]["serialNumber"], null, data.body[key]["achievement"], data.body[key]["accepted"], data.body[key]["denied"]));
            this.setThemesToStudent(data.body[key]["email"], this.teacher.Student.find(s => s.Email == data.body[key]["email"]));
          }
        }
      }
    },
      err => {
        console.log("Error");
        console.log(err)
      }
    );
  };
}

