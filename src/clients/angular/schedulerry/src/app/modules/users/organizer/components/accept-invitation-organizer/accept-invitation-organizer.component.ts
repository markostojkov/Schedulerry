import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

import { AuthService } from 'src/app/core/services';
import { NotificationService } from 'src/app/core/services/notification.service';
import { ButtonType } from 'src/app/shared-app/components/generic/button/button.models';
import { FormValidators } from 'src/app/shared-app/validators/form-validators.validator';
import { AcceptInvitationOrganizerRequest } from '../../models';
import { OrganizerUserApiService } from '../../services';

@Component({
  selector: 'app-accept-invitation-organizer',
  templateUrl: './accept-invitation-organizer.component.html',
  styleUrls: ['./accept-invitation-organizer.component.scss']
})
export class AcceptInvitationOrganizerComponent implements OnInit {
  public formGroup: FormGroup;
  public organizerPassword = new FormControl('', [
    Validators.required,
    Validators.maxLength(50),
    Validators.minLength(6),
    FormValidators.passwordStrength
  ]);
  public organizerConfirmPassword = new FormControl('', []);
  public termsAndConditionCheckbox = new FormControl(true, [Validators.required]);

  public isVerified = false;
  public passwordCard = true;
  public ButtonType = ButtonType;
  private verificationCode = '';

  constructor(
    private route: ActivatedRoute,
    private api: OrganizerUserApiService,
    private auth: AuthService,
    private notification: NotificationService
  ) {
    this.formGroup = new FormGroup(
      {
        OrganizerPassword: this.organizerPassword,
        OrganizerConfirmPassword: this.organizerConfirmPassword,
        TermsAndConditionCheckbox: this.termsAndConditionCheckbox
      },
      { validators: this.passwordMatch }
    );
  }

  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      this.verificationCode = params.code;
    });
  }

  public setPasswordAndVerify(): void {
    this.api
      .acceptInvitationOrganizer(
        this.verificationCode,
        new AcceptInvitationOrganizerRequest(this.organizerPassword.value, this.organizerConfirmPassword.value)
      )
      .subscribe(
        () => {
          this.isVerified = true;
          this.passwordCard = false;
        },
        (error) => {
          this.notification.handleErrorsNotification(error.error);
          this.isVerified = false;
          this.passwordCard = false;
        }
      );
  }

  public login(): void {
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
