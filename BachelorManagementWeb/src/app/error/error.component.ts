import { Component } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { TitleService } from '../services/title.service';

@Component({
  selector: 'error',
  templateUrl: './error.component.html',
  styleUrls: ['../app.component.scss']
})

export class ErrorComponent {
  welcomeText: string = "Something went wrong,";
  welcomeSubtext: string = "please try again later!";
  
  titleService: TitleService;

  constructor(private title: Title) {
    this.titleService = new TitleService(title);
    this.titleService.setTitle("BDMApp Error");
  }

}
