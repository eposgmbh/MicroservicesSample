import { Component, OnInit } from '@angular/core';

import { MatSnackBar, MatSnackBarConfig } from '@angular/material';

import { environment } from '../environments/environment';
import { LoadingIndicatorService } from './loading-indicator.service';
import { AuthService } from './auth.service';
import { routerTransitionAnimation } from './router-transition.animation';

import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  animations: [routerTransitionAnimation]
})
export class AppComponent implements OnInit {
  environmentName = environment.name;
  apiGatewayUri = environment.apiGatewayUri;
  isLoading = false;
  panelOpenState = false;
  selectedValue: string;

  constructor(
    private loadingIndicatorService: LoadingIndicatorService,
    private snackBar: MatSnackBar, public auth: AuthService
  ) {
    loadingIndicatorService.appComponent = this;

    auth.handleAuthentication();
  }

  ngOnInit(): void {
    var theHubConnection = new HubConnectionBuilder()
      .withUrl(environment.messageBroadcastUri)
      .build();

    theHubConnection.on('Message', message => {
      MatSnackBarConfig
      this.snackBar.open(message, "OK", { duration: 8000, horizontalPosition: "right", verticalPosition: "top" });
    });

    theHubConnection.start().catch(error => {
      console.error(error.toString());
    });
  }
}
