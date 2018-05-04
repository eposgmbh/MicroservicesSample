import { DataSource } from '@angular/cdk/table';

import { Note } from './note';
import { NotesService } from './notes.service';

import { Observable, Subject } from 'rxjs';

export class NotesDataSource extends DataSource<Note> {
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
