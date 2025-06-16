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
    public class DocenteRepository : IDocenteRepository
    {
        private readonly UniversidadDbContext _context;

        public DocenteRepository(UniversidadDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Docente entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Docente.Add(entity);
        }

        public void Delete(int id)
        {
            var docente = _context.Docente.Find(id);
            if (docente != null)
            {
                _context.Docente.Remove(docente);
            }
        }

        public IEnumerable<Docente> GetAll()
        {
            return _context.Docente.ToList();
        }

        public Docente GetById(int id)
        {
            return _context.Docente.Find(id);
        }

        public void Update(Docente entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
