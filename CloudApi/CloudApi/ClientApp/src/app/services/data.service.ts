import { Injectable } from '@angular/core';
import { MoviesService, IMovie, Result } from '../services/movies.service';

@Injectable()
export class DataService {

  constructor() { }
  Movie: Result;
}
