import { Injectable } from '@angular/core';
import { MoviesService, IMovie, Result, IMovieFullList, Genre } from '../services/movies.service';

@Injectable()
export class DataService {

  constructor() { }
  Movie: IMovieFullList;
  SelectionsFamily: string[] = ["All", "Felidae", "Canidae", "Elephantidae"]
  SelectionsOrder: string[] = ["All", "Carnivora", "Proboscidea"]
  SelectionsStatus: string[] = ["All", "Domesticated", "Not Endangered", "Endangered", "Vulnerable"]
}

