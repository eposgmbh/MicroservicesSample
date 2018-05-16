import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', pathMatch: 'full', loadChildren: 'app/notes/notes.module#NotesModule', data: { state: "notes" } },
  { path: 'settings', pathMatch: 'full', loadChildren: 'app/settings/settings.module#SettingsModule', data: { state: "settings" } }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
