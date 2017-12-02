import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { CursoFormComponent } from './components/curso-form/curso-form.component';
import { CursoService } from './services/curso.service';
import { CursoListComponent } from './components/curso-list/curso-list.component';
import { CursoAlterComponent } from './components/curso-alter/curso-alter.component';
import { ProfessorListComponent } from './components/professor-list/professor-list.component';
import { ProfessorService } from './services/professor.service';
import { ProfessorAlterComponent } from './components/professor-alter/professor-alter.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        CursoFormComponent,
        CursoListComponent,
        CursoAlterComponent,
        ProfessorListComponent,
        ProfessorAlterComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },            
            { path: 'home', component: HomeComponent },
            { path: 'cursos/novo', component: CursoFormComponent },
            { path: 'cursos/listar', component: CursoListComponent },
            { path: 'cursos/alterar', component: CursoAlterComponent },
            { path: 'cursos/alterar/:id', component: CursoAlterComponent },
            { path: 'professores/listar', component: ProfessorListComponent },
            { path: 'professores/alterar', component: ProfessorAlterComponent },
            { path: 'professores/alterar/:id', component: CursoAlterComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        CursoService,
        ProfessorService
    ]
})
export class AppModuleShared {
}
