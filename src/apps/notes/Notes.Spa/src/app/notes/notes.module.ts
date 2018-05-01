import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NotesRoutingModule } from "./notes-routing.module";
import { NotesComponent } from './notes.component';
import { NotesService } from './notes.service';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  imports: [CommonModule, SharedModule, NotesRoutingModule],
  declarations: [NotesComponent],
  exports: [NotesComponent],
  providers: [NotesService]
})
export class NotesModule { }
