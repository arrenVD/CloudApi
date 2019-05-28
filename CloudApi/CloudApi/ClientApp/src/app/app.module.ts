import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { MoviesService } from './services/movies.service';
import { MoviesComponent } from './movies/Movies.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MovieComponent } from './movie/movie.component';
import { DataService } from './services/data.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    MoviesComponent,
    MovieComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'movies', component: MoviesComponent },
      { path: 'movies/:id', component: MovieComponent },
    ])
  ],
  providers: [
    MoviesService,
    DataService

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
