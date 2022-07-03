import { NgModule } from '@angular/core';

import { SharedAppModule } from 'src/app/shared-app/shared-app.module';
import { SharedMaterialModule } from 'src/app/shared-material/shared-material.module';
import { COMPONENTS } from './components/components';
import { ROUTES } from './organizer.routes';
import { SERVICES } from './services/services';

@NgModule({
  declarations: [COMPONENTS],
  providers: [SERVICES],
  imports: [SharedAppModule, SharedMaterialModule, ROUTES]
})
export class OrganizerModule {}
