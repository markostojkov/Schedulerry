import { DatePipe } from '@angular/common';
import { ServiceOptionScheduleViewModel } from '../state/organization-state/organization-view-models.models';

export class DateTimeExtension {
  public static getWorkingTime(schedule: ServiceOptionScheduleViewModel, dayClosedText: string | undefined): string | undefined {
    if (schedule.isOpen) {
      const datePipe = new DatePipe('en');

      return `${datePipe.transform(schedule.timeOpen.toString(), 'HH:mm')} - ${datePipe.transform(
        schedule.timeCloses.toString(),
        'HH:mm'
      )}`;
    }
    return dayClosedText;
  }
}
