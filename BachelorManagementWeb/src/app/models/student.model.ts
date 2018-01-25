import { Bachelor } from "./bachelor-degree.model";

export class Student {
    constructor(firstName, lastName, email, themes) {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.Themes = themes;
     }
    Id: number;
    FirstName: string;
    LastName: string;
    Email: string;    
    Themes: Array<Bachelor>
}