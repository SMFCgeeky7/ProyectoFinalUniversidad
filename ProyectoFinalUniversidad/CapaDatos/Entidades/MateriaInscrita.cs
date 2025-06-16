using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ProyectoFinalUniversidad.CapaDatos.Entidades;

namespace ProyectoFinalUniversidad.CapaDatos.Entidades
{
    public class MateriaInscrita
    {
        public int CodMateria { get; set; }
        public string Nombre { get; set; }
        public int Creditos { get; set; }
        public ObservableCollection<string> GrupoOptions { get; set; }
        public string Grupo { get; set; } // "A" o "B"
        public bool EsSeleccionada { get; set; }
        public PlanEstudio PlanEstudio { get; set; }
        public bool EsCupoLleno { get; set; }
    }
}
