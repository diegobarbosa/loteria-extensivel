import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { JogoListaComponent } from './jogo-lista/jogo-lista.component';
import { JogoListaItemComponent } from './jogo-lista-item/jogo-lista-item.component';

import { JogosService } from './Services/JogosService';

import { ConcursosService } from './Services/ConcursosService';

import { HttpClientModule } from '@angular/common/http';
import { MegaSenaComponent } from './Jogos/mega-sena/mega-sena.component'; 

import { GeradorDeNumeros } from './Services/GeradorDeNumeros';
import { NumeroComponent } from './jogos/numero/numero.component';
import { NumeroListaComponent } from './jogos/numero-lista/numero-lista.component';

@NgModule({
  declarations: [
    AppComponent,
    JogoListaComponent,
    JogoListaItemComponent,
    MegaSenaComponent,
    NumeroComponent,
    NumeroListaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [JogosService, ConcursosService, GeradorDeNumeros],
  bootstrap: [AppComponent]
})
export class AppModule { }
