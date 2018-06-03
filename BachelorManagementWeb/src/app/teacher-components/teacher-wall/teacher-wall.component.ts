import { Component } from '@angular/core';
import { MeetingRequestStatus } from '../../models/meeting-request-status.model';
import { DayOfWeek } from '../../models/day-of-week.model';
import { DateClass } from '../../models/date.model';
import { TeacherObservation } from '../../models/teacher-observation.model';
import { Month } from '../../models/month.model';
import { Comment } from '../../models/comment.model';
import { TitleService } from '../../services/title.service';
import { Title } from '@angular/platform-browser';
import { HttpClient } from '@angular/common/http';
import { Teacher } from '../../models/teacher.model';

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

  meetingRequestBody: {
    StudentEmail: string,
    TeacherEmail: string,
    Date: Date
  }

  postBody:{
    StudentEmail: string;
    TeacherEmail: string;
    CommentContent: string;
  }

  commentBody:{
    CommentId: number;
    CommentContent: string;
  }

  constructor(private title: Title, private http: HttpClient) {
    this.titleService = new TitleService(title);
    this.titleService.setTitle("BDMApp Teacher Wall");
  }

  ngOnInit() {
    this.getTeacherWallComments();
    this.getMeetingRequestStatus();
  }

  getMeetingRequestStatus(){
    const commentResponse = this.http.get('http://localhost:64250/api/student/studentMeetingRequestStatus/' + this.studentEmail, { observe: 'response' });

    commentResponse.subscribe(
      data => {
         this.meetingRequestStatus = MeetingRequestStatus[data.body['status']];
         if(data.body['status'] == 1 || data.body['status'] == 2){
          this.requestAMeetingButton = this.cancel;
          this.meetingRequest = true;
         }
      },
      err => {
        console.log("Error");
        console.log(err)
      }
    );
  }

  getTeacherWallComments() {
    const commentResponse = this.http.get('http://localhost:64250/api/teacher/comments/' + this.teacherEmail, { observe: 'response' });

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
        console.log("Error");
        console.log(err)
      }
    );
  }

  getTeacherWallCommentReplies(commentId: number) {
    const commentReplyResponse = this.http.get('http://localhost:64250/api/teacher/comments/' + this.teacherEmail + "/" + commentId, { observe: 'response' });

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
        console.log("Error");
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
      Date: new Date()
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
      Date: new Date()
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
          console.log("Error");
          console.log(err)
        }
      );
    
  }

  addPost(commentContent: string) {
    this.postBody = {
      StudentEmail: this.studentEmail,
      TeacherEmail: this.teacherEmail,
      CommentContent: commentContent
    }

    const commentReplyResponse = this.http.post('http://localhost:64250/api/teacher/comments', this.postBody, { observe: 'response' });

    commentReplyResponse.subscribe(
      data => {
        window.location.reload();
      },
      err => {
        console.log("Error");
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