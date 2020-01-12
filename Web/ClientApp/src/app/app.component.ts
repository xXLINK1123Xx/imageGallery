import { Component } from '@angular/core';
import {Title} from "@angular/platform-browser";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'Image Gallery';
  constructor(titleService: Title) {
    titleService.setTitle(this.title);
  }
}
