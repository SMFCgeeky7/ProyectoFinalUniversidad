using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalUniversidad.CapaNegocio.Interfaces
{
    public interface IMessageObserver
    {
        void Update(string message);
    }
}
