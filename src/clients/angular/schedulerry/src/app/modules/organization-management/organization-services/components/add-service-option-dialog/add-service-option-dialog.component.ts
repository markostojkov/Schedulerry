import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Observable } from 'rxjs';

import { OrganizationStateFacade } from 'src/app/core/state/organization-state.facade';
import { CreateServiceOptionForOrganizationRequest } from 'src/app/core/state/organization-state/organization-state.models';
import { ServiceViewModel } from 'src/app/core/state/organization-state/organization-view-models.models';
import { ButtonType } from 'src/app/shared-app/components/generic/button/button.models';
import { FormValidators } from 'src/app/shared-app/validators/form-validators.validator';
import { CURRENCIES } from 'src/assets/currencies';
import { SERVICE_OPTION_TIMESPAN_MINUTES } from 'src/assets/service-option-timespans';
import { OrganizationManagementApiService } from '../../../api/organization-management-api.service';

@Component({
  selector: 'app-add-service-option-dialog',
  templateUrl: './add-service-option-dialog.component.html',
  styleUrls: ['./add-service-option-dialog.component.scss']
})
export class AddServiceOptionDialogComponent implements OnInit {
  public formGroup: FormGroup;
  public serviceOptionName = new FormControl('', [Validators.required, Validators.maxLength(200)]);
  public serviceOptionDescription = new FormControl('', [Validators.maxLength(400)]);
  public serviceOptionTimeLength = new FormControl('', [Validators.required]);
  public serviceOptionPrice = new FormControl(null, [Validators.required]);
  public serviceOptionCurrency = new FormControl('', [Validators.required]);

  public imageUrl = '';
  public service!: ServiceViewModel;

  public ButtonType = ButtonType;
  public currencies = CURRENCIES;
  public serviceTimespans = SERVICE_OPTION_TIMESPAN_MINUTES;

  public uploadUrl$!: Observable<string>;

  constructor(
    public dialogRef: MatDialogRef<AddServiceOptionDialogComponent>,
    private api: OrganizationManagementApiService,
    private organizationFacade: OrganizationStateFacade
  ) {
    this.formGroup = new FormGroup({
      Name: this.serviceOptionName,
      Description: this.serviceOptionDescription,
      TimeLength: this.serviceOptionTimeLength,
      Price: this.serviceOptionPrice,
      Currency: this.serviceOptionCurrency
    });
  }

  ngOnInit(): void {
    this.uploadUrl$ = this.api.getUploadUrlForServiceOptionImage(this.service.uid);
  }

  public setImageUrl(url: any): void {
    this.imageUrl = url;
  }

  public save(): void {
    this.organizationFacade.createServiceOptionForOrganization(
      new CreateServiceOptionForOrganizationRequest(
        this.serviceOptionName.value,
        this.serviceOptionDescription.value,
        this.imageUrl,
        this.serviceOptionTimeLength.value,
        this.serviceOptionPrice.value,
        this.serviceOptionCurrency.value
      ),
      this.service.uid
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
