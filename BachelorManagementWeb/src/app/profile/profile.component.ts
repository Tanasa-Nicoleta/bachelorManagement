import { Component } from '@angular/core';
import { TitleService } from '../services/title.service';
import { Title } from '@angular/platform-browser';
import { Mean } from '../models/mean.model';
import { HttpClient } from '@angular/common/http';
import { Student } from '../models/student.model';
import { Bachelor } from '../models/bachelor-degree.model';
import { TeacherProfile } from '../models/teacher-profile.model';
import { DayOfWeek } from '../models/day-of-week.model';
import { TokenService } from '../services/token.service';

@Component({
  selector: 'profile',
  templateUrl: './profile.component.html',
  styleUrls: ['../app.component.scss', '../student-components/student.component.scss', '../teacher-components/teacher.component.scss']
})

export class ProfileComponent {
  studentEmail: string;
  teacherEmail: string;
  editText: string = "edit profile";
  submitText: string = "submit";
  isTeacher: boolean = localStorage.getItem('isTeacher') == "True";
  showEditForm: boolean = false;
  showEditConsultation: boolean = false;
  editConsultationButton: string = "edit";
  saveConsultationButton: string = "submit";
  cancelButton: string = "cancel";

  student: Student;
  teacher: TeacherProfile = new TeacherProfile(null, null, null, null, null, null, null);
  titleService: TitleService;
  tokenService: TokenService;
  token: string;

  editProfileBody: {
    Email: string;
    GitUrl: string;
    BachelorThemeTitle: string;
    BachelorThemeDescription: string;
    Token: string;
  }

  editConsultationBody: {
    TeacherEmail: string;
    Day: DayOfWeek;
    Interval: string;
    Token: string;
  }

  constructor(private title: Title, private http: HttpClient) {
    this.studentEmail = localStorage.getItem("studentEmail");
    this.teacherEmail = localStorage.getItem("teacherEmail");

    this.titleService = new TitleService(title);
    this.titleService.setTitle("BDMApp Profile");
    this.tokenService = new TokenService();
    this.token = this.tokenService.buildToken();
  }

  ngOnInit() {
    if (this.isTeacher) {
      this.getTeacherDetails(this.studentEmail);
    } else {
      this.getStudentsDetails(this.studentEmail)
    }
  }


  private getTeacherDetails(email: string) {
    const theacherResponse = this.http.get('http://localhost:64250/api/teacher/' + this.teacherEmail + '/' + this.teacherEmail + '/' + this.token, { observe: 'response' });

    theacherResponse.subscribe(
      data => {
        this.teacher = new TeacherProfile(data.body["firstName"], data.body["lastName"], data.body["email"], null, data.body["jobTitle"], data.body["requirement"], null)
        this.setThemesToTeacher();
        this.setStudentsToTeacher();
        this.setConsultationToTeacher();
      },
      err => {
        console.log("Error");
        console.log(err)
      }
    );
  }


  private getStudentsDetails(email: string) {
    const studentResponse = this.http.get('http://localhost:64250/api/student/' + email + "/" + this.token, { observe: 'response' });

    studentResponse.subscribe(
      data => {
        this.student = new Student(data.body['firstName'], data.body['lastName'], data.body['email'], null,
          data.body['gitUrl'], data.body['startYear'], data.body['serialNumber'], null, data.body['achievements'], data.body['accepted'], data.body['denied']);

        this.setThemesToStudent(email, this.student);
        this.setTeacherToStudent(email, this.student);
        this.setMeansToStudent(email, this.student);
      },
      err => {
        console.log("Error");
        console.log(err)
      }
    );


  }

