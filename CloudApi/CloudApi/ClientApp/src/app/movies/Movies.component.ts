import { Component, OnInit } from '@angular/core';
import { MoviesService, IMovie, Result } from '../services/movies.service';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css']
})
export class MoviesComponent implements OnInit
{
  constructor(private svc: MoviesService)
  {

  }

  ngOnInit()
  {

  }


  MoviesList: Result[];
}

