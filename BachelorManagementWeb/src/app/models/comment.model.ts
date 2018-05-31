import { DateClass } from "./date.model";

export class Comment {
    constructor(name, content, timestamp) {
        this.Name = name;
        this.Content = content;
        this.Timestamp = timestamp;
    }
    Name: string;
    Content: string;
    Timestamp: DateClass
}