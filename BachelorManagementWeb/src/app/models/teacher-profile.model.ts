import { Bachelor } from "./bachelor-degree.model";
import { Student } from "./student.model";
import { DayOfWeek } from "./day-of-week.model";

export class TeacherProfile {
    constructor(firstName, lastName, email, theme, grade, requirement, student) {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.Theme = theme;
        this.Grade = grade;
        this.Requirement = requirement;
        this.Student = student;
    }
    FirstName: string;
    LastName: string;
    Email: string;
    Theme: Array<Bachelor>;
    Grade: string;
    Requirement: string;
    Student: Array<Student>;
    ConsultationDay: string;
    ConsultationInterval: string;
}