import { Component, OnInit } from '@angular/core';
import { CursoService } from '../../services/curso.service';

@Component({
  selector: 'app-curso-list',
  templateUrl: './curso-list.component.html',
  styleUrls: ['./curso-list.component.css']
})
export class CursoListComponent implements OnInit {
  cursos: any[];
  isHidden = false;
  constructor(private cursoService: CursoService) {
    console.log("iniciado");
   }

  ngOnInit() {
    this.cursoService.getCursos()
    .subscribe(cursos => this.cursos = cursos);
  }

}
