import { Component, OnInit } from '@angular/core';
import {PostsService} from "../services/images.service";
import {Post} from "../models/post.model";
import {Tag} from "../models/tag.model";
import {filter, flatMap, take} from "rxjs/operators";
import {from} from "rxjs";
import {Title} from "@angular/platform-browser";
import {ActivatedRoute, Router} from "@angular/router";

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
              private titleService: Title,
              private route: ActivatedRoute,
              private router: Router,) {}


  public changePage(newPage : number) {

    this.router.navigate(['../../posts', newPage],{relativeTo: this.route, skipLocationChange: false})
      .then(res => this.page = newPage);
  }


  ngOnInit(): void {
    this.titleService.setTitle(this.title);

    this.route.paramMap.subscribe(params => {

      this.page = Number.parseInt(params.get("page")) | this.page;
      console.log(`page: ${params.get("page")}`);

      this.imageService.getPosts(this.page, null).subscribe(data => {
        this.images = data;
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
    });
  }
}
