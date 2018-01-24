import { DateClass } from "./date.model";
import { timeout } from "q";

export class TeacherObservation{
    constructor(obs, timestamp){
        this.observation = obs;
        this.timestamp = timestamp;
    }

    observation: string;
    timestamp: DateClass;
}