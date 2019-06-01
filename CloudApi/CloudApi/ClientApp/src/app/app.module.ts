import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { MoviesService } from './services/movies.service';
import { movieListComponent } from './movieList/movieList.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MovieComponent } from './movie/movie.component';
import { DataService } from './services/data.service';
import { AnimalsListComponent } from './animals-list/animals-list.component';
import { AnimalComponent } from './animal/animal.component';
import { AnimalsService } from './services/animals.service';
import { CreateAnimalComponent } from './create-animal/create-animal.component';
import { LoginComponent } from './login/login.component';
import { environment } from '../environments/environment';
import { AuthService } from './services/auth.service';
import { CallbackComponent } from './callback/callback.component';
import { ROUTES } from './app.routes';
import { HttpModule } from '@angular/http';
import { AuthGuardService } from './services/auth-guard.service';
import { ScopeGuardService } from './services/scope-guard.service';
import { ProfileComponent } from './profile/profile.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    movieListComponent,
    MovieComponent,
    AnimalsListComponent,
    AnimalComponent,
    CreateAnimalComponent,
    LoginComponent,
    CallbackComponent,
    ProfileComponent

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    BrowserAnimationsModule,
    HttpModule,
    FormsModule,
    RouterModule.forRoot(ROUTES)
  ],
  providers: [
    MoviesService,
    DataService,
    AnimalsService,
    AuthService,
    AuthGuardService,
    ScopeGuardService

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
