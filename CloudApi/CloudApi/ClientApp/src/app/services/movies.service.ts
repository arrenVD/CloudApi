import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class MoviesService {
  constructor(private http: HttpClient) {

  }


  private APIKey: string = "918a26f4ecb6651e662a45c7190354e7";
  private APIVersion: number = 3;
  private movieDB_URL = "https://api.themoviedb.org";

  getMoviesList(SortBy: string, Order: string, Page: Number, Year: Number) {

    console.log(`${this.movieDB_URL}/${this.APIVersion}/discover/movie?api_key=${this.APIKey}&language=en-US&sort_by=${SortBy}.${Order}&include_adult=false&include_video=false&page=${Page}&primary_release_year=${Year}`)
    return this.http.get<IMovie>(`${this.movieDB_URL}/${this.APIVersion}/discover/movie?api_key=${this.APIKey}&language=en-US&sort_by=${SortBy}.${Order}&include_adult=false&include_video=false&page=${Page}&primary_release_year=${Year}`);
  }
  GetMovie(ID: Number)
  {
    return this.http.get<Result>(`${this.movieDB_URL}/${this.APIVersion}/movie/${ID}?api_key=${this.APIKey}`);
  }
  GetUpcoming(Page: number) {
    return this.http.get<IMovie>(`${this.movieDB_URL}/${this.APIVersion}/movie/upcoming?api_key=${this.APIKey}&language=en-US&page=${Page}`);
  }
  GetLatest(Page: number) {
    return this.http.get<IMovie>(`${this.movieDB_URL}/${this.APIVersion}/movie/now_playing?api_key=${this.APIKey}&language=en-US&page=${Page}`);
  }
}

export interface Result {
  vote_count: number;
  id: number;
  video: boolean;
  vote_average: number;
  title: string;
  popularity: number;
  poster_path: string;
  original_language: string;
  original_title: string;
  genre_ids: number[];
  backdrop_path: string;
  adult: boolean;
  overview: string;
  release_date: string;
}

export interface IMovie {
  page: number;
  total_results: number;
  total_pages: number;
  results: Result[];
}
