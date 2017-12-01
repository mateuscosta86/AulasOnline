import { SaveCurso } from './../models/savecurso';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class CursoService {

  constructor( private http: Http ) { }

  getCursos() {
    return this.http.get('/api/cursos')
      .map(res => res.json());
  }

  getCurso(id: number) {
    return this.http.get('/api/cursos/' + id)
    .map(res => res.json());
  }

  createCurso(saveCurso: SaveCurso) {
    return this.http.post('/api/cursos', saveCurso)
      .map( res => res.json());
  }

  apagar(id: number) {
    return this.http.delete('/api/cursos/' + id)
      .map(res => res.json());
  }
}
