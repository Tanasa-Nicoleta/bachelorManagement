import { Component } from '@angular/core';

@Component({
  selector: 'student-header',
  templateUrl: './student-header.component.html',
  styleUrls: ['../../app.component.scss']
})

export class StudentHeaderComponent {  
  Username: string = "someone@info.uaic.ro";
}