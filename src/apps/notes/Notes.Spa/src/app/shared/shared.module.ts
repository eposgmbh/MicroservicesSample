import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { MatCardModule } from "@angular/material/card";
import { MatTabsModule } from "@angular/material/tabs";
import { MatSnackBarModule } from "@angular/material/snack-bar";
import { MatTableModule } from "@angular/material/table";
import { MatButtonModule } from "@angular/material/button";
import { MatIconModule } from "@angular/material/icon";

@NgModule({
  imports: [CommonModule],
  exports: [
    CommonModule, FormsModule, HttpClientModule,
    MatCardModule, MatTabsModule, MatSnackBarModule, MatTableModule, MatButtonModule, MatIconModule
  ]
})
export class SharedModule { }
