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
    public class EtudiantsController : ControllerBase
    {
        private readonly EoliaContext _context;

        public EtudiantsController(EoliaContext context)
        {
            _context = context;
        }

        // GET: api/Etudiants
        [HttpGet]
        public IEnumerable<Etudiant> GetEtudiant()
        {
            return _context.Etudiant;
        }

        // GET: api/Etudiants/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEtudiant([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var etudiant = await _context.Etudiant.FindAsync(id);

            if (etudiant == null)
            {
                return NotFound();
            }

            return Ok(etudiant);
        }

        // POST: api/Etudiants
        [HttpPost]
        public async Task<IActionResult> PostEtudiant([FromBody] Etudiant etudiant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Etudiant.Add(etudiant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEtudiant", new { id = etudiant.EtudiantId }, etudiant);
        }

        private bool EtudiantExists(int id)
        {
            return _context.Etudiant.Any(e => e.EtudiantId == id);
        }
    }
}