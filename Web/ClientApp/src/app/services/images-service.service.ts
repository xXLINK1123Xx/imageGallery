import {HttpClient} from "@angular/common/http";
import {Image} from "../models/Image";
import {Injectable} from "@angular/core";
import {Observable} from "rxjs";

@Injectable()
export class ImagesService{
  constructor(private http : HttpClient) {

  }

  public getImages(page: number, tags: string[]): Observable<Image[]> {
    return this.http.get<Image[]>('/images?page='+page);
  }
}
