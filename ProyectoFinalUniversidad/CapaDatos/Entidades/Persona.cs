using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalUniversidad.CapaDatos.Entidades
{
    public class Persona
    {
        public string Ci { get; set; } = string.Empty;
        public string PrimerNombre { get; set; } = string.Empty;
        public string PrimerApellido { get; set; } = string.Empty;
        public string SegundoApellido { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public string Departamento { get; set; } = string.Empty;
        public string UnidadAcademica { get; set; } = string.Empty;
        public string Carrera { get; set; } = string.Empty;
    }
}
