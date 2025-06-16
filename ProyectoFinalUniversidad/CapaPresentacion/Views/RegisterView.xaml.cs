using System;
using System.Windows;
using System.Windows.Controls;
using ProyectoFinalUniversidad.CapaNegocio.Services;

namespace ProyectoFinalUniversidad.CapaPresentacion.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class RegisterView : Window
    {
        private readonly UserService _userService;

        public RegisterView()
        {
            InitializeComponent();
            _userService = new UserService();
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

            var user = new
            {
                Ci = txtCi.Text,
                Password = txtPassword.Password,
                PrimerApellido = txtPrimerApellido.Text,
                SegundoApellido = txtSegundoApellido.Text,
                Nombre = txtNombre.Text,
                Genero = ((ComboBoxItem)cmbGenero.SelectedItem).Content.ToString(),
                Departamento = ((ComboBoxItem)cmbDepartamento.SelectedItem).Content.ToString(),
                UnidadAcademica = ((ComboBoxItem)cmbUnidadAcademica.SelectedItem).Content.ToString(),
                Carrera = cmbCarrera.SelectedItem != null ? ((ComboBoxItem)cmbCarrera.SelectedItem).Content.ToString() : null
            };

            try
            {
                _userService.RegisterUser(user);
                MessageBox.Show("Usuario registrado exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar usuario: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}