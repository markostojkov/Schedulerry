import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import * as moment from 'moment';
import { NotificationService } from 'src/app/core/services/notification.service';

import { OrganizationStateFacade } from 'src/app/core/state/organization-state.facade';
import { CreateServiceOptionWorkingTimeRequest } from 'src/app/core/state/organization-state/organization-state.models';
import { ServiceOptionViewModel } from 'src/app/core/state/organization-state/organization-view-models.models';
import { ButtonType } from 'src/app/shared-app/components/generic/button/button.models';
import { DaysOfWeek, DAYS_OF_WEEK_REPRESENTATION } from 'src/app/shared-app/models/service-option.models';

class ScheduleDayForm {
  constructor(public dayOfWeek: DaysOfWeek, public timeOpen: FormControl, public workingTime: FormControl, public isOpen: boolean) {}
}

@Component({
  selector: 'app-add-service-option-schedule-dialog',
  templateUrl: './add-service-option-schedule-dialog.component.html',
  styleUrls: ['./add-service-option-schedule-dialog.component.scss']
})
export class AddServiceOptionScheduleDialogComponent implements OnInit {
  public serviceOption!: ServiceOptionViewModel;
  public serviceUid!: string;

  public ButtonType = ButtonType;
  public daysOfWeek = DAYS_OF_WEEK_REPRESENTATION;
  public daysOfWeekEditOpen = [false, false, false, false, false, false, false];
  public daysOfWeekForm = new Array<ScheduleDayForm>();

  public formGroup = new FormGroup({});

  constructor(
    public dialogRef: MatDialogRef<AddServiceOptionScheduleDialogComponent>,
    private organizationFacade: OrganizationStateFacade,
    private notification: NotificationService
  ) {}

  ngOnInit(): void {
    this.daysOfWeekForm = this.serviceOption.serviceOptionSchedules.map((dayOfWeekSchedule, i) => {
      const worktimeStart = `${dayOfWeekSchedule.timeOpen.hours()}:${dayOfWeekSchedule.timeOpen.minutes()}`;
      const worktimeEnd = `${dayOfWeekSchedule.timeCloses.hours()}:${dayOfWeekSchedule.timeCloses.minutes()}`;

      return new ScheduleDayForm(
        DAYS_OF_WEEK_REPRESENTATION[i].dayEnum,
        new FormControl(worktimeStart),
        new FormControl(worktimeEnd),
        dayOfWeekSchedule.isOpen
      );
    });

    this.daysOfWeekForm.forEach((x) => [x.timeOpen.markAsTouched(), x.workingTime.markAsTouched()]);
  }

  public save(): void {
    if (this.formIsValid()) {
      const request = this.daysOfWeekForm.map((day) => {
        const timeOpen = moment(day.timeOpen.value, [moment.ISO_8601, 'HH:mm']);
        const endingTime = moment(day.workingTime.value, [moment.ISO_8601, 'HH:mm']);
        const workingMinutes = moment.duration(endingTime.diff(timeOpen)).asMinutes();

        if (day.isOpen) {
          return new CreateServiceOptionWorkingTimeRequest(day.dayOfWeek, timeOpen, workingMinutes);
        }
        return new CreateServiceOptionWorkingTimeRequest(day.dayOfWeek, timeOpen, 0);
      });
      this.organizationFacade.createServiceOptionScheduleForServiceOption(request, this.serviceUid, this.serviceOption.uid);
      this.organizationFacade.effectError$.subscribe(() => [
        this.dialogRef.close(),
        this.notification.successNotification('add-service-options-schedule-dialog-success-edit')
      ]);
    }
  }

  public getDayOfWeekFromEnum(dayOfWeekEnum: DaysOfWeek): string | undefined {
    return DAYS_OF_WEEK_REPRESENTATION.find((x) => x.dayEnum === dayOfWeekEnum)?.dayDescription;
  }

  public dayScheduleCheckboxChanged(index: number): void {
    this.daysOfWeekEditOpen[index] = !this.daysOfWeekEditOpen[index];
  }

  private formIsValid(): boolean {
    const validForm = this.daysOfWeekForm.map((day, i) => {
      if (day.isOpen) {
        const startingTime = moment(day.timeOpen.value, [moment.ISO_8601, 'HH:mm']);
        const endingTime = moment(day.workingTime.value, [moment.ISO_8601, 'HH:mm']);

        if (startingTime.isAfter(endingTime)) {
          this.daysOfWeekForm[i].workingTime.setErrors({ endingTimeBeforeStartingTime: true });
          return false;
        }

        return true;
      }

      return true;
    });

    return !validForm.includes(false);
  }
}
