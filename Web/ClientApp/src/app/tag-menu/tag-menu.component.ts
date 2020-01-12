import {Component, Input} from "@angular/core";
import {Tag} from "../models/tag.model";
import {range} from "rxjs";

@Component({
  selector: 'tag-menu',
  templateUrl: './tag-menu.component.html',
  styleUrls: ['./tag-menu.component.css']
  }
)
export class TagMenuComponent {

  @Input()
  public tags: Tag[] = [];

  constructor() {
   //range(0, 10).subscribe(res => this.tags.push(res));
  }
}
