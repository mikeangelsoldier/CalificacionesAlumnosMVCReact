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
    public class CursosController : ControllerBase
    {
        private readonly CalificacionesAlumnosContext _context;

        public CursosController(CalificacionesAlumnosContext context)
        {
            _context = context;
        }

        // GET: api/Cursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCurso()
        {
            if (_context.Curso == null)
            {
                return NotFound();
            }
            return await _context.Curso.ToListAsync();
        }

        // GET: api/Cursos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCurso(int id)
        {
            if (_context.Curso == null)
            {
                return NotFound();
            }
            var curso = await _context.Curso.FindAsync(id);

            if (curso == null)
            {
                return NotFound();
            }

            return curso;
        }

        // PUT: api/Cursos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(int id, Curso curso)
        {
            if (id != curso.Id)
            {
                return BadRequest();
            }

            _context.Entry(curso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursoExists(id))
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

        // POST: api/Cursos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Curso>> PostCurso(Curso curso)
        {
            if (_context.Curso == null)
            {
                return Problem("Entity set 'CalificacionesAlumnosContext.Curso'  is null.");
            }
            _context.Curso.Add(curso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCurso", new { id = curso.Id }, curso);
        }

        // DELETE: api/Cursos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            if (_context.Curso == null)
            {
                return NotFound();
            }
            var curso = await _context.Curso.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            _context.Curso.Remove(curso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CursoExists(int id)
        {
            return (_context.Curso?.Any(e => e.Id == id)).GetValueOrDefault();
        }



        [HttpGet]
        [Route("CursosDisponibles/{estudianteId}")]
        public async Task<IActionResult> cursosDisponibles(int estudianteId)
        {


            List<Curso> lista = await _context.Curso

            .OrderByDescending(c => c.Id)
            .ToListAsync();


            /*
            List<EstudianteCurso> lista = await _context.EstudianteCurso
            .Include(ec => ec.Curso)
            .Include(ec => ec.Estudiante)
            .Where(ec => ec.EstudianteId == estudianteId)
            .OrderByDescending(c => c.Id).ToListAsync();


            */

            return StatusCode(StatusCodes.Status200OK, lista);
        }


    }
}
