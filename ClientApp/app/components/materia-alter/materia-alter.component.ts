import { MateriaService } from './../../services/materia.service';
import { Component, OnInit } from '@angular/core';
import { SaveMateria } from '../../models/savemateria';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-materia-alter',
  templateUrl: './materia-alter.component.html',
  styleUrls: ['./materia-alter.component.css']
})
export class MateriaAlterComponent implements OnInit {

  materias: any[];  
  materia: any;
  id: number;
  saveMateria: SaveMateria = { id: 0, nome: "" };
  sub: any;

  constructor(private materiaService: MateriaService, private route: ActivatedRoute) {
      
    // console.log("iniciado");
   }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => this.id = +params['id']);
    if(this.id) {
      this.materiaService.getMateria(this.id)
      .subscribe(materia => {
        this.materia = materia;
        this.saveMateria.nome = this.materia.nome;
      });
    }      
    else {
      this.saveMateria.nome = "";
    }
    
    this.materiaService.getMaterias()
    .subscribe(materias => this.materias = materias);
  }

  reloadMaterias() {
    this.materiaService.getMaterias()
    .subscribe(materias => this.materias = materias);
  }

  onClickForAlter(event: any) {
    // console.log(event);
    this.id = event.srcElement.id;
    console.log("Materia a ser alterado: " + this.id);
    this.materiaService.getMateria(this.id)
      .subscribe(materia => {
        this.materia = materia;
        this.saveMateria.nome = this.materia.nome;
      });
    
    let buttons: HTMLCollection = event.srcElement.parentElement.children;
    // console.log(buttons)
    for(var i = 0; i< buttons.length; i++)
      buttons[i].classList.remove("active");

    event.toElement.classList.add("active");
  }

  onMakeChange() {
    console.log("Materia: ", this.saveMateria);
  }

  submit() {
    console.log(event);
    this.saveMateria.id = this.id;
    this.materiaService.alterar(this.id, this.saveMateria)
      .subscribe(x => this.reloadMaterias());
      
    this.saveMateria.nome = "";
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

}
