using ProyectoFinalUniversidad.CapaDatos.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalUniversidad.CapaDatos.Repositories.Implementations
{
    public class UsuarioLoginRepository : IUsuarioLoginRepository
    {
        private readonly UniversidadDbContext _context;

        public UsuarioLoginRepository(UniversidadDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
