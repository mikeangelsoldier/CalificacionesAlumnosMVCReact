using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CalificacionesAlumnosMVCReact.Models
{
    public class Estudiante
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Apellidos { get; set; }

        public double? Calificacion { get; set; }

        // Relaciones
        public ICollection<EstudianteCurso>? EstudiantesCursos { get; } // = new List<EstudianteCurso>();


    }
}