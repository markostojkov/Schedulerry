import { OrganizationAction, OrganizationActionTypes } from './organization.actions';
import { initialState, OrganizationState } from './organization.state';

export function reducer(state = initialState, action: OrganizationAction): OrganizationState {
  switch (action.type) {
    case OrganizationActionTypes.GetOrganizationStateSuccess:
    case OrganizationActionTypes.GetOrganizationStateForPreviewSuccess: {
      return {
        ...state,
        uid: action.payload.uid,
        name: action.payload.name,
        description: action.payload.description,
        phoneNumber: action.payload.phoneNumber,
        services: action.payload.services,
        organizers: action.payload.organizers
      };
    }

    case OrganizationActionTypes.CreateServiceForOrganizationSuccess: {
      if (state.services) {
        return {
          ...state,
          services: [...state.services, action.payload]
        };
      }

      return {
        ...state,
        services: [action.payload]
      };
    }

    case OrganizationActionTypes.CreateServiceOptionForOrganizationSuccess: {
      if (state.services) {
        return {
          ...state,
          services: state.services.map((x) => {
            if (x.uid === action.serviceUid) {
              return {
                ...x,
                serviceOptions: [...x.serviceOptions, action.payload]
              };
            }

            return x;
          })
        };
      }

      return {
        ...state
      };
    }

    case OrganizationActionTypes.CreateServiceScheduleForServiceOptionSuccess: {
      if (state.services) {
        return {
          ...state,
          services: state.services.map((service) => {
            if (service.uid === action.serviceUid) {
              return {
                ...service,
                serviceOptions: service.serviceOptions.map((serviceOption) => {
                  if (serviceOption.uid === action.serviceOptionUid) {
                    return {
                      ...serviceOption,
                      serviceOptionSchedules: action.payload
                    };
                  }

                  return serviceOption;
                })
              };
            }

            return service;
          })
        };
      }

      return {
        ...state
      };
    }

    case OrganizationActionTypes.AddOrganizerForOrganizationSuccess: {
      if (state.organizers) {
        return {
          ...state,
          organizers: [...state.organizers, action.payload]
        };
      }
      return {
        ...state,
        organizers: [action.payload]
      };
    }

    case OrganizationActionTypes.EffectStartedWorking: {
      return {
        ...state,
        effectWorking: true
      };
    }

    case OrganizationActionTypes.EffectFinishedWorking: {
      return {
        ...state,
        effectWorking: false,
        effectError: true
      };
    }

    case OrganizationActionTypes.EffectFinishedWorkingError: {
      return {
        ...state,
        effectError: action.payload
      };
    }

    default: {
      return {
        ...state
      };
    }
  }
}
