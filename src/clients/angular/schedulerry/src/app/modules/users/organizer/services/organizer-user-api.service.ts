import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { BaseApiService } from 'src/app/shared-app/services/base-api.service';
import { AcceptInvitationOrganizerRequest, RegisterOrganizerRequest } from '../models';

@Injectable({
  providedIn: 'root'
})
export class OrganizerUserApiService extends BaseApiService {
  constructor(protected http: HttpClient) {
    super(http);
  }

  public registerOrganizer(body: RegisterOrganizerRequest): Observable<void> {
    return this.post('organizations', body);
  }

  public verifyOrganizer(verificationCode: string): Observable<void> {
    return this.post(`organizers/verify/${verificationCode}`);
  }

  public acceptInvitationOrganizer(verificationCode: string, request: AcceptInvitationOrganizerRequest): Observable<void> {
    return this.post(`organizers/accept-invitation/${verificationCode}`, request);
  }
}
