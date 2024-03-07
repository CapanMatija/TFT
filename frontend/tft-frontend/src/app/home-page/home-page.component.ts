import { ChangeDetectionStrategy, ChangeDetectorRef, Component } from "@angular/core";
import { AuthService } from "../services/auth.service";
import { Router } from "@angular/router";

@Component({
    selector: 'app-home-page',
    templateUrl: './home-page.component.html',
    styleUrls: ['./home-page.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class HomePageComponent {

    constructor(private authService: AuthService, private cdref: ChangeDetectorRef, protected router: Router) {}

    onLogout(): void {
        this.authService.logout();
        this.cdref.detectChanges();
    }

  onFilmovi(): void {
    this.router.navigate(['./film'])
  }

  onKorisnickiRacun(): void {
    this.router.navigate(['./korisnicki-racun'])
  }
}