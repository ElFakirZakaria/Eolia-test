using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProject.Models;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly EoliaContext _context;

        public NotesController(EoliaContext context)
        {
            _context = context;
        }

        // GET: api/Notes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notes>> GetNotes(int id)
        {
            var notes =await _context.Notes.FirstOrDefaultAsync(e => e.EtudiantId==id);

            if (notes == null)
            {
                return NotFound();
            }

            return notes;
        }

        // POST: api/Notes
        [HttpPost]
        public async Task<ActionResult<Notes>> PostNotes(Notes notes)
        {
            _context.Notes.Add(notes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotes", new { id = notes.NoteId }, notes);
        }


        private bool NotesExists(int id)
        {
            return _context.Notes.Any(e => e.NoteId == id);
        }
    }
}
