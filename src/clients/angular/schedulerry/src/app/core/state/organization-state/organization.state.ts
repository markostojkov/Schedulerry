import { HttpErrorResponse } from '@angular/common/http';
import { OrganizerViewModel, ServiceViewModel } from './organization-view-models.models';

export const organizationStateKey = 'organization';

export interface OrganizationState {
  uid: string | null;
  name: string | null;
  phoneNumber: string | null | undefined;
  description: string | null | undefined;
  services: ServiceViewModel[] | null;
  organizers: OrganizerViewModel[] | null;
  effectWorking: boolean;
  effectError: HttpErrorResponse | null | boolean;
}

export const initialState: OrganizationState = {
  uid: null,
  name: null,
  description: null,
  phoneNumber: null,
  services: null,
  organizers: null,
  effectWorking: false,
  effectError: null
};
