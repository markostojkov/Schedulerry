import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import * as moment from 'moment';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { BaseApiService } from 'src/app/shared-app/services/base-api.service';
import { ReservationForServiceOptionResponse, ReservationForServiceOptionViewModel } from '../models/reservation.models';

@Injectable({
  providedIn: 'root'
})
export class ReservationsApiService extends BaseApiService {
  constructor(protected http: HttpClient) {
    super(http);
  }

  public getReservationsForServiceOptionInInterval(
    start: moment.Moment,
    end: moment.Moment,
    serviceUid: string,
    serviceOptionUid: string
  ): Observable<ReservationForServiceOptionViewModel[]> {
    return this.get<ReservationForServiceOptionResponse[]>(
      `reservations/services/${serviceUid}/serviceoptions/${serviceOptionUid}?startDate=${start.toISOString()}&endDate=${end.toISOString()}`
    ).pipe(
      map((x) =>
        x.map(
          (y) =>
            new ReservationForServiceOptionViewModel(
              y.reservationUid,
              moment(y.dateTimeOfReservation),
              moment(y.dateTimeOfReservationEnding),
              y.reservationLastsForMinutes
            )
        )
      )
    );
  }
}
