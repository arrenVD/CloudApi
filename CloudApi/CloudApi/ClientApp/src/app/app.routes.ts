import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CallbackComponent } from './callback/callback.component';
import { AnimalsListComponent } from './animals-list/animals-list.component';
import { AnimalComponent } from './animal/animal.component';
import { MovieComponent } from './movie/movie.component';
import { CreateAnimalComponent } from './create-animal/create-animal.component';
import { movieListComponent } from './movieList/movieList.component';

export const ROUTES: Routes = [
        { path: '', component: HomeComponent },
      { path: 'callback', component: CallbackComponent },
      { path: 'movies', component: movieListComponent },
      { path: 'movies/:id', component: MovieComponent },
      { path: 'animals', component: AnimalsListComponent },
      { path: 'animal/create', component: CreateAnimalComponent },
      { path: 'animal/:id', component: AnimalComponent },
      { path: '**', redirectTo: '' }
];
