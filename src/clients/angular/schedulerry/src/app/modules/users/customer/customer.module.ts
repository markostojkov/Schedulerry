import { NgModule } from '@angular/core';

import { COMPONENTS } from './components/components';
import { SharedAppModule } from 'src/app/shared-app/shared-app.module';
import { SharedMaterialModule } from 'src/app/shared-material/shared-material.module';
import { ROUTES } from './customer.routes';
import { SERVICES } from './services/services';

@NgModule({
  declarations: [COMPONENTS],
  imports: [SharedAppModule, SharedMaterialModule, ROUTES],
  providers: [SERVICES]
})
export class CustomerModule {}
