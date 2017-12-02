import { Component, OnInit } from '@angular/core';
import { SaveDisciplina } from '../../models/savedisciplina';
import { DisciplinaService } from '../../services/disciplina.service';

@Component({
  selector: 'app-disciplina-form',
  templateUrl: './disciplina-form.component.html',
  styleUrls: ['./disciplina-form.component.css']
})
export class DisciplinaFormComponent implements OnInit {

  disciplinas: any[];
  saveDisciplina: SaveDisciplina = { id: 0, nome: ""};
  constructor(private disciplinaService: DisciplinaService) {
    
    // console.log("Disciplina: ", this.saveDisciplina);
    
  }

  ngOnInit() {
    this.LoadDisciplinas();
  }

  LoadDisciplinas() {
    this.disciplinaService.getDisciplinas()
    .subscribe(disciplinas => { 
      this.disciplinas = disciplinas;
      // console.log("disciplinas: ", this.disciplinas);
    });
  }

  OnMakeChange() {
    // console.log("Disciplina: ", this.saveDisciplina);
  }

  submit() {
    this.disciplinaService.createDisciplina(this.saveDisciplina)
      .subscribe(x => {
        // console.log("Criado!");
        this.LoadDisciplinas();
      });
  }

  delete(id: number) {
    if(confirm("Tem certeza?"))
    this.disciplinaService.apagar(id)
      .subscribe(x => {
        // console.log("Deletado: ", id );
        this.LoadDisciplinas();
      });
  }
}
