import { CursoService } from './../../services/curso.service';
import { Component, OnInit } from '@angular/core';
import { SaveCurso } from '../../models/savecurso';

@Component({
  selector: 'app-curso-form',
  templateUrl: './curso-form.component.html',
  styleUrls: ['./curso-form.component.css']
})
export class CursoFormComponent implements OnInit {
  cursos: any[];
  saveCurso: SaveCurso = { nome: "", preco: 0};
  constructor(private cursoService: CursoService) {
    
    // console.log("Curso: ", this.saveCurso);
    
  }

  ngOnInit() {
    this.LoadCursos();
  }

  LoadCursos() {
    this.cursoService.getCursos()
    .subscribe(cursos => { 
      this.cursos = cursos;
      // console.log("cursos: ", this.cursos);
    });
  }

  OnMakeChange() {
    // console.log("Curso: ", this.saveCurso);
  }

  submit() {
    this.cursoService.createCurso(this.saveCurso)
      .subscribe(x => {
        // console.log("Criado!");
        this.LoadCursos();
      });
  }

  delete(id: number) {
    if(confirm("Tem certeza?"))
    this.cursoService.apagar(id)
      .subscribe(x => {
        // console.log("Deletado: ", id );
        this.LoadCursos();
      });

  }

}
