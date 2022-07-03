import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

import { ErrorResponse } from 'src/app/shared-app/models';
import { TranslateFromJsonService } from 'src/app/shared-app/services';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  constructor(private toastr: ToastrService, private translate: TranslateFromJsonService) {}

  public handleErrorsNotification(error: ErrorResponse): void {
    if (error) {
      Object.keys(error).forEach((errorField) => {
        error[errorField].forEach((message) => {
          this.toastr.error(this.translate.instant(message), errorField);
        });
      });
    }
  }

  public successNotification(title: string, description?: string): void {
    this.toastr.success(this.translate.instant(description), this.translate.instant(title));
  }
}
