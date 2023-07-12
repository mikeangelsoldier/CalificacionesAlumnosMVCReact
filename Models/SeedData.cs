using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CalificacionesAlumnosMVCReact.Data;
using System;
using System.Linq;

namespace CalificacionesAlumnosMVCReact.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new CalificacionesAlumnosContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<CalificacionesAlumnosContext>>()))
        {
            // Look for any movies.
            if (context.Curso.Any())
            {
                return;   // DB has been seeded
            }

            context.Curso.AddRange(
                new Curso
                {
                    Nombre = "Curso React",
                    Creditos = 15
                },
                new Curso
                {
                    Nombre = "Curso Testing",
                    Creditos = 25
                },
                new Curso
                {
                    Nombre = "Curso .NET Core",
                    Creditos = 20
                },
                new Curso
                {
                    Nombre = "Curso Angular",
                    Creditos = 22
                },
                new Curso
                {
                    Nombre = "Curso Android",
                    Creditos = 18
                }
            );

            // context.SaveChanges();


            context.Estudiante.AddRange(
                new Estudiante
                {
                    Nombre = "Miguel Ángel",
                    Apellidos = " Ramírez Lira",
                    Calificacion = null
                },
                new Estudiante
                {
                    Nombre = "Miguel2 Ángel2",
                    Apellidos = " Ramírez2 Lira2",
                    Calificacion = null
                },
                new Estudiante
                {
                    Nombre = "Miguel3 Ángel3",
                    Apellidos = " Ramírez3 Lira3",
                    Calificacion = null
                },
                new Estudiante
                {
                    Nombre = "Miguel4 Ángel4",
                    Apellidos = " Ramírez4 Lira4",
                    Calificacion = null
                }
            );

            // context.SaveChanges();


            context.EstudianteCurso.AddRange(
                new EstudianteCurso
                {
                    CursoId = 1,
                    EstudianteId = 1,
                    Calificacion = 75.68
                },
                new EstudianteCurso
                {
                    CursoId = 2,
                    EstudianteId = 1,
                    Calificacion = 86.50
                }
            );

            context.SaveChanges();
        }
    }
}