import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FlexLayoutModule } from '@angular/flex-layout';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { NgxMaterialTimepickerModule } from 'ngx-material-timepicker';
import { FileUploadModule } from 'ng2-file-upload';

import { COMPONENTS } from './components/generic/components';
import { SharedMaterialModule } from '../shared-material/shared-material.module';
import { DIRECTIVES } from './directives/directives';
import { SERVICES } from './services/services';
import { PIPES } from './pipes/pipes';
import { FileUploadComponent } from './components/generic/file-upload/file-upload.component';
import { HandleSelectFormErrorsDirective } from './directives/handle-select-form-errors.directive';

@NgModule({
  declarations: [COMPONENTS, DIRECTIVES, PIPES, FileUploadComponent, HandleSelectFormErrorsDirective],
  providers: [SERVICES],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    TranslateModule,
    SharedMaterialModule,
    FlexLayoutModule,
    FileUploadModule,
    NgxMaterialTimepickerModule
  ],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    TranslateModule,
    FlexLayoutModule,
    FileUploadModule,
    NgxMaterialTimepickerModule,
    COMPONENTS,
    DIRECTIVES,
    PIPES
  ]
})
export class SharedAppModule {}
