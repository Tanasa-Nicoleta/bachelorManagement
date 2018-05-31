import { Component } from '@angular/core';
import { TitleService } from '../services/title.service';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['../app.component.scss']
})

export class WelcomeComponent {
  welcomeText: string = "Welcome to the Bachelor Degree Management App,";
  welcomeSubtext: string = "keep up with the good work and you will succeed!";

  titleService: TitleService;

  constructor(private title: Title) {
    this.titleService = new TitleService(title);
    this.titleService.setTitle("BDMApp Welcome");
  }
}