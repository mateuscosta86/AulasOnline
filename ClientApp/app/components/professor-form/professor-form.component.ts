import { Component, OnInit } from '@angular/core';
import { SaveProfessor } from '../../models/saveprofessor';
import { ProfessorService } from '../../services/professor.service';

@Component({
  selector: 'app-professor-form',
  templateUrl: './professor-form.component.html',
  styleUrls: ['./professor-form.component.css']
})
export class ProfessorFormComponent implements OnInit {

  professores: any[];
  saveProfessor: SaveProfessor = { id: 0, nome: "", sobrenome: ""};
  constructor(private professorService: ProfessorService) {
  }

  ngOnInit() {
    this.LoadProfessores();
  }

  LoadProfessores() {
    this.professorService.getProfessores()
    .subscribe(professores => { 
      this.professores = professores;
    });
  }

  OnMakeChange() {
  }

  submit() {
    this.professorService.createProfessor(this.saveProfessor)
      .subscribe(x => {
        this.LoadProfessores();
      });
  }

  delete(id: number) {
    if(confirm("Tem certeza?"))
    this.professorService.apagar(id)
      .subscribe(x => {
        this.LoadProfessores();
      });
  }
}
