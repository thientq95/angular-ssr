import { Component, OnInit, TemplateRef } from '@angular/core';
import { MovieService } from '../../core/services/movie.service';
import { Movie } from '../../core/models/movie.model';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
    selector: 'app-movie-list',
    templateUrl: './movie-list.component.html',
    styleUrls: ['./movie-list.component.scss'],
    providers: [MovieService],
})
export class MovieListComponent implements OnInit {
    modalRef: BsModalRef;
    listMovie: Movie[];

    action: string;
    data: Movie;

    constructor(
        private movieService: MovieService, 
        private modalService: BsModalService
    ) {}

    ngOnInit(): void {
        this.loadAllMovie();
    }

    loadAllMovie() {
        this.movieService.getMovies().subscribe(
            res => this.listMovie = res
        )
    }

    openModalCreate(template: TemplateRef<any>) {
        this.action = 'CREATE';
        this.modalRef = this.modalService.show(template);
    }

    openModalEdit(template: TemplateRef<any>, movie) {
        this.data = movie;
        this.action = 'EDIT';
        this.modalRef = this.modalService.show(template);
    }

    remove(item) {
        this.movieService.deleteMovie(item.id).subscribe(
            res => {
                this.loadAllMovie();
            }
        )
    }

    hideModal(isPost) {
        if(isPost) {
            this.loadAllMovie();
        }
        this.modalRef.hide();
    }

    openModal(template: TemplateRef<any>) {
        this.modalRef = this.modalService.show(template);
      }
}
