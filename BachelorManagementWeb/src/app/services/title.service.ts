import { Title } from "@angular/platform-browser";

export class TitleService {

    constructor(private titleService: Title) { }

    public setTitle(title: string) {
        this.titleService.setTitle(title);
    }
}