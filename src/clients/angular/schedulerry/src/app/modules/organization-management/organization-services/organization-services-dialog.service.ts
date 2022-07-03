import { Injectable } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { ServiceOptionViewModel, ServiceViewModel } from 'src/app/core/state/organization-state/organization-view-models.models';

import { AddServiceDialogComponent } from './components/add-service-dialog/add-service-dialog.component';
import { AddServiceOptionDialogComponent } from './components/add-service-option-dialog/add-service-option-dialog.component';
import { AddServiceOptionScheduleDialogComponent } from './components/add-service-option-schedule-dialog/add-service-option-schedule-dialog.component';

@Injectable()
export class OrganizationServicesDialog {
  constructor(private dialog: MatDialog) {}

  public addServiceDialog(): Observable<any> {
    let dialogRef: MatDialogRef<AddServiceDialogComponent>;
    dialogRef = this.dialog.open(AddServiceDialogComponent, {
      width: '650px',
      height: 'auto'
    });

    return dialogRef.afterClosed();
  }

  public addServiceOptionDialog(service: ServiceViewModel): Observable<any> {
    let dialogRef: MatDialogRef<AddServiceOptionDialogComponent>;
    dialogRef = this.dialog.open(AddServiceOptionDialogComponent, {
      width: '650px',
      height: 'auto'
    });

    dialogRef.componentInstance.service = service;

    return dialogRef.afterClosed();
  }

  public addServiceOptionSchedulesDialog(serviceOption: ServiceOptionViewModel, serviceUid: string): Observable<any> {
    let dialogRef: MatDialogRef<AddServiceOptionScheduleDialogComponent>;
    dialogRef = this.dialog.open(AddServiceOptionScheduleDialogComponent, {
      width: '650px',
      height: 'auto'
    });

    dialogRef.componentInstance.serviceOption = serviceOption;
    dialogRef.componentInstance.serviceUid = serviceUid;

    return dialogRef.afterClosed();
  }
}
