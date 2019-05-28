import { Injectable } from '@angular/core';
import { MoviesService, IMovie, Result, IMovieFullList, Genre } from '../services/movies.service';

@Injectable()
export class DataService {

  constructor() { }
  Movie: IMovieFullList;
}
