import { Component } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { TitleService } from '../../services/title.service';
import { HttpClient } from '@angular/common/http';
import { Student } from '../../models/student.model';
import { Bachelor } from '../../models/bachelor-degree.model';
import { TokenService } from '../../services/token.service';

@Component({
    selector: 'student-work',
    templateUrl: './student-work.component.html',
    styleUrls: ['../../app.component.scss']
})

export class StudentWorkComponent {
    dueDate: Date = new Date(2018, 6, 15);
    teacherEmail: string;
    studentEmail: string;

    students: Array<Student> = new Array<Student>();
    titleService: TitleService;
    tokenService: TokenService;
    token: string;

    constructor(private title: Title, private http: HttpClient) {
        this.teacherEmail = localStorage.getItem('teacherEmail');
        this.studentEmail = localStorage.getItem('studentEmail');
        this.titleService = new TitleService(title);
        this.titleService.setTitle("BDMApp Student Work");
        this.tokenService = new TokenService();
        this.token = this.tokenService.buildToken();
    }

    ngOnInit() {
        this.getTeacherStudents(this.teacherEmail);
    }

    getTeacherStudents(email: string) {
        if (localStorage.getItem('isTeacher') == 'True') {
            var teacherResponse = this.http.get('http://localhost:64250/api/teacher/students/' + this.teacherEmail + '/' + email + '/' + this.token, { observe: 'response' });
        }

        if (localStorage.getItem('isTeacher') == 'False') {
            teacherResponse = this.http.get('http://localhost:64250/api/teacher/students/' + this.studentEmail + '/' + email + '/' + this.token, { observe: 'response' });
        }

        teacherResponse.subscribe(
            data => {
                for (let key in data.body) {
                    if (data.body[key]) {
                        this.students.push(new Student(data.body[key]['firstName'], data.body[key]['lastName'],
                            data.body[key]['email'], null, data.body[key]['gitUrl'],
                            data.body[key]['startYear'], data.body[key]['serialNumber'], null, data.body[key]['achievements'],
                            data.body[key]['accepted'], data.body[key]['denied']));
                    }
                    this.setBachelorThemeToStudents(data.body[key]['email'], key);
                }
            },
            err => {
                console.log("Error getting teacher students");
                console.log(err)
            }
        );
    }

    setBachelorThemeToStudents(email: string, key: string) {
        if (localStorage.getItem('isTeacher') == 'True') {
            var themeResponse = this.http.get('http://localhost:64250/api/student/themes/' + this.teacherEmail + '/' + email + '/' + this.token, { observe: 'response' });
        }

        if (localStorage.getItem('isTeacher') == 'False') {
            themeResponse = this.http.get('http://localhost:64250/api/student/themes/' + this.studentEmail + '/' + email + '/' + this.token, { observe: 'response' });
        }

        themeResponse.subscribe(
            data => {
                this.students[key]['Theme'] = new Bachelor(data.body['title'], data.body['description']);
            },
            err => {
                console.log("Error geeting bachelor themes");
                console.log(err)
            }
        );
    }
}