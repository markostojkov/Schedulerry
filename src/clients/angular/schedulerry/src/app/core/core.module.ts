import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';

import { environment } from '@env/environment';
import { SharedAppModule } from '../shared-app/shared-app.module';
import { SharedMaterialModule } from '../shared-material/shared-material.module';
import { COMPONENTS } from './components/components';
import { GUARDS } from './guards/guards';
import { LoaderInterceptor } from './interceptors/loader.interceptor';
import { SERVICES } from './services/services';
import { reducers } from './state';
import { OrganizationEffects } from './state/organization-state/organization.effects';
import { TokenInterceptor } from './interceptors/token.interceptor';

@NgModule({
  declarations: [COMPONENTS],
  providers: [
    SERVICES,
    GUARDS,
    { provide: HTTP_INTERCEPTORS, useClass: LoaderInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true }
  ],
  imports: [
    SharedAppModule,
    HttpClientModule,
    SharedMaterialModule,
    RouterModule,
    StoreModule.forRoot(reducers),
    EffectsModule.forRoot([OrganizationEffects]),
    StoreDevtoolsModule.instrument({
      name: 'Schedulerry App DevTools',
      maxAge: 25,
      logOnly: !environment.production
    })
  ],
  exports: [HttpClientModule, COMPONENTS]
})
export class CoreModule {}
