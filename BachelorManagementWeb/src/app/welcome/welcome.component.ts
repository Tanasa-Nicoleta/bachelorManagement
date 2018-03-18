import { Component } from '@angular/core';

@Component({
  selector: 'welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['../app.component.scss']
})

export class WelcomeComponent {
  welcomeText: string = "Welcome to the Bachelor Degree Management App,";
  welcomeSubtext: string = "keep up with the good work and you will succeed!";
}