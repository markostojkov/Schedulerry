import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { COMPONENTS } from './components/components';
import { PublicRoutingModule } from './public.routes';

@NgModule({
  declarations: [COMPONENTS],
  imports: [CommonModule, PublicRoutingModule]
})
export class PublicModule {}
