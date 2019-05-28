import { Component, OnInit } from '@angular/core';
import { DataService } from '../services/data.service';
import { MoviesService, IMovie, Result } from '../services/movies.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
export class MovieComponent implements OnInit {

  constructor(private svcData: DataService, private router: Router, private svc: MoviesService, private activatedRoute: ActivatedRoute) { }

  URL: string;
  ngOnInit()
  {
    //this.Movie = this.svcData.Movie
    this.activatedRoute.params.subscribe(params => {
      if (typeof params['id'] !== 'undefined') {
        this.ID = params['id'];
      } else {
        this.ID = 0;
      }
    })
    this.svc.GetMovie(this.ID).subscribe((result => {
      this.Movie = result
    }))
  }
  Movie: Result;
  ID: number
}
