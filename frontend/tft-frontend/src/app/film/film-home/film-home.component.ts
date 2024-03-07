import {  ChangeDetectorRef, Component, OnInit, ViewChild } from "@angular/core";
import { FilmEntityService } from "../../services/film-entity.service";
import { FilmDetailComponent } from "../film-detail/film-detail.component";

@Component({
    selector: 'app-film-home',
    templateUrl: './film-home.component.html',
    styleUrls: ['./film-home.component.scss']
})
export class FilmHomeComponent implements OnInit{
    filmovi: FilmTableModel[] = [];

    isEdit = false;
    protected selectedFilm: FilmTableModel | null = null;

    @ViewChild(FilmDetailComponent) detail!: FilmDetailComponent;

    constructor(private filmEntityService: FilmEntityService, private cdref: ChangeDetectorRef) {}

    ngOnInit(): void {
        this.filmEntityService.getFilms().subscribe((response) => {
            this.filmovi = [];
            for (let i = 0; i < response.length; i++) {
                this.filmovi.push({
                        Id: response[i].id,
                        Naslov: response[i].naslov,
                        Budzet: response[i].budzet
                    });
            }
        });
    }

    onDodajFilm(Id?: number): void {
        this.selectedFilm = this.filmovi.find(x => x.Id == Id) ?? null;
        this.isEdit = true;
        this.cdref.detectChanges();
    }

    onEditDialogClose(): void {
        this.isEdit = false;
        this.selectedFilm = null;
    }

    onSubmit(): void {
        this.detail.onSubmit().subscribe(() => this.onEditDialogClose())
    }
}

export interface FilmTableModel {
    Id: number;
    Naslov: string;
    Budzet: number;
}