using ProyectoFinalUniversidad.CapaNegocio.Interfaces;
using ProyectoFinalUniversidad.Comun;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace ProyectoFinalUniversidad.CapaNegocio.Servicios
{
    public class TcpService : ISubject, IDisposable
    {
        private TcpClient? _tcpClient;
        private NetworkStream? _stream;
        private readonly List<IMessageObserver> _observers;
        private bool _isDisposed;

        public TcpService()
        {
            _observers = new List<IMessageObserver>();
            ConnectToServer();
        }

        private void ConnectToServer()
        {
            try
            {
                _tcpClient = new TcpClient(Constants.ServerAddress, Constants.ServerPort);
                _stream = _tcpClient.GetStream();
                Task.Run(StartListening);
            }
            catch
            {
                MessageBox.Show(Constants.ErrorMessageServerNotConnected,
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void StartListening()
        {
            var buffer = new byte[256];
            while (_tcpClient?.Connected == true && !_isDisposed)
            {
                try
                {
                    if (_stream == null) break;

                    var bytesRead = _stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    var message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    NotifyObservers(message);
                }
                catch (Exception ex) when (ex is ObjectDisposedException or IOException)
                {
                    MessageBox.Show($"Error de conexión: {ex.Message}",
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
            }
        }

        public int GetCupo(int codMateria, string grupo)
        {
            try
            {
                if (_tcpClient?.Connected != true)
                {
                    ConnectToServer();
                }

                var request = $"CHECK_CUPO|CodMateria:{codMateria}|Grupo:{grupo}";
                SendData(request);
                var response = ReadData();

                if (response.StartsWith("CUPO_DISPONIBLE", StringComparison.OrdinalIgnoreCase))
                {
                    var parts = response.Split('|');
                    var cupoStr = parts[2].Split(':')[1];
                    return int.Parse(cupoStr);
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        private void SendData(string data)
        {
            if (_stream == null) return;

            var bytes = Encoding.ASCII.GetBytes(data);
            _stream.Write(bytes, 0, bytes.Length);
        }

        private string ReadData()
        {
            if (_stream == null) return string.Empty;

            var buffer = new byte[256];
            var bytesRead = _stream.Read(buffer, 0, buffer.Length);
            return Encoding.ASCII.GetString(buffer, 0, bytesRead);
        }

        public void RegisterObserver(IMessageObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IMessageObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers(string message)
        {
            foreach (var observer in _observers.ToList())
            {
                observer.Update(message);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _stream?.Dispose();
                    _tcpClient?.Dispose();
                }
                _isDisposed = true;
            }
        }
    }
}
