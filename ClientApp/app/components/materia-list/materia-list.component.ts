import { Component, OnInit } from '@angular/core';
import { MateriaService } from '../../services/materia.service';

@Component({
  selector: 'app-materia-list',
  templateUrl: './materia-list.component.html',
  styleUrls: ['./materia-list.component.css']
})
export class MateriaListComponent implements OnInit {

  materias: any[];  
  materia: any = {};
  constructor(private materiaService: MateriaService) {
        
   }

  ngOnInit() {
    this.materiaService.getMaterias()
    .subscribe(materias => this.materias = materias);
  }

  onClickForDetails(event: any) {
    // console.log(event);
    var id = event.srcElement.id;
    // console.log(id);
    this.materiaService.getMateria(id)
      .subscribe(materia => this.materia = materia);
    
    let buttons: HTMLCollection = event.srcElement.parentElement.children;
    // console.log(buttons)
    for(var i = 0; i< buttons.length; i++)
      buttons[i].classList.remove("active");

    event.toElement.classList.add("active");
  }
}
