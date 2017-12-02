import { Component, OnInit } from '@angular/core';
import { SaveMateria } from '../../models/savemateria';
import { MateriaService } from '../../services/materia.service';

@Component({
  selector: 'app-materia-form',
  templateUrl: './materia-form.component.html',
  styleUrls: ['./materia-form.component.css']
})
export class MateriaFormComponent implements OnInit {
  materias: any[];
  saveMateria: SaveMateria = { id: 0, nome: ""};
  constructor(private materiaService: MateriaService) {
    
    // console.log("Materia: ", this.saveMateria);
    
  }

  ngOnInit() {
    this.LoadMaterias();
  }

  LoadMaterias() {
    this.materiaService.getMaterias()
    .subscribe(materias => { 
      this.materias = materias;
      // console.log("materias: ", this.materias);
    });
  }

  OnMakeChange() {
    // console.log("Materia: ", this.saveMateria);
  }

  submit() {
    this.materiaService.createMateria(this.saveMateria)
      .subscribe(x => {
        // console.log("Criado!");
        this.LoadMaterias();
      });
  }

  delete(id: number) {
    if(confirm("Tem certeza?"))
    this.materiaService.apagar(id)
      .subscribe(x => {
        // console.log("Deletado: ", id );
        this.LoadMaterias();
      });

  }
}
