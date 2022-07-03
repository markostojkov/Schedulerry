import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs/operators';

import { AuthService } from 'src/app/core/services';
import { NotificationService } from 'src/app/core/services/notification.service';
import { ButtonType } from 'src/app/shared-app/components/generic/button/button.models';
import { CustomerUserApiService } from '../../services';

@Component({
  selector: 'app-verify-customer',
  templateUrl: './verify-customer.component.html',
  styleUrls: ['./verify-customer.component.scss']
})
export class VerifyCustomerComponent implements OnInit {
  public ButtonType = ButtonType;

  public isVerified = false;

  constructor(
    private route: ActivatedRoute,
    private api: CustomerUserApiService,
    private auth: AuthService,
    private notification: NotificationService
  ) {}

  ngOnInit(): void {
    this.route.queryParams
      .pipe(
        switchMap((res) => {
          return this.api.verifyCustomer(res.code);
        })
      )
      .subscribe(
        () => {
          this.isVerified = true;
        },
        (err) => {
          this.notification.handleErrorsNotification(err.error);
        }
      );
  }

  public login(): void {
    this.auth.login();
  }
}
