import { DateClass } from "./date.model";

export class Comment {
    constructor(name, content, timestamp) {
        this.name = name;
        this.content = content;
        this.timestamp = timestamp;
    }
    name: string;
    content: string;
    timestamp: DateClass
}