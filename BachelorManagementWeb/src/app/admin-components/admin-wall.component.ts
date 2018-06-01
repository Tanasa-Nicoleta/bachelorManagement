import { Component } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { HttpClient } from '@angular/common/http';
import { Teacher } from '../models/teacher.model';
import { TitleService } from '../services/title.service';
import { Bachelor } from '../models/bachelor-degree.model';

@Component({
    selector: 'admin-wall',
    templateUrl: './admin-wall.component.html',
    styleUrls: ['../app.component.scss', '../student-components/student.component.scss', '../teacher-components/teacher.component.scss']
})

export class AdminWallComponent {
    deleteText: string = "Remove";
    editText: string = "Edit";
    addTeacherText: string = "Add new record";
    submitText: string = "Submit";
    showAddTeacherButton: boolean = true;
    showAddTeacherForm: boolean = false;

    titleService: TitleService;
    teacherList: Array<Teacher> = new Array<Teacher>();


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

    addNewRecord(){        
        this.showAddTeacherButton = true;
        this.showAddTeacherForm = false;
    }
}
