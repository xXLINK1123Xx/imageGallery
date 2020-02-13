import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {PostsService} from '../services/images.service';
import {Post} from '../models/post.model';
import {Title} from '@angular/platform-browser';

@Component({
  selector: 'app-image-viewer',
  templateUrl: './image-viewer.component.html',
  styleUrls: ['./image-viewer.css']
})
export class ImageViewerComponent implements OnInit {

  public postId: number;
  public post: Post;

  constructor(
    private route: ActivatedRoute,
    private postService: PostsService,
    private titleService: Title) {}


  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.postId = Number.parseInt(params.get('postId'));
      this.postService.getPost(this.postId).subscribe(post => {
        if (!post) {
          console.error(`no post with id ${this.postId} were found`);
          return;
        }
        console.log(post);
        this.post = post;
        this.setTitle();
      });
    });
  }

  private setTitle(): void {
    let title = '';
    if (this.post.characters && this.post.characters.length > 0) {
      title += this.post.characters.map<string>(c => c.name).join(', ');
    }
    if (this.post.copyright) {
      title += this.post.copyright.replace('_', ' ');
    }
    if (this.post.artist) {
      title += ` by ${this.post.artist.name.replace('_', ' ')}`;
    }

    this.titleService.setTitle(title);

  }

}
