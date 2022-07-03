import { ModuleWithProviders } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AcceptInvitationOrganizerComponent, RegisterOrganizerComponent, VerifyOrganizerComponent } from './components';

const routes: Routes = [
  {
    path: 'register',
    component: RegisterOrganizerComponent
  },
  {
    path: 'verify',
    component: VerifyOrganizerComponent
  },
  {
    path: 'join-organization',
    component: AcceptInvitationOrganizerComponent
  }
];

export const ROUTES: ModuleWithProviders<any> = RouterModule.forChild(routes);
