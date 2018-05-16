import { Component, OnInit, ViewChild } from '@angular/core';
import { Form } from '@angular/forms';

import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material';

import { LoadingIndicatorService } from '../core/loading-indicator.service';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.scss']
})
export class SettingsComponent {
  constructor(private loadingIndicatorService: LoadingIndicatorService) { }
}
