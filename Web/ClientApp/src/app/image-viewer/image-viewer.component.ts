import {Component, OnInit} from "@angular/core";
import {ActivatedRoute} from "@angular/router";
import {PostsService} from "../services/images-service.service";
import {Post} from "../models/post.model";

@Component({
  selector: "app-image-viewer",
  templateUrl: "./image-viewer.component.html",
  styleUrls: ["./image-viewer.css"]
})
export class ImageViewerComponent implements OnInit{

  public postId: number;
  public post: Post;

  constructor(private route: ActivatedRoute,
  private postService: PostsService)
  {}


  ngOnInit(){
    this.route.paramMap.subscribe(params =>{
      this.postId = Number.parseInt(params.get("postId"));
      this.postService.getPost(this.postId).subscribe(post => {
        if (post === undefined || post === null) {
          console.error(`no post with id ${this.postId} were found`);
          return;
        }
        this.post = post;
      });
    });
  }

}
