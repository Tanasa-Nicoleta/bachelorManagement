import { Component } from '@angular/core';

@Component({
  selector: 'profile',
  templateUrl: './profile.component.html',
  styleUrls: ['../app.component.scss']
})

export class ProfileComponent {
  userFirstName: string = "username";
  userLastName: string = "username last";
  gitUrl: string = "https://github.com/Tanasa-Nicoleta/bachelorManagement";

}
