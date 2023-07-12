using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CalificacionesAlumnosMVCReact.Models
{
    public class EstudianteCurso
    {

        public int Id { get; set; }

        public int? EstudianteId { get; set; }

        public int? CursoId { get; set; }

        public double? Calificacion { get; set; }


        // Relaciones
        public Estudiante? Estudiante { get; set; }

        public Curso? Curso { get; set; }

    }
}

