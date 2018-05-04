import { Component } from '@angular/core';

import { NotesDataSource } from './notes.data.source';
import { Note } from './note';
import { NotesService } from './notes.service';

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.scss']
})
export class NotesComponent {
  constructor(private notesService: NotesService) { }

  dataSource = new NotesDataSource(this.notesService);
  displayedColumns = ['text', 'author', 'updated'];
  newNote = new Note();

  addNote() {
    this.notesService.addNote(this.newNote).subscribe(() => {
      this.newNote = new Note();
      this.dataSource.reload();
    });
  }
}
