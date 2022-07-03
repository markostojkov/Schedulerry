import { ModuleWithProviders } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterCustomerComponent, VerifyCustomerComponent } from './components';

const routes: Routes = [
  {
    path: 'register',
    component: RegisterCustomerComponent
  },
  {
    path: 'verify',
    component: VerifyCustomerComponent
  }
];

export const ROUTES: ModuleWithProviders<any> = RouterModule.forChild(routes);
