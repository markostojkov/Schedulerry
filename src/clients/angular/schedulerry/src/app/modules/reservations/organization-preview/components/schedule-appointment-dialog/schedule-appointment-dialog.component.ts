import { ChangeDetectionStrategy, ChangeDetectorRef, Component, ElementRef, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import * as moment from 'moment';

import { ServiceOptionViewModel } from 'src/app/core/state/organization-state/organization-view-models.models';
import { ButtonType } from 'src/app/shared-app/components/generic/button/button.models';
import { ScheduleDatesDto } from 'src/app/shared-app/components/generic/date-range-with-selection-strategy/date-range-with-selection-strategy.models';
import { PreviewScheduleInterval, ReservationForServiceOptionViewModel, ScheduleReservationDto } from '../../../models/reservation.models';
import { ReservationsApiService } from '../../../services/reservations-api.service';

@Component({
  selector: 'app-schedule-appointment-dialog',
  templateUrl: './schedule-appointment-dialog.component.html',
  styleUrls: ['./schedule-appointment-dialog.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ScheduleAppointmentDialogComponent implements OnInit {
  public serviceOption!: ServiceOptionViewModel;
  public serviceUid!: string;
  public previewScheduleInterval!: PreviewScheduleInterval;
  public bookedDates!: ReservationForServiceOptionViewModel[];
  public scheduleFormField = new FormControl([Validators.required]);

  public ButtonType = ButtonType;
  public working = true;

  constructor(
    private api: ReservationsApiService,
    public dialogRef: MatDialogRef<ScheduleAppointmentDialogComponent>,
    private cd: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    const today = moment();
    const nextWeek = moment().add(6, 'days');

    this.previewScheduleInterval = new PreviewScheduleInterval(today, nextWeek);
    this.api.getReservationsForServiceOptionInInterval(today, nextWeek, this.serviceUid, this.serviceOption.uid).subscribe((res) => {
      this.bookedDates = res;
      this.working = false;
      this.cd.markForCheck();
    });
  }

  public dateRangeChanged(dates: ScheduleDatesDto): void {
    this.previewScheduleInterval = new PreviewScheduleInterval(dates.startDate, dates.endDate);
    this.api
      .getReservationsForServiceOptionInInterval(dates.startDate, dates.endDate, this.serviceUid, this.serviceOption.uid)
      .subscribe((res) => {
        this.bookedDates = res;
        this.cd.detectChanges();
      });
  }

  public save(): void {}

  public previewScheduleIntervalDates(): moment.Moment[] {
    const datesList = new Array<moment.Moment>();
    const startDate = moment(this.previewScheduleInterval.date);

    while (startDate.isSameOrBefore(this.previewScheduleInterval.dateFinish)) {
      datesList.push(moment(startDate));
      startDate.add(1, 'days');
    }

    return datesList;
  }

  public getFreeTimesForDate(date: moment.Moment): ScheduleReservationDto[] {
    const bookedTimesForDate = this.bookedDates.filter((x) => x.dateTimeOfReservation.date() === date.date());
    const freeTimesForDateStart = moment(date).set({ hour: 0, minute: 0, second: 0, millisecond: 0 });

    console.log('YE');

    return this.getTimeRanges(this.serviceOption.serviceOptionTimeLength, freeTimesForDateStart).map((x) => {
      const timeRangeEndingDateTime = moment(x).add(this.serviceOption.serviceOptionTimeLength, 'minutes');
      const timePeriodFree =
        bookedTimesForDate.filter(
          (bookedDate) =>
            bookedDate.dateTimeOfReservation.isBefore(timeRangeEndingDateTime) && x.isBefore(bookedDate.dateTimeOfReservationEnding)
        ).length === 0;

      return new ScheduleReservationDto(x, timePeriodFree);
    });
  }

  public getTimeRanges(interval: number, startDate: moment.Moment): moment.Moment[] {
    const ranges = Array<moment.Moment>();
    const date = startDate;

    for (let minutes = 0; minutes < 24 * 60; minutes = minutes + interval) {
      ranges.push(moment(date).set({ hour: 0, minute: minutes, second: 0, millisecond: 0 }));
    }

    return ranges;
  }

  public chooseTime(element: EventTarget | null): void {
    const htmlElement = element as HTMLElement;
  }
}
