import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Validators,FormControl,FormGroup } from '@angular/forms';
import { environment } from './../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit{
    loginForm!: FormGroup;

    constructor(
        private httpClient: HttpClient, 
        private authService: AuthService,
        private crdef: ChangeDetectorRef
    ){}
    
    ngOnInit() {
        this.loginForm = new FormGroup({
            'login': new FormControl('', Validators.required),
            'password': new FormControl('', Validators.required)
        });
    }
    
    onSubmit() { 
        JSON.stringify(this.loginForm.value)
        this.httpClient.post(environment.apiUrl + '/api/Auth/Login', {
            Username: this.loginForm.value.login,
            Password: this.loginForm.value.password
        }).pipe(tap((x) => {
            if (x) 
            {
                const response = (x as any);
                this.authService.setToken(response.token);
                this.crdef.detectChanges();
            }
        })).subscribe();
    }
}

