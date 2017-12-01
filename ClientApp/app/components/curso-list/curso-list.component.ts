import { Component, OnInit } from '@angular/core';
import { CursoService } from '../../services/curso.service';

@Component({
  selector: 'app-curso-list',
  templateUrl: './curso-list.component.html',
  styleUrls: ['./curso-list.component.css']
})
export class CursoListComponent implements OnInit {
  cursos: any[];  
  curso: any = {};
  constructor(private cursoService: CursoService) {
    
    // console.log("iniciado");
   }

  ngOnInit() {
    this.cursoService.getCursos()
    .subscribe(cursos => this.cursos = cursos);
  }

  onClickForDetails(event: any) {
    // console.log(event);
    var id = event.srcElement.id;
    // console.log(id);
    this.cursoService.getCurso(id)
      .subscribe(curso => this.curso = curso);
    
    let buttons: HTMLCollection = event.srcElement.parentElement.children;
    // console.log(buttons)
    for(var i = 0; i< buttons.length; i++)
      buttons[i].classList.remove("active");

    event.toElement.classList.add("active");
  }

}
