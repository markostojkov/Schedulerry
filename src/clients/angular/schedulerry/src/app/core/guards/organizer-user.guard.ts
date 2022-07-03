import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ApplicationUserType } from 'src/app/shared-app/models';
import { AuthService } from '../services';

@Injectable({
  providedIn: 'root'
})
export class OrganizerUserGuard implements CanActivate {
  constructor(private auth: AuthService, private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
    return this.auth.currentUser().pipe(
      map((user) => {
        if (!user) {
          this.router.navigateByUrl('/');
          return false;
        }

        return user.userType === ApplicationUserType.Organizer;
      })
    );
  }
}
