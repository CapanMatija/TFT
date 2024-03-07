import { Component, Input, OnInit } from "@angular/core";
import { ZanrEntityService } from "../../services/zanr-entity.service";
import { FilmEntityService } from "../../services/film-entity.service";
import { FilmDetailModel } from "../../models/film.models";
import { Zanr } from "../../models/zanr.models";
import { Observable, take } from "rxjs";
import { DirektorEntityService } from "../../services/direktor-entity.service";
import { DirektorLookupModel } from "../../models/direktor.model";

@Component({
    selector: 'app-film-detail',
    templateUrl: './film-detail.component.html',
    styleUrls: ['./film-detail.component.scss']
})
export class FilmDetailComponent implements OnInit{
    protected film: FilmDetailModel = {};
    protected zanrovi: Zanr[] = [];
    protected direktori: DirektorLookupModel[] = [];
    @Input() filmId?: number;

    constructor(
        private zanrEntityService: ZanrEntityService,
        private filmEntityService: FilmEntityService,
        private direktorEntityService: DirektorEntityService
        ){}

    ngOnInit(): void {
        this.getFormData();
        // if (this.filmId != null) 
        // {
            this.getData();
        // }
    }

    onSubmit(): Observable<any> {
        this.film.DirektorId = this.film.Direktor?.Id;
        return this.filmEntityService.saveFilm(this.film).pipe(take(1));
    }

    getFormData(): void {
        this.zanrEntityService.getZanrs().subscribe((result) => 
        {
            this.zanrovi = result.map(function(res) {
                return {
                    Id: res.id,
                    Naziv: res.naziv
                }
            });
        })

        this.direktorEntityService.getDirektors().subscribe((result) => 
        {
            this.direktori = result.map(function(res) {
                return {
                    Id: res.id,
                    ImeIPrezime: res.ime + ' ' + res.prezime
                }
            })
        })

    }

    getData(): void {
        if (this.filmId != null) 
        {
            this.filmEntityService.getFilm(this.filmId).subscribe((result) => {
                this.film = {
                    Id: this.filmId,
                    Naslov: result.naslov,
                    Opis: result.opis,
                    Budzet: result.budzet,
                    Trajanje: result.trajanje,
                    PocetakSnimanja: result.pocetakSnimanja,
                    KrajSnimanja: result.krajSnimanja,
                    DirektorId: result.direktorId,
                    Direktor: this.direktori.find(x => x.Id == result.direktorId)
                }
            })
        }
        
    }

    
}