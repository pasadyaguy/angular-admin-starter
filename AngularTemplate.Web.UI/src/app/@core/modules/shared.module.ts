import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NbSecurityModule } from '@nebular/security';
import { AgGridModule } from 'ag-grid-angular';
import {
  NbBadgeModule,
  NbSelectModule,
  NbActionsModule,
  NbCardModule,
  NbRadioModule,
  NbAlertModule,
  NbLayoutModule,
  NbMenuModule,
  NbRouteTabsetModule,
  NbSearchModule,
  NbSidebarModule,
  NbTabsetModule,
  NbThemeModule,
  NbStepperModule,
  NbUserModule,
  NbCheckboxModule,
  NbPopoverModule,
  NbContextMenuModule,
  NbProgressBarModule,
  NbSpinnerModule,
  NbDialogModule,
} from '@nebular/theme';
import { RouterModule } from '@angular/router';
import { ImageService } from '../data/image.service';
import { MaterialModule } from './material.module';
import { QuillModule } from 'ngx-quill'
import { QuillEditorToolbarConfig } from '../config/quill-editor-toolbar-config';
import { DialogConfig } from '../config/dialog-config';
import { TemplateRendererComponent } from '../components/template-renderer/template-renderer.component';

const NB_MODULES = [
  NbBadgeModule,
  NbSelectModule,
  NbCardModule,
  NbRadioModule,
  NbAlertModule,
  NbStepperModule,
  NbLayoutModule,
  NbTabsetModule,
  NbRouteTabsetModule,
  NbMenuModule,
  NbUserModule,
  NbActionsModule,
  NbSearchModule,
  NbSidebarModule,
  NbCheckboxModule,
  NbPopoverModule,
  NbContextMenuModule,
  NbSecurityModule, // *nbIsGranted directive,
  NbProgressBarModule,
  NbSpinnerModule,
  NbThemeModule,
];

const CUSTOM_COMPONENTS = [
  TemplateRendererComponent,
]

@NgModule({
    imports: [
      CommonModule,
      FormsModule,
      MaterialModule.forRoot(),
      ReactiveFormsModule,
      NB_MODULES,
      RouterModule,
      NgbModule,
      AgGridModule.withComponents(null),
      QuillModule.forRoot({
        modules: {
          toolbar: QuillEditorToolbarConfig
        }
      }),
      NbDialogModule.forRoot(DialogConfig),
    ],
    exports: [
        MaterialModule,
        ...NB_MODULES,
        ...CUSTOM_COMPONENTS,
        FormsModule,
        AgGridModule,
        NbDialogModule,
        QuillModule,
    ],
    declarations: [
      ...CUSTOM_COMPONENTS,
    ],
    providers: [ ImageService ],
    entryComponents: [

    ]
})
export class SharedModule { }
