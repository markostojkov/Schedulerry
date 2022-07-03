import { Injectable } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Observable } from 'rxjs';

import { AddOrganizerDialogComponent } from './components/add-organizer-dialog/add-organizer-dialog.component';

@Injectable()
export class OrganizationUsersDialogService {
  constructor(private dialog: MatDialog) {}

  public addOrganizerDialog(): Observable<any> {
    let dialogRef: MatDialogRef<AddOrganizerDialogComponent>;
    dialogRef = this.dialog.open(AddOrganizerDialogComponent, {
      width: '650px',
      height: 'auto'
    });

    return dialogRef.afterClosed();
  }
}
