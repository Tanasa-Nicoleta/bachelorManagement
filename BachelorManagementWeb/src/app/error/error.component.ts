import { Component } from '@angular/core';

@Component({
  selector: 'error',
  templateUrl: './error.component.html',
  styleUrls: ['../app.component.scss']
})

export class ErrorComponent {
  welcomeText: string = "Something went wrong,";
  welcomeSubtext: string = "please try again later!";
}
