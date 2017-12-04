import { Component, OnInit } from '@angular/core';
import { AulaService } from '../../services/aula.service';
import { SaveAula } from '../../models/saveaula';
import { ActivatedRoute } from '@angular/router';
import { ProfessorService } from '../../services/professor.service';
import { DisciplinaService } from '../../services/disciplina.service';
import { MateriaService } from '../../services/materia.service';
import { CursoService } from '../../services/curso.service';

@Component({
  selector: 'app-aula-alter',
  templateUrl: './aula-alter.component.html',
  styleUrls: ['./aula-alter.component.css']
})
export class AulaAlterComponent implements OnInit {

  aulas: any[];  
  professores: any[];
  materias: any[];
  disciplinas: any[];
  cursos: any[];
  
  aula: any;
  id: number;
  saveAula: SaveAula = { id: 0,
                         titulo: "",
                         duracao: 0,
                         materiaId: 0,
                         disciplinaId: 0,
                         professorId: 0,
                         cursoId: 0 };
  sub: any;

  constructor(private aulaService: AulaService, 
              private route: ActivatedRoute,
              private professorService: ProfessorService, 
              private disciplinaService: DisciplinaService,
              private materiaService: MateriaService,
              private cursoService: CursoService) {
      
    // console.log("iniciado");
   }

  ngOnInit() {
    this.LoadAulas();
    this.LoadCursos();
    this.LoadDisciplinas();
    this.LoadProfessores();
    this.LoadMaterias();

    this.sub = this.route.params.subscribe(params => this.id = +params['id']);
    if(this.id) {
      this.aulaService.getAula(this.id)
      .subscribe(aula => {
        this.aula = aula;
        console.log(this.aula);
        this.saveAula.titulo = this.aula.titulo;
        this.saveAula.duracao = this.aula.duracao;
        this.saveAula.materiaId = this.aula.materia.id;
        this.saveAula.disciplinaId = this.aula.disciplina.id;
        this.saveAula.professorId = this.aula.professor.id;
        this.saveAula.cursoId = this.aula.curso.id;
      });
    }      
    else {
      this.saveAula.titulo = "";
      this.saveAula.duracao = 0;
      this.saveAula.materiaId = 0;
      this.saveAula.disciplinaId = 0;
      this.saveAula.professorId = 0;
      this.saveAula.cursoId = 0 ;
    }
    
    this.aulaService.getAulas()
    .subscribe(aulas => this.aulas = aulas);
  }

  reloadAulas() {
    this.aulaService.getAulas()
    .subscribe(aulas => this.aulas = aulas);
  }

  onClickForAlter(event: any) {
    // console.log(event);
    this.id = event.srcElement.id;
    console.log("Aula a ser alterado: " + this.id);
    this.aulaService.getAula(this.id)
      .subscribe(aula => {
        this.aula = aula;
        this.saveAula.titulo = this.aula.titulo;
        this.saveAula.duracao = this.aula.duracao;
        this.saveAula.materiaId = this.aula.materia.id;
        this.saveAula.disciplinaId = this.aula.disciplina.id;
        this.saveAula.professorId = this.aula.professor.id;
        this.saveAula.cursoId = this.aula.curso.id;
      });
    
    let buttons: HTMLCollection = event.srcElement.parentElement.children;
    // console.log(buttons)
    for(var i = 0; i< buttons.length; i++)
      buttons[i].classList.remove("active");

    event.toElement.classList.add("active");
  }

  onMakeChange() {
    console.log("Aula: ", this.saveAula);
  }

  submit() {
    console.log(event);
    this.saveAula.id = this.id;
    this.aulaService.alterar(this.id, this.saveAula)
      .subscribe(x => this.reloadAulas());
      
      this.saveAula.titulo = "";
      this.saveAula.duracao = 0;
      this.saveAula.materiaId = 0;
      this.saveAula.disciplinaId = 0;
      this.saveAula.professorId = 0;
      this.saveAula.cursoId = 0 ;

  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
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

}


