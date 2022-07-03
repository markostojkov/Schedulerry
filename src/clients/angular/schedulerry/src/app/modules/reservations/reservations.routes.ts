import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PreviewOrganizationComponent } from './organization-preview/components/preview-organization/preview-organization.component';
import { PreviewServiceComponent } from './organization-preview/components/preview-service/preview-service.component';

const routes: Routes = [
  {
    path: '',
    component: PreviewOrganizationComponent
  },
  {
    path: 'services/:serviceUid',
    component: PreviewServiceComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ReservationsRoutingModule {}
