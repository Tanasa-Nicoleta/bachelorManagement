import { Component } from '@angular/core';
import { MeetingRequestStatus } from '../../models/meeting-request-status.model';
import { DayOfWeek } from '../../models/day-of-week.model';
import { DateClass } from '../../models/date.model';
import { TeacherObservation } from '../../models/teacher-observation.model';
import { Month } from '../../models/month.model';
import { Comment } from '../../models/comment.model';
import { TitleService } from '../../services/title.service';
import { Title } from '@angular/platform-browser';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Teacher } from '../../models/teacher.model';
import { TokenService } from '../../services/token.service';

@Component({
  selector: 'teacher-wall',
  templateUrl: './teacher-wall.component.html',
  styleUrls: ['../../app.component.scss', '../teacher.component.scss']
})

export class TeacherWallComponent {
  teacherName: string = "Vlad Simion";
  studentName: string = "Mihai Ursache";
  studentEmail: string = "mihai.ursache@info.uaic.ro";
  availableDay: string = DayOfWeek[0];
  availableHours: string = "12:00";
  upcomingDeadlineDay: DateClass = new DateClass(1, Month[2], 2018, "14:00");
  requestAMeetingButton: string = "Request a meeting";
  request: string = "Request a meeting";
  cancel: string = "Cancel the meeting request";
  meetingRequest: boolean = false;
  meetingRequestStatus: string = MeetingRequestStatus[0];
  hideCommentsButton: string = "Hide comments";
  showCommentsButton: string = "Show comments";
  showComments: boolean = false;
  teacherEmail: string = "vlad.simion@info.uaic.ro";
  teacherObs: [[TeacherObservation, [Comment | null], boolean]] = [
    [new TeacherObservation("Hello everybody! Welcome to my page.", new DateClass(1, Month[1], 2018, "12:00"), 0),
    [new Comment(this.studentName, "Hello! Thank you!", new DateClass(20, Month[1], 2018, "14:40"))],
    this.showComments]];

  titleService: TitleService; 
  tokenService: TokenService;
  token: string;

  meetingRequestBody: {
    StudentEmail: string,
    TeacherEmail: string,
    Date: Date,
    Token: string
  }

  postBody:{
    StudentEmail: string;
    TeacherEmail: string;
    CommentContent: string;
    Token: string;
  }

  commentBody:{
    CommentId: number;
    CommentContent: string;
  }

  constructor(private title: Title, private http: HttpClient) {
    this.titleService = new TitleService(title);
    this.titleService.setTitle("BDMApp Teacher Wall");
    this.tokenService = new TokenService();   
    this.token = this.tokenService.buildToken();
  }

  ngOnInit() {
    this.getTeacherWallComments();
    this.getMeetingRequestStatus();
  }

  getMeetingRequestStatus(){
    const commentResponse = this.http.get('http://localhost:64250/api/student/studentMeetingRequestStatus/' + this.studentEmail + '/' + this.token, { observe: 'response' });

    commentResponse.subscribe(
      data => {
         this.meetingRequestStatus = MeetingRequestStatus[data.body['status']];
         if(data.body['status'] == 1 || data.body['status'] == 2){
          this.requestAMeetingButton = this.cancel;
          this.meetingRequest = true;
         }
      },
      err => {
        console.log("Error getting status");
        console.log(err)
      }
    );
  }

  getTeacherWallComments() {
    if(localStorage.getItem('isTeacher') == 'False'){
      var commentResponse = this.http.get('http://localhost:64250/api/teacher/comments/'+ this.studentEmail + '/' + this.teacherEmail + '/' + this.token, { observe: 'response' });
    }

    if(localStorage.getItem('isTeacher') == 'True'){
      var commentResponse = this.http.get('http://localhost:64250/api/teacher/comments/'+ this.teacherEmail + '/' + this.teacherEmail + '/' + this.token, { observe: 'response' });
    }

    commentResponse.subscribe(
      data => {
        for (let key in data.body) {
          if (data.body.hasOwnProperty(key)) {
            this.teacherObs.push(
              [new TeacherObservation(data.body[key]['commentContent'], new DateClass(20, Month[1], 2018, "14:40"), data.body[key]['id']),
              [new Comment(this.teacherName, "some content", new DateClass(20, Month[1], 2018, "14:40"))],
                false]);

          }
          this.getTeacherWallCommentReplies(data.body[key]['id']);
        }
      },
      err => {
        console.log("Error comments");
        console.log(err)
      }
    );
  }

  getTeacherWallCommentReplies(commentId: number) {
    if(localStorage.getItem('isTeacher') == 'False'){
      var commentReplyResponse = this.http.get('http://localhost:64250/api/teacher/comments/' + this.studentEmail + '/' + this.teacherEmail + "/" + commentId + '/' + this.token, { observe: 'response' });
    }

    if(localStorage.getItem('isTeacher') == 'True'){
      var commentReplyResponse = this.http.get('http://localhost:64250/api/teacher/comments/' + this.teacherEmail + '/' + this.teacherEmail + "/" + commentId + '/' + this.token, { observe: 'response' });
    }

    commentReplyResponse.subscribe(
      data => {
        for (let key in data.body) {
          if (data.body.hasOwnProperty(key)) {
            for (let index in this.teacherObs) {
              if (this.teacherObs[index][0].Id == commentId) {
                this.teacherObs[index][1].push(new Comment("Mihai Ursache", data.body[key]['commentReplyContent'], new DateClass(20, Month[1], 2018, "14:40")));
              }
            }
          }
        }
      },
      err => {
        console.log("Error comment replies");
        console.log(err)
      }
    );
  }

  requestMetting() {
    if (this.requestAMeetingButton == this.request) {
      this.registerRequestMeeting();
    }

    if (this.requestAMeetingButton == this.cancel) {
      this.cancelRequestMeeting();
    }

    this.displayMeetingRequest();
  }

  registerRequestMeeting() {
    this.meetingRequestBody = {
      StudentEmail: this.studentEmail,
      TeacherEmail: this.teacherEmail,
      Date: new Date(),
      Token: this.token
    }

    const commentReplyResponse = this.http.post('http://localhost:64250/api/student/studentMeetingRequest', this.meetingRequestBody, { observe: 'response' });

    commentReplyResponse.subscribe(
      data => {
        this.meetingRequestStatus = MeetingRequestStatus[0];
      },
      err => {
        console.log("Error requesting meeting");
        console.log(err)
      }
    );

  }

  cancelRequestMeeting() {
    this.meetingRequestBody = {
      StudentEmail: this.studentEmail,
      TeacherEmail: this.teacherEmail,
      Date: new Date(),
      Token: this.token
    }

    const commentReplyResponse = this.http.post('http://localhost:64250/api/student/deleteStudentMeetingRequest', this.meetingRequestBody, { observe: 'response' });

    commentReplyResponse.subscribe(
      data => {

      },
      err => {
        console.log("Error canceling meeting");
        console.log(err)
      }
    );

  }

  displayMeetingRequest() {
    if (this.meetingRequest) {
      this.meetingRequest = false;
    }
    else {
      this.meetingRequest = true;
    }

    if (this.requestAMeetingButton == this.request) {
      this.requestAMeetingButton = this.cancel;
    }
    else {
      this.requestAMeetingButton = this.request;
    }
  }

  addComment(commentContent: string, teacherObservation: [TeacherObservation, [Comment | null], boolean]) {
      this.commentBody = {
        CommentId: teacherObservation[0].Id,
        CommentContent: commentContent
      }
  
      const commentReplyResponse = this.http.post('http://localhost:64250/api/teacher/addCommentReply', this.commentBody, { observe: 'response' });
  
      commentReplyResponse.subscribe(
        data => {
          window.location.reload();
        },
        err => {
          console.log("Error adding comment");
          console.log(err)
        }
      );
    
  }

  addPost(commentContent: string) {
    this.postBody = {
      StudentEmail: this.studentEmail,
      TeacherEmail: this.teacherEmail,
      CommentContent: commentContent,
      Token: this.token
    }

    const commentReplyResponse = this.http.post('http://localhost:64250/api/teacher/comments', this.postBody, { observe: 'response' });

    commentReplyResponse.subscribe(
      data => {
        window.location.reload();
      },
      err => {
        console.log("Error add post");
        console.log(err)
      }
    );
  }

  showAllComments(teacherObservation: [TeacherObservation, [Comment | null], boolean]) {
    this.teacherObs.forEach(teacherOb => {
      if (teacherOb[0] == teacherObservation[0]) {
        teacherOb[2] = teacherOb[2] == true ? false : true;
      }
    });
  }
}