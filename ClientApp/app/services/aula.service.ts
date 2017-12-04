import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { SaveAula } from '../models/saveaula';

@Injectable()
export class AulaService {

  constructor(private http: Http) { }
  
    getAulas() {
      return this.http.get('/api/aulas')
        .map(res => res.json());
    }
  
    getAula(id: number) {
      return this.http.get('/api/aulas/' + id)
      .map(res => res.json());
    }
  
    createAula(saveAula: SaveAula) {
      return this.http.post('/api/aulas', saveAula)
        .map( res => res.json());
    }
  
    apagar(id: number) {
      return this.http.delete('/api/aulas/' + id)
        .map(res => res.json());
    }
  
    alterar(id: number, saveAula: SaveAula) {
      return this.http.put('/api/aulas/' + id, saveAula)
      .map(res => res.json());
    }
}
