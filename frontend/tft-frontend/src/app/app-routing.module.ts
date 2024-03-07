import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'film',
    loadChildren: () => import('./film/film.module').then((m) => m.FilmModule)
  },
  {
    path: 'korisnicki-racun',
    loadChildren: () => import('./korisnicki-racun/korisnicki-racun.module').then((m) => m.KorisnickiRacunModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
