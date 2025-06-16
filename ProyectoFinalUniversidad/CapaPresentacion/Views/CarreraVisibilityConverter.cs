using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ProyectoFinalUniversidad.CapaPresentacion.Views
{
    public class CarreraVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // El valor es el SelectedIndex del ComboBox de Departamento
            // 0 = Estudiantil, 2 = Docente (según tu XAML)
            if (value is int selectedIndex)
            {
                // Visible solo si es Estudiantil (0) o Docente (2)
                return (selectedIndex == 0 || selectedIndex == 2) ? Visibility.Visible : Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
} 