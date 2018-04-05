using System;
using System.Collections.Generic;
using System.Linq;

using Notes.Model;

namespace Notes.Persistence
{
    public class NoteRepository : INoteRepository
    {
        private readonly NoteContext myContext;

        public NoteRepository(NoteContext context) {
            myContext = context;
        }

        public IEnumerable<Note> GetAllNotes() {
            return myContext.Notes.ToList();
        }

        public void AddNote(Note note) {
            myContext.Notes.Add(note);
            myContext.SaveChanges();
        }

        public Note GetNoteById(string id) {
            var theNotes =
                from theNote in myContext.Notes
                where theNote.Id == id
                select theNote;

            return theNotes.SingleOrDefault();
        }

        public bool Delete(string id) {
            Note theNote = GetNoteById(id);
            if (theNote == null) {
                return false;
            }

            myContext.Notes.Remove(theNote);
            myContext.SaveChanges();

            return true;
        }

        public bool Update(Note note) {
            Note theNote = GetNoteById(note.Id);
            if (theNote == null) {
                return false;
            }

            theNote.Text = note.Text;
            theNote.Author = note.Author;

            if (note.Updated != theNote.Updated) {
                theNote.Updated = note.Updated;
            } else {
                theNote.Updated = DateTime.Now;
            }

            myContext.Notes.Update(theNote);
            myContext.SaveChanges();

            return true;
        }
    }
}
