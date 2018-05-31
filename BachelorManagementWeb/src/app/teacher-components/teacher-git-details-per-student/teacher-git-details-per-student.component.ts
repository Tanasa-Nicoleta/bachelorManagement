import { Component, OnInit } from '@angular/core';
import { Teacher } from '../../models/teacher.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { logging } from 'selenium-webdriver';
import { Language } from '../../models/language.model';
import { Commit } from '../../models/commit.model';
import { TitleService } from '../../services/title.service';
import { Title } from '@angular/platform-browser';
import { Repository } from '../../models/repository';

@Component({
  selector: 'teacher-git-details-per-student',
  templateUrl: './teacher-git-details-per-student.component.html',
  styleUrls: ['../../app.component.scss', '../teacher.component.scss']
})

export class TeacherGitDetailsPerStudentComponent implements OnInit {
  gitUserName: string = "Tanasa-Nicoleta";
  gitProjectName: string = "bachelorManagement";

  userData: Repository = new Repository(null, null);
  languagesData: any;
  commitsData: any;
  languagesArray: Language[] = [];
  commitsArray: Array<Commit> = new Array<Commit>();
  titleService: TitleService;

  constructor(private http: HttpClient, private title: Title) {
    this.titleService = new TitleService(title);
    this.titleService.setTitle("BDMApp Teacher Details Per Student");
  }

  ngOnInit() {
    this.getRepositoryData();
    this.getLanguagesData();
    this.getCommitData();
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
  }

  iterateForCommits() {
    for (var key in this.commitsData) {
      if (this.commitsData.hasOwnProperty(key)) {
        this.commitsArray.push(new Commit(this.commitsData[key].commit.message, new Date(this.commitsData[key].commit.author.date)));
      }
    }
  }

}


