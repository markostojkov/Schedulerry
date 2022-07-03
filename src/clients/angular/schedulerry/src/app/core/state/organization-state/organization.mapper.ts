import * as moment from 'moment';
import {
  AddOrganizerForOrganizationResponse,
  CreateServiceForOrganizationResponse,
  CreateServiceOptionForOrganizationResponse,
  CreateServiceOptionWorkingTimeResponse,
  OrganizationStateResponse,
  ServiceOptionScheduleStateResponse,
  ServiceOptionStateResponse,
  ServiceStateResponse
} from './organization-state.models';
import {
  OrganizationViewModel,
  OrganizerViewModel,
  ServiceOptionScheduleViewModel,
  ServiceOptionViewModel,
  ServiceViewModel
} from './organization-view-models.models';

export class OrganizationMapper {
  public static ToOrganizationViewModel(organizationState: OrganizationStateResponse): OrganizationViewModel {
    const organizers = organizationState.organizers.map((x) => new OrganizerViewModel(x.uid, x.username, x.email, x.emailConfirmed));

    return new OrganizationViewModel(
      organizationState.organizationUid,
      organizationState.name,
      OrganizationMapper.ToServiceViewModelList(organizationState.services),
      organizers,
      organizationState.description,
      organizationState.phoneNumber
    );
  }

  public static ToOrganizerViewModel(x: AddOrganizerForOrganizationResponse): OrganizerViewModel {
    return new OrganizerViewModel(x.uid, x.username, x.email, x.emailConfirmed);
  }

  public static ToServiceViewModel(x: CreateServiceForOrganizationResponse): ServiceViewModel {
    return new ServiceViewModel(x.uid, x.name, [], x.description, x.imageUrl);
  }

  public static ToServiceViewModelList(x: ServiceStateResponse[]): ServiceViewModel[] {
    if (x.length > 0) {
      return x.map(
        (service) =>
          new ServiceViewModel(
            service.uid,
            service.name,
            OrganizationMapper.ToServiceOptionViewModelList(service.serviceOptions),
            service.description,
            service.imageUrl
          )
      );
    }

    return [];
  }

  public static ToServiceOptionViewModel(x: CreateServiceOptionForOrganizationResponse): ServiceOptionViewModel {
    return new ServiceOptionViewModel(
      x.uid,
      x.name,
      x.price,
      x.currency,
      x.serviceOptionTimeLength,
      OrganizationMapper.ToServiceOptionScheduleViewModelFromResponse(x.serviceOptionSchedules),
      x.description,
      x.imageUrl
    );
  }

  public static ToServiceOptionViewModelList(x: ServiceOptionStateResponse[]): ServiceOptionViewModel[] {
    if (x.length > 0) {
      return x.map(
        (serviceOption) =>
          new ServiceOptionViewModel(
            serviceOption.uid,
            serviceOption.name,
            serviceOption.price,
            serviceOption.currency,
            serviceOption.serviceOptionTimeLength,
            OrganizationMapper.ToServiceOptionScheduleViewModel(serviceOption.serviceOptionSchedules),
            serviceOption.description,
            serviceOption.imageUrl
          )
      );
    }

    return [];
  }

  public static ToServiceOptionScheduleViewModel(x: ServiceOptionScheduleStateResponse[]): ServiceOptionScheduleViewModel[] {
    if (x.length > 0) {
      return x.map(
        (schedule) =>
          new ServiceOptionScheduleViewModel(
            schedule.uid,
            schedule.dayOfWeek,
            moment(schedule.timeOpen),
            moment(schedule.timeOpen).add(schedule.workingTimeMinutes, 'm'),
            schedule.workingTimeMinutes !== 0
          )
      );
    }

    return [];
  }

  public static ToServiceOptionScheduleViewModelFromResponse(
    x: CreateServiceOptionWorkingTimeResponse[]
  ): ServiceOptionScheduleViewModel[] {
    if (x.length > 0) {
      return x.map(
        (schedule) =>
          new ServiceOptionScheduleViewModel(
            schedule.uid,
            schedule.dayOfWeek,
            moment(schedule.timeOpen),
            moment(schedule.timeOpen).add(schedule.workingTimeMinutes, 'm'),
            schedule.workingTimeMinutes !== 0
          )
      );
    }

    return [];
  }
}
