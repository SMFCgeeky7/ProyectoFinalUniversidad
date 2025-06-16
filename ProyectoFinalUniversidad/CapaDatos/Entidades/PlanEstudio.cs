using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalUniversidad.CapaDatos.Entidades
{
    public class PlanEstudio
    {
        public int Cod_PlanEstudio { get; set; }
        public DateTime Fecha_Aprobacion { get; set; }
        public int Duracion_Total { get; set; }
        public int Horas_Teoricas { get; set; }
        public int Horas_Practicas { get; set; }
        public string Detalles { get; set; } // Detalles adicionales del plan de estudio
    }
}
