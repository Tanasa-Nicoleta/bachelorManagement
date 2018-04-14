import { Bachelor } from "./bachelor-degree.model";

export class Student {
    constructor(firstName, lastName, email, theme) {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.Theme = theme
    }
    Id: number;
    FirstName: string;
    LastName: string;
    Email: string;
    Theme: Bachelor
}