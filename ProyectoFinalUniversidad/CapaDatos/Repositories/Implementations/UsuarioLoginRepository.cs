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
    public class UsuarioLoginRepository : IUsuarioLoginRepository
    {
        private readonly UniversidadDbContext _context;

        public UsuarioLoginRepository(UniversidadDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(UsuarioLogin usuario)
        {
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));
            _context.UsuarioLogin.Add(usuario);
        }

        public void Update(UsuarioLogin usuario)
        {
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));
            _context.Entry(usuario).State = EntityState.Modified;
        }

        public UsuarioLogin? GetById(string username)
        {
            if (string.IsNullOrEmpty(username)) throw new ArgumentNullException(nameof(username));
            return _context.UsuarioLogin.Find(username);
        }

        public IEnumerable<UsuarioLogin> GetAll()
        {
            return _context.UsuarioLogin.ToList();
        }

        public void Delete(string username)
        {
            if (string.IsNullOrEmpty(username)) throw new ArgumentNullException(nameof(username));
            var usuario = _context.UsuarioLogin.Find(username);
            if (usuario != null)
            {
                _context.UsuarioLogin.Remove(usuario);
            }
        }

        public UsuarioLogin? FindByUsername(string username)
        {
            if (string.IsNullOrEmpty(username)) throw new ArgumentNullException(nameof(username));
            return _context.UsuarioLogin.FirstOrDefault(u => u.Username == username);
        }
    }
}
