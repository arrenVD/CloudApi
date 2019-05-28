import { Component, OnInit, SimpleChange } from '@angular/core';
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
    this.SelectedOption = "popularity";
    this.SelectedOrder = "asc";
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
  SelectedYear: number = 0;

  MoviesList: Result[];

  SearchMovies()
  {
    this.svc.getMoviesList(this.SelectedOption, this.SelectedOrder, this.CurrentPage, this.SelectedYear).subscribe((result) => {
      console.table(result);
      this.MoviesList = result.results
    })
  }

  //SORTEER FUNCTIONALITEIT
  // druk op top van tabel om te kiezen waar op te sorteren
  //druk een 2e keer op hetzelfde -> sorteerorde veranderen
  //nummber verandert ook sorteerorder
  SortOnVote()
  {
    if (this.SelectedOption == "vote_average") {
      this.ChangeOrder()
    }
    else {
        this.SelectedOption = "vote_average";
    }
    this.SearchMovies();
  }
  SortOnTitle() {
    if (this.SelectedOption == "original_title") {
      this.ChangeOrder()
    }
    else {
      this.SelectedOption = "original_title";
    }
    this.SearchMovies();
  }
  SortOnRelease() {
    if (this.SelectedOption == "release_date") {
      this.ChangeOrder()
    }
    else {
      this.SelectedOption = "release_date";
    }
    this.SearchMovies();
  }
  SortOnPopularity() {
    if (this.SelectedOption == "popularity") {
      this.ChangeOrder()
    }
    else {
      this.SelectedOption = "popularity";
    }
    this.SearchMovies();
  }
  ChangeOrder() {
    if (this.SelectedOrder == "asc") {
      this.SelectedOrder = "desc";
    }
    else {
      this.SelectedOrder = "asc"
    }
    this.SearchMovies();
  }
}