  setThemesToStudent(email: string, student: Student) {
      if (localStorage.getItem('isTeacher') == 'True') {
        var themeResponse = this.http.get('http://localhost:64250/api/student/themes/' + this.teacherEmail + "/" + email + "/" + this.token, { observe: 'response' });
      }
  
      if (localStorage.getItem('isTeacher') == 'False') {
        themeResponse = this.http.get('http://localhost:64250/api/student/themes/' + this.studentEmail + "/" + email + "/" + this.token, { observe: 'response' });
      }


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

  setTeacherToStudent(email: string, student: Student) {
    let theacherRespose = this.http.get('http://localhost:64250/api/student/teacher/' + email + "/" + this.token, { observe: 'response' });

    theacherRespose.subscribe(data => {
      if (data.body) {
        student.TeacherName = data.body['firstName'] + " " + data.body['lastName'];
      }
    },
      err => {
        console.log("Error");
        console.log(err)
      }
    );
  }

  setMeansToStudent(email: string, student: Student) {
    let meansResponse = this.http.get('http://localhost:64250/api/student/means/' + email + "/" + this.token, { observe: 'response' });

    meansResponse.subscribe(data => {
      if (data.body) {
        student.Means = new Mean(data.body['firstSemester'], data.body['secondSemester'], data.body['thirdSemester'],
          data.body['fourthSemester'], data.body['fifthSemester'], data.body['sixthSemester'])

      }
    },
      err => {
        console.log("Error");
        console.log(err)
      }
    );
  }

  setThemesToTeacher() {
    this.teacher.Theme = new Array<Bachelor>();
    let themeResponse = this.http.get('http://localhost:64250/api/teacher/themes/' + this.teacherEmail + '/' + this.teacher.Email + "/" + this.token, { observe: 'response' });

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

  setStudentsToTeacher() {
    this.teacher.Student = new Array<Student>();

    let themeResponse = this.http.get('http://localhost:64250/api/teacher/students/'+ this.teacher.Email + '/' + this.teacher.Email + "/" + this.token, { observe: 'response' });

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

  setConsultationToTeacher() {
    if (localStorage.getItem('isTeacher') == 'True') {
      var consultationResponse = this.http.get('http://localhost:64250/api/teacher/getConsultation/' + this.teacherEmail +'/' + this.teacherEmail + "/" + this.token, { observe: 'response' });
    }

    if (localStorage.getItem('isTeacher') == 'False') {
      consultationResponse = this.http.get('http://localhost:64250/api/teacher/getConsultation/'  + this.studentEmail +'/' +  this.teacherEmail + "/" + this.token, { observe: 'response' });
    }


    consultationResponse.subscribe(data => {
      if (data.body) {
        this.teacher.ConsultationDay = DayOfWeek[data.body['day']];
        this.teacher.ConsultationInterval = data.body['interval'];
      }
    },
      err => {
        console.log("Error");
        console.log(err)
      }
    );
  }

  enableEditProfile() {
    this.showEditForm = true;
  }

  cancelEditProfile() {
    this.showEditForm = false;
  }

  editRecord(email: string, gitUrl: string, themeTitle: string, themeDescription: string) {

    console.log("HERE:", email, gitUrl, themeTitle, themeDescription);

    this.editProfileBody = {
      Email: email,
      BachelorThemeDescription: themeDescription,
      BachelorThemeTitle: themeTitle,
      GitUrl: gitUrl,
      Token: this.token
    }

    const resp = this.http.put('http://localhost:64250/api/student/editStudent', this.editProfileBody, { responseType: 'text' });

    resp.subscribe(
      data => {
        window.location.reload();
      },
      err => {
        console.log("Error");
        console.log(err)
      });
  }

  allowEditConsultation() {
    this.showEditConsultation = true;
  }

  cancelConsultation() {
    this.showEditConsultation = false;
  }

  editConsultation(email: string, day: string, interval: string) {
    this.editConsultationBody = {
      TeacherEmail: email,
      Day: DayOfWeek[day],
      Interval: interval,
      Token: this.token
    }

    const resp = this.http.put('http://localhost:64250/api/teacher/editConsultation', this.editConsultationBody, { responseType: 'text' });

    resp.subscribe(
      data => {
        window.location.reload();
      },
      err => {
        console.log("Error");
        console.log(err)
      });

    this.showEditConsultation = false;

  }

}

