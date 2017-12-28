import { Bachelor } from "./bachelor-degree-description.model";

export class Teacher {
    constructor() { }
    Id: number;
    FirstName: string;
    LastName: string;
    Email: string;
    NoOfSpots: number;
    NoOfAvailableSpots: number;
    ThemeTitles: string;
    Themes: Array<Bachelor>
}