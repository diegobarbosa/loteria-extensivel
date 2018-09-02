import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class ConcursosService {

  constructor(private http: HttpClient) { }

  apostar(idConcurso: number, aposta: any) {
    return this.http.post(`/api/concursos/${idConcurso}/Apostar`, aposta);
  }


  processar(idConcurso: number) {
    return this.http.post(`/api/concursos/${idConcurso}/processar`, {});
  }


  vencedores(idConcurso: number) {
    return this.http.get(`/api/concursos/${idConcurso}/vencedores`);
  }


}
