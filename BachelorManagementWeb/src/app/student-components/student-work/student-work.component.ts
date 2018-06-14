import { Component } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { TitleService } from '../../services/title.service';
import { HttpClient } from '@angular/common/http';
import { Student } from '../../models/student.model';
import { Bachelor } from '../../models/bachelor-degree.model';
import { TokenService } from '../../services/token.service';
import { Commit } from '../../models/commit.model';
import { Router } from '@angular/router';

@Component({
    selector: 'student-work',
    templateUrl: './student-work.component.html',
    styleUrls: ['../../app.component.scss', '../student.component.scss']
})

export class StudentWorkComponent {
    gitUserName: string = "Tanasa-Nicoleta";
    gitProjectName: string = "bachelorManagement";
    dueDate: Date = new Date(2018, 6, 15);
    teacherEmail: string;
    studentEmail: string;

    students: Array<Student> = new Array<Student>();
    commitsArray: Array<Commit> = new Array<Commit>();
    titleService: TitleService;
    tokenService: TokenService;
    token: string;
    commitsData: any;

    constructor(private title: Title, private http: HttpClient, private router: Router) {
        this.teacherEmail = localStorage.getItem('teacherEmail');
        this.studentEmail = localStorage.getItem('studentEmail');
        this.titleService = new TitleService(title);
        this.titleService.setTitle("BDMApp Student Work");
        this.tokenService = new TokenService();
        this.token = this.tokenService.buildToken();
    }

    ngOnInit() {
        this.getTeacherStudents(this.teacherEmail);
        this.getCommitData();
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

    getCommitData() {
        var resp = this.http.get('https://api.github.com/repos/' + this.gitUserName + '/' + this.gitProjectName + '/commits ');

        resp.subscribe(
            data => {
                this.commitsData = data;
                this.iterateForCommits();
            },
            err => {
                console.log("Error");
                console.log(err)
            });
    }

    iterateForCommits() {
        let i = 0;
        for (var key in this.commitsData) {
            if (i < 5) {
                if (this.commitsData.hasOwnProperty(key)) {
                    this.commitsArray.push(new Commit(this.commitsData[key].commit.message, new Date(this.commitsData[key].commit.author.date)));
                }
            }
            i++;
        }
    }

    goToDetails(email: string){
        this.router.navigateByUrl('/gitDetails');
    }

}