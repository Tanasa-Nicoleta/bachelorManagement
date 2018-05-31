import { Component } from '@angular/core';

@Component({
  selector: 'profile-header',
  templateUrl: './profile-header.component.html',
  styleUrls: ['../../app.component.scss']
})

export class ProfileHeaderComponent {  
  Username: string = "someone@info.uaic.ro";
}