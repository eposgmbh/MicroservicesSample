import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoadingIndicatorService } from './loading-indicator.service';

@NgModule({
  imports: [CommonModule],
  providers: [LoadingIndicatorService]
})
export class CoreModule { }
