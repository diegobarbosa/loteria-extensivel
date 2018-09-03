import { Component, OnInit, Input, Output } from '@angular/core';

@Component({
  selector: 'app-numero',
  templateUrl: './numero.component.html',
  styleUrls: ['./numero.component.scss']
})
export class NumeroComponent implements OnInit {

  constructor() { }

  ngOnInit() {

    this.selecionado = false;
  }


  @Input() numero: number;

  @Output() selecionado: boolean;

  numeroClicado() {
    this.selecionado = !this.selecionado;
  }

}
