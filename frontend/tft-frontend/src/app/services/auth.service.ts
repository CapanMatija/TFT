import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { JwtHelperService } from "@auth0/angular-jwt";

export interface TokenModel {
    unique_name: string;
}

@Injectable()
export class AuthService {
    private rawToken = '';
    private jwtHelper = new JwtHelperService();
    private unique_name = '';

    constructor(protected router: Router) {}

    public getToken(): string 
    {
        return this.rawToken;
    }

    get isAuthenticated(): boolean {
        return !this.jwtHelper.isTokenExpired(this.rawToken);
    }

    get getUniqueName(): string {
        return this.unique_name;
    }
    
    setToken(token: string)
    {
        this.rawToken = token;
        this.decodeToken(token);
    }

    removeToken(): void {
        localStorage.removeItem('userToken');
        this.rawToken = '';
    }

    private decodeToken(token: string) {
        const decodedToken: TokenModel = this.jwtHelper.decodeToken(token) ?? {unique_name: ''};
        localStorage.setItem('userToken', token);
        this.unique_name = decodedToken.unique_name;
    }

    async onAppInitialize(): Promise<any> {
        const userTokenFromStorage = localStorage.getItem('userToken');

        if (userTokenFromStorage == null || userTokenFromStorage == '' || userTokenFromStorage == 'undefined') {
            return null;
        }

        this.setToken(userTokenFromStorage);
        if (!this.isAuthenticated) {
            this.logout()
        }
    }

    logout(): void {
        this.removeToken();
        this.router.navigate([''])
    }
}

export function initToken(authService: AuthService) {
    return () => {
        return authService.onAppInitialize();
    }
}