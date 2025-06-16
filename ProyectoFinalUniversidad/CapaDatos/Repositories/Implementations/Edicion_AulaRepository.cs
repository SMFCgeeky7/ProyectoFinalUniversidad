using ProyectoFinalUniversidad.CapaDatos.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalUniversidad.CapaDatos.Repositories.Implementations
{
    public class Edicion_AulaRepository : IEdicion_AulaRepository
    {
        private readonly UniversidadDbContext _context;

        public Edicion_AulaRepository(UniversidadDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
