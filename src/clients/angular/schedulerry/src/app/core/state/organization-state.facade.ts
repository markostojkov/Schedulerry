import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Action, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { filter, map, skip } from 'rxjs/operators';

import {
  AddOrganizerForOrganizationRequest,
  CreateServiceForOrganizationRequest,
  CreateServiceOptionForOrganizationRequest,
  CreateServiceOptionWorkingTimeRequest
} from './organization-state/organization-state.models';
import { OrganizerViewModel, ServiceViewModel } from './organization-state/organization-view-models.models';
import {
  AddOrganizerForOrganization,
  CreateServiceForOrganization,
  CreateServiceOptionForOrganization,
  CreateServiceScheduleForServiceOption,
  EffectStartedWorking,
  GetOrganizationState,
  GetOrganizationStateForPreview
} from './organization-state/organization.actions';
import { organizationStateQuery } from './organization-state/organization.selectors';
import { OrganizationState } from './organization-state/organization.state';

@Injectable({
  providedIn: 'root'
})
export class OrganizationStateFacade {
  getOrganizationServices$: Observable<ServiceViewModel[] | null>;
  getOrganizationOrganizers$: Observable<OrganizerViewModel[] | null>;
  getOrganization$: Observable<OrganizationState>;
  getOrganizationName$: Observable<string | null>;
  getOrganizationUid$: Observable<string | null>;

  effectWorking$: Observable<boolean | HttpErrorResponse>;
  effectError$: Observable<HttpErrorResponse | null | boolean>;

  constructor(private store: Store<OrganizationState>) {
    this.effectWorking$ = this.store.select(organizationStateQuery.effectWorking);
    this.getOrganizationServices$ = this.store.select(organizationStateQuery.getServices);
    this.getOrganizationOrganizers$ = this.store.select(organizationStateQuery.getOrganizers);
    this.getOrganizationName$ = this.store.select(organizationStateQuery.getOrganizationName);
    this.getOrganization$ = this.store.select(organizationStateQuery.getOrganization);
    this.effectError$ = this.store.select(organizationStateQuery.effectError).pipe(skip(1));
    this.getOrganizationUid$ = this.store.select(organizationStateQuery.getOrganizationUid).pipe(filter((x) => x !== null));
  }

  public getService(serviceUid: string): Observable<ServiceViewModel | null> {
    return this.getOrganizationServices$.pipe(
      map((services) => {
        let service = null;
        services?.forEach((x) => {
          if (x.uid === serviceUid) {
            service = x;
          }
        });
        return service;
      })
    );
  }

  public fetchOrganizationState(organizationUid: string): void {
    this.dispatchEffect(new GetOrganizationState(organizationUid));
  }

  public fetchOrganizationStateForPreview(organizationUid: string): void {
    this.dispatchEffect(new GetOrganizationStateForPreview(organizationUid));
  }

  public createServiceForOrganization(request: CreateServiceForOrganizationRequest): void {
    this.dispatchEffect(new CreateServiceForOrganization(request));
  }

  public createServiceOptionForOrganization(request: CreateServiceOptionForOrganizationRequest, serviceUid: string): void {
    this.dispatchEffect(new CreateServiceOptionForOrganization(request, serviceUid));
  }

  public createServiceOptionScheduleForServiceOption(
    request: CreateServiceOptionWorkingTimeRequest[],
    serviceUid: string,
    serviceOptionUid: string
  ): void {
    this.dispatchEffect(new CreateServiceScheduleForServiceOption(request, serviceUid, serviceOptionUid));
  }

  public addOrganizerForOrganization(request: AddOrganizerForOrganizationRequest): void {
    this.dispatchEffect(new AddOrganizerForOrganization(request));
  }

  private dispatchEffect(action: Action): void {
    this.store.dispatch(new EffectStartedWorking());
    this.store.dispatch(action);
  }
}
