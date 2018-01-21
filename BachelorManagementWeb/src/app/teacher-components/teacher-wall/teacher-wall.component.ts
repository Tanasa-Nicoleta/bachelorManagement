import { Component } from '@angular/core';
import { MeetingRequestStatus } from '../../models/meeting-request-status.model';
import { DayOfWeek } from '../../models/day-of-week.model';
import { DateClass } from '../../models/date.model';

@Component({
  selector: 'teacher-wall',
  templateUrl: './teacher-wall.component.html',
  styleUrls: ['../../app.component.scss', '../teacher.component.scss']
})

export class TeacherWallComponent {
  teacherName: string = "Teacher Name"; // to be taken from api
  availableDay: string = DayOfWeek[0];
  upcomingDeadlineDay: DateClass =  new DateClass(1, 3, 2018, "14:00");
  availableHours: string = "12:00";
  requestAMeetingButton: string = "Request a meeting";
  meetingRequest: boolean = false;
  meetingRequestStatus: string = MeetingRequestStatus[0];

  requestMetting(){
    if(this.meetingRequest){
      this.meetingRequest = false;
    }
    else{
      this.meetingRequest = true;
    }
    
    if(this.requestAMeetingButton == "Request a meeting"){
      this.requestAMeetingButton = "Cancel the meeting request";
    }
    else{
      this.requestAMeetingButton = "Request a meeting";
    }
  }
}