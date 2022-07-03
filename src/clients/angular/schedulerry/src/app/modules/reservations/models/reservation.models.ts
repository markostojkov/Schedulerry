import * as moment from 'moment';

export class ReservationForServiceOptionResponse {
  reservationUid!: string;
  dateTimeOfReservation!: moment.Moment;
  dateTimeOfReservationEnding!: moment.Moment;
  reservationLastsForMinutes!: number;
}

export class ReservationForServiceOptionViewModel {
  constructor(
    public reservationUid: string,
    public dateTimeOfReservation: moment.Moment,
    public dateTimeOfReservationEnding: moment.Moment,
    public reservationLastsForMinutes: number
  ) {}
}

export class ScheduleReservationDto {
  constructor(public date: moment.Moment, public avaliable: boolean) {}
}

export class PreviewScheduleInterval {
  constructor(public date: moment.Moment, public dateFinish: moment.Moment) {}
}
