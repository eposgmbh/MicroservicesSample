import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from "../../environments/environment";

@Injectable()
export class NotesService {
  private readonly serviceUrl = `${environment.apiGatewayUri}bff/notes`;

  constructor(private http: HttpClient) { }

  public getNotes() {
    return this.http.get<Note[]>(this.serviceUrl);
  }
}

export interface Note {
  id: string;
  text: string;
  author: string;
  updated: Date;
}
