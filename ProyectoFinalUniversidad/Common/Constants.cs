using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalUniversidad.Comun
{
    public static class Constants
    {
        // Constantes para la base de datos
        public const string ConnectionString = "Server=localhost;Database=UniversidadDB;Trusted_Connection=True;";

        // Constantes para el servidor TCP
        public const string ServerAddress = "127.0.0.1";
        public const int ServerPort = 5000;

        // Mensajes de error
        public const string ErrorMessageCarnetExists = "El carnet de identidad ya existe.";
        public const string ErrorMessageCupoLleno = "El grupo está lleno.";
        public const string ErrorMessageMateriasExcedidas = "Solo puedes inscribir hasta 7 materias.";
        public const string ErrorMessageInvalidCredentials = "Credenciales inválidas.";
        public const string ErrorMessageServerNotConnected = "No se pudo conectar al servidor. Asegúrate de que el servidor esté en ejecución.";

        // Mensajes de éxito
        public const string SuccessMessageRegistro = "Registro exitoso.";
        public const string SuccessMessageInscripcion = "Inscripción exitosa.";
        public const string SuccessMessageInicioSesion = "Inicio de sesión exitoso.";

        // Campos de usuario
        public const int UsernameLength = 8; // 2 letras del apellido + 6 números
        public const int MinCreditosMateria = 1;
        public const int MaxCreditosMateria = 10;
        public const int MaxMateriasInscripcion = 7;

        // Roles
        public const string RoleEstudiante = "Estudiante";
        public const string RoleDocente = "Docente";
        public const string RoleAdministrativo = "Administrativo";

        // Rutas de archivos
        public const string LogoPath = @"Assets\LogoUniversidad.png";

        // Otras constantes
        public const int CupoMaximoPorGrupo = 20;
    }
}
