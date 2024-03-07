import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { UrlHelperService } from "./url-helper.service";
import { Observable, map } from "rxjs";
import { UserDetailModel } from "../models/user.models";

@Injectable({
    providedIn: 'root'
})
export class UserEntityService {

    constructor(
        private http: HttpClient,
        private urlHelper: UrlHelperService
    ) {}

    private readonly CONTROLLER_NAME = 'api/User';

    getUsers(): Observable<any[]> {
        const url = this.urlHelper.getUrl(this.CONTROLLER_NAME, 'getUsers');

        return this.http.get<any[]>(url).pipe(
            map(data => 
                {
                    console.log("Data: ", data)
                    return data;
                })
        );
    }

    getUser(Id: number): Observable<any> {
        const url = this.urlHelper.getUrl(this.CONTROLLER_NAME, Id.toString());

        return this.http.get<any[]>(url).pipe(
            map(data => 
                {
                    return data;
                })
        );
    }

    saveUser(user: UserDetailModel) {
        const url = this.urlHelper.getUrl(this.CONTROLLER_NAME);

        return this.http.post(url, user).pipe(
            map( data => {
                return data
            }) 
        );
    }
}