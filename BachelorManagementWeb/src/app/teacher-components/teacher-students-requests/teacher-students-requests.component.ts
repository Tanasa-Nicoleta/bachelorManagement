import { Component } from '@angular/core';
import { Student } from '../../models/student.model';
import { Bachelor } from '../../models/bachelor-degree.model';
import { Achievement } from '../../models/achievement.model';
import { TitleService } from '../../services/title.service';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { MeetingRequest } from '../../models/meeting-request';
import { MeetingRequestStatus } from '../../models/meeting-request-status.model';
import { TokenService } from '../../services/token.service';

@Component({
  selector: 'teacher-students-requests',
  templateUrl: './teacher-students-requests.component.html',
  styleUrls: ['../../app.component.scss', '../teacher.component.scss']
})

export class TeacherStudentsRequestsComponent {
  email: string = "vlad.simion@info.uaic.ro";
  acceptStudentsRequest: string = "Accept";
  declineStudentsRequest: string = "Decline";
  dueDatePassed: boolean = false; //this.limitDate < this.today;
  limitDate: Date = new Date(2018, 6, 15);

  numberOfSpots: number;
  numberOfAvailableSpots: number;
  studentList: Array<Student> = new Array<Student>();
  titleService: TitleService;
  meetingRequests: Array<MeetingRequest> = new Array<MeetingRequest>();
  today: Date = new Date(); 
  tokenService: TokenService;
  token: string;

  meetingRequestBody: {
    StudentEmail: string,
    TeacherEmail: string,
    Date: Date,
    Token: string
  }

  constructor(private title: Title, private http: HttpClient, private router: Router) {
    this.titleService = new TitleService(title);
    this.titleService.setTitle("BDMApp Teacher Students Requests");
    this.tokenService = new TokenService();   
    this.token = this.tokenService.buildToken();
  }

  ngOnInit() {
    if (this.dueDatePassed) {
      this.getTeacherMeetingRequests(this.email);
      this.getTeacherStudents(this.email);
    }
    else {
      this.getTeacherDetails(this.email);
      this.getTeacherStudents(this.email);
    }
  }

  getTeacherMeetingRequests(email: string) {
    const teacherResponse = this.http.get('http://localhost:64250/api/teacher/studentMeetingRequest/' + email + '/' + this.token, { observe: 'response' });

    teacherResponse.subscribe(
      data => {
        for (let key in data.body) {
          if (data.body[key]) {
            this.meetingRequests.push(new MeetingRequest(data.body[key]["studentEmail"], data.body[key]["teacherEmail"],
              new Date(data.body[key]["date"]), null, null));
            this.getMeetingRequestStatus(this.meetingRequests.find(m => m.StudentEmail == data.body[key]["studentEmail"]), data.body[key]["studentEmail"])
          }
        }
      },
      err => {
        console.log("Error 1");
        console.log(err)
      }
    );
  }

  getMeetingRequestStatus(meetingRequest: MeetingRequest, email: string) {
    const commentResponse = this.http.get('http://localhost:64250/api/student/studentMeetingRequestStatus/' + email + '/' + this.token, { observe: 'response' });

    commentResponse.subscribe(
      data => {
        meetingRequest.Accepted = MeetingRequestStatus[data.body['status']] == MeetingRequestStatus[1];
        meetingRequest.Declined = MeetingRequestStatus[data.body['status']] == MeetingRequestStatus[2];
      },
      err => {
        console.log("Error");
        console.log(err)
      }
    );
  }


  getTeacherDetails(email: string) {
    const teacherResponse = this.http.get('http://localhost:64250/api/teacher/' + email + '/' + email +  '/' + this.token, { observe: 'response' });

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
    const studentResponse = this.http.get('http://localhost:64250/api/teacher/students/' + email + '/' + this.token, { observe: 'response' });

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
    this.studentList[key]['Theme'] = new Bachelor(null, null);

    const themeResponse = this.http.get('http://localhost:64250/api/student/themes/'+ this.email + '/' + email + '/' + this.token, { observe: 'response' });

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
          Token: this.token
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
          Token: this.token
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

  acceptRequestMetting(studentEmail: string, teacherEmail: string) {
    this.meetingRequestBody = {
      StudentEmail: studentEmail,
      TeacherEmail: teacherEmail,
      Date: new Date(),
      Token: this.token
    }

    const commentReplyResponse = this.http.post('http://localhost:64250/api/teacher/acceptStudentMeetingRequest', this.meetingRequestBody, { observe: 'response' });

    commentReplyResponse.subscribe(
      data => {
        this.meetingRequests.forEach(meetingRequest => {
          if (meetingRequest.StudentEmail == studentEmail) { meetingRequest.Accepted = true; }
        });
      },
      err => {
        console.log("Error canceling meeting");
        console.log(err)
      }
    );
  }

  declineRequestMetting(studentEmail: string, teacherEmail: string) {
    this.meetingRequestBody = {
      StudentEmail: studentEmail,
      TeacherEmail: teacherEmail,
      Date: new Date(),
      Token: this.token
    }

    const commentReplyResponse = this.http.post('http://localhost:64250/api/teacher/declineStudentMeetingRequest', this.meetingRequestBody, { observe: 'response' });

    commentReplyResponse.subscribe(
      data => {
        this.meetingRequests.forEach(meetingRequest => {
          if (meetingRequest.StudentEmail == studentEmail) { meetingRequest.Declined = true; }
        });
      },
      err => {
        console.log("Error canceling meeting");
        console.log(err)
      }
    );
  }
}
