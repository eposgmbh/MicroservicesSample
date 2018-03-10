using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Notes.Model;

namespace Notes.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    public class NotesController : Controller
    {
        private readonly INoteRepository myNoteRepository;

        public NotesController(INoteRepository noteRepository) {
            myNoteRepository = noteRepository;
        }

        // GET api/v1/notes
        [HttpGet]
        public IEnumerable<Note> GetAllNotes() => myNoteRepository.GetAllNotes();

        // GET api/v1/notes/{id}
        [HttpGet("{id}", Name = nameof(GetNoteById))]
        public IActionResult GetNoteById(string id) {
            Note theNote = myNoteRepository.GetNoteById(id);
            if (theNote == null) {
                return NotFound();
            }

            return new ObjectResult(theNote);
        }

        // POST api/v1/notes Note
        [HttpPost]
        public IActionResult AddNote([FromBody] Note note) {
            myNoteRepository.AddNote(note);
            return CreatedAtRoute(nameof(GetNoteById), new { id = note.Id }, note);
        }

        // DELETE api/v1/notes/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteNote(string id) {
            if (myNoteRepository.Delete(id)) {
                return NoContent();
            }

            return NotFound();
        }


        // PUT api/v1/notes Note
        [HttpPut("{id}")]
        public IActionResult UpdateNote(string id, [FromBody] Note note) {
            if (id != note.Id) {
                return BadRequest();
            }

            if (myNoteRepository.Update(note)) {
                return NoContent();
            }

            return NotFound();
        }
    }
}
