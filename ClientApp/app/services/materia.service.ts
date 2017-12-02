import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { SaveMateria } from '../models/savemateria';

@Injectable()
export class MateriaService {

  constructor(private http: Http) { }
  
    getMaterias() {
      return this.http.get('/api/materias')
        .map(res => res.json());
    }
  
    getMateria(id: number) {
      return this.http.get('/api/materias/' + id)
      .map(res => res.json());
    }
  
    createMateria(saveMateria: SaveMateria) {
      return this.http.post('/api/materias', saveMateria)
        .map( res => res.json());
    }
  
    apagar(id: number) {
      return this.http.delete('/api/materias/' + id)
        .map(res => res.json());
    }
  
    alterar(id: number, saveMateria: SaveMateria) {
      return this.http.put('/api/materias/' + id, saveMateria)
      .map(res => res.json());
    }

}
