using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CalificacionesAlumnosMVCReact.Models
{
    public class Curso
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public int? Creditos { get; set; }

        // Relaciones
        public ICollection<EstudianteCurso> EstudiantesCursos { get; }

    }
}