import { Component } from '@angular/core';
import { DataSource } from '@angular/cdk/table';
import { Observable } from 'rxjs/Observable';

import { NotesService, Note } from './notes.service';

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.scss']
})
export class NotesComponent {
  constructor(private notesService: NotesService) { }

  dataSource = new NotesDataSource(this.notesService);
  displayedColumns = ["text", "author", "updated"];
}

class NotesDataSource extends DataSource<Note> {
  constructor(private notesService: NotesService) {
    super();
  }

  connect(): Observable<Note[]> {
    return this.notesService.getNotes();
  }
  disconnect() { }
}
