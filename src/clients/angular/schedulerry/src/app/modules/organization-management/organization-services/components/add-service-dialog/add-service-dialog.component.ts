import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

import { OrganizationStateFacade } from 'src/app/core/state/organization-state.facade';
import { CreateServiceForOrganizationRequest } from 'src/app/core/state/organization-state/organization-state.models';
import { ButtonType } from 'src/app/shared-app/components/generic/button/button.models';
import { FormValidators } from 'src/app/shared-app/validators/form-validators.validator';
import { OrganizationManagementApiService } from '../../../api/organization-management-api.service';

@Component({
  selector: 'app-add-service-dialog',
  templateUrl: './add-service-dialog.component.html',
  styleUrls: ['./add-service-dialog.component.scss']
})
export class AddServiceDialogComponent implements OnInit {
  public formGroup: FormGroup;
  public serviceName = new FormControl('', [Validators.required, Validators.maxLength(200)]);
  public serviceDescription = new FormControl('', [Validators.maxLength(400)]);
  public imageUrl = '';

  public ButtonType = ButtonType;

  public uploadUrl$ = this.api.getUploadUrlForServiceImage();

  constructor(
    public dialogRef: MatDialogRef<AddServiceDialogComponent>,
    private api: OrganizationManagementApiService,
    private organizationFacade: OrganizationStateFacade
  ) {
    this.formGroup = new FormGroup({
      Name: this.serviceName,
      Description: this.serviceDescription
    });
  }

  ngOnInit(): void {}

  public setImageUrl(url: any): void {
    this.imageUrl = url;
  }

  public save(): void {
    this.organizationFacade.createServiceForOrganization(
      new CreateServiceForOrganizationRequest(this.serviceName.value, this.serviceDescription.value, this.imageUrl)
    );

    this.organizationFacade.effectError$.subscribe(
      () => {
        this.dialogRef.close();
      },
      (error) => {
        FormValidators.setFormServerErrors(this.formGroup, error.error);
      }
    );
  }
}
