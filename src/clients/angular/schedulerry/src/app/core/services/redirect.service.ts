import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { switchMap } from 'rxjs/operators';

import { ApplicationUserType } from 'src/app/shared-app/models';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class RedirectService {
  constructor(private router: Router, private auth: AuthService) {}

  public redirectLoggedInUser(): void {
    this.auth
      .signupCallback()
      .pipe(switchMap(() => this.auth.currentUser()))
      .subscribe((currentUser) => {
        if (currentUser) {
          switch (currentUser.userType) {
            case ApplicationUserType.Customer:
              this.redirectCustomer();
              break;
            case ApplicationUserType.Organizer:
              this.redirectOrganizer();
              break;
          }
        }
      });
  }

  private redirectOrganizer(): void {
    this.auth.selfUserDto().subscribe((user) => {
      if (user) {
        this.router.navigateByUrl(`organizations/${user.organizationUid}/dashboard`);
      }
    });
  }

  private redirectCustomer(): void {
    this.router.navigateByUrl('public/home');
  }
}
