import {Component, Input, OnInit} from '@angular/core';
import {PostsService} from "../services/images.service";
import {Post} from "../models/post.model";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'image-preview',
  templateUrl: './image-preview.component.html',
  styleUrls: ['./image-preview.css']
})
export class ImagePreviewComponent{

  @Input()
  public image: Post;

  constructor(private httpClient: HttpClient){

  }
}
