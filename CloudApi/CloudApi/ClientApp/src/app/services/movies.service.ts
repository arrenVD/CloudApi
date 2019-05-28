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
    return this.http.get<IMovieFullList>(`${this.movieDB_URL}/${this.APIVersion}/movie/${ID}?api_key=${this.APIKey}`);
  }
  GetUpcoming(Page: number) {
    return this.http.get<IMovie>(`${this.movieDB_URL}/${this.APIVersion}/movie/upcoming?api_key=${this.APIKey}&language=en-US&page=${Page}`);
  }
  GetLatest(Page: number) {
    return this.http.get<IMovie>(`${this.movieDB_URL}/${this.APIVersion}/movie/now_playing?api_key=${this.APIKey}&language=en-US&page=${Page}`);
  }
  SearchQuery(Page: number, Query: string) {
    return this.http.get<IMovie>(`${this.movieDB_URL}/${this.APIVersion}/search/movie?api_key=${this.APIKey}&language=en-US&query=${Query}&page=${Page}`);
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

export interface Genre {
  id: number;
  name: string;
}

export interface ProductionCompany {
  id: number;
  logo_path?: any;
  name: string;
  origin_country: string;
}

export interface ProductionCountry {
  iso_3166_1: string;
  name: string;
}

export interface SpokenLanguage {
  iso_639_1: string;
  name: string;
}

export interface IMovieFullList {
  adult: boolean;
  backdrop_path: string;
  belongs_to_collection?: any;
  budget: number;
  genres: Genre[];
  homepage?: any;
  id: number;
  imdb_id: string;
  original_language: string;
  original_title: string;
  overview: string;
  popularity: number;
  poster_path: string;
  production_companies: ProductionCompany[];
  production_countries: ProductionCountry[];
  release_date: string;
  revenue: number;
  runtime: number;
  spoken_languages: SpokenLanguage[];
  status: string;
  tagline: string;
  title: string;
  video: boolean;
  vote_average: number;
  vote_count: number;
}

