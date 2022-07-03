import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './organization-dashboard/components/dashboard/dashboard.component';
import { ServiceOptionsComponent } from './organization-services/components/service-options/service-options.component';
import { ServicesComponent } from './organization-services/components/services/services.component';
import { OrganizersComponent } from './organization-users/components/organizers/organizers.component';

const routes: Routes = [
  {
    path: 'services',
    component: ServicesComponent
  },
  {
    path: 'services/:serviceUid',
    component: ServiceOptionsComponent
  },
  {
    path: 'organizers',
    component: OrganizersComponent
  },
  {
    path: 'dashboard',
    component: DashboardComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrganizationManagementRoutingModule {}
