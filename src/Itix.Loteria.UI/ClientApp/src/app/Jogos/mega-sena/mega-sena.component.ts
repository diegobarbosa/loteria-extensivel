import { Component, OnInit } from '@angular/core';

import { JogosService } from '../../Services/JogosService';

import { GeradorDeNumeros } from '../../Services/GeradorDeNumeros';

@Component({
  selector: 'app-mega-sena',
  templateUrl: './mega-sena.component.html',
  styleUrls: ['./mega-sena.component.scss']
})
export class MegaSenaComponent implements OnInit {

  constructor(
    private jogosService: JogosService
   
  ) { }

  jogo: any;



  ngOnInit() {

    this.jogosService
      .getByCodigo("megasena")
      .subscribe(jogo => this.jogo = jogo);

  

  }

}
