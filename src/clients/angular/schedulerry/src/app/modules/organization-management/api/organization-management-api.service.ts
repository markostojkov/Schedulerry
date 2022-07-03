import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { switchMap, take } from 'rxjs/operators';

import { OrganizationStateFacade } from 'src/app/core/state/organization-state.facade';
import { BaseApiService } from 'src/app/shared-app/services/base-api.service';

@Injectable({
  providedIn: 'root'
})
export class OrganizationManagementApiService extends BaseApiService {
  constructor(protected http: HttpClient, private organizationFacade: OrganizationStateFacade) {
    super(http);
  }

  public getUploadUrlForServiceImage(): Observable<string> {
    return this.organizationFacade.getOrganizationUid$.pipe(
      take(1),
      switchMap((uid) => this.get<string>(`organizations/${uid}/services/pre-signed-key`))
    );
  }

  public getUploadUrlForServiceOptionImage(serviceUid: string): Observable<string> {
    return this.organizationFacade.getOrganizationUid$.pipe(
      take(1),
      switchMap((uid) => this.get<string>(`organizations/${uid}/services/${serviceUid}/serviceoptions/pre-signed-key`))
    );
  }
}
