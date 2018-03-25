export class Commit{
    constructor(message, date){
        this.message = message;
        this.date = date;
    }
    message: string;
    date: Date;
}