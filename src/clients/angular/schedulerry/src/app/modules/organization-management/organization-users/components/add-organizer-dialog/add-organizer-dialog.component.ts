import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { filter, switchMap } from 'rxjs/operators';

import { OrganizationStateFacade } from 'src/app/core/state/organization-state.facade';
import { AddOrganizerForOrganizationRequest } from 'src/app/core/state/organization-state/organization-state.models';
import { ButtonType } from 'src/app/shared-app/components/generic/button/button.models';
import { FormValidators } from 'src/app/shared-app/validators/form-validators.validator';

@Component({
  selector: 'app-add-organizer-dialog',
  templateUrl: './add-organizer-dialog.component.html',
  styleUrls: ['./add-organizer-dialog.component.scss']
})
export class AddOrganizerDialogComponent implements OnInit {
  public formGroup: FormGroup;
  public organizerUsername = new FormControl('', [Validators.required, Validators.maxLength(256)]);
  public organizerEmail = new FormControl('', [Validators.required, Validators.email, Validators.maxLength(256)]);

  public ButtonType = ButtonType;

  constructor(public dialogRef: MatDialogRef<AddOrganizerDialogComponent>, private organizationFacade: OrganizationStateFacade) {
    this.formGroup = new FormGroup({
      Username: this.organizerUsername,
      Email: this.organizerEmail
    });
  }
  ngOnInit(): void {}

  save(): void {
    this.organizationFacade.addOrganizerForOrganization(
      new AddOrganizerForOrganizationRequest(this.organizerEmail.value, this.organizerUsername.value)
    );

    this.organizationFacade.effectError$.subscribe((err) => {
      if (err === true) {
        this.dialogRef.close();
      }

      if (err instanceof HttpErrorResponse) {
        FormValidators.setFormServerErrors(this.formGroup, err.error);
      }
    });
  }
}
