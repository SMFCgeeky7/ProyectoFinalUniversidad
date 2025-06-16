using ProyectoFinalUniversidad.Comun;
using ProyectoFinalUniversidad.CapaDatos.Entidades;
using ProyectoFinalUniversidad.CapaNegocio.Helpers;
using ProyectoFinalUniversidad.CapaDatos.Repositories.Interfaces;
using ProyectoFinalUniversidad.CapaNegocio.Servicios;
using ProyectoFinalUniversidad;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProyectoFinalUniversidad.CapaPresentacion.Controllers
{
    public static class CurrentUser
    {
        public static string CI { get; set; }
        public static string Cod_Estudiante { get; set; }
    }

    public class EnrollmentController : INotifyPropertyChanged
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly TcpService _tcpService;
        private readonly NotificationService _notificationService;
        private ObservableCollection<MateriaInscrita> _materiasDisponibles;
        private int _materiasSeleccionadasCount = 0;

        public EnrollmentController(IUnitOfWork unitOfWork, TcpService tcpService, NotificationService notificationService)
        {
            _unitOfWork = unitOfWork;
            _tcpService = tcpService;
            _notificationService = notificationService;
            LoadMateriasDisponibles();
            AceptarCommand = new RelayCommand(ConfirmarInscripcion);
        }

        public ObservableCollection<MateriaInscrita> MateriasDisponibles
        {
            get => _materiasDisponibles;
            set
            {
                _materiasDisponibles = value;
                OnPropertyChanged();
            }
        }

        public int MateriasSeleccionadasCount
        {
            get => _materiasSeleccionadasCount;
            set
            {
                _materiasSeleccionadasCount = value;
                OnPropertyChanged(nameof(MateriasSeleccionadasCount));
            }
        }

        public bool MateriasSeleccionadasValidas => MateriasSeleccionadasCount > 0 && MateriasSeleccionadasCount <= Constants.MaxMateriasInscripcion;

        public ICommand AceptarCommand { get; }

        private void LoadMateriasDisponibles()
        {
            // Obtener carrera del estudiante
            var carreraEstudiante = _unitOfWork.Personas.GetById(int.Parse(CurrentUser.CI)).Carrera;

            // Cargar materias de la carrera del estudiante
            var materias = _unitOfWork.Materias.GetAll()
                .Where(m => m.Carrera == carreraEstudiante)
                .Select(m => new MateriaInscrita
                {
                    CodMateria = m.Cod_Materia,
                    Nombre = m.Nombre,
                    Creditos = m.Credito,
                    GrupoOptions = new ObservableCollection<string> { "A", "B" },
                    PlanEstudio = _unitOfWork.PlanEstudios.GetById(m.Cod_Materia)
                })
                .ToList();

            MateriasDisponibles = new ObservableCollection<MateriaInscrita>(materias);
        }

        private void ConfirmarInscripcion()
        {
            try
            {
                // Validar cupo y guardar en BD
                foreach (var materia in MateriasDisponibles.Where(m => m.EsSeleccionada))
                {
                    // Verificar cupo vía servidor TCP
                    var cupo = _tcpService.GetCupo(materia.CodMateria, materia.Grupo);
                    if (cupo <= 0)
                    {
                        _notificationService.ShowErrorMessage($"Grupo {materia.Grupo} de {materia.Nombre} está lleno.");
                        return;
                    }
                }

                // Guardar en la base de datos
                try
                {
                    foreach (var materia in MateriasDisponibles.Where(m => m.EsSeleccionada))
                    {
                        var inscripcion = new Plan_Estudiante
                        {
                            Cod_Estudiante = CurrentUser.Cod_Estudiante,
                            Cod_PlanEstudio = materia.CodMateria,
                            Grupo = materia.Grupo
                        };
                        _unitOfWork.Plan_Estudiantes.Add(inscripcion);
                    }
                    _unitOfWork.Save();
                    _notificationService.ShowSuccessMessage("Inscripción exitosa!");
                    // Cerrar ventana
                    this.CloseAction?.Invoke();
                }
                catch (Exception ex)
                {
                    _notificationService.ShowErrorMessage($"Error: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                _notificationService.ShowErrorMessage($"Error: {ex.Message}");
            }
        }

        private void UpdateMateriasSeleccionadasCount()
        {
            MateriasSeleccionadasCount = MateriasDisponibles.Count(m => m.EsSeleccionada);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Action CloseAction { get; set; }
    }
}
