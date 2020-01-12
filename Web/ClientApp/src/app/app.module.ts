import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import {TagMenuComponent} from "./tag-menu/tag-menu.component";
import {PostsService} from "./services/images.service";
import {ImagePreviewComponent} from "./image-preview/image-preview.component";
import {ImageViewerComponent} from "./image-viewer/image-viewer.component";
import {TagComponent} from "./tag/tag.component";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    TagMenuComponent,
    FetchDataComponent,
    ImagePreviewComponent,
    ImageViewerComponent,
    TagComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'fetch-data', component: FetchDataComponent },
      {path: 'posts/:postId', component: ImageViewerComponent },
    ])
  ],
  providers: [
    PostsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
