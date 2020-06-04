import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './views/home/home.component';
import { MaterialComponent } from './views/material/material.component';
import { DependencyComponent } from './views/dependency/dependency.component';
import { UserComponent } from './views/user/user.component';
import { UserListComponent } from './views/user-list/user-list.component';
import { UserFormComponent } from './views/user-form/user-form.component';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MovieFormComponent } from './views/movie-form/movie-form.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ModalModule } from 'ngx-bootstrap/modal';
import { ChatbotComponent } from './views/chatbot/chatbot.component';
import { MovieListComponent } from './views/movie-list/movie-list.component';
@NgModule({
    declarations: [
        AppComponent,
        HomeComponent,
        MaterialComponent,
        DependencyComponent,
        UserComponent,
        UserListComponent,
        UserFormComponent,
        MovieListComponent,
        MovieFormComponent,
        ChatbotComponent,
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'serverApp' }),
        AppRoutingModule,
        HttpClientModule,
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        BrowserAnimationsModule,
        ModalModule.forRoot()
    ],
    providers: [],
    bootstrap: [AppComponent],
})
export class AppModule {}
