import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { FilmHomeComponent } from "./film-home/film-home.component";

const routes: Routes = [
    {path: '', component: FilmHomeComponent}
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class FilmRoutingModule {}