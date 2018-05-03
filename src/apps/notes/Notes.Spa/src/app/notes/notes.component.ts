import { Component } from '@angular/core';
import { DataSource } from '@angular/cdk/table';

import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';

import { Note } from "./note";
import { NotesService } from './notes.service';

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.scss']
})
export class NotesComponent {
  constructor(private notesService: NotesService) { }

  dataSource: NotesDataSource = new NotesDataSource(this.notesService);
  displayedColumns = ["text", "author", "updated"];
  newNote: Note = new Note();

  addNote() {
    this.notesService.addNote(this.newNote).subscribe(() => {
      this.newNote = new Note();
      this.dataSource.reload();
    });
  }
}

class NotesDataSource extends DataSource<Note> {
  constructor(private notesService: NotesService) {
    super();
  }

  private firstCall = true;
  subject: Subject<Note[]> = new Subject<Note[]>();

  reload() {
    this.notesService.getNotes().subscribe(notes => {
      this.subject.next(notes);
    });
  }

  connect(): Observable<Note[]> {
    if (this.firstCall) {
      this.reload();
      this.firstCall = false;
    }

    return this.subject;
  }

  disconnect() { }
}
