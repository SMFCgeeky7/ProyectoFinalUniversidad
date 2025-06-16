using ProyectoFinalUniversidad.CapaDatos.Repositories.Interfaces;
using ProyectoFinalUniversidad.CapaDatos.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalUniversidad.CapaDatos.Repositories.Implementations
{
    public class AsistenciaRepository : IAsistenciaRepository
    {
        private readonly UniversidadDbContext _context;

        public AsistenciaRepository(UniversidadDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
