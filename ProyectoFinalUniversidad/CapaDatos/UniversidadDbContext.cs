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
