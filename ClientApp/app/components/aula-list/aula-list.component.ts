import { Component, OnInit } from '@angular/core';
import { AulaService } from '../../services/aula.service';

@Component({
  selector: 'app-aula-list',
  templateUrl: './aula-list.component.html',
  styleUrls: ['./aula-list.component.css']
})
export class AulaListComponent implements OnInit {

  aulas: any[];  
  aula: any = { id: 0,
                titulo: "",
                duracao: 0
              };
  constructor(private aulaService: AulaService) {        
   }

  ngOnInit() {
    this.aulaService.getAulas()
    .subscribe(aulas => this.aulas = aulas);
  }

  onClickForDetails(event: any) {
    // console.log(event);
    var id = event.srcElement.id;
    // console.log(id);
    this.aulaService.getAula(id)
      .subscribe(aula => this.aula = aula);
    
    let buttons: HTMLCollection = event.srcElement.parentElement.children;
    // console.log(buttons)
    for(var i = 0; i< buttons.length; i++)
      buttons[i].classList.remove("active");

    event.toElement.classList.add("active");
  }
}
