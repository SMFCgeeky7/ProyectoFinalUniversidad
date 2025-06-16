using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoFinalUniversidad.CapaNegocio.Servicios
{
    public class NotificationService : IObserver
    {
        private readonly TcpService _tcpService;

        public NotificationService(TcpService tcpService)
        {
            _tcpService = tcpService;
            _tcpService.RegisterObserver(this);
        }

        public void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message, "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void Update(string message)
        {
            // Procesar mensajes del servidor TCP
            if (message.StartsWith("CUPO_DISPONIBLE"))
            {
                var parts = message.Split('|');
                var grupo = parts[1].Split(':')[1];
                var cupoRestante = parts[2].Split(':')[1];
                ShowErrorMessage($"Grupo {grupo} está lleno. Cupo restante: {cupoRestante}");
            }
            else if (message.StartsWith("ALERTA"))
            {
                ShowErrorMessage(message.Replace("ALERTA|", ""));
            }
            else if (message.StartsWith("EXITO"))
            {
                ShowSuccessMessage(message.Replace("EXITO|", ""));
            }
        }

        public void Notify(string message)
        {
            _tcpService.SendData(message);
        }
    }
}
