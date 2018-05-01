import { Component } from '@angular/core';
import { TitleService } from '../services/title.service';
import { Title } from '@angular/platform-browser';
import { Mean } from '../models/mean.model';

@Component({
  selector: 'profile',
  templateUrl: './profile.component.html',
  styleUrls: ['../app.component.scss']
})

export class ProfileComponent {
  userFirstName: string = "username";
  userLastName: string = "username last";
  userGitUrl: string = "https://github.com/Tanasa-Nicoleta/bachelorManagement";
  userRegNo: string = "009001SL043456";
  userStartYear: number = 2017;
  mean: Mean = new Mean(8.5, 9, 6, 7.8, 5, 7);

  titleService: TitleService;

  constructor(private title: Title) {
    this.titleService = new TitleService(title);
    this.titleService.setTitle("BDMApp Profile");
  }
}
