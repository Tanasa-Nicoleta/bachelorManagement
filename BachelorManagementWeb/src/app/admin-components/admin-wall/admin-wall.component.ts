import { Component } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { HttpClient } from '@angular/common/http';
import { Teacher } from '../../models/teacher.model';
import { TitleService } from '../../services/title.service';
import { Bachelor } from '../../models/bachelor-degree.model';

@Component({
    selector: 'admin-wall',
    templateUrl: './admin-wall.component.html',
    styleUrls: ['../../app.component.scss', '../../student-components/student.component.scss', '../../teacher-components/teacher.component.scss']
})

export class AdminWallComponent {
    deleteText: string = "Remove";
    editText: string = "Edit";
    addTeacherText: string = "Add new record";
    submitText: string = "Submit";
    showAddTeacherButton: boolean = true;
    showAddTeacherForm: boolean = false;
    showEditTeacherForm: boolean = false;

    titleService: TitleService;
    teacherList: Array<Teacher> = new Array<Teacher>();
    teacher: Teacher = new Teacher(null, null, null, null, null, null, null, null, null);

    removeTeacherBody: {
        Email: string
    }

    teacherBody: {
        Email: string;
        FirstName: string;
        LastName: string;
        Discipline: string;
        JobTitle: string;
        NumberOfSpots: number;
    }

    constructor(private title: Title, private http: HttpClient) {
        this.titleService = new TitleService(title);
        this.titleService.setTitle("BDMApp Admin wall");
    }

    ngOnInit() {
        this.getTeachers();
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
                    }
                }
            },
            err => {
                console.log("Error");
                console.log(err)
            }
        );
    }

    enableTeacherForm() {
        this.showAddTeacherButton = false;
        this.showAddTeacherForm = true;
    }

    addNewRecord(email: string, fName: string, lName: string, discipline: string, numberOfSpots: number, grade: string) {
        this.showAddTeacherButton = true;
        this.showAddTeacherForm = false;

        this.teacherBody = {
            Email: email,
            FirstName: fName,
            LastName: lName,
            Discipline: discipline,
            NumberOfSpots: numberOfSpots,
            JobTitle: grade
        };

        const resp = this.http.post('http://localhost:64250/api/admin/addTeacher', this.teacherBody, { responseType: 'text' });

        resp.subscribe(
            data => {
                window.location.reload();
            },
            err => {
                console.log("Error");
                console.log(err)
            });
    }

    removeTeacher(teacherEmail: string) {
        this.removeTeacherBody = {
            Email: teacherEmail
        };

        const resp = this.http.post('http://localhost:64250/api/admin/removeTeacher', this.removeTeacherBody, { responseType: 'text' });

        resp.subscribe(
            data => {
                window.location.reload();
            },
            err => {
                console.log("Error");
                console.log(err)
            });
    }

    editTeacher(email: string, fName: string, lName: string, discipline: string, numberOfSpots: number, grade: string) {
        this.teacher = new Teacher(fName, lName, email, numberOfSpots, null, null, discipline, grade, null);

        this.showEditTeacherForm = true;
        this.showAddTeacherButton = false;
    }

    editRecord(email: string, fName: string, lName: string, discipline: string, numberOfSpots: number, grade: string) {
        this.showEditTeacherForm = false;
        this.showAddTeacherForm = false;
        this.showAddTeacherButton = true;

        this.teacherBody = {
            Email: email,
            FirstName: fName,
            LastName: lName,
            Discipline: discipline,
            NumberOfSpots: numberOfSpots,
            JobTitle: grade
        };

        const resp = this.http.put('http://localhost:64250/api/admin/editTeacher', this.teacherBody, { responseType: 'text' });

        resp.subscribe(
            data => {
                window.location.reload();
            },
            err => {
                console.log("Error");
                console.log(err)
            });

    }
}

