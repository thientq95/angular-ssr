import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './views/home/home.component';
import { DependencyComponent } from './views/dependency/dependency.component';
import { MaterialComponent } from './views/material/material.component';
import { UserComponent } from './views/user/user.component';
import { MovieListComponent } from './views/movie-list/movie-list.component';
import { ChatbotComponent } from './views/chatbot/chatbot.component';

const routes: Routes = [
    {
        path: 'home',
        component: HomeComponent,
    },
    {
        path: 'chatbot',
        component: ChatbotComponent,
    },
    {
        path: 'material',
        component: MaterialComponent,
    },
    {
        path: 'user',
        component: UserComponent
    },
    {
        path: 'movie',
        component: MovieListComponent
    }
];

@NgModule({
    imports: [
        RouterModule.forRoot(routes, {
            initialNavigation: 'enabled',
        }),
    ],
    exports: [RouterModule],
})
export class AppRoutingModule {}
