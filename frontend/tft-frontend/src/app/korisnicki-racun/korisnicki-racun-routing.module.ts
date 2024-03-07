import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { KorisnickiRacunHomeComponent } from "./korisnicki-racun-home/korisnicki-racun-home.component";

const routes: Routes = [
    {path: '', component: KorisnickiRacunHomeComponent}
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class KorisnickiRacunRoutingModule {}