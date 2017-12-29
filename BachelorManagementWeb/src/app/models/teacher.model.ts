import { Bachelor } from "./bachelor-degree.model";

export class Teacher {
    constructor() { }
    Id: number;
    FirstName: string;
    LastName: string;
    Email: string;
    NoOfSpots: number;
    NoOfAvailableSpots: number;
    ThemeTitles: string;
    Themes: Array<Bachelor>;
    Discipline: string;
    Grade: string;
}