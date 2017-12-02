import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { SaveDisciplina } from '../models/savedisciplina';

@Injectable()
export class DisciplinaService {

  constructor(private http: Http) { }
  
    getDisciplinas() {
      return this.http.get('/api/disciplinas')
        .map(res => res.json());
    }
  
    getDisciplina(id: number) {
      return this.http.get('/api/disciplinas/' + id)
      .map(res => res.json());
    }
  
    createDisciplina(saveDisciplina: SaveDisciplina) {
      return this.http.post('/api/disciplinas', saveDisciplina)
        .map( res => res.json());
    }
  
    apagar(id: number) {
      return this.http.delete('/api/disciplinas/' + id)
        .map(res => res.json());
    }
  
    alterar(id: number, saveDisciplina: SaveDisciplina) {
      return this.http.put('/api/disciplinas/' + id, saveDisciplina)
      .map(res => res.json());
    }

}
