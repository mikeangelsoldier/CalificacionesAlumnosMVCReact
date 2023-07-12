using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CalificacionesAlumnosMVCReact.Data;
using CalificacionesAlumnosMVCReact.Models;

namespace CalificacionesAlumnosMVCReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesCursosController : ControllerBase
    {
        private readonly CalificacionesAlumnosContext _context;

        public EstudiantesCursosController(CalificacionesAlumnosContext context)
        {
            _context = context;
        }

        // GET: api/EstudiantesCursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstudianteCurso>>> GetEstudianteCurso()
        {
            if (_context.EstudianteCurso == null)
            {
                return NotFound();
            }
            return await _context.EstudianteCurso.ToListAsync();
        }

        // GET: api/EstudiantesCursos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstudianteCurso>> GetEstudianteCurso(int id)
        {
            if (_context.EstudianteCurso == null)
            {
                return NotFound();
            }
            var estudianteCurso = await _context.EstudianteCurso.FindAsync(id);

            if (estudianteCurso == null)
            {
                return NotFound();
            }

            return estudianteCurso;
        }

        // PUT: api/EstudiantesCursos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudianteCurso(int id, EstudianteCurso estudianteCurso)
        {
            if (id != estudianteCurso.Id)
            {
                return BadRequest();
            }

            _context.Entry(estudianteCurso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudianteCursoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EstudiantesCursos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstudianteCurso>> PostEstudianteCurso(EstudianteCurso estudianteCurso)
        {
            if (_context.EstudianteCurso == null)
            {
                return Problem("Entity set 'CalificacionesAlumnosContext.EstudianteCurso'  is null.");
            }
            _context.EstudianteCurso.Add(estudianteCurso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstudianteCurso", new { id = estudianteCurso.Id }, estudianteCurso);
        }

        // DELETE: api/EstudiantesCursos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudianteCurso(int id)
        {
            if (_context.EstudianteCurso == null)
            {
                return NotFound();
            }
            var estudianteCurso = await _context.EstudianteCurso.FindAsync(id);
            if (estudianteCurso == null)
            {
                return NotFound();
            }

            _context.EstudianteCurso.Remove(estudianteCurso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstudianteCursoExists(int id)
        {
            return (_context.EstudianteCurso?.Any(e => e.Id == id)).GetValueOrDefault();
        }







        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] EstudianteCurso request)
        {
            await _context.EstudianteCurso.AddAsync(request);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }



        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar(int id)
        {

            return StatusCode(StatusCodes.Status200OK, id);
            _context.EstudianteCurso.Update(null);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }



        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            EstudianteCurso estudianteCurso = _context.EstudianteCurso.Find(id);

            _context.EstudianteCurso.Remove(estudianteCurso);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }







    }
}
