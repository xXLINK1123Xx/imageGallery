import {HttpClient} from "@angular/common/http";
import {Post} from "../models/post.model";
import {Injectable} from "@angular/core";
import {Observable} from "rxjs";

@Injectable()
export class PostsService{

  private wsn = "http://localhost:5000";

  constructor(private http : HttpClient) {

  }

  public getPosts(page: number, tags: string[]): Observable<Post[]> {
    return this.http.get<Post[]>(this.wsn + '/api/posts?page='+page);
  }

  public getPost(id: number): Observable<Post> {
    return this.http.get<Post>(this.wsn + '/api/posts/'+id);
  }

}
