import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SettingsRoutingModule } from './settings-routing.module';
import { SettingsComponent } from './settings.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  imports: [CommonModule, SharedModule, SettingsRoutingModule],
  declarations: [SettingsComponent],
  exports: [SettingsComponent],
  providers: []
})
export class SettingsModule { }
