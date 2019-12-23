import { Component, OnInit } from '@angular/core';
import {PostsService} from "../services/images-service.service";
import {Post} from "../models/post.model";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.css']
})
export class HomeComponent{

  public images: Post[];
  public page: number = 1;

  constructor(private imageService: PostsService){
    this.imageService.getPosts(this.page, null).subscribe(data => {
      this.images = data;
      //console.log(this.images);
    });
  }


  public nextPage() {
    this.imageService.getPosts(++this.page, null).subscribe(data => this.images = data);
  }

  public prevPage() {
    if(--this.page < 1) {
      this.page = 1;
    }
    this.imageService.getPosts(this.page, null).subscribe(data => this.images = data);
  }
}
