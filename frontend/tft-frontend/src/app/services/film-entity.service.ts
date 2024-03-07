import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { UrlHelperService } from "./url-helper.service";
import { Observable, map } from "rxjs";
import { FilmDetailModel } from "../models/film.models";

@Injectable({
    providedIn: 'root'
})
export class FilmEntityService {

    constructor(
        private http: HttpClient,
        private urlHelper: UrlHelperService
    ) {}

    private readonly CONTROLLER_NAME = 'api/Film';

    getFilms(): Observable<any[]> {
        const url = this.urlHelper.getUrl(this.CONTROLLER_NAME);

        return this.http.get<any[]>(url).pipe(
            map(data => 
                {
                    return data;
                })
        );
    }

    getFilm(Id: number): Observable<any> {
        const url = this.urlHelper.getUrl(this.CONTROLLER_NAME, Id.toString());

        return this.http.get<any[]>(url).pipe(
            map(data => 
                {
                    return data;
                })
        );
    }

    saveFilm(film: FilmDetailModel) {
        const url = this.urlHelper.getUrl(this.CONTROLLER_NAME);

        return this.http.post(url, film).pipe(
            map( data => {
                return data
            }) 
        );
    }
}