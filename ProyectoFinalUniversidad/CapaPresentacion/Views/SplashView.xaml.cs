using ProyectoFinalUniversidad.CapaPresentacion.Controllers;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProyectoFinalUniversidad.CapaNegocio.Servicios;
using System.Threading.Tasks;

namespace ProyectoFinalUniversidad.CapaPresentacion.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SplashView : Window
    {
        private TcpService _tcpService;
        public SplashView()
        {
            InitializeComponent();
            _tcpService = new TcpService();
            CheckConnection();
        }

        private async void CheckConnection()
        {
            await Task.Run(async () =>
            {
                while (!_tcpService.IsConnected)
                {
                    await Task.Delay(500);
                }
                Dispatcher.Invoke(() =>
                {
                    var loginView = new LoginView();
                    loginView.Show();
                    this.Close();
                });
            });
        }
    }
}