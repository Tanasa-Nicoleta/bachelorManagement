import { Component } from '@angular/core';
import { MeetingRequestStatus } from '../../models/meetingRequestStatus.model';

@Component({
  selector: 'teacher-wall',
  templateUrl: './teacher-wall.component.html',
  styleUrls: ['../../app.component.scss', '../teacher.component.scss']
})

export class TeacherWallComponent {
  teacherName: string = "Teacher Name"; // to be taken from api
  availableDayAndHour: [string, string] = ["Monday", "12:00"];
  requestAMeetingButton: string = "Request a meeting";
  meetingRequest: boolean = false;
  meetingResuestStatus: MeetingRequestStatus = MeetingRequestStatus.Pending;

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