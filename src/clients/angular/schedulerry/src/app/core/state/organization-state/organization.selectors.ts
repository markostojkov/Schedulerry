import { createFeatureSelector, createSelector } from '@ngrx/store';
import { OrganizationState, organizationStateKey } from './organization.state';

export const getOrganizationState = createFeatureSelector<OrganizationState>(organizationStateKey);

const getOrganization = createSelector(getOrganizationState, (state) => state);
const getServices = createSelector(getOrganizationState, (state) => state.services);
const getOrganizers = createSelector(getOrganizationState, (state) => state.organizers);
const getOrganizationUid = createSelector(getOrganizationState, (state) => state.uid);
const getOrganizationName = createSelector(getOrganizationState, (state) => state.name);

const effectWorking = createSelector(getOrganizationState, (state) => state.effectWorking);
const effectError = createSelector(getOrganizationState, (state) => state.effectError);

export const organizationStateQuery = {
  getServices,
  getOrganizers,
  getOrganization,
  getOrganizationUid,
  getOrganizationName,
  effectWorking,
  effectError
};
