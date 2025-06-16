using Microsoft.EntityFrameworkCore;
using ProyectoFinalUniversidad.CapaDatos.Entidades;
using ProyectoFinalUniversidad.CapaDatos.Repositories.Interfaces;
using ProyectoFinalUniversidad.Comun;
using System.Security.Cryptography;
using System.Text;

namespace ProyectoFinalUniversidad.CapaNegocio.Servicios
{
    public class AuthService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public bool Login(string username, string password, string role)
        {
            ArgumentException.ThrowIfNullOrEmpty(username);
            ArgumentException.ThrowIfNullOrEmpty(password);
            ArgumentException.ThrowIfNullOrEmpty(role);

            try
            {
                _unitOfWork.BeginTransaction();

                var usuario = _unitOfWork.UsuarioLogins.FindByUsername(username);
                if (usuario == null)
                {
                    return false;
                }

                var hashedPassword = HashPassword(password);
                if (!hashedPassword.SequenceEqual(usuario.PasswordHash))
                {
                    return false;
                }

                var persona = _unitOfWork.Personas.GetById(usuario.Ci);
                if (persona == null || persona.Departamento != role)
                {
                    return false;
                }

                usuario.UltimoIngreso = DateTime.Now;
                _unitOfWork.UsuarioLogins.Update(usuario);
                _unitOfWork.Save();
                _unitOfWork.CommitTransaction();

                return true;
            }
            catch
            {
                _unitOfWork.RollbackTransaction();
                return false;
            }
        }

        public bool Register(string ci, string password, string primerApellido, string segundoApellido,
            string nombre, string genero, string departamento, string unidadAcademica, string carrera, string role)
        {
            if (string.IsNullOrEmpty(ci) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(primerApellido) || string.IsNullOrEmpty(nombre))
            {
                return false;
            }

            try
            {
                _unitOfWork.BeginTransaction();

                if (_unitOfWork.Personas.GetById(ci) != null)
                {
                    return false;
                }

                string username = GenerateUniqueUsername(primerApellido);

                var persona = new Persona
                {
                    Ci = ci,
                    PrimerNombre = nombre,
                    PrimerApellido = primerApellido,
                    SegundoApellido = segundoApellido,
                    Genero = genero,
                    Departamento = departamento,
                    UnidadAcademica = unidadAcademica,
                    Carrera = carrera
                };

                var usuario = new UsuarioLogin
                {
                    Ci = ci,
                    Username = username,
                    PasswordHash = HashPassword(password),
                    FechaCreacion = DateTime.Now,
                    Estado = true
                };

                _unitOfWork.Personas.Add(persona);
                _unitOfWork.UsuarioLogins.Add(usuario);

                var rolEntity = role switch
                {
                    Constants.RoleEstudiante => new Estudiante { Ci = ci },
                    Constants.RoleDocente => new Docente { Ci = ci },
                    Constants.RoleAdministrativo => new Administrativo { Ci = ci },
                    _ => throw new ArgumentException("Rol no válido", nameof(role))
                };

                switch (role)
                {
                    case Constants.RoleEstudiante:
                        _unitOfWork.Estudiantes.Add((Estudiante)rolEntity);
                        break;
                    case Constants.RoleDocente:
                        _unitOfWork.Docentes.Add((Docente)rolEntity);
                        break;
                    case Constants.RoleAdministrativo:
                        _unitOfWork.Administrativos.Add((Administrativo)rolEntity);
                        break;
                }

                _unitOfWork.Save();
                _unitOfWork.CommitTransaction();
                return true;
            }
            catch
            {
                _unitOfWork.RollbackTransaction();
                return false;
            }
        }

        private string GenerateUniqueUsername(string apellido)
        {
            var baseName = apellido[..Math.Min(2, apellido.Length)].ToUpper();
            var random = new Random();

            for (int i = 0; i < 100; i++)
            {
                var username = $"{baseName}{random.Next(100000, 999999)}";
                if (_unitOfWork.UsuarioLogins.FindByUsername(username) == null)
                    return username;
            }

            throw new InvalidOperationException("No se pudo generar un nombre de usuario único");
        }

        private static byte[] HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}