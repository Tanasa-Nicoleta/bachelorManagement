import { Bachelor } from "./bachelor-degree-description.model";

export class Student {
    constructor() { }
    Id: number;
    FirstName: string;
    LastName: string;
    Email: string;    
    Themes: Array<Bachelor>
}