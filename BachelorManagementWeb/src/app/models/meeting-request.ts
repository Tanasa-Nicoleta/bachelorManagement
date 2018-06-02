export class MeetingRequest {
    constructor(studentEmail, teacherEmail, date, accepted, declined) {
        this.StudentEmail = studentEmail;
        this.TeacherEmail = teacherEmail;
        this.Date = date;
        this.Accepted = accepted;
        this.Declined = declined;
    }
    StudentEmail: string;
    TeacherEmail: string;
    Date: Date;
    Accepted: boolean;
    Declined: boolean;
}