import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl, ValidationErrors } from '@angular/forms';

import { AuthService } from 'src/app/core/services';
import { ButtonType } from 'src/app/shared-app/components/generic/button/button.models';
import { FormValidators } from 'src/app/shared-app/validators/form-validators.validator';
import { CustomerRegisterRequest } from '../../models';
import { CustomerUserApiService } from '../../services';

@Component({
  selector: 'app-register-customer',
  templateUrl: './register-customer.component.html',
  styleUrls: ['./register-customer.component.scss']
})
export class RegisterCustomerComponent implements OnInit {
  public ButtonType = ButtonType;
  public successfullRegistration = false;

  public formGroup: FormGroup;
  public customerUsername = new FormControl('', [Validators.required, Validators.maxLength(256)]);
  public customerEmail = new FormControl('', [Validators.required, Validators.email, Validators.maxLength(256)]);
  public customerPassword = new FormControl('', [
    Validators.required,
    Validators.maxLength(50),
    Validators.minLength(6),
    FormValidators.passwordStrength
  ]);
  public customerConfirmPassword = new FormControl('', []);
  public termsAndConditionCheckbox = new FormControl(true, [Validators.required]);

  constructor(private api: CustomerUserApiService, private auth: AuthService) {
    this.formGroup = new FormGroup(
      {
        CustomerUsername: this.customerUsername,
        CustomerEmail: this.customerEmail,
        CustomerPassword: this.customerPassword,
        CustomerConfirmPassword: this.customerConfirmPassword,
        TermsAndConditionCheckbox: this.termsAndConditionCheckbox
      },
      { validators: this.passwordMatch }
    );
  }

  ngOnInit(): void {}

  public register(): void {
    const request = new CustomerRegisterRequest(
      this.customerUsername.value,
      this.customerEmail.value,
      this.customerPassword.value,
      this.customerConfirmPassword.value
    );

    this.api.registerCustomer(request).subscribe(
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
    const password = control.get('CustomerPassword')?.value;
    const confirmPassword = control.get('CustomerConfirmPassword')?.value;

    if (password === confirmPassword) {
      control.get('CustomerConfirmPassword')?.setErrors(null);
      return null;
    }

    control.get('CustomerConfirmPassword')?.setErrors({ passwordNotMatch: true });
    return { passwordNotMatch: true };
  }
}
