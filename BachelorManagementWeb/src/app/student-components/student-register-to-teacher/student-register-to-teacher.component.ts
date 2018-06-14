import { Component } from '@angular/core';
import { Teacher } from '../../models/teacher.model';
import { Bachelor } from '../../models/bachelor-degree.model';
import { TitleService } from '../../services/title.service';
import { Title } from '@angular/platform-browser';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Student } from '../../models/student.model';
import { TokenService } from '../../services/token.service';
import { Router } from '@angular/router';

@Component({
    selector: 'student-register-to-teacher',
    templateUrl: './student-register-to-teacher.component.html',
    styleUrls: ['../../app.component.scss', '../student.component.scss']
})

export class StudentRegisterToTeacherComponent {
    dueDate: Date = new Date(2018, 6, 15);
    optionText: string = "Next step";
    acceptedByTeacher: boolean = false;

    teacherList: Array<Teacher> = new Array<Teacher>();
    studentEmail: string;
    teacherEmails: string[] = [];
    titleService: TitleService;
    student: Student;
    tokenService: TokenService;
    token: string;

    constructor(private title: Title, private http: HttpClient, private router: Router) {
        this.titleService = new TitleService(title);
        this.titleService.setTitle("BDMApp Student Register To Teacher");
        this.tokenService = new TokenService();
        this.token = this.tokenService.buildToken();
    }

    ngOnInit() {
        this.studentEmail = localStorage.getItem('studentEmail');
        this.getStudent(this.studentEmail);        
        this.getTeachers();
    }

    getStudent(email: string) {
        const studentResponse = this.http.get('http://localhost:64250/api/student/' + email + '/' + this.token, { observe: 'response' });

        studentResponse.subscribe(
            data => {
                this.student = new Student(data.body['firstName'], data.body['lastName'], data.body['email'], null, data.body['gitUrl'], data.body['startYear'], data.body['serialNumber'], null, data.body['achievements'], data.body['accepted'], data.body['denied']);
                this.student.Pending = data.body['pending'];

                if (this.student.Accepted == true) {
                    this.acceptedByTeacher = true;
                    this.router.navigateByUrl('/teacherWall');
                }

                if (this.student.Denied == true) {
                    this.student.Pending = false;
                }
            },
            err => {
                console.log("Error");
                console.log(err)
            }
        );
    }

    applyToTeacher(teacherFirstName: string, teacherLastName: string) {
        localStorage.setItem('teacherEmail', teacherFirstName + '.' + teacherLastName + '@info.uaic.ro');
        this.student.Pending = true;
        this.router.navigateByUrl('/studentRegisterToTeacherDetails');
    }

    getTeachers() {
        const teacherResponse = this.http.get('http://localhost:64250/api/teachers/' + this.studentEmail + '/' + this.token, { observe: 'response' });

        teacherResponse.subscribe(
            data => {
                for (let key in data.body) {
                    if (data.body.hasOwnProperty(key)) {
                        this.teacherList.push(new Teacher(data.body[key]['firstName'], data.body[key]['lastName'],
                            data.body[key]['email'], data.body[key]['numberOfSpots'], data.body[key]['numberOfAvailableSpots'],
                            new Array<Bachelor>(), data.body[key]['discipline'], data.body[key]['jobTitle'], data.body[key]['requirement']));
                        this.teacherEmails.push(data.body[key]['email']);
                    }
                }
                this.setThemesToTeacher();
            },
            err => {
                console.log("Error");
                console.log(err)
            }
        );
    }

    setThemesToTeacher() {
        let i = 0;
        let j = 0;

        for (let email in this.teacherEmails) {
            let themeResponse = this.http.get('http://localhost:64250/api/teacher/themes/' + this.studentEmail + '/' + this.teacherEmails[email] + '/' + this.token, { observe: 'response' });

            themeResponse.subscribe(data => {
                if (data.body[i]) {
                    this.teacherList[j].Theme = new Bachelor(data.body[i]['title'], data.body[i]['description']);;
                }
                j++;
            },
                err => {
                    console.log("Error");
                    console.log(err)
                }
            );
        }
    }
}
