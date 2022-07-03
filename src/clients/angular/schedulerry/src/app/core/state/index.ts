import { ActionReducerMap } from '@ngrx/store';

import { reducer as organizationReducer } from './organization-state/organization.reducers';
import { OrganizationState } from './organization-state/organization.state';

export interface State {
  organization: OrganizationState;
}

export const reducers: ActionReducerMap<State, any> = {
  organization: organizationReducer
};
