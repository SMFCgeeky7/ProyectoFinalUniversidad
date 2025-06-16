using ProyectoFinalUniversidad.CapaDatos.Repositories.Interfaces;
using ProyectoFinalUniversidad.CapaDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalUniversidad.CapaDatos.Repositories.Implementations
{
    public class PlanEstudioRepository : IPlanEstudioRepository
    {
        private readonly UniversidadDbContext _context;

        public PlanEstudioRepository(UniversidadDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(PlanEstudio entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Plan_Estudio.Add(entity);
        }

        public void Update(PlanEstudio entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public PlanEstudio? GetById(int id)
        {
            return _context.Plan_Estudio.Find(id);
        }

        public IEnumerable<PlanEstudio> GetAll()
        {
            return _context.Plan_Estudio.ToList();
        }

        public void Delete(int id)
        {
            var entity = _context.Plan_Estudio.Find(id);
            if (entity != null)
            {
                _context.Plan_Estudio.Remove(entity);
            }
        }
    }
}
