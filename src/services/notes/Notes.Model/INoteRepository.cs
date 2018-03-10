using System.Collections.Generic;

namespace Notes.Model
{
    public interface INoteRepository
    {
        IEnumerable<Note> GetAllNotes();

        void AddNote(Note note);

        Note GetNoteById(string id);

        bool Delete(string id);

        bool Update(Note note);
    }
}
