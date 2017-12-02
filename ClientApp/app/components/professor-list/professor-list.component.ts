import { Component, OnInit } from '@angular/core';
import { ProfessorService } from '../../services/professor.service';

@Component({
  selector: 'app-professor-list',
  templateUrl: './professor-list.component.html',
  styleUrls: ['./professor-list.component.css']
})
export class ProfessorListComponent implements OnInit {

  professores: any[];  
  professor: any = {};
  constructor(private professorService: ProfessorService) {
    
    // console.log("iniciado");
   }

  ngOnInit() {
    this.professorService.getProfessores()
    .subscribe(professores => this.professores = professores);
  }

  onClickForDetails(event: any) {
    // console.log(event);
    var id = event.srcElement.id;
    // console.log(id);
    this.professorService.getProfessor(id)
      .subscribe(professor => this.professor = professor);
    
    let buttons: HTMLCollection = event.srcElement.parentElement.children;
    // console.log(buttons)
    for(var i = 0; i< buttons.length; i++)
      buttons[i].classList.remove("active");

    event.toElement.classList.add("active");
  }

}
