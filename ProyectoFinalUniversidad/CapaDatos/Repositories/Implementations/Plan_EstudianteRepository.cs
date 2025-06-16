using ProyectoFinalUniversidad.CapaDatos.Repositories.Interfaces;
using ProyectoFinalUniversidad.CapaDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalUniversidad.CapaDatos.Repositories.Implementations
{
    public class Plan_EstudianteRepository : IPlan_EstudianteRepository
    {
        private readonly UniversidadDbContext _context;

        public Plan_EstudianteRepository(UniversidadDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Plan_Estudiante entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Plan_Estudiante.Add(entity);
        }

        public void Update(Plan_Estudiante entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public Plan_Estudiante? GetById(int id)
        {
            return _context.Plan_Estudiante.Find(id);
        }

        public IEnumerable<Plan_Estudiante> GetAll()
        {
            return _context.Plan_Estudiante.ToList();
        }

        public void Delete(int id)
        {
            var entity = _context.Plan_Estudiante.Find(id);
            if (entity != null)
            {
                _context.Plan_Estudiante.Remove(entity);
            }
        }
    }
}
