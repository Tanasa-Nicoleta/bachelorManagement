export class Commit {
    constructor(message, date) {
        this.Message = message;
        this.Date = date;
    }
    Message: string;
    Date: Date;
}