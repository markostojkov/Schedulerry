import * as moment from 'moment';
import { DaysOfWeek, TimeLengthMinutesOptionsEnum } from 'src/app/shared-app/models/service-option.models';

export class OrganizationStateResponse {
  organizationUid!: string;
  name!: string;
  description?: string;
  phoneNumber?: string;
  services!: ServiceStateResponse[];
  organizers!: OrganizerStateResponse[];
}

export class ServiceStateResponse {
  uid!: string;
  name!: string;
  description?: string;
  imageUrl?: string;
  serviceOptions!: ServiceOptionStateResponse[];
}

export class ServiceOptionStateResponse {
  uid!: string;
  name!: string;
  description?: string;
  imageUrl?: string;
  price!: number;
  currency!: string;
  serviceOptionTimeLength!: TimeLengthMinutesOptionsEnum;
  serviceOptionSchedules!: ServiceOptionScheduleStateResponse[];
}

export class ServiceOptionScheduleStateResponse {
  uid!: string;
  dayOfWeek!: DaysOfWeek;
  timeOpen!: moment.Moment;
  workingTimeMinutes!: number;
}

export class OrganizerStateResponse {
  uid!: string;
  username!: string;
  email!: string;
  emailConfirmed!: boolean;
}

export class CreateServiceForOrganizationRequest {
  constructor(public name: string, public description: string, public imageUrl: string) {}
}

export class CreateServiceForOrganizationResponse {
  uid!: string;
  organizationUid!: string;
  name!: string;
  description!: string;
  imageUrl!: string;
}

export class CreateServiceOptionForOrganizationRequest {
  constructor(
    public name: string,
    public description: string,
    public imageUrl: string,
    public timeLength: number,
    public price: number,
    public currency: string
  ) {}
}

export class CreateServiceOptionForOrganizationResponse {
  uid!: string;
  serviceUid!: string;
  name!: string;
  description!: string;
  imageUrl!: string;
  serviceOptionTimeLength!: TimeLengthMinutesOptionsEnum;
  price!: number;
  currency!: string;
  serviceOptionSchedules!: CreateServiceOptionWorkingTimeResponse[];
}

export class CreateServiceOptionWorkingTimeRequest {
  constructor(public dayOfWeek: DaysOfWeek, public timeOpen: moment.Moment, public workingTimeMinutes: number) {}
}

export class CreateServiceOptionWorkingTimeResponse {
  uid!: string;
  serviceOptionUid!: string;
  dayOfWeek!: DaysOfWeek;
  timeOpen!: moment.Moment;
  workingTimeMinutes!: number;
}

export class AddOrganizerForOrganizationRequest {
  constructor(public organizerEmail: string, public organizerUsername: string) {}
}

export class AddOrganizerForOrganizationResponse {
  uid!: string;
  organizationUid!: string;
  username!: string;
  email!: string;
  emailConfirmed!: boolean;
}
