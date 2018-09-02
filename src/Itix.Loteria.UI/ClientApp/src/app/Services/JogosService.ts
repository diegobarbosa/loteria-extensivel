import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class JogosService {

  constructor(private http: HttpClient) { }

  get() : Observable<Array<any>> {
    return this.http.get<Array<any>>(`/api/jogos`);
  }

  getByCodigo(codigoJogo: string): Observable<any> {
    return this.http.get<any>(`/api/jogos/` + codigoJogo);
  }



}
