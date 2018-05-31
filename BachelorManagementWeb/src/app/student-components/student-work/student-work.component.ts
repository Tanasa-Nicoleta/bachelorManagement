import { Component } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { TitleService } from '../../services/title.service';
import { HttpClient } from '@angular/common/http';
import { Student } from '../../models/student.model';
import { Bachelor } from '../../models/bachelor-degree.model';

@Component({
    selector: 'student-work',
    templateUrl: './student-work.component.html',
    styleUrls: ['../../app.component.scss']
})

export class StudentWorkComponent {
    titleService: TitleService;
    dueDate: Date = new Date(2018, 6, 15);
    teacherEmail: string = "vlad.simion@info.uaic.ro";
    students: Array<Student> = new Array<Student>();

    constructor(private title: Title, private http: HttpClient) {
        this.titleService = new TitleService(title);
        this.titleService.setTitle("BDMApp Student Work");
    }

    ngOnInit() {
        this.getTeacherStudents(this.teacherEmail);
    }

    getTeacherStudents(email: string) {
        const teacherResponse = this.http.get('http://localhost:64250/api/teacher/students/' + email, { observe: 'response' });

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
                console.log("Error");
                console.log(err)
            }
        );
    }

    setBachelorThemeToStudents(email: string, key: string) {
        const themeResponse = this.http.get('http://localhost:64250/api/student/themes/' + email, { observe: 'response' });
        themeResponse.subscribe(
            data => {
                this.students[key]['Theme'] = new Bachelor(data.body['title'], data.body['description']);
            },
            err => {
                console.log("Error");
                console.log(err)
            }
        );
    }
}