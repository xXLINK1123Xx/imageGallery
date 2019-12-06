import {Component, Input, OnInit} from '@angular/core';
import {ImagesService} from "../services/images-service.service";
import {Image} from "../models/Image";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'image-preview',
  templateUrl: './image-preview.component.html',
  styleUrls: ['./image-preview.css']
})
export class ImagePreviewComponent{

  @Input()
  public image: Image;

  public kekLol : string;

  constructor(private httpClient: HttpClient){

  }

  public getImageData(){
    this.httpClient.get(this.image.fileUrl).subscribe(data => console.log(data));
  }
}
