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
import { CursoListComponent } from './components/curso-list/curso-list.component';
import { CursoAlterComponent } from './components/curso-alter/curso-alter.component';
import { ProfessorListComponent } from './components/professor-list/professor-list.component';
import { ProfessorAlterComponent } from './components/professor-alter/professor-alter.component';
import { ProfessorFormComponent } from './components/professor-form/professor-form.component';
import { MateriaFormComponent } from './components/materia-form/materia-form.component';
import { MateriaListComponent } from './components/materia-list/materia-list.component';
import { MateriaAlterComponent } from './components/materia-alter/materia-alter.component';
import { DisciplinaFormComponent } from './components/disciplina-form/disciplina-form.component';

import { DisciplinaService } from './services/disciplina.service';
import { MateriaService } from './services/materia.service';
import { ProfessorService } from './services/professor.service';
import { CursoService } from './services/curso.service';
import { DisciplinaAlterComponent } from './components/disciplina-alter/disciplina-alter.component';
import { DisciplinaListComponent } from './components/disciplina-list/disciplina-list.component';
import { AulaFormComponent } from './components/aula-form/aula-form.component';
import { AulaListComponent } from './components/aula-list/aula-list.component';
import { AulaAlterComponent } from './components/aula-alter/aula-alter.component';
import { AulaService } from './services/aula.service';


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
        ProfessorAlterComponent,
        ProfessorFormComponent,
        MateriaFormComponent,
        MateriaListComponent,
        MateriaAlterComponent,
        DisciplinaFormComponent,
        DisciplinaAlterComponent,
        DisciplinaListComponent,
        AulaFormComponent,
        AulaListComponent,
        AulaAlterComponent
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
            { path: 'professores/novo', component: ProfessorFormComponent },
            { path: 'professores/listar', component: ProfessorListComponent },
            { path: 'professores/alterar', component: ProfessorAlterComponent },
            { path: 'professores/alterar/:id', component: ProfessorAlterComponent },
            { path: 'materias/novo', component: MateriaFormComponent },
            { path: 'materias/listar', component: MateriaListComponent },
            { path: 'materias/alterar', component: MateriaAlterComponent },
            { path: 'materias/alterar/:id', component: MateriaAlterComponent },
            { path: 'disciplinas/novo', component: DisciplinaFormComponent },
            { path: 'disciplinas/listar', component: DisciplinaListComponent },
            { path: 'disciplinas/alterar', component: DisciplinaAlterComponent },
            { path: 'disciplinas/alterar/:id', component: DisciplinaAlterComponent },
            { path: 'aulas/novo', component: AulaFormComponent },
            { path: 'aulas/listar', component: AulaListComponent },
            { path: 'aulas/alterar', component: AulaAlterComponent },
            { path: 'aulas/alterar/:id', component: AulaAlterComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        CursoService,
        ProfessorService,
        MateriaService,
        DisciplinaService,
        AulaService
    ]
})
export class AppModuleShared {
}
