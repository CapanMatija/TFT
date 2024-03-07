import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { UrlHelperService } from "./url-helper.service";
import { Observable, map } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class ZanrEntityService {

    constructor(
        private http: HttpClient,
        private urlHelper: UrlHelperService
    ) {}

    private readonly CONTROLLER_NAME = 'api/Zanr';

    getZanrs(): Observable<any[]> {
        const url = this.urlHelper.getUrl(this.CONTROLLER_NAME);

        return this.http.get<any[]>(url).pipe(
            map(data => 
                {
                    return data;
                })
        );
    }
}