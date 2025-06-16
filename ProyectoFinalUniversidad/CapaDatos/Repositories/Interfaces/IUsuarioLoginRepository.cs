using ProyectoFinalUniversidad.CapaDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalUniversidad.CapaDatos.Repositories.Interfaces
{
    public interface IUsuarioLoginRepository: IGenericRepository<UsuarioLogin>
    {
        UsuarioLogin? FindByUsername(string username);
        UsuarioLogin? GetById(string username);
        void Add(UsuarioLogin usuario);
        void Update(UsuarioLogin usuario);
    }
}
