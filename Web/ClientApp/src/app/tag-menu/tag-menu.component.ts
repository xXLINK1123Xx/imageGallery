import {Component} from "@angular/core";
import {Tag} from "../models/Tag";
import {range} from "rxjs";

@Component({
  selector: 'tag-menu',
  templateUrl: './tag-menu.component.html',
  styleUrls: ['./tag-menu.component.css']
  }
)
export class TagMenuComponent {

  public tags: number[] = [];

  constructor() {
   range(0, 10).subscribe(res => this.tags.push(res));
  }
}
