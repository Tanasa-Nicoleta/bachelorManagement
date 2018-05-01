import { Bachelor } from "./bachelor-degree.model";

export class Teacher {
    constructor(firstName, lastName, email, noOfSpots, noOfAvailableSpots, themes, discipline, grade, requirement) {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.NoOfSpots = noOfSpots;
        this.NoOfAvailableSpots = noOfAvailableSpots;
        this.Themes = themes;
        this.Discipline = discipline
        this.Grade = grade;
        this.Requirement = requirement;
    }
    Id: number;
    FirstName: string;
    LastName: string;
    Email: string;
    NoOfSpots: number;
    NoOfAvailableSpots: number;
    Themes: Array<Bachelor>;
    Discipline: string;
    Grade: string;
    Requirement: string;
}