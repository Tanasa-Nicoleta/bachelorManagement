import { Bachelor } from "./bachelor-degree.model";
import { Mean } from "./mean.model";
import { Teacher } from "./teacher.model";
import { Achievement } from "./achievement.model";
import { debug } from "util";

export class Student {
    constructor(firstName, lastName, email, theme, gitUrl, startYear, serialNumber, means, achievement, accepted, denied) {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.Theme = theme;
        this.GitUrl = gitUrl;
        this.StartYear = startYear;
        this.SerialNumber = serialNumber;
        this.Means = means;
        this.Achievement = achievement;
        this.Accepted = accepted;
        this.Denied = denied;
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
    Achievement: string;
    Accepted: boolean;
    Denied: boolean;
}