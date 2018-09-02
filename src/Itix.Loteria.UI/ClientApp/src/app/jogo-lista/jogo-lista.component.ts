import { Component, Input, OnInit } from '@angular/core';

import { JogosService } from '../Services/JogosService';

@Component({
  selector: 'app-jogo-lista',
  templateUrl: './jogo-lista.component.html',
  styleUrls: ['./jogo-lista.component.scss']
})
export class JogoListaComponent implements OnInit {

  jogos: Array<any>;

  constructor(private jogosService: JogosService) {

  }

  ngOnInit() {
    this.jogosService
      .get()
      .subscribe(jogos => this.jogos = jogos);
  }




}
