import { MateriaService } from './../../services/materia.service';
import { DisciplinaService } from './../../services/disciplina.service';
import { AulaService } from './../../services/aula.service';
import { Component, OnInit } from '@angular/core';
import { SaveAula } from '../../models/saveaula';
import { ProfessorService } from '../../services/professor.service';
import { CursoService } from '../../services/curso.service';

@Component({
  selector: 'app-aula-form',
  templateUrl: './aula-form.component.html',
  styleUrls: ['./aula-form.component.css']
})
export class AulaFormComponent implements OnInit {
  aulas: any[];
  professores: any[];
  materias: any[];
  disciplinas: any[];
  cursos: any[];
  
  saveAula: SaveAula = { id: 0,
     titulo: "",
     duracao: 0, 
     materiaId: 0, 
     disciplinaId: 0, 
     professorId: 0, 
     cursoId: 0 
    };

  constructor(private aulaService: AulaService, 
    private professorService: ProfessorService, 
    private disciplinaService: DisciplinaService,
    private materiaService: MateriaService,
    private cursoService: CursoService) {

    }

  ngOnInit() {
    this.LoadAulas();
    this.LoadCursos();
    this.LoadDisciplinas();
    this.LoadProfessores();
    this.LoadMaterias();
    
    console.log(this.aulas);
  }

  LoadAulas() {
    this.aulaService.getAulas()
    .subscribe(aulas =>  
      this.aulas = aulas
    );
  }

  LoadCursos() {
    this.cursoService.getCursos()
    .subscribe(cursos => { 
      this.cursos = cursos;
    });
  }
  
  LoadMaterias() {
    this.materiaService.getMaterias()
    .subscribe(materias => { 
      this.materias = materias;
    });
  }

  LoadDisciplinas() {
    this.disciplinaService.getDisciplinas()
    .subscribe(disciplinas => { 
      this.disciplinas = disciplinas;
    });
  }

  LoadProfessores() {
    this.professorService.getProfessores()
    .subscribe(professores => { 
      this.professores = professores;
    });
  }

  delete(id: number) {
    if(confirm("Tem certeza?"))
    this.aulaService.apagar(id)
      .subscribe(x => {
        // console.log("Deletado: ", id );
        this.LoadAulas();
      });

  }

  submit() {
    this.aulaService.createAula(this.saveAula)
      .subscribe(x => {
        // console.log("Criado!");
        this.LoadAulas();
      });
  }

  onMakeChange() {
    console.log(this.saveAula)
  }
}
