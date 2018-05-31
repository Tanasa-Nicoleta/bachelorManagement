import { Month } from "./month.model";

export class DateClass {
    constructor(day, month, year, hour) {
        this.Day = day;
        this.Month = month;
        this.Year = year;
        this.Hour = hour;
    }
    Day: number;
    Month: Month;
    Year: number;
    Hour: string;
}