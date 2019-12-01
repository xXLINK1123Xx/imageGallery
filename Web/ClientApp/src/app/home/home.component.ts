import { Component, OnInit } from '@angular/core';
import {ImagesService} from "../services/images-service.service";
import {Image} from "../models/Image";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.css']
})
export class HomeComponent{

  public images: Image[];
  public page: number = 1;

  constructor(private imageService: ImagesService){
    this.imageService.getImages(this.page, null).subscribe(data => {
      this.images = data;
      console.log(this.images);
    });
  }


  public nextPage() {
    this.imageService.getImages(++this.page, null).subscribe(data => this.images = data);
  }

  public prevPage() {
    if(--this.page < 1) {
      this.page = 1;
    }
    this.imageService.getImages(this.page, null).subscribe(data => this.images = data);
  }
}
