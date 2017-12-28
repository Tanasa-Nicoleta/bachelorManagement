import { Bachelor } from "./bachelor-degree.model";

export class Student {
    constructor() { }
    Id: number;
    FirstName: string;
    LastName: string;
    Email: string;    
    Themes: Array<Bachelor>
}