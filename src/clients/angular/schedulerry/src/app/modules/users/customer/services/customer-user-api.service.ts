import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { BaseApiService } from 'src/app/shared-app/services/base-api.service';
import { CustomerRegisterRequest } from '../models';

@Injectable({
  providedIn: 'root'
})
export class CustomerUserApiService extends BaseApiService {
  constructor(protected http: HttpClient) {
    super(http);
  }

  public registerCustomer(body: CustomerRegisterRequest): Observable<void> {
    return this.post('customers', body);
  }

  public verifyCustomer(verificationCode: string): Observable<void> {
    return this.post(`customers/verify/${verificationCode}`);
  }
}
