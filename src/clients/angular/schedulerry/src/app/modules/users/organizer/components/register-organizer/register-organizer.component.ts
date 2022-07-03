import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';

import { AuthService } from 'src/app/core/services';
import { ButtonType } from 'src/app/shared-app/components/generic/button/button.models';
import { FormValidators } from 'src/app/shared-app/validators/form-validators.validator';
import { RegisterOrganizerRequest } from '../../models';
import { OrganizerUserApiService } from '../../services';

@Component({
  selector: 'app-register-organizer',
  templateUrl: './register-organizer.component.html',
  styleUrls: ['./register-organizer.component.scss']
})
export class RegisterOrganizerComponent implements OnInit {
  public ButtonType = ButtonType;
  public successfullRegistration = false;
  public image = 'assets/images/register-bg.jpg';

  public formGroup: FormGroup;
  public organizationName = new FormControl('', [Validators.required, Validators.maxLength(200)]);
  public organizerUsername = new FormControl('', [Validators.required, Validators.maxLength(256)]);
  public organizerEmail = new FormControl('', [Validators.required, Validators.email, Validators.maxLength(256)]);
  public organizerPassword = new FormControl('', [
    Validators.required,
    Validators.maxLength(50),
    Validators.minLength(6),
    FormValidators.passwordStrength
  ]);
  public organizerConfirmPassword = new FormControl('', []);
  public termsAndConditionCheckbox = new FormControl(true, [Validators.required]);

  constructor(private api: OrganizerUserApiService, private auth: AuthService) {
    this.formGroup = new FormGroup(
      {
        OrganizationName: this.organizationName,
        OrganizerUsername: this.organizerUsername,
        OrganizerEmail: this.organizerEmail,
        OrganizerPassword: this.organizerPassword,
        OrganizerConfirmPassword: this.organizerConfirmPassword,
        TermsAndConditionCheckbox: this.termsAndConditionCheckbox
      },
      { validators: this.passwordMatch }
    );
  }

  ngOnInit(): void {}

  public register(): void {
    const request = new RegisterOrganizerRequest(
      this.organizationName.value,
      this.organizerUsername.value,
      this.organizerEmail.value,
      this.organizerPassword.value,
      this.organizerConfirmPassword.value
    );

    this.api.registerOrganizer(request).subscribe(
      () => {
        this.successfullRegistration = true;
        this.formGroup.reset();
        Object.keys(this.formGroup.controls).forEach((key) => {
          this.formGroup.get(key)?.setErrors(null);
        });
      },
      (err) => {
        FormValidators.setFormServerErrors(this.formGroup, err.error);
      }
    );
  }

  public goToLogin(): void {
    this.auth.login();
  }

  private passwordMatch(control: AbstractControl): ValidationErrors | null {
    const password = control.get('OrganizerPassword')?.value;
    const confirmPassword = control.get('OrganizerConfirmPassword')?.value;

    if (password === confirmPassword) {
      control.get('OrganizerConfirmPassword')?.setErrors(null);
      return null;
    }

    control.get('OrganizerConfirmPassword')?.setErrors({ passwordNotMatch: true });
    return { passwordNotMatch: true };
  }
}
