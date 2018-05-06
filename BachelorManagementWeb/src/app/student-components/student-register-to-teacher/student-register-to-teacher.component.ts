import { Component } from '@angular/core';
import { Teacher } from '../../models/teacher.model';
import { Bachelor } from '../../models/bachelor-degree.model';
import { TitleService } from '../../services/title.service';
import { Title } from '@angular/platform-browser';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

@Component({
    selector: 'student-register-to-teacher',
    templateUrl: './student-register-to-teacher.component.html',
    styleUrls: ['../../app.component.scss', '../student.component.scss']
})

export class StudentRegisterToTeacherComponent {
    optionText: string = "Next step";
    teacherList: Array<Teacher> = new Array<Teacher>();
    teacherEmails: string[] = [];
    titleService: TitleService;

    constructor(private title: Title, private http: HttpClient) {
        this.titleService = new TitleService(title);
        this.titleService.setTitle("BDMApp Student Register To Teacher");
    }

    ngOnInit() {
        this.getTeachers();
    }

    applyToTeacher(teacherFirstName: string, teacherLastName: string) {
        console.log(teacherFirstName + " " + teacherLastName);
        //send those to the next file
    }

    getTeachers() {
        const teacherResponse = this.http.get('http://localhost:64250/api/teacher', { observe: 'response' });

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

        for (let email in this.teacherEmails) {
            let themeResponse = this.http.get('http://localhost:64250/api/teacher/themes/' + this.teacherEmails[email], { observe: 'response' });

            themeResponse.subscribe(data => {
                if (data.body[i]) {
                    this.teacherList[i].Theme = new Bachelor(data.body[i]['title'], data.body[i]['description'])
                }
            },
                err => {
                    console.log("Error");
                    console.log(err)
                }
            );
        }
    }
}
