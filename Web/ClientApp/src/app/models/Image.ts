import {Tag} from "./Tag";

export class Image {
  public id: number;

  public createdAt: Date;

  public tags: Tag[];

  public width: number;

  public height: number;

  public previewFileUrl: string;

  public fileUrl : string;

  public sourceFileUrl: string;

  public artist: string;

  public copyright :string;

  public characters: string[];

}
