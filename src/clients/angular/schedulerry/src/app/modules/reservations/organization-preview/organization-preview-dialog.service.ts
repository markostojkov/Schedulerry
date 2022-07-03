import { Injectable } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { ServiceOptionViewModel } from 'src/app/core/state/organization-state/organization-view-models.models';
import { ScheduleAppointmentDialogComponent } from './components/schedule-appointment-dialog/schedule-appointment-dialog.component';

@Injectable()
export class OrganizationPreviewDialogService {
  constructor(private dialog: MatDialog) {}

  public scheduleAppointment(serviceOption: ServiceOptionViewModel, serviceUid: string): Observable<any> {
    let dialogRef: MatDialogRef<ScheduleAppointmentDialogComponent>;
    dialogRef = this.dialog.open(ScheduleAppointmentDialogComponent, {
      width: '950px',
      height: 'auto'
    });

    dialogRef.componentInstance.serviceOption = serviceOption;
    dialogRef.componentInstance.serviceUid = serviceUid;

    return dialogRef.afterClosed();
  }
}
