import { Component, OnInit } from '@angular/core';
import { DataService } from '../services/data.service';
import { MoviesService, IMovie, Result, IMovieFullList, Genre } from '../services/movies.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
export class MovieComponent implements OnInit {

  constructor(private svcData: DataService, private router: Router, private svc: MoviesService, private activatedRoute: ActivatedRoute)
  {
  }
  Genres: Genre[];
  url: string;
  url_imgRoot: string = "http://image.tmdb.org/t/p/w185/"
  ngOnInit()
  {
    //this.Movie = this.svcData.Movie
    this.activatedRoute.params.subscribe(params => {
      if (typeof params['id'] !== 'undefined') {
        this.ID = params['id'];
      } else {
        this.ID = 2;
      }
    })

    this.svc.GetMovie(this.ID).subscribe((result => {
      this.Movie = result

      this.Genres = result.genres

    }))
    //this.url = `${this.url_imgRoot}${this.Movie.poster_path}`
  }
  Movie: IMovieFullList;
  ID: number
}
export interface Genre {
  id: number;
  name: string;
}
