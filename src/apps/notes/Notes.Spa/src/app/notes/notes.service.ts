import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';

import { Note } from "./note";
import { environment } from "../../environments/environment";

@Injectable()
export class NotesService {
  private readonly serviceUrl = `${environment.apiGatewayUri}bff/notes`;

  constructor(private http: HttpClient) { }

  getNotes(): Observable<Note[]> {
    return this.http.get<Note[]>(this.serviceUrl);
  }

  addNote(note: Note) {
    return this.http.post(this.serviceUrl, note);
  }
}
