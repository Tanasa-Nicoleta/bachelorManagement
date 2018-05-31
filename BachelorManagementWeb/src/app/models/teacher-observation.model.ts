import { DateClass } from "./date.model";
import { timeout } from "q";

export class TeacherObservation {
    constructor(obs, timestamp, id) {
        this.Observation = obs;
        this.Timestamp = timestamp;
        this.Id = id;
    }
    Id: number;
    Observation: string;
    Timestamp: DateClass;
}