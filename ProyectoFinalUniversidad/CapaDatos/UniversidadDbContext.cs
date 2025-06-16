using Microsoft.EntityFrameworkCore;
using ProyectoFinalUniversidad.CapaDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ProyectoFinalUniversidad.CapaDatos
{
    public class UniversidadDbContext : DbContext
    {
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Materia> Materia { get; set; }
        public DbSet<PlanEstudio> Plan_Estudio { get; set; }
        public DbSet<Plan_Estudiante> Plan_Estudiante { get; set; }
        public DbSet<Administrativo> Administrativo { get; set; }
        public DbSet<Asistencia> Asistencia { get; set; }
        public DbSet<Auditoria_Persona> Auditoria_Persona { get; set; }
        public DbSet<Aula> Aula { get; set; }
        public DbSet<Aula_Horario> Aula_Horario { get; set; }
        public DbSet<Bloque> Bloque { get; set; }
        public DbSet<Carrera> Carrera { get; set; }
        public DbSet<Docente> Docente { get; set; }
        public DbSet<Edicion> Edicion { get; set; }
        public DbSet<Edicion_Aula> Edicion_Aula { get; set; }
        public DbSet<Edicion_Materia> Edicion_Materia { get; set; }
        public DbSet<Est_EdNota> Est_EdNota { get; set; }
        public DbSet<Facultad> Facultad { get; set; }
        public DbSet<Gestion> Gestion { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<Horario> Horario { get; set; }
        public DbSet<MateriaInscrita> MaterialInscrita { get; set; }
        public DbSet<Participa_Administrativo> Participa_Administrativo { get; set; }
        public DbSet<Participa_Docente> Participa_Docente { get; set; }
        public DbSet<Pisos> Pisos { get; set; }
        public DbSet<Plan_Materia> Plan_Materia { get; set; }
        public DbSet<Universidad> Universidad { get; set; }
        public DbSet<UsuarioLogin> UsuarioLogin { get; set; }
        // ... (mantener los otros DbSets que necesites)

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Comun.Constants.ConnectionString);
            }
        }
    }
}
