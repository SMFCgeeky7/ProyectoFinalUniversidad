using ProyectoFinalUniversidad.Controllers;
using System.Text;
using System.Windows;
using ProyectoFinalUniversidad.CapaPresentacion.Controllers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProyectoFinalUniversidad.CapaNegocio.Servicios;

namespace ProyectoFinalUniversidad.CapaPresentacion.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private AuthService _authService;
        public LoginView()
        {
            InitializeComponent();
            _authService = new AuthService(new UnitOfWork(new UniversidadDbContext()));
        }

        private void BtnIngresar_Click(object sender, RoutedEventArgs e)
        {
            var ci = txtCi.Text;
            var password = txtPassword.Password;

            if (string.IsNullOrEmpty(ci) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor complete todos los campos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Aquí irá la lógica de autenticación
        }

        private void TxtRegistrarse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var registerView = new RegisterView();
            registerView.Show();
            this.Close();
        }
    }
}