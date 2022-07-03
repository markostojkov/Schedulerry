import { NgModule } from '@angular/core';

import { SharedAppModule } from 'src/app/shared-app/shared-app.module';
import { SharedMaterialModule } from 'src/app/shared-material/shared-material.module';
import { COMPONENTS } from './components';
import { DIALOG_COMPONENTS } from './dialog-components';
import { OrganizationPreviewDialogService } from './organization-preview/organization-preview-dialog.service';
import { ReservationsRoutingModule } from './reservations.routes';

@NgModule({
  declarations: [COMPONENTS, DIALOG_COMPONENTS],
  imports: [SharedAppModule, SharedMaterialModule, ReservationsRoutingModule],
  providers: [OrganizationPreviewDialogService]
})
export class ReservationsModule {}
