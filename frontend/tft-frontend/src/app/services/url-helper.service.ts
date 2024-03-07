import { Injectable } from "@angular/core";
import { environment } from "../../environments/environment";
import { HttpParams } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})
export class UrlHelperService {
    private readonly baseUrl: string;
    private readonly delimiter = '/';

    constructor() {
        this.baseUrl = environment.apiUrl
    }

    getUrl(...args: string []): string {
        args.unshift(this.baseUrl);
        return args.join(this.delimiter);
    }

    getQueryParameters(params: any): HttpParams {
        const paramKeys = Object.keys(params);
        let httpParams = new HttpParams();

        for (const propertyName of paramKeys) {
            httpParams = httpParams.append(propertyName, params[propertyName]);
        }

        return httpParams;
    }
}