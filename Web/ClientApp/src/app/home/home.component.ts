import { Component, OnInit } from '@angular/core';
import {PostsService} from "../services/images.service";
import {Post} from "../models/post.model";
import {Tag} from "../models/tag.model";
import {filter, flatMap, take} from "rxjs/operators";
import {from} from "rxjs";
import {Title} from "@angular/platform-browser";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.css']
})
export class HomeComponent implements OnInit{

  public title: string = 'Image Gallery';
  public images: Post[];
  public availableTags: Tag[] = [];
  public page: number = 1;

  constructor(private imageService: PostsService,
              private titleService: Title) {}


  public changePage(newPage : number) {
    this.page = newPage;
    this.imageService.getPosts(this.page, null).subscribe(data => this.images = data);
  }


  ngOnInit(): void {
    this.titleService.setTitle(this.title);
    this.imageService.getPosts(this.page, null).subscribe(data => {
      this.images = data;
      console.log(this.images);


      from(this.images).pipe(
        flatMap( img => img.tags),
        filter(t => t.name !== '' && t.name !== '/\\/\\/\\'),
        take(20)
      ).subscribe( t => {
        if(this.availableTags.indexOf(t) === -1)
          this.availableTags.push(t);
        this.availableTags = this.availableTags.sort((a, b) => a.name.localeCompare(b.name));
      });
    });
  }
}
