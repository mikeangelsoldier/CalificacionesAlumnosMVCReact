using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CalificacionesAlumnosMVCReact.Models;

namespace CalificacionesAlumnosMVCReact.Data
{
    public class CalificacionesAlumnosContext : DbContext
    {
        public CalificacionesAlumnosContext (DbContextOptions<CalificacionesAlumnosContext> options)
            : base(options)
        {
        }

        public DbSet<CalificacionesAlumnosMVCReact.Models.Curso> Curso { get; set; } = default!;

        public DbSet<CalificacionesAlumnosMVCReact.Models.Estudiante> Estudiante { get; set; } = default!;

        public DbSet<CalificacionesAlumnosMVCReact.Models.EstudianteCurso> EstudianteCurso { get; set; } = default!;
    }
}
