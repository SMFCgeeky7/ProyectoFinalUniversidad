using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalUniversidad.CapaDatos.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonaRepository Personas { get; }
        IUsuarioLoginRepository UsuarioLogins { get; }
        IEstudianteRepository Estudiantes { get; }
        IDocenteRepository Docentes { get; }
        IAdministrativoRepository Administrativos { get; }
        IMateriaRepository Materias { get; }
        IPlanEstudioRepository PlanEstudios { get; }
        ICarreraRepository Carreras { get; }
        IFacultadRepository Facultades { get; }
        IUniversidadRepository Universidades { get; }
        IEdicionRepository Ediciones { get; }
        IGrupoRepository Grupos { get; }
        IPlan_EstudianteRepository Plan_Estudiantes { get; }
        IPlan_MateriaRepository Plan_Materias { get; }
        IAuditoria_PersonaRepository Auditoria_Personas { get; }
        IAsistenciaRepository Asistencias { get; }
        IEst_EdNotaRepository Est_EdNotas { get; }
        IParticipa_AdministrativoRepository Participa_Administrativos { get; }
        IParticipa_DocenteRepository Participa_Docentes { get; }
        IGestionRepository Gestiones { get; }
        IBloqueRepository Bloques { get; }
        IPisosRepository Pisos { get; }
        IAulaRepository Aulas { get; }
        IHorarioRepository Horarios { get; }
        IAula_HorarioRepository Aula_Horarios { get; }
        IEdicion_AulaRepository Edicion_Aulas { get; }

        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        void Save();
    }
}
