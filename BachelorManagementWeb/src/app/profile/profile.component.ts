import { Component } from '@angular/core';
import { TitleService } from '../services/title.service';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'profile',
  templateUrl: './profile.component.html',
  styleUrls: ['../app.component.scss']
})

export class ProfileComponent {
  userFirstName: string = "username";
  userLastName: string = "username last";
  userGitUrl: string = "https://github.com/Tanasa-Nicoleta/bachelorManagement";

  titleService: TitleService;

  constructor(private title: Title) {
    this.titleService = new TitleService(title);
    this.titleService.setTitle("BDMApp Profile");
  }
}
