import { Component, OnInit } from '@angular/core';
import { SaveDisciplina } from '../../models/savedisciplina';
import { DisciplinaService } from '../../services/disciplina.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-disciplina-alter',
  templateUrl: './disciplina-alter.component.html',
  styleUrls: ['./disciplina-alter.component.css']
})
export class DisciplinaAlterComponent implements OnInit {

  disciplinas: any[];  
  disciplina: any;
  id: number;
  saveDisciplina: SaveDisciplina = { id: 0, nome: "" };
  sub: any;

  constructor(private disciplinaService: DisciplinaService, private route: ActivatedRoute) {
      
    // console.log("iniciado");
   }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => this.id = +params['id']);
    if(this.id) {
      this.disciplinaService.getDisciplina(this.id)
      .subscribe(disciplina => {
        this.disciplina = disciplina;
        this.saveDisciplina.nome = this.disciplina.nome;
      });
    }      
    else {
      this.saveDisciplina.nome = "";
    }
    
    this.disciplinaService.getDisciplinas()
    .subscribe(disciplinas => this.disciplinas = disciplinas);
  }

  reloadDisciplinas() {
    this.disciplinaService.getDisciplinas()
    .subscribe(disciplinas => this.disciplinas = disciplinas);
  }

  onClickForAlter(event: any) {
    // console.log(event);
    this.id = event.srcElement.id;
    console.log("Disciplina a ser alterado: " + this.id);
    this.disciplinaService.getDisciplina(this.id)
      .subscribe(disciplina => {
        this.disciplina = disciplina;
        this.saveDisciplina.nome = this.disciplina.nome;
      });
    
    let buttons: HTMLCollection = event.srcElement.parentElement.children;
    // console.log(buttons)
    for(var i = 0; i< buttons.length; i++)
      buttons[i].classList.remove("active");

    event.toElement.classList.add("active");
  }

  onMakeChange() {
    console.log("Disciplina: ", this.saveDisciplina);
  }

  submit() {
    console.log(event);
    this.saveDisciplina.id = this.id;
    this.disciplinaService.alterar(this.id, this.saveDisciplina)
      .subscribe(x => this.reloadDisciplinas());
      
    this.saveDisciplina.nome = "";
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

}
