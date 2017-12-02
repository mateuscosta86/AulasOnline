import { Component, OnInit } from '@angular/core';
import { SaveProfessor } from '../../models/saveprofessor';
import { ProfessorService } from '../../services/professor.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-professor-alter',
  templateUrl: './professor-alter.component.html',
  styleUrls: ['./professor-alter.component.css']
})
export class ProfessorAlterComponent implements OnInit {

  professores: any[];  
  professor: any;
  id: number;
  saveProfessor: SaveProfessor = { id: 0, nome: "", sobreNome: "" };
  sub: any;

  constructor(private professorService: ProfessorService, private route: ActivatedRoute) {
      
    // console.log("iniciado");
   }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => this.id = +params['id']);
    if(this.id) {
      this.professorService.getProfessor(this.id)
      .subscribe(Prof => {
        this.professor = Prof;
        this.saveProfessor.nome = this.professor.nome;
        this.saveProfessor.sobreNome = this.professor.sobreNome;
      });
    }      
    else {
      this.saveProfessor.nome = "";
      this.saveProfessor.sobreNome = "";
    }
    
    this.professorService.getProfessores()
    .subscribe(profs => this.professores = profs);
  }

  reloadProfessores() {
    this.professorService.getProfessores()
    .subscribe(profs => this.professores = profs);
  }

  onClickForAlter(event: any) {
    // console.log(event);
    this.id = event.srcElement.id;
    console.log("Professor a ser alterado: " + this.id);
    this.professorService.getProfessor(this.id)
      .subscribe(prof => {
        this.professor = prof;
        this.saveProfessor.nome = this.professor.nome;
        this.saveProfessor.sobreNome = this.professor.sobreNome;
      });
    
    let buttons: HTMLCollection = event.srcElement.parentElement.children;
    // console.log(buttons)
    for(var i = 0; i< buttons.length; i++)
      buttons[i].classList.remove("active");

    event.toElement.classList.add("active");
  }

  onMakeChange() {
    console.log("Professor: ", this.saveProfessor);
  }

  submit() {
    console.log(event);
    this.saveProfessor.id = this.id;
    this.professorService.alterar(this.id, this.saveProfessor)
      .subscribe(x => this.reloadProfessores());
      
    this.saveProfessor.nome = "";
    this.saveProfessor.sobreNome  = "";

  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

}
