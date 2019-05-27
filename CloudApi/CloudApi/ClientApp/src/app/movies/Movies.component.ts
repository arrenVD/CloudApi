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
    this.Options = ["Popularity","Vote average", "Release date"]
    this.SelectedOption = "Popularity";
    this.Order = ["Ascending", "Descending"]
    this.SelectedOrder = "Ascending";
    this.Pages = Array(100).fill(1).map((x, i) => i)
    this.CurrentPage = 1;
  }

  ngOnInit()
  {
    this.SearchMovies();
  }
  CurrentPage: number;
  Pages: Number[];
  Options: string[];
  Order: string[];
  SelectedOrder: string;
  SelectedOption: string;
  MoviesList: Result[];
  SelectedYear: number = 0;

  SearchMovies()
  {
    this.svc.getMoviesList(this.SelectedOption, this.SelectedOrder, this.CurrentPage, this.SelectedYear).subscribe((result) => {
      console.table(result);

    })
  }
}


