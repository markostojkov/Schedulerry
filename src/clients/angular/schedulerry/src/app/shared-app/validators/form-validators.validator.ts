import { AbstractControl, FormGroup, ValidationErrors } from '@angular/forms';

export class FormValidators {
  static passwordStrength(control: AbstractControl): ValidationErrors | null {
    const passwordStrengthRegex = new RegExp('^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$');

    if (passwordStrengthRegex.test(control.value)) {
      return null;
    }

    return { passwordStrengthLow: true };
  }

  static setFormServerErrors(formGroup: FormGroup, errors: any): void {
    Object.keys(errors).forEach((errorKey) => {
      formGroup.get(errorKey)?.setErrors({ serverErrors: errors[errorKey] });
    });
  }
}
