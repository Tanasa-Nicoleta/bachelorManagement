import { Bachelor } from "./bachelor-degree.model";

export class Teacher {
    constructor(firstName, lastName, email, noOfSpots, noOfAvailableSpots, theme, discipline, grade, requirement) {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.NoOfSpots = noOfSpots;
        this.NoOfAvailableSpots = noOfAvailableSpots;
        this.Theme = theme;
        this.Discipline = discipline
        this.Grade = grade;
        this.Requirement = requirement;
    }
    FirstName: string;
    LastName: string;
    Email: string;
    NoOfSpots: number;
    NoOfAvailableSpots: number;
    Theme: Bachelor;
    Discipline: string;
    Grade: string;
    Requirement: string;
}