import { Month } from "./month.model";

export class DateClass{
    constructor(day, month, year, hour){
        this.day = day;
        this.month = month;
        this.year = year;
        this.hour = hour;
    }
    day: number;
    month: Month;
    year: number;
    hour: string;
}