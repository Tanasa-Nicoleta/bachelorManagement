import { Component } from '@angular/core';
import { Teacher } from '../../models/teacher.model';
import { Bachelor } from '../../models/bachelor-degree.model';
import { TitleService } from '../../services/title.service';
import { Title } from '@angular/platform-browser';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'student-register-details',
    templateUrl: './student-register-details.component.html',
    styleUrls: ['../../app.component.scss', '../student.component.scss', './student-register-details.component.scss']
})


export class StudentRegisterToTeacherDetailsComponent {

    buttonText: string = "Subimt";

    //api  call for the teachers list
    teacherList: Array<Teacher>;
    teacher1: Teacher;
    teacher2: Teacher;
    theme1: Bachelor;
    theme2: Bachelor;
    theme3: Bachelor;

    titleService: TitleService;

    constructor(private title: Title, private http: HttpClient) {
        this.titleService = new TitleService(title);
        this.titleService.setTitle("BDMApp Student Register To Teacher Details");
    }

    ngOnInit() {        
        
        const themeResponse = this.http.get('http://localhost:64250/api/teacher', {observe: 'response'});
        
        themeResponse.subscribe(      
              data => {      
                  console.log(data.body)
                  console.log(data.body[0]['firstName']);                  
                this.teacher1 = new Teacher(data.body[0]['firstName'], data.body[0]['lastName'], "", 3, 2, "", [this.theme1, this.theme2], "Discipline1", "Prof", "");
              },
              err => {
                console.log("Error");
                console.log(err)                  
              }
            );

        this.theme1 = new Bachelor("Theme1", "Description1 for Theme1");
        this.theme2 = new Bachelor("Theme2", "Description2 for Theme 2 and some random extra text");
        this.theme3 = new Bachelor("Theme3", "Description3 and other random text just for the text to align");

        const teacherResponse = this.http.get('http://localhost:64250/api/teacher', {observe: 'response'});
        
        teacherResponse.subscribe(      
              data => {      
                  console.log(data.body)
                  console.log(data.body[0]['firstName']);                  
                this.teacher1 = new Teacher(data.body[0]['firstName'], data.body[0]['lastName'], "", 3, 2, "", [this.theme1, this.theme2], "Discipline1", "Prof", "");
              },
              err => {
                console.log("Error");
                console.log(err)                  
              }
            );

        this.teacher2 = new Teacher("Ioana", "Pascu", "", 12, 11, "", [this.theme3], "Discipline2", "Prof Doctor", "");

        this.teacherList = [this.teacher1, this.teacher2];
    }

    applyToTeacherWithDetails(title: string, description: string, achievement: string) {
        console.log(title + " " + description + " " + achievement);
        //api call for applying to a teacher
    }
}
