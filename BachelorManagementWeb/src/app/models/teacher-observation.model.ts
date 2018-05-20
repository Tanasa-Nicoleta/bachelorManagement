import { DateClass } from "./date.model";
import { timeout } from "q";

export class TeacherObservation {
    constructor(obs, timestamp, id) {
        this.observation = obs;
        this.timestamp = timestamp;
        this.id = id;
    }
    id: number;
    observation: string;
    timestamp: DateClass;
}