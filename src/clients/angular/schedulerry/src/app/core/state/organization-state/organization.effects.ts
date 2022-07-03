import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, mergeMap, switchMap, withLatestFrom } from 'rxjs/operators';

import { BaseApiService } from 'src/app/shared-app/services/base-api.service';
import { OrganizationStateFacade } from '../organization-state.facade';
import {
  AddOrganizerForOrganizationResponse,
  CreateServiceForOrganizationResponse,
  CreateServiceOptionForOrganizationResponse,
  CreateServiceOptionWorkingTimeResponse,
  OrganizationStateResponse
} from './organization-state.models';
import {
  AddOrganizerForOrganizationSuccess,
  CreateServiceForOrganization,
  CreateServiceForOrganizationSuccess,
  CreateServiceOptionForOrganization,
  CreateServiceOptionForOrganizationSuccess,
  CreateServiceScheduleForServiceOption,
  CreateServiceScheduleForServiceOptionSuccess,
  EffectFinishedWorking,
  EffectFinishedWorkingError,
  GetOrganizationState,
  GetOrganizationStateForPreview,
  GetOrganizationStateForPreviewSuccess,
  GetOrganizationStateSuccess,
  OrganizationActionTypes
} from './organization.actions';
import { OrganizationMapper } from './organization.mapper';

@Injectable({
  providedIn: 'root'
})
export class OrganizationEffects {
  constructor(private actions$: Actions, private api: BaseApiService, private facade: OrganizationStateFacade) {}

  getOrganizationState$ = createEffect(() => {
    return this.actions$.pipe(
      ofType<GetOrganizationState>(OrganizationActionTypes.GetOrganizationState),
      switchMap((action) => {
        return this.api.get<OrganizationStateResponse>(`organizations/${action.organizationUid}`).pipe(
          switchMap((state) => [
            new GetOrganizationStateSuccess(OrganizationMapper.ToOrganizationViewModel(state)),
            new EffectFinishedWorking()
          ]),
          catchError((err) => [new EffectFinishedWorkingError(err)])
        );
      })
    );
  });

  getOrganizationPreviewState$ = createEffect(() => {
    return this.actions$.pipe(
      ofType<GetOrganizationStateForPreview>(OrganizationActionTypes.GetOrganizationStateForPreview),
      switchMap((action) => {
        return this.api.get<OrganizationStateResponse>(`organizations/${action.organizationUid}/preview`).pipe(
          switchMap((state) => [
            new GetOrganizationStateForPreviewSuccess(OrganizationMapper.ToOrganizationViewModel(state)),
            new EffectFinishedWorking()
          ]),
          catchError((err) => [new EffectFinishedWorkingError(err)])
        );
      })
    );
  });

  createServiceForOrganization$ = createEffect(() => {
    return this.actions$.pipe(
      ofType<CreateServiceForOrganization>(OrganizationActionTypes.CreateServiceForOrganization),
      withLatestFrom(this.facade.getOrganizationUid$),
      switchMap(([action, organizationUid]) => {
        return this.api.post<CreateServiceForOrganizationResponse>(`organizations/${organizationUid}/services`, action.request).pipe(
          mergeMap((state) => [
            new CreateServiceForOrganizationSuccess(OrganizationMapper.ToServiceViewModel(state)),
            new EffectFinishedWorking()
          ]),
          catchError((err) => [new EffectFinishedWorkingError(err)])
        );
      })
    );
  });

  createServiceOptionForService$ = createEffect(() => {
    return this.actions$.pipe(
      ofType<CreateServiceOptionForOrganization>(OrganizationActionTypes.CreateServiceOptionForOrganization),
      withLatestFrom(this.facade.getOrganizationUid$),
      switchMap(([action, organizationUid]) => {
        return this.api
          .post<CreateServiceOptionForOrganizationResponse>(
            `organizations/${organizationUid}/services/${action.serviceUid}/serviceoptions`,
            action.request
          )
          .pipe(
            mergeMap((state) => [
              new CreateServiceOptionForOrganizationSuccess(OrganizationMapper.ToServiceOptionViewModel(state), state.serviceUid),
              new EffectFinishedWorking()
            ]),
            catchError((err) => [new EffectFinishedWorkingError(err)])
          );
      })
    );
  });

  createServiceOptionScheduleForServiceOption$ = createEffect(() => {
    return this.actions$.pipe(
      ofType<CreateServiceScheduleForServiceOption>(OrganizationActionTypes.CreateServiceScheduleForServiceOption),
      withLatestFrom(this.facade.getOrganizationUid$),
      switchMap(([action, organizationUid]) => {
        return this.api
          .post<CreateServiceOptionWorkingTimeResponse[]>(
            `organizations/${organizationUid}/services/${action.serviceUid}/serviceoptions/${action.serviceOptionUid}`,
            action.request
          )
          .pipe(
            mergeMap((state) => [
              new CreateServiceScheduleForServiceOptionSuccess(
                OrganizationMapper.ToServiceOptionScheduleViewModelFromResponse(state),
                action.serviceOptionUid,
                action.serviceUid
              ),
              new EffectFinishedWorking()
            ]),
            catchError((err) => [new EffectFinishedWorkingError(err)])
          );
      })
    );
  });

  addOrganizerForOrganization$ = createEffect(() => {
    return this.actions$.pipe(
      ofType<CreateServiceForOrganization>(OrganizationActionTypes.AddOrganizerForOrganization),
      withLatestFrom(this.facade.getOrganizationUid$),
      switchMap(([action, organizationUid]) => {
        return this.api.post<AddOrganizerForOrganizationResponse>(`organizations/${organizationUid}/organizers`, action.request).pipe(
          mergeMap((state) => [
            new AddOrganizerForOrganizationSuccess(OrganizationMapper.ToOrganizerViewModel(state)),
            new EffectFinishedWorking()
          ]),
          catchError((err) => [new EffectFinishedWorkingError(err)])
        );
      })
    );
  });
}
