import { NgModule } from '@angular/core';

import { COMPONENTS } from './components';
import { DIALOG_COMPONENTS } from './dialog-components';
import { OrganizationManagementRoutingModule } from './organization-management.routes';
import { SharedMaterialModule } from 'src/app/shared-material/shared-material.module';
import { SharedAppModule } from 'src/app/shared-app/shared-app.module';
import { OrganizationServicesDialog } from './organization-services/organization-services-dialog.service';
import { OrganizationUsersDialogService } from './organization-users/organization-users-dialog.service';

@NgModule({
  declarations: [COMPONENTS, DIALOG_COMPONENTS],
  imports: [OrganizationManagementRoutingModule, SharedAppModule, SharedMaterialModule],
  entryComponents: [DIALOG_COMPONENTS],
  providers: [OrganizationServicesDialog, OrganizationUsersDialogService]
})
export class OrganizationManagementModule {}
