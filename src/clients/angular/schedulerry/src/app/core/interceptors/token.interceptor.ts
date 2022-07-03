import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';

import { AuthService } from '../services';
import { environment } from '@env/environment';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  constructor(private auth: AuthService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    if (!request.url.startsWith(environment.apiRoute)) {
      return next.handle(request);
    }

    return this.auth.currentUserToken().pipe(
      switchMap((token) => {
        const requestToForward = request.clone({
          setHeaders: { Authorization: `Bearer ${token}` }
        });
        return next.handle(requestToForward);
      })
    );
  }
}
