import { Component, OnInit, SimpleChange } from '@angular/core';
import { MoviesService, IMovie, Result, Genre, IMovieFullList } from '../services/movies.service';
import { DataService } from '../services/data.service';

@Component({
  selector: 'app-movies',
  templateUrl: './MovieList.component.html',
  styleUrls: ['./MovieList.component.css']
})
export class movieListComponent implements OnInit {
  constructor(private svc: MoviesService, private dataSvc: DataService) {
    this.SelectedOption = "popularity";
    this.SelectedOrder = "desc";
    this.Pages = Array(100).fill(1).map((x, i) => i)
    this.CurrentPage = 1;
  }

  ngOnInit() {
    this.SearchMovies();
  }
  CurrentPage: number;
  Pages: Number[];
  Options: string[];
  Order: string[];
  SelectedOrder: string;
  SelectedOption: string;
  SelectedYear: number = 0;
  ItemsPerPage: number = 20
  MoviesList: Result[];
  TotalPages: number = 1;
  TotalItems: number = 0;
  CurrentSelection: string = "All";
  Selections: string[] = ["Upcoming", "Now Playing", "All"]
  PreviousSelection: string = "All"
  CurrentKeyWord: string = "";
  SearchQuery: string = "";
  SearchMovies() {
    if (this.SearchQuery == "" || Number(this.CurrentKeyWord)) {
      if (this.CurrentSelection == "Upcoming") {
        this.svc.GetUpcoming(this.CurrentPage).subscribe((result => {
          this.MoviesList = result.results
          this.TotalItems = result.total_results;
          if (result.total_pages < 500) {
            this.Pages = Array(result.total_pages).fill(1).map((x, i) => i + 1)
          }
          else {
            this.Pages = Array(500).fill(1).map((x, i) => i + 1)
          }
        }))
      }
      else if (this.CurrentSelection == "Now Playing") {
        this.svc.GetLatest(this.CurrentPage).subscribe((result => {
          this.MoviesList = result.results
          this.TotalItems = result.total_results;
          if (result.total_pages < 500) {
            this.Pages = Array(result.total_pages).fill(1).map((x, i) => i + 1)
          }
          else {
            this.Pages = Array(500).fill(1).map((x, i) => i + 1)
          }
        }))
      }
      else {
        this.svc.getMoviesList(this.SelectedOption, this.SelectedOrder, this.CurrentPage, this.SelectedYear).subscribe((result) => {
          console.table(result);
          this.MoviesList = result.results
          this.TotalItems = result.total_results;
          if (result.total_pages < 500) {
            this.Pages = Array(result.total_pages).fill(1).map((x, i) => i + 1)
          }
          else {
            this.Pages = Array(500).fill(1).map((x, i) => i + 1)
          }
        })
      }
    }
    else {
      this.svc.SearchQuery(this.CurrentPage, this.SearchQuery).subscribe((result) => {
        console.table(result);
        this.MoviesList = result.results
        this.TotalItems = result.total_results;
        if (result.total_pages < 500) {
          this.Pages = Array(result.total_pages).fill(1).map((x, i) => i + 1)
        }
        else {
          this.Pages = Array(500).fill(1).map((x, i) => i + 1)
        }
      })

    }
}

  SearchInput() {
  if (Number(this.CurrentKeyWord)) {
    this.SelectedYear = Number(this.CurrentKeyWord)
  }
  else {
    this.SearchQuery = this.CurrentKeyWord
    }
  this.CurrentSelection = "All"
  this.SearchMovies()
  }
  GetMovie(movie: IMovieFullList)
{
  this.dataSvc.Movie = movie;
}
ChangeSelection() {
  this.CurrentPage = 1
  this.SearchQuery = ""
  this.CurrentKeyWord = ""
  this.SearchMovies()
}
//SORTEER FUNCTIONALITEIT
// druk op top van tabel om te kiezen waar op te sorteren
//druk een 2e keer op hetzelfde -> sorteerorde veranderen
//nummber verandert ook sorteerorder
//Titel doet raar... is ook original_title, title was er niet
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

