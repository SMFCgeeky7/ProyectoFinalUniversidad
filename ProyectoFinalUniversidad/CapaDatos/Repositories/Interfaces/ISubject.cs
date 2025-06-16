using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalUniversidad.CapaNegocio.Interfaces
{
    public interface ISubject
    {
        void RegisterObserver(IMessageObserver observer);
        void RemoveObserver(IMessageObserver observer);
        void NotifyObservers(string message);
    }
}
