import { DaysOfWeek, TimeLengthMinutesOptionsEnum } from 'src/app/shared-app/models/service-option.models';

export class OrganizationViewModel {
  constructor(
    public uid: string,
    public name: string,
    public services: ServiceViewModel[],
    public organizers: OrganizerViewModel[],
    public description?: string,
    public phoneNumber?: string
  ) {}
}

export class ServiceViewModel {
  constructor(
    public uid: string,
    public name: string,
    public serviceOptions: ServiceOptionViewModel[],
    public description?: string,
    public imageUrl?: string
  ) {}
}

export class ServiceOptionViewModel {
  constructor(
    public uid: string,
    public name: string,
    public price: number,
    public currency: string,
    public serviceOptionTimeLength: TimeLengthMinutesOptionsEnum,
    public serviceOptionSchedules: ServiceOptionScheduleViewModel[],
    public description?: string,
    public imageUrl?: string
  ) {}
}

export class ServiceOptionScheduleViewModel {
  constructor(
    public uid: string,
    public dayOfWeek: DaysOfWeek,
    public timeOpen: moment.Moment,
    public timeCloses: moment.Moment,
    public isOpen: boolean
  ) {}
}

export class OrganizerViewModel {
  constructor(public uid: string, public username: string, public email: string, public emailConfirmed: boolean) {}
}
