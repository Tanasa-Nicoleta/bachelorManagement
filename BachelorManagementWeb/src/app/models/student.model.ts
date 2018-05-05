import { Bachelor } from "./bachelor-degree.model";
import { Mean } from "./mean.model";
import { Teacher } from "./teacher.model";

export class Student {
    constructor(firstName, lastName, email, theme, gitUrl, startYear, serialNumber, means) {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.Theme = theme;
        this.GitUrl = gitUrl;
        this.StartYear = startYear;
        this.SerialNumber = serialNumber;
        this.Means = means
    }
    Id: number;
    FirstName: string;
    LastName: string;
    Email: string;
    Theme: Bachelor;
    GitUrl: string;
    StartYear: number;
    SerialNumber: string;
    Means: Mean;
    TeacherName: string;
}