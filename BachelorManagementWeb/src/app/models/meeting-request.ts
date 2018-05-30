export class MeetingRequest{
    constructor(studentEmail, teacherEmail, date) {
        this.StudentEmail = studentEmail;
        this.TeacherEmail = teacherEmail;
        this.Date = date;
    }

    StudentEmail: string;
    TeacherEmail: string;
    Date: Date;
}