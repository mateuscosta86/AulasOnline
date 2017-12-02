import { Component, OnInit } from '@angular/core';
import { DisciplinaService } from '../../services/disciplina.service';

@Component({
  selector: 'app-disciplina-list',
  templateUrl: './disciplina-list.component.html',
  styleUrls: ['./disciplina-list.component.css']
})
export class DisciplinaListComponent implements OnInit {

  disciplinas: any[];  
  disciplina: any = {};
  constructor(private disciplinaService: DisciplinaService) {
        
   }

  ngOnInit() {
    this.disciplinaService.getDisciplinas()
    .subscribe(disciplinas => this.disciplinas = disciplinas);
  }

  onClickForDetails(event: any) {
    // console.log(event);
    var id = event.srcElement.id;
    // console.log(id);
    this.disciplinaService.getDisciplina(id)
      .subscribe(disciplina => this.disciplina = disciplina);
    
    let buttons: HTMLCollection = event.srcElement.parentElement.children;
    // console.log(buttons)
    for(var i = 0; i< buttons.length; i++)
      buttons[i].classList.remove("active");

    event.toElement.classList.add("active");
  }

}
