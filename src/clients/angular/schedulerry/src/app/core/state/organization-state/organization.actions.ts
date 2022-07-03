import { HttpErrorResponse } from '@angular/common/http';
import { Action } from '@ngrx/store';
import {
  AddOrganizerForOrganizationRequest,
  CreateServiceForOrganizationRequest,
  CreateServiceOptionForOrganizationRequest,
  CreateServiceOptionWorkingTimeRequest
} from './organization-state.models';
import {
  OrganizationViewModel,
  OrganizerViewModel,
  ServiceOptionScheduleViewModel,
  ServiceOptionViewModel,
  ServiceViewModel
} from './organization-view-models.models';

export enum OrganizationActionTypes {
  GetOrganizationState = '[Organization] Get state',
  GetOrganizationStateSuccess = '[Organization] Get state success',
  GetOrganizationStateForPreview = '[Organization] Get state preview',
  GetOrganizationStateForPreviewSuccess = '[Organization] Get state preview success',
  CreateServiceScheduleForServiceOption = '[Organization] Create service option schedule',
  CreateServiceScheduleForServiceOptionSuccess = '[Organization] Create service option schedule success',
  CreateServiceForOrganization = '[Organization] Create service',
  CreateServiceForOrganizationSuccess = '[Organization] Create service success',
  CreateServiceOptionForOrganization = '[Organization] Create service option',
  CreateServiceOptionForOrganizationSuccess = '[Organization] Create service option success',
  AddOrganizerForOrganization = '[Organization] Add organizer',
  AddOrganizerForOrganizationSuccess = '[Organization] Add organizer success',
  EffectStartedWorking = '[Organization] Effect Started Working',
  EffectFinishedWorking = '[Organization] Effect Finished Working',
  EffectFinishedWorkingError = '[Organization] Effect Finished Working error'
}

export class GetOrganizationState implements Action {
  readonly type = OrganizationActionTypes.GetOrganizationState;

  constructor(public organizationUid: string) {}
}

export class GetOrganizationStateSuccess implements Action {
  readonly type = OrganizationActionTypes.GetOrganizationStateSuccess;

  constructor(public payload: OrganizationViewModel) {}
}

export class GetOrganizationStateForPreview implements Action {
  readonly type = OrganizationActionTypes.GetOrganizationStateForPreview;

  constructor(public organizationUid: string) {}
}

export class GetOrganizationStateForPreviewSuccess implements Action {
  readonly type = OrganizationActionTypes.GetOrganizationStateForPreviewSuccess;

  constructor(public payload: OrganizationViewModel) {}
}

export class CreateServiceScheduleForServiceOption implements Action {
  readonly type = OrganizationActionTypes.CreateServiceScheduleForServiceOption;

  constructor(public request: CreateServiceOptionWorkingTimeRequest[], public serviceUid: string, public serviceOptionUid: string) {}
}

export class CreateServiceScheduleForServiceOptionSuccess implements Action {
  readonly type = OrganizationActionTypes.CreateServiceScheduleForServiceOptionSuccess;

  constructor(public payload: ServiceOptionScheduleViewModel[], public serviceOptionUid: string, public serviceUid: string) {}
}

export class CreateServiceForOrganization implements Action {
  readonly type = OrganizationActionTypes.CreateServiceForOrganization;

  constructor(public request: CreateServiceForOrganizationRequest) {}
}

export class CreateServiceForOrganizationSuccess implements Action {
  readonly type = OrganizationActionTypes.CreateServiceForOrganizationSuccess;

  constructor(public payload: ServiceViewModel) {}
}

export class CreateServiceOptionForOrganization implements Action {
  readonly type = OrganizationActionTypes.CreateServiceOptionForOrganization;

  constructor(public request: CreateServiceOptionForOrganizationRequest, public serviceUid: string) {}
}

export class CreateServiceOptionForOrganizationSuccess implements Action {
  readonly type = OrganizationActionTypes.CreateServiceOptionForOrganizationSuccess;

  constructor(public payload: ServiceOptionViewModel, public serviceUid: string) {}
}

export class AddOrganizerForOrganization implements Action {
  readonly type = OrganizationActionTypes.AddOrganizerForOrganization;

  constructor(public request: AddOrganizerForOrganizationRequest) {}
}

export class AddOrganizerForOrganizationSuccess implements Action {
  readonly type = OrganizationActionTypes.AddOrganizerForOrganizationSuccess;

  constructor(public payload: OrganizerViewModel) {}
}

export class EffectStartedWorking implements Action {
  readonly type = OrganizationActionTypes.EffectStartedWorking;

  constructor() {}
}

export class EffectFinishedWorking implements Action {
  readonly type = OrganizationActionTypes.EffectFinishedWorking;

  constructor() {}
}

export class EffectFinishedWorkingError implements Action {
  readonly type = OrganizationActionTypes.EffectFinishedWorkingError;

  constructor(public payload: HttpErrorResponse) {}
}

export type OrganizationAction =
  | GetOrganizationStateSuccess
  | GetOrganizationStateForPreviewSuccess
  | CreateServiceForOrganizationSuccess
  | CreateServiceOptionForOrganizationSuccess
  | CreateServiceScheduleForServiceOptionSuccess
  | AddOrganizerForOrganizationSuccess
  | EffectStartedWorking
  | EffectFinishedWorking
  | EffectFinishedWorkingError;
