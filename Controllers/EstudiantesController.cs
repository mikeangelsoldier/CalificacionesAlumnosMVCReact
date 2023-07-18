using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CalificacionesAlumnosMVCReact.Data;
using CalificacionesAlumnosMVCReact.Models;

using System.Text.Json;
using System.Text.Json.Serialization;


namespace CalificacionesAlumnosMVCReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly CalificacionesAlumnosContext _context;

        public EstudiantesController(CalificacionesAlumnosContext context)
        {
            _context = context;
        }

        // GET: api/Estudiantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudiante>>> GetEstudiante()
        {
            if (_context.Estudiante == null)
            {
                return NotFound();
            }
            return await _context.Estudiante.ToListAsync();
        }

        // GET: api/Estudiantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> GetEstudiante(int id)
        {
            if (_context.Estudiante == null)
            {
                return NotFound();
            }
            var estudiante = await _context.Estudiante.FindAsync(id);

            if (estudiante == null)
            {
                return NotFound();
            }

            return estudiante;
        }

        // PUT: api/Estudiantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudiante(int id, Estudiante estudiante)
        {
            if (id != estudiante.Id)
            {
                return BadRequest();
            }

            _context.Entry(estudiante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudianteExists(id))
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

        // POST: api/Estudiantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Estudiante>> PostEstudiante(Estudiante estudiante)
        {
            if (_context.Estudiante == null)
            {
                return Problem("Entity set 'CalificacionesAlumnosContext.Estudiante'  is null.");
            }
            _context.Estudiante.Add(estudiante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstudiante", new { id = estudiante.Id }, estudiante);
        }

        // DELETE: api/Estudiantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudiante(int id)
        {
            if (_context.Estudiante == null)
            {
                return NotFound();
            }
            var estudiante = await _context.Estudiante.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            _context.Estudiante.Remove(estudiante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstudianteExists(int id)
        {
            return (_context.Estudiante?.Any(e => e.Id == id)).GetValueOrDefault();
        }



        /************************************************/



        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {

            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true
            };

            List<Estudiante> lista = await _context.Estudiante

            .OrderByDescending(c => c.Id)
            .Include(e => e.EstudiantesCursos)
            .ToListAsync();

            return StatusCode(StatusCodes.Status200OK, lista);
        }


        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] Estudiante request)
        {
            await _context.Estudiante.AddAsync(request);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }



        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] Estudiante request)
        {
            _context.Estudiante.Update(request);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }



        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            Estudiante estudiante = _context.Estudiante.Find(id);

            _context.Estudiante.Remove(estudiante);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }




        [HttpDelete]
        [Route("EliminarCursoAlumno/{id:int}")]
        public async Task<IActionResult> EliminarCursoAlumno(int id)
        {
            EstudianteCurso estudianteCurso = _context.EstudianteCurso.Find(id);

            _context.EstudianteCurso.Remove(estudianteCurso);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }







        [HttpGet]
        [Route("lista/{estudianteId}/ListaClasesDeEstudiante")]
        public async Task<IActionResult> ListaClasesDeEstudiante(int estudianteId)
        {
            List<EstudianteCurso> lista = await _context.EstudianteCurso
            .Include(ec => ec.Curso)
            .Include(ec => ec.Estudiante)
            .Where(ec => ec.EstudianteId == estudianteId)
            .OrderByDescending(c => c.Id).ToListAsync();

            return StatusCode(StatusCodes.Status200OK, lista);
        }

        /*
        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] EstudianteCurso request)
        {
            await _context.EstudianteCurso.AddAsync(request);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }

*/

        public class ModeloCalificacion
        {
            public int Id { get; set; }
            public double Calificacion { get; set; }
        }

        [HttpPost]
        [Route("EditarEstudianteCurso")]
        public async Task<IActionResult> EditarEstudianteCurso([FromBody] ModeloCalificacion request)
        {

            // return StatusCode(StatusCodes.Status200OK, request);


            // return StatusCode(StatusCodes.Status200OK, id);


            EstudianteCurso estudianteCurso = _context.EstudianteCurso.Find(request.Id);
            // return StatusCode(StatusCodes.Status200OK, estudianteCurso);

            estudianteCurso.Calificacion = request.Calificacion;


            _context.EstudianteCurso.Update(estudianteCurso);
            await _context.SaveChangesAsync();



            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        /*

        public class ModeloAgregarACurso
                {
                    public int EstudianteId { get; set; }
                    public double CursoId { get; set; }
                }

                [HttpPost]
                [Route("RegistrarEstudianteACurso")]
                public async Task<IActionResult> RegistrarEstudianteACurso([FromBody] ModeloAgregarACurso request)
                {

                    // return StatusCode(StatusCodes.Status200OK, request);


                    // return StatusCode(StatusCodes.Status200OK, id);


                    EstudianteCurso estudianteCurso = _context.EstudianteCurso.Find(request.Id);
                    // return StatusCode(StatusCodes.Status200OK, estudianteCurso);

                    estudianteCurso.Calificacion = request.Calificacion;


                    _context.EstudianteCurso.Update(estudianteCurso);
                    await _context.SaveChangesAsync();



                    return StatusCode(StatusCodes.Status200OK, "ok");
                }

        */




        [HttpPost]
        [Route("RegistrarEstudianteACurso")]
        public async Task<IActionResult> RegistrarEstudianteACurso([FromBody] EstudianteCurso request)
        {
            await _context.EstudianteCurso.AddAsync(request);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }





        /*
                [HttpDelete]
                [Route("Eliminar/{id:int}")]
                public async Task<IActionResult> Eliminar(int id)
                {
                    EstudianteCurso estudianteCurso = _context.EstudianteCurso.Find(id);

                    _context.EstudianteCurso.Remove(estudianteCurso);
                    await _context.SaveChangesAsync();

                    return StatusCode(StatusCodes.Status200OK, "ok");
                }
        */




    }
}
