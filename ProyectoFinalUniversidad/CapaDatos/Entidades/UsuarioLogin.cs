using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalUniversidad.CapaDatos.Entidades
{
    public class UsuarioLogin : EntityBase
    {
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
        public DateTime FechaCreacion { get; set; }
        public DateTime? UltimoIngreso { get; set; }
        public bool Estado { get; set; }
    }
}
