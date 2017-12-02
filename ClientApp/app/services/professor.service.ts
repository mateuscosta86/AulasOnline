import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import 'rxjs/add/operator/map';
import { SaveProfessor } from '../models/saveprofessor';

@Injectable()
export class ProfessorService {

  constructor(private http: Http) { }

  getProfessores() {
    return this.http.get('/api/professores')
      .map(res => res.json());
  }

  getProfessor(id: number) {
    return this.http.get('/api/professores/' + id)
    .map(res => res.json());
  }

  createProfessor(saveProfessor: SaveProfessor) {
    return this.http.post('/api/professores', saveProfessor)
      .map( res => res.json());
  }

  apagar(id: number) {
    return this.http.delete('/api/professores/' + id)
      .map(res => res.json());
  }

  alterar(id: number, saveProfessor: SaveProfessor) {
    return this.http.put('/api/professores/' + id, saveProfessor)
    .map(res => res.json());
  }
}
