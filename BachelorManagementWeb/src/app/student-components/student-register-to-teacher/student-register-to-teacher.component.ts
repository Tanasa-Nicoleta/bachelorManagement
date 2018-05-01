import { Component } from '@angular/core';
import { Teacher } from '../../models/teacher.model';
import { Bachelor } from '../../models/bachelor-degree.model';
import { TitleService } from '../../services/title.service';
import { Title } from '@angular/platform-browser';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'student-register-to-teacher',
    templateUrl: './student-register-to-teacher.component.html',
    styleUrls: ['../../app.component.scss', '../student.component.scss']
})


export class StudentRegisterToTeacherComponent {
    optionText: string = "Next step";

    //api  call for the teachers list
    teacherList: Array<Teacher> = new Array<Teacher>();
    teacher1: Teacher;
    teacher2: Teacher;
    theme1: Bachelor;
    theme2: Bachelor;
    theme3: Bachelor;

    titleService: TitleService;

    constructor(private title: Title, private http: HttpClient) {
        this.titleService = new TitleService(title);
        this.titleService.setTitle("BDMApp Student Register To Teacher");
    }
    
    ngOnInit() {

                
        const themeResponse = this.http.get('http://localhost:64250/api/teacher', {observe: 'response'});
        
        themeResponse.subscribe(      
              data => {      
                data.body  
                for(let key in data.body){
                    if(data.body.hasOwnProperty(key))
                    {                    
                    this.teacherList.push(new Teacher(data.body[key]['firstName'], data.body[key]['lastName'], 
                      data.body[key]['email'], data.body[key]['numberOfSpots'], data.body[key]['numberOfAvailableSpots'], "'title'",
                      null, data.body[key]['discipline'], data.body[key]['jobTitle'], data.body[key]['requirement']));
                    }
                }
              },
              err => {
                console.log("Error");
                console.log(err)                  
              }
            );

         

        this.theme1 = new Bachelor("Theme1", "Description1 for Theme1");
        this.theme2 = new Bachelor("Theme2", "Description2 for Theme 2 and some random extra text");
        this.theme3 = new Bachelor("Theme3", "Description3 and other random text just for the text to align");
    }

    applyToTeacher(teacherFirstName: string, teacherLastName: string) {
        console.log(teacherFirstName + " " + teacherLastName);
        //send those to the next file
    }
}