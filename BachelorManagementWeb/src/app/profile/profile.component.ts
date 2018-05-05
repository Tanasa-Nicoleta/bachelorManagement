import { Component } from '@angular/core';
import { TitleService } from '../services/title.service';
import { Title } from '@angular/platform-browser';
import { Mean } from '../models/mean.model';
import { HttpClient } from '@angular/common/http';
import { Student } from '../models/student.model';

@Component({
  selector: 'profile',
  templateUrl: './profile.component.html',
  styleUrls: ['../app.component.scss']
})

export class ProfileComponent {

  email: string = "mihai.ursache@info.uaic.ro";
  student: Student;

  titleService: TitleService;

  constructor(private title: Title, private http: HttpClient) {
    this.titleService = new TitleService(title);
    this.titleService.setTitle("BDMApp Profile");
  }

  ngOnInit() {
    this.getStudentsDetails(this.email)
  }

  private getStudentsDetails(email: string) {
    const theacherResponse = this.http.get('http://localhost:64250/api/student/' + this.email, { observe: 'response' });

    theacherResponse.subscribe(
      data => {
        console.log(data.body);
        this.student = new Student(data.body['firstName'], data.body['lastName'], data.body['email'], null,
          data.body['gitUrl'], data.body['startYear'], data.body['serialNumber'], null);
      },
      err => {
        console.log("Error");
        console.log(err)
      }
    );
  }

  private getStudentBachelorTheme(email:string){
    
  }
}
