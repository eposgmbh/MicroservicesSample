import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { AppComponent } from '../app.component';

@Injectable()
export class LoadingIndicatorService {
  appComponent: AppComponent;

  show() {
    this.appComponent.isLoading = true;
  }

  hide() {
    this.appComponent.isLoading = false;
  }
}
