import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponse } from '../models/api.model';
import { Movie } from '../models/movie.model';

@Injectable()
export class MovieService {
    constructor(private http: HttpClient) {}
    baseUrl: string = 'https://localhost:44337/api/Movie/';

    getMovies(): Observable<Movie[]> {
        return this.http.get<Movie[]>(this.baseUrl);
    }

    getMovieById(id: string): Observable<Movie> {
        return this.http.get<Movie>(this.baseUrl + id);
    }

    createMovie(movie: Movie): Observable<Movie> {
        return this.http.post<Movie>(this.baseUrl, movie);
    }

    updateMovie(id: string, movie: Movie): Observable<Movie> {
        return this.http.put<Movie>(this.baseUrl + id, movie);
    }

    deleteMovie(id: string): Observable<Movie> {
        return this.http.delete<Movie>(this.baseUrl + id);
    }
}
