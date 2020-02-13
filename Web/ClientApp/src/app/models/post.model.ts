import {Tag} from './tag.model';

export class Post {
  public id: number;

  public createdAt: Date;

  public tags: Tag[];

  public width: number;

  public height: number;

  public previewFileUrl: string;

  public fileUrl: string;

  public sourceFileUrl: string;

  public artist: Tag;

  public copyright: string;

  public characters: Tag[];

}
