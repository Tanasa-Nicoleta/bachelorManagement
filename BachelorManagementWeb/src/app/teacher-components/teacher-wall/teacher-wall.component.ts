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

  availableDay: string = DayOfWeek[0];
  availableHours: string = "12:00";

  upcomingDeadlineDay: DateClass = new DateClass(1, Month[2], 2018, "14:00");

  requestAMeetingButton: string = "Request a meeting";
  meetingRequest: boolean = false;
  meetingRequestStatus: string = MeetingRequestStatus[0];

  hideCommentsButton: string = "Hide comments";
  showCommentsButton: string = "Show comments";
  showComments: boolean = false;
  teacherEmail: string = "vlad.simion@info.uaic.ro";

  teacherObs: [[TeacherObservation, [Comment | null], boolean]] = [
    [new TeacherObservation("Hello everybody! Welcome to my page.", new DateClass(1, Month[1], 2018, "12:00"), 0),
    [new Comment(this.studentName, "Hello! Thank you, mister " + this.teacherName + "!", new DateClass(20, Month[1], 2018, "14:40"))],
    this.showComments]];

  titleService: TitleService;

  constructor(private title: Title, private http: HttpClient) {
    this.titleService = new TitleService(title);
    this.titleService.setTitle("BDMApp Teacher Wall");
  }

  ngOnInit() {
    this.getTeacherWallComments();
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
           for(let index in this.teacherObs){
              if(this.teacherObs[index][0].id == commentId){
                this.teacherObs[index][1].push(new Comment("Mihai Ursache", data.body[key]['commentReplyContent'], new DateClass(20, Month[1], 2018, "14:40")));
              }
            }            
          }}
      },
      err => {
        console.log("Error");
        console.log(err)
      }
    );
  }

  requestMetting() {
    if (this.meetingRequest) {
      this.meetingRequest = false;
    }
    else {
      this.meetingRequest = true;
    }

    if (this.requestAMeetingButton == "Request a meeting") {
      this.requestAMeetingButton = "Cancel the meeting request";
    }
    else {
      this.requestAMeetingButton = "Request a meeting";
    }
  }

  addComment(commentContent: string, teacherObservation: [TeacherObservation, [Comment | null], boolean]) {

    let datetime = new Date();
    let minutes = (datetime.getMinutes() + "").length == 2 ? datetime.getMinutes() : "0" + datetime.getMinutes();
    let hour = datetime.getHours() + ":" + minutes;
    let comment = new Comment(teacherObservation[1][0].name,
      commentContent,
      new DateClass(datetime.getDate(), Month[datetime.getMonth()], datetime.getFullYear(), hour));

    this.teacherObs.forEach(teacherOb => {
      if (teacherOb[0] == teacherObservation[0]) {
        teacherOb[1].push(comment);
      }
    });
  }

  addPost(commentContent: string){
    this.teacherObs[0].push(new TeacherObservation(commentContent, Date.now, 1));
  }

  showAllComments(teacherObservation: [TeacherObservation, [Comment | null], boolean]) {
    this.teacherObs.forEach(teacherOb => {
      if (teacherOb[0] == teacherObservation[0]) {
        teacherOb[2] = teacherOb[2] == true ? false : true;
      }
    });
  }
}