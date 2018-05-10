import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { FlexLayoutModule } from '@angular/flex-layout';

import { MatCardModule } from '@angular/material/card';
import { MatTabsModule } from '@angular/material/tabs';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatSelectModule } from '@angular/material/select';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatStepperModule } from '@angular/material/stepper';

@NgModule({
  imports: [CommonModule],
  exports: [
    CommonModule, FormsModule, HttpClientModule,
    FlexLayoutModule,
    MatCardModule, MatTabsModule, MatSnackBarModule, MatTableModule, MatButtonModule, MatIconModule, MatInputModule,
    MatToolbarModule, MatSidenavModule, MatListModule, MatProgressBarModule, MatSelectModule, MatExpansionModule,
    MatStepperModule
  ]
})
export class SharedModule { }
