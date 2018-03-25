import { Component, OnInit } from '@angular/core';
import { Teacher } from '../../models/teacher.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { logging } from 'selenium-webdriver';
import { Language } from '../../models/language.model';
import { Commit } from '../../models/commit.model';

@Component({
  selector: 'teacher-git-details-per-student',
  templateUrl: './teacher-git-details-per-student.component.html',
  styleUrls: ['../../app.component.scss', '../teacher.component.scss']
})


export class TeacherGitDetailsPerStudentComponent implements OnInit {
  gitUserName: string = "Tanasa-Nicoleta";
  gitProjectName: string = "bachelorManagement";

  userData: any;
  languagesData: any;
  commitsData: any;
  errorData: any;

  languagesArray: Language[] = [];
  commitsArray: Commit[] = []

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getRepositoryData();
    this.getLanguagesData();
    this.getCommitData();
  };

  getRepositoryData() {
    var resp = this.http.get('https://api.github.com/users/' + this.gitUserName + '/repos');

    resp.subscribe(
      data => {
        this.userData = data;
      },
      err => {
        this.errorData = err;
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
        this.errorData = err;
      });
  }

  getCommitData(){
    var resp = this.http.get('https://api.github.com/repos/' + this.gitUserName + '/' + this.gitProjectName + '/commits ');
  resp.subscribe(
    data => {
      this.commitsData = data;
      this.iterateForCommits();
    },
    err => {
      this.errorData = err;
    });
  }

  iterateForLanguages() {
    for (var key in this.languagesData) {
      if (this.languagesData.hasOwnProperty(key)) {
        this.languagesArray.push(new Language(key, this.languagesData[key] / 1024 / 1024));
      }
    }
  }

  iterateForCommits(){
    for (var key in this.commitsData) {
      if (this.commitsData.hasOwnProperty(key)) {
        this.commitsArray.push(new Commit(this.commitsData.commit.commit, this.commitsData.commit.author.date));
      }
    }
  }

  convertDate(date: Date){
  }

}


