import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ApiService } from '../../core/api.service';
import { User } from '../../core/models/user.model';

@Component({
    selector: 'app-user',
    templateUrl: './user.component.html',
    styleUrls: ['./user.component.scss'],
    providers: [ApiService]
})
export class UserComponent implements OnInit {
    form: FormGroup;
    users = [
        {
            userName: 'thientq',
            fullName: 'Trần Quốc Thiện',
            email: 'thientq.spkt@gmail.com',
            gender: true
        },
        {
            userName: 'thientq',
            fullName: 'Trần Quốc Thiện',
            email: 'thientq.spkt@gmail.com',
            gender: true
        },
        {
            userName: 'thientq',
            fullName: 'Trần Quốc Thiện',
            email: 'thientq.spkt@gmail.com',
            gender: true
        },
        {
            userName: 'hdht',
            fullName: 'Hồ Đặng Hữu Trọng',
            email: 'trong.hdhd@gmail.com',
            gender: true
        },
        {
            userName: 'thientq',
            fullName: 'Trần Quốc Thiện',
            email: 'thientq.spkt@gmail.com',
            gender: true
        }
    ];

    listUser: User[];
    listSelected: User[];
    constructor(
        private formBuilder: FormBuilder,
        private apiService: ApiService
    ) {
        this.form = this.createFormUser();
    }

    ngOnInit(): void {
        this.loadAllUser();
    }

    createFormUser() {
        return this.formBuilder.group({
            userName: [''],
            fullName: [''],
            email: [''],
            gender: [true]
        })
    }

    loadAllUser() {
        this.apiService.getUsers().subscribe(res => {
            this.listUser = res.data;
        });
    }

    onSubmit() {
        console.log(this.form.value);
        if (this.form.valid) {
            // code here
        }
    }
}
