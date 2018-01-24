import { Component } from '@angular/core';
import { MeetingRequestStatus } from '../../models/meeting-request-status.model';
import { DayOfWeek } from '../../models/day-of-week.model';
import { DateClass } from '../../models/date.model';
import { TeacherObservation } from '../../models/teacher-observation.model';
import { Month } from '../../models/month.model';
import { Comment } from '../../models/comment.model';

@Component({
  selector: 'teacher-wall',
  templateUrl: './teacher-wall.component.html',
  styleUrls: ['../../app.component.scss', '../teacher.component.scss']
})

export class TeacherWallComponent {
  teacherName: string = "Teacher Name"; // to be taken from api
  studentName: string = "Student Name";

  availableDay: string = DayOfWeek[0];
  availableHours: string = "12:00";

  upcomingDeadlineDay: DateClass = new DateClass(1, Month[2], 2018, "14:00");

  requestAMeetingButton: string = "Request a meeting";
  meetingRequest: boolean = false;
  meetingRequestStatus: string = MeetingRequestStatus[0];

  addCommentButton: string = "Add comment";

  teacherObs: [[TeacherObservation, [Comment | null]]] = [
    [new TeacherObservation("Hello everybody! Welcome to my page.", new DateClass(1, Month[1], 2018, "12:00")),
      [new Comment(this.studentName, "Hello! Thank you!", new DateClass(1, Month[1], 2018, "12:00")),
      new Comment(this.studentName, "Hello! Thank you, mister " + this.teacherName + "!", new DateClass(20, Month[1], 2018, "14:40"))]],
    [new TeacherObservation("Good morning! I want to see your papers soon.", new DateClass(20, Month[1], 2018, "14:40")),
      [new Comment(this.studentName, "Hello! Thank you, mister " + this.teacherName + "!", new DateClass(20, Month[1], 2018, "14:40"))]],
    [new TeacherObservation("Hello! Any updates?", new DateClass(21, Month[1], 2018, "12:00")),
      [null]],
    [new TeacherObservation("Is anybody having a problem?", new DateClass(22, Month[1], 2018, "19:35")),
      [null]],
    [new TeacherObservation("I  have some news for you!" +
      "I'm not available to see you in person in the next two weeks because of some personal problems." +
      "I would be available on this platform so if you got ay questions plese shoot. :)",
      new DateClass(25, Month[1], 2018, "21:30")),
      [null]],
    [new TeacherObservation("Good morning! I want to see your updated papers on Monday.", new DateClass(29, Month[1], 2018, "12:28")),
      [null]]
  ];


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

  addComment(){

  }
}