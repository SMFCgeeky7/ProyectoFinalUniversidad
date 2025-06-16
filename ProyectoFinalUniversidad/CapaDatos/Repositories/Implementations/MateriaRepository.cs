using ProyectoFinalUniversidad.CapaDatos.Repositories.Interfaces;
using ProyectoFinalUniversidad.CapaDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalUniversidad.CapaDatos.Repositories.Implementations
{
    public class MateriaRepository : IMateriaRepository
    {
        private readonly UniversidadDbContext _context;

        public MateriaRepository(UniversidadDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Materia entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Materia.Add(entity);
        }

        public void Update(Materia entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public Materia? GetById(int id)
        {
            return _context.Materia.Find(id);
        }

        public IEnumerable<Materia> GetAll()
        {
            return _context.Materia.ToList();
        }

        public void Delete(int id)
        {
            var materia = _context.Materia.Find(id);
            if (materia != null)
            {
                _context.Materia.Remove(materia);
            }
        }
    }
}
