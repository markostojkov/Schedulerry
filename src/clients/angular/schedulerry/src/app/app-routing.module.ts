import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AnonymousMainViewComponent } from './core/components/anonymous-main-view/anonymous-main-view.component';
import { CustomerMainViewComponent } from './core/components/customer-main-view/customer-main-view.component';
import { OrganizerMainViewComponent } from './core/components/organizer-main-view/organizer-main-view.component';
import { CustomerUserGuard, OrganizerUserGuard } from './core/guards';

const routes: Routes = [
  {
    path: 'organizer',
    loadChildren: () => import('./modules/users/organizer/organizer.module').then((x) => x.OrganizerModule)
  },
  {
    path: 'customer',
    loadChildren: () => import('./modules/users/customer/customer.module').then((x) => x.CustomerModule)
  },
  {
    component: CustomerMainViewComponent,
    canActivate: [CustomerUserGuard],
    path: 'reservation/:organizationUid',
    children: [
      {
        path: '',
        loadChildren: () => import('./modules/reservations/reservations.module').then((x) => x.ReservationsModule)
      }
    ]
  },
  {
    component: OrganizerMainViewComponent,
    canActivate: [OrganizerUserGuard],
    path: 'organizations/:organizationUid',
    children: [
      {
        path: '',
        loadChildren: () =>
          import('./modules/organization-management/organization-management.module').then((x) => x.OrganizationManagementModule)
      }
    ]
  },
  {
    component: AnonymousMainViewComponent,
    path: 'public',
    children: [
      {
        path: '',
        loadChildren: () => import('./modules/public/public.module').then((x) => x.PublicModule)
      }
    ]
  },
  {
    path: '**',
    redirectTo: 'public/home'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
