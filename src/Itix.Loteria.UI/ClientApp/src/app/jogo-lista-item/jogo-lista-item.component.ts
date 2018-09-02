import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-jogo-lista-item',
  templateUrl: './jogo-lista-item.component.html',
  styleUrls: ['./jogo-lista-item.component.scss']
})
export class JogoListaItemComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }


  @Input() jogo: any;

}
