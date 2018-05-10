import { Component } from '@angular/core';

import { environment } from '../environments/environment';
import { LoadingIndicatorService } from './core/loading-indicator.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  environmentName = environment.name;
  apiGatewayUri = environment.apiGatewayUri;
  isLoading = false;
  panelOpenState = false;
  selectedValue: string;

  constructor(loadingIndicatorService: LoadingIndicatorService) {
    loadingIndicatorService.appComponent = this;
  }
}
