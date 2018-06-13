import { Component } from '@angular/core';
import { Teacher } from '../../models/teacher.model';
import { Bachelor } from '../../models/bachelor-degree.model';
import { TitleService } from '../../services/title.service';
import { Title } from '@angular/platform-browser';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { TokenService } from '../../services/token.service';

@Component({
    selector: 'student-register-details',
    templateUrl: './student-register-details.component.html',
    styleUrls: ['../../app.component.scss', '../student.component.scss', './student-register-details.component.scss']
})

export class StudentRegisterToTeacherDetailsComponent {

    buttonText: string = "Subimt";
    teacherEmail: string;
    studentEmail: string;

    teacher: Teacher;
    titleService: TitleService;
    tokenService: TokenService;
    token: string;
    
    body: {
        Email: string;
        Description: string;
        Achievement: string;
        Title: string;
        Token: string;
    };

    constructor(private title: Title, private http: HttpClient, private router: Router) {
        this.teacherEmail = localStorage.getItem('teacherEmail');
        this.studentEmail = localStorage.getItem('studentEmail');
        this.titleService = new TitleService(title);
        this.titleService.setTitle("BDMApp Student Register To Teacher Details");
        this.tokenService = new TokenService();   
        this.token = this.tokenService.buildToken();
    }

    ngOnInit() {
        this.getTeacherDetails(this.teacherEmail);
    }

    getTeacherDetails(teacherEmail: string) {
        const theacherResponse = this.http.get('http://localhost:64250/api/teacher/' + this.studentEmail + '/' + this.teacherEmail + '/' + this.token, { observe: 'response' });

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
        let themeResponse = this.http.get('http://localhost:64250/api/teacher/themes/' + this.studentEmail+ '/' +  this.teacher.Email + '/' + this.token, { observe: 'response' });

        themeResponse.subscribe(
            data => {
                for (let key in data.body) {
                    if (data.body[key]) {
                        this.teacher.Theme = new Bachelor(data.body[key]['title'], data.body[key]['description']);
                    }
                }
            },
            err => {
                console.log("Error");
                console.log(err)
            }
        );
    }


    applyToTeacherWithDetails(title: string, description: string, achievement: string) {
        this.body = {
            Email: this.studentEmail,
            Achievement: achievement,
            Description: description,
            Title: title,
            Token: this.token
        };

        const resp = this.http.post('http://localhost:64250/api/student/addTheme', this.body, { responseType: 'text' });

        resp.subscribe(
            data => {
                this.router.navigateByUrl('/studentRegisterToTeacher');
            },
            err => {
                console.log("Error");
                console.log(err)
                //if (err.status == 400)
            }
        );
    }
}
