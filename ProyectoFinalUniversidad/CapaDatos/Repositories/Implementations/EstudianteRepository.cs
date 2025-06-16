using ProyectoFinalUniversidad.CapaDatos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalUniversidad.CapaDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalUniversidad.CapaDatos.Repositories.Implementations
{
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly UniversidadDbContext _context;

        public EstudianteRepository(UniversidadDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Estudiante entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Estudiante.Add(entity);
        }

        public void Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
            var estudiante = _context.Estudiante.Find(id);
            if (estudiante != null)
            {
                _context.Estudiante.Remove(estudiante);
            }
        }

        public IEnumerable<Estudiante> GetAll()
        {
            return _context.Estudiante.ToList();
        }

        public Estudiante GetById(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
            return _context.Estudiante.Find(id);
        }

        public void Update(Estudiante entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
