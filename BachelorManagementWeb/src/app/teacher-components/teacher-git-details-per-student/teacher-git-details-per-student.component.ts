import { Component, OnInit } from '@angular/core';
import { Teacher } from '../../models/teacher.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { logging } from 'selenium-webdriver';
import { Language } from '../../models/language.model';
import { Commit } from '../../models/commit.model';
import { TitleService } from '../../services/title.service';
import { Title } from '@angular/platform-browser';
import { Repository } from '../../models/repository';
import { delay } from 'q';

@Component({
  selector: 'teacher-git-details-per-student',
  templateUrl: './teacher-git-details-per-student.component.html',
  styleUrls: ['../../app.component.scss', '../teacher.component.scss']
})

export class TeacherGitDetailsPerStudentComponent implements OnInit {
  p: number = 1;
  collection: any = ["1", "2", "3","1", "2", "3", "1", "2", "3", "1", "2", "3",  ];

  gitUserName: string = "Tanasa-Nicoleta";
  gitProjectName: string = "bachelorManagement";

  userData: Repository = new Repository(null, null);
  languagesData: any;
  commitsData: any;
  languagesArray: Language[] = [];
  commitsArray: Array<Commit> = new Array<Commit>();
  titleService: TitleService;

  languageChartLabels: string[] = [];
  languageChartData: number[] = [];
  languageChartType: string = 'doughnut';
  languageChartColors: Array<any> = [{ backgroundColor: ['rgba(127, 255, 212, 0.5)', 'rgba(107, 77, 194, 0.5)', 'rgba(0, 255, 255, 0.5)', 'rgba(253, 227, 167, 0.5)', 'rgba(111, 200, 206, 0.5)'] }];

  addChartData: number[] = [];
  delChartData: number[] = [];
  addAndDelChartData: Array<any> = [
    { data: this.addChartData, label: 'Additons' },
    { data: this.delChartData, label: 'Deletions' }
  ];
  addAndDelChartLabels: Array<any> = ['week 1', 'week 2', 'week 3', 'week 4', 'week 5', 'week 6', 'week 7', 'week 8', 'week 9', 'week 10'];
  addAndDelChartColors: Array<any> = [
    {
      backgroundColor: 'rgba(127, 255, 212, 0.5)',
      borderColor: 'rgba(148,159,177,1)',
      pointBackgroundColor: 'rgba(148,159,177,1)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(148,159,177,0.8)'
    },
    {
      backgroundColor: 'rgba(243, 71, 96, 0.5)',
      borderColor: 'rgba(77,83,96,1)',
      pointBackgroundColor: 'rgba(77,83,96,1)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(77,83,96,1)'
    }
  ];
  addAndDelChartLegend: boolean = true;
  addAndDelChartType: string = 'line';
  addAndDelChartOptions: any = {
    scales: {
      yAxes: [{
        id: 'y-axis-1', ticks: {
          min: 0,
          max: 160
        }}]
    }
  };

  constructor(private http: HttpClient, private title: Title) {
    this.titleService = new TitleService(title);
    this.titleService.setTitle("BDMApp Teacher Details Per Student");
  }

  public chartHovered(e: any): void {
    console.log(e);
  }

  ngOnInit() {
    this.getRepositoryData();
    this.getLanguagesData();
    this.getCommitData();
    this.getAdditonsAndDelletionPerWeek();
  };

  getRepositoryData() {

    var resp = this.http.get('https://api.github.com/users/' + this.gitUserName + '/repos', { observe: 'response' });

    resp.subscribe(
      data => {
        this.userData = new Repository(data.body[0]["name"], data.body[0]["html_url"]);
      },
      err => {
        console.log("Error");
        console.log(err)
      });
  }

  getLanguagesData() {
    var resp = this.http.get('https://api.github.com/repos/' + this.gitUserName + '/' + this.gitProjectName + '/languages ');

    resp.subscribe(
      data => {
        this.languagesData = data;
        this.iterateForLanguages();
      },
      err => {
        console.log("Error");
        console.log(err)
      });
  }

  getAdditonsAndDelletionPerWeek() {

    var resp = this.http.get('https://api.github.com/repos/' + this.gitUserName + '/' + this.gitProjectName + '/stats/code_frequency');

    resp.subscribe(
      data => {
        let i = 0;
        for (let key in data) {
          if (data[key] && i > 26) {
            this.addChartData.push(data[key][1] / 100);
            this.delChartData.push(data[key][2] * (-1) / 100);
          }
          i++;
        }
      },
      err => {
        console.log("Error");
        console.log(err)
      });
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

  iterateForLanguages() {
    for (var key in this.languagesData) {
      if (this.languagesData.hasOwnProperty(key)) {
        this.languagesArray.push(new Language(key, this.languagesData[key] / 1024 / 1024));
      }
    }
    this.languagesArray.forEach(l =>
      this.languageChartLabels.push(l.Name)
    );

    this.languagesArray.forEach(l =>
      this.languageChartData.push(l.Size)
    );
  }

  iterateForCommits() {
    for (var key in this.commitsData) {
      if (this.commitsData.hasOwnProperty(key)) {
        this.commitsArray.push(new Commit(this.commitsData[key].commit.message, new Date(this.commitsData[key].commit.author.date)));
      }
    }
  }

}


