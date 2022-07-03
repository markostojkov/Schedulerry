import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';

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
import { OrganizationPreviewDialogService } from '../../organization-preview-dialog.service';

@Component({
  selector: 'app-preview-service',
  templateUrl: './preview-service.component.html',
  styleUrls: ['./preview-service.component.scss']
})
export class PreviewServiceComponent implements OnInit {
  public service$!: Observable<ServiceViewModel | null>;
  public ButtonType = ButtonType;
  constructor(
    private route: ActivatedRoute,
    private organizationFacade: OrganizationStateFacade,
    private translate: TranslateFromJsonService,
    private dialog: OrganizationPreviewDialogService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.service$ = this.organizationFacade.getService(params.serviceUid);
    });
  }

  public getDayOfWeekFromEnum(dayOfWeekEnum: DaysOfWeek): string | undefined {
    return DAYS_OF_WEEK_REPRESENTATION.find((x) => x.dayEnum === dayOfWeekEnum)?.dayDescription;
  }

  public getWorkingTime(schedule: ServiceOptionScheduleViewModel): string | undefined {
    return DateTimeExtension.getWorkingTime(schedule, this.translate.instant('services-options-schedule-day-closed'));
  }

  public bookAppointment(serviceOption: ServiceOptionViewModel, serviceUid: string): void {
    this.dialog.scheduleAppointment(serviceOption, serviceUid);
  }
}
