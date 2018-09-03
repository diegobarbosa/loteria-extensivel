import { Injectable } from '@angular/core';


@Injectable()
export class GeradorDeNumeros {


  gerarNumeros(ate: number): Array<number> {

    return Array.from({ length: (ate) }, (v, k) => k + 1);

  }

  
}
