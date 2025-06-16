using Microsoft.EntityFrameworkCore;
using ProyectoFinalUniversidad.CapaDatos.Entidades;
using ProyectoFinalUniversidad.CapaDatos.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoFinalUniversidad.CapaDatos.Repositories.Implementations
{
    public class AdministrativoRepository : IGenericRepository<Administrativo>
    {
        private readonly UniversidadDbContext _context;

        public AdministrativoRepository(UniversidadDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Administrativo entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Administrativo.Add(entity);
        }

        public void Delete(int id)
        {
            var administrativo = _context.Administrativo.Find(id);
            if (administrativo != null)
            {
                _context.Administrativo.Remove(administrativo);
            }
        }

        public IEnumerable<Administrativo> GetAll()
        {
            return _context.Administrativo.ToList();
        }

        public Administrativo GetById(int id)
        {
            return _context.Administrativo.Find(id);
        }

        public void Update(Administrativo entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}