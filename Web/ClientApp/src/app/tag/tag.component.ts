import {Component, Input, OnInit} from '@angular/core';
import {Tag} from '../models/tag.model';

@Component({
  selector: 'post-tag',
  templateUrl: './tag.component.html',
  styleUrls: ['./tag.component.css']
})
export class TagComponent implements OnInit {

  @Input()
  public tag: Tag;

  constructor() { }

  ngOnInit() {
  }

}
