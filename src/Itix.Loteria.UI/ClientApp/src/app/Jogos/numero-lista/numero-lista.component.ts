import { Component, OnInit, Input } from '@angular/core';

import { GeradorDeNumeros } from '../../Services/GeradorDeNumeros';

@Component({
  selector: 'app-numero-lista',
  templateUrl: './numero-lista.component.html',
  styleUrls: ['./numero-lista.component.scss']
})
export class NumeroListaComponent implements OnInit {

  constructor(private geradorDeNumeros: GeradorDeNumeros) { }

  numeros: Array<any>;

  @Input() ate: number;


  ngOnInit() {
    this.numeros = this.geradorDeNumeros.gerarNumeros(this.ate);
  }

}
