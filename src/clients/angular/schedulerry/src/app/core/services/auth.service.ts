import { Injectable } from '@angular/core';
import { UserManager } from 'oidc-client';
import { Observable, from, of } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';

import { environment } from '@env/environment';
import { ApplicationUser, SelfUserResponse } from 'src/app/shared-app/models';
import { BaseApiService } from 'src/app/shared-app/services/base-api.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private userManager: UserManager = new UserManager({
    authority: environment.identityRoute,
    client_id: environment.identityClientId,
    redirect_uri: `${window.location.origin}`,
    response_type: 'id_token token',
    scope: 'openid app.api.schedulerry profile',
    post_logout_redirect_uri: window.location.origin
  });

  constructor(private baseApi: BaseApiService) {}

  public login(): void {
    this.userManager.signinRedirect();
  }

  public logout(): void {
    this.userManager.signoutRedirect();
  }

  public isLoggedIn(): Observable<boolean> {
    return from(this.userManager.getUser()).pipe(
      map((user) => {
        if (user) {
          return true;
        }

        return false;
      })
    );
  }

  public currentUser(): Observable<ApplicationUser | null> {
    return from(this.userManager.getUser()).pipe(
      map((user) => {
        if (!user) {
          return null;
        }

        return new ApplicationUser(
          user.profile.id,
          user.profile.userType,
          user.profile.emailAddress,
          user.profile.username,
          user.profile.isVerified
        );
      })
    );
  }

  public currentUserToken(): Observable<string> {
    return from(this.userManager.getUser()).pipe(
      map((user) => {
        if (user?.access_token) {
          return user.access_token;
        }

        return '';
      })
    );
  }

  public selfUserDto(): Observable<SelfUserResponse | null> {
    return this.isLoggedIn().pipe(
      switchMap((loggedIn) => {
        if (loggedIn) {
          return this.baseApi.getSelfUser();
        }
        return of(null);
      })
    );
  }

  public signupCallback(): Observable<boolean> {
    return from(this.userManager.signinRedirectCallback()).pipe(map((user) => user !== null));
  }
}
