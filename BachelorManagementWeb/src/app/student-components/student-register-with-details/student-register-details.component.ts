import { Component } from '@angular/core';
import { Teacher } from '../../models/teacher.model';
import { Bachelor } from '../../models/bachelor-degree.model';
import { TitleService } from '../../services/title.service';
import { Title } from '@angular/platform-browser';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
    selector: 'student-register-details',
    templateUrl: './student-register-details.component.html',
    styleUrls: ['../../app.component.scss', '../student.component.scss', './student-register-details.component.scss']
})


export class StudentRegisterToTeacherDetailsComponent {

    buttonText: string = "Subimt";

    teacher: Teacher;

    titleService: TitleService;
    email: string = "vlad.simion@info.uaic.ro";
    studentEmail: string = "mihai.ursache@info.uaic.ro";

    body: {
        UserEmail: string;
        Description: string;
        Achievement: string;
        Title: string;
      };

    constructor(private title: Title, private http: HttpClient, private router: Router) {
        this.titleService = new TitleService(title);
        this.titleService.setTitle("BDMApp Student Register To Teacher Details");
    }

    ngOnInit() {
        this.getTeacherDetails(this.email);
    }

    getTeacherDetails(email: string) {
        const theacherResponse = this.http.get('http://localhost:64250/api/teacher/' + this.email, { observe: 'response' });

        theacherResponse.subscribe(
            data => {
                this.teacher = new Teacher(data.body['firstName'], data.body['lastName'],
                    data.body['email'], data.body['numberOfSpots'], data.body['numberOfAvailableSpots'],
                    new Array<Bachelor>(), data.body['discipline'], data.body['jobTitle'], data.body['requirement']);
                this.setThemesToTeacher();
            },
            err => {
                console.log("Error");
                console.log(err)
            }
        );
    }

    setThemesToTeacher() {
        let themeResponse = this.http.get('http://localhost:64250/api/teacher/themes/' + this.teacher.Email, { observe: 'response' });

        themeResponse.subscribe(data => {
            for (let key in data.body) {
                if (data.body[key]) {
                    this.teacher.Themes.push(new Bachelor(data.body[key]['title'], data.body[key]['description']));
                }
            }   
            console.log(this.teacher);
        },
            err => {
                console.log("Error");
                console.log(err)
            });
    }

    
    applyToTeacherWithDetails(title: string, description: string, achievement: string) {
        this.body = {
            UserEmail: this.studentEmail,
            Achievement: achievement,
            Description: description,
            Title: title
          };
        const resp = this.http.post('http://localhost:64250/api/student/addTheme', this.body, {responseType: 'text'});
        
            resp.subscribe(      
              data => {
                console.log("Succes");
                this.router.navigateByUrl('/teacherWall');        
              },
              err => {
                console.log("Error");
                console.log(err)
                //if (err.status == 400)
              });
    }
}
