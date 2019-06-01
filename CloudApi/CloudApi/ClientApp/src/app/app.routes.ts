import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CallbackComponent } from './callback/callback.component';
import { AnimalsListComponent } from './animals-list/animals-list.component';
import { AnimalComponent } from './animal/animal.component';
import { MovieComponent } from './movie/movie.component';
import { CreateAnimalComponent } from './create-animal/create-animal.component';
import { movieListComponent } from './movieList/movieList.component';
import { AuthGuardService } from './services/auth-guard.service';
import { ScopeGuardService } from './services/scope-guard.service';
import { ProfileComponent } from './profile/profile.component';


export const ROUTES: Routes = [
        { path: '', component: HomeComponent },
  { path: 'callback', component: CallbackComponent },
  { path: 'profile', component: ProfileComponent,canActivate: [AuthGuardService]},
      { path: 'movies', component: movieListComponent },
      { path: 'movies/:id', component: MovieComponent },
  { path: 'animals', component: AnimalsListComponent, canActivate: [AuthGuardService ]},
  { path: 'animal/create', component: CreateAnimalComponent, canActivate: [AuthGuardService ]},
  { path: 'animal/:id', component: AnimalComponent, canActivate: [AuthGuardService ]}
];
