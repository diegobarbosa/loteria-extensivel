import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { JogoListaComponent } from './jogo-lista/jogo-lista.component';

import { MegaSenaComponent } from './Jogos/mega-sena/mega-sena.component';

const routes: Routes = [
  { path: '', component: JogoListaComponent },
  { path: 'jogo/megasena', component: MegaSenaComponent },


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
