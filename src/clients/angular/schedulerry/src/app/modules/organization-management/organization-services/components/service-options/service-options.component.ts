import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { DateTimeExtension } from 'src/app/core/extensions/DateTimeExtension';

import { OrganizationStateFacade } from 'src/app/core/state/organization-state.facade';
import {
  ServiceOptionScheduleViewModel,
  ServiceOptionViewModel,
  ServiceViewModel
} from 'src/app/core/state/organization-state/organization-view-models.models';
import { ButtonType } from 'src/app/shared-app/components/generic/button/button.models';
import { DaysOfWeek, DAYS_OF_WEEK_REPRESENTATION } from 'src/app/shared-app/models/service-option.models';
import { TranslateFromJsonService } from 'src/app/shared-app/services';
import { OrganizationServicesDialog } from '../../organization-services-dialog.service';

@Component({
  selector: 'app-service-options',
  templateUrl: './service-options.component.html',
  styleUrls: ['./service-options.component.scss']
})
export class ServiceOptionsComponent implements OnInit {
  public ButtonType = ButtonType;
  public service!: ServiceViewModel;
  public serviceUid!: string;

  constructor(
    private route: ActivatedRoute,
    private organizationFacade: OrganizationStateFacade,
    private dialog: OrganizationServicesDialog,
    private translate: TranslateFromJsonService
  ) {}

  ngOnInit(): void {
    this.route.params
      .pipe(
        switchMap((params) => {
          this.serviceUid = params.serviceUid;
          return this.organizationFacade.getOrganizationServices$;
        })
      )
      .subscribe((services) => {
        const service = services?.find((x) => x.uid === this.serviceUid);

        if (service) {
          this.service = service;
        }
      });
  }

  public newServiceOption(): void {
    this.dialog.addServiceOptionDialog(this.service);
  }

  public serviceOptionSchedule(serviceOption: ServiceOptionViewModel): void {
    this.dialog.addServiceOptionSchedulesDialog(serviceOption, this.serviceUid);
  }

  public getWorkingTime(schedule: ServiceOptionScheduleViewModel): string | undefined {
    return DateTimeExtension.getWorkingTime(schedule, this.translate.instant('services-options-schedule-day-closed'));
  }

  public getDayOfWeekFromEnum(dayOfWeekEnum: DaysOfWeek): string | undefined {
    return DAYS_OF_WEEK_REPRESENTATION.find((x) => x.dayEnum === dayOfWeekEnum)?.dayDescription;
  }
}
