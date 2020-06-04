import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponse } from './models/api.model';
import { User } from './models/user.model';

@Injectable()
export class ApiService {
    constructor(private http: HttpClient) {}
    baseUrl: string = 'https://localhost:44337/api/User/';

    getUsers(): Observable<ApiResponse<User[]>> {
        return this.http.get<ApiResponse<User[]>>(this.baseUrl);
    }

    getUserById(id: number): Observable<ApiResponse<User>> {
        return this.http.get<ApiResponse<User>>(this.baseUrl + id);
    }

    createUser(user: User): Observable<ApiResponse<User>> {
        return this.http.post<ApiResponse<User>>(this.baseUrl, user);
    }

    updateUser(user: User): Observable<ApiResponse<User>> {
        return this.http.put<ApiResponse<User>>(this.baseUrl + user.id, user);
    }

    deleteUser(id: number): Observable<ApiResponse<User>> {
        return this.http.delete<ApiResponse<User>>(this.baseUrl + id);
    }

    getData() {
        return this.http.get("https://egov.ascvn.com.vn/HeThong/GridReadThongTinLienLac");
    }
}
