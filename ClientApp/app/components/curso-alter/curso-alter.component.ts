import { SaveCurso } from './../../models/savecurso';
import { Component, OnInit } from '@angular/core';
import { CursoService } from '../../services/curso.service';
import { ActivatedRoute } from '@angular/router';
import { OnDestroy } from '@angular/core/src/metadata/lifecycle_hooks';

@Component({
  selector: 'app-curso-alter',
  templateUrl: './curso-alter.component.html',
  styleUrls: ['./curso-alter.component.css']
})
export class CursoAlterComponent implements OnInit, OnDestroy {
  
  cursos: any[];  
  curso: any;
  id: number;
  saveCurso: SaveCurso = { id: 0, nome: "", preco: 0 };
  sub: any;

  constructor(private cursoService: CursoService, private route: ActivatedRoute) {
      
    // console.log("iniciado");
   }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => this.id = +params['id']);
    if(this.id) {
      this.cursoService.getCurso(this.id)
      .subscribe(curso => {
        this.curso = curso;
        this.saveCurso.nome = this.curso.nome;
        this.saveCurso.preco = this.curso.preco;
      });
    }      
    else {
      this.saveCurso.nome = "";
      this.saveCurso.preco = 0;
    }
    
    this.cursoService.getCursos()
    .subscribe(cursos => this.cursos = cursos);
  }

  reloadCursos() {
    this.cursoService.getCursos()
    .subscribe(cursos => this.cursos = cursos);
  }

  onClickForAlter(event: any) {
    // console.log(event);
    this.id = event.srcElement.id;
    console.log("Curso a ser alterado: " + this.id);
    this.cursoService.getCurso(this.id)
      .subscribe(curso => {
        this.curso = curso;
        this.saveCurso.nome = this.curso.nome;
        this.saveCurso.preco = this.curso.preco;
      });
    
    let buttons: HTMLCollection = event.srcElement.parentElement.children;
    // console.log(buttons)
    for(var i = 0; i< buttons.length; i++)
      buttons[i].classList.remove("active");

    event.toElement.classList.add("active");
  }

  onMakeChange() {
    console.log("Curso: ", this.saveCurso);
  }

  submit() {
    console.log(event);
    this.saveCurso.id = this.id;
    this.cursoService.alterar(this.id, this.saveCurso)
      .subscribe(x => this.reloadCursos());
      
    this.saveCurso.nome = "";
    this.saveCurso.preco  = 0;

  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

}
