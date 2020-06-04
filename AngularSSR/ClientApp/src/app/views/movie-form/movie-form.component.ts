import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { MovieService } from '../../core/services/movie.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Movie } from '../../core/models/movie.model';

@Component({
    selector: 'app-movie-form',
    templateUrl: './movie-form.component.html',
    styleUrls: ['./movie-form.component.scss'],
    providers: [MovieService],
})
export class MovieFormComponent implements OnInit {
    @Input() data?: Movie;
    @Input() action: string;
    @Output() closeModal = new EventEmitter<boolean>();
    form: FormGroup;

    movie: Movie;
    constructor(
        private movieService: MovieService,
        private formBuilder: FormBuilder
    ) {
        this.form = this.createForm();
    }

    ngOnInit(): void {
        if (this.action === 'EDIT') {
            this.form.patchValue(this.data);
            this.movie = Object.assign({}, this.data);
        }
    }

    createForm() {
        return this.formBuilder.group({
            code: [''],
            name: ['']
        });
    }

    onSubmit() {
        if (this.form.valid) {
            if (this.action === 'CREATE') {
                this.movieService.createMovie(this.form.value).subscribe(
                    res => {
                        this.closeModal.emit(true);
                    }
                )
            } else {
                this.movieService.updateMovie(this.movie.id, this.form.value).subscribe(
                    res => {
                        this.closeModal.emit(true);
                    }
                )
            }
        }
    }

    close() {
        this.closeModal.emit(false);
    }
}
