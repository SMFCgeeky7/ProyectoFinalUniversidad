using System;
using System.Windows;
using System.Windows.Controls;
using ProyectoFinalUniversidad.CapaNegocio.Servicios;

namespace ProyectoFinalUniversidad.CapaPresentacion.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class RegisterView : Window
    {
        private readonly AuthService _authService;

        public RegisterView()
        {
            InitializeComponent();
            _authService = new AuthService(new ProyectoFinalUniversidad.CapaDatos.Repositories.UnitOfWork(new ProyectoFinalUniversidad.CapaDatos.UniversidadDbContext()));
            LoadCarreras();
        }

        private void LoadCarreras()
        {
            cmbCarrera.Items.Clear();
            cmbCarrera.Items.Add(new ComboBoxItem { Content = "Ingeniería Informática" });
            cmbCarrera.Items.Add(new ComboBoxItem { Content = "Ingeniería Civil" });
            cmbCarrera.Items.Add(new ComboBoxItem { Content = "Ingeniería Eléctrica" });
            cmbCarrera.Items.Add(new ComboBoxItem { Content = "Ingeniería Mecánica" });
        }

        private void CmbDepartamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbDepartamento.SelectedItem is ComboBoxItem selectedItem)
            {
                string departamento = selectedItem.Content.ToString();
                cmbCarrera.Visibility = (departamento == "Estudiantil" || departamento == "Docente") ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCi.Text) || string.IsNullOrWhiteSpace(txtPassword.Password) ||
                string.IsNullOrWhiteSpace(txtPrimerApellido.Text) || string.IsNullOrWhiteSpace(txtSegundoApellido.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) || cmbGenero.SelectedItem == null ||
                cmbDepartamento.SelectedItem == null || cmbUnidadAcademica.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var ci = txtCi.Text;
            var password = txtPassword.Password;
            var primerApellido = txtPrimerApellido.Text;
            var segundoApellido = txtSegundoApellido.Text;
            var nombre = txtNombre.Text;
            var genero = ((ComboBoxItem)cmbGenero.SelectedItem).Content.ToString();
            var departamento = ((ComboBoxItem)cmbDepartamento.SelectedItem).Content.ToString();
            var unidadAcademica = ((ComboBoxItem)cmbUnidadAcademica.SelectedItem).Content.ToString();
            var carrera = cmbCarrera.SelectedItem != null ? ((ComboBoxItem)cmbCarrera.SelectedItem).Content.ToString() : null;
            var role = departamento; // O ajusta según tu lógica de roles

            try
            {
                bool registrado = _authService.Register(ci, password, primerApellido, segundoApellido, nombre, genero, departamento, unidadAcademica, carrera, role);
                if (registrado)
                {
                    MessageBox.Show("Usuario registrado exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el usuario. Verifique los datos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar usuario: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}