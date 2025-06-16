using Microsoft.EntityFrameworkCore.Storage;
using ProyectoFinalUniversidad.CapaDatos.Entidades;
using ProyectoFinalUniversidad.CapaDatos.Repositories.Implementations;
using ProyectoFinalUniversidad.CapaDatos.Repositories.Interfaces;
using System;

namespace ProyectoFinalUniversidad.CapaDatos.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly UniversidadDbContext _context;
        private IDbContextTransaction _transaction;

        private IPersonaRepository? _personaRepository;
        private IUsuarioLoginRepository? _usuarioLoginRepository;
        private IEstudianteRepository? _estudianteRepository;
        private IDocenteRepository? _docenteRepository;
        private IAdministrativoRepository? _administrativoRepository;
        private IMateriaRepository? _materiaRepository;
        private IPlanEstudioRepository? _planEstudioRepository;
        private ICarreraRepository? _carreraRepository;
        private IFacultadRepository? _facultadRepository;
        private IUniversidadRepository? _universidadRepository;
        private IEdicionRepository? _edicionRepository;
        private IGrupoRepository? _grupoRepository;
        private IPlan_EstudianteRepository? _planEstudianteRepository;
        private IPlan_MateriaRepository? _planMateriaRepository;
        private IAuditoria_PersonaRepository? _auditoriaPersonaRepository;
        private IAsistenciaRepository? _asistenciaRepository;
        private IEst_EdNotaRepository? _estEdNotaRepository;
        private IParticipa_AdministrativoRepository? _participaAdministrativoRepository;
        private IParticipa_DocenteRepository? _participaDocenteRepository;
        private IGestionRepository? _gestionRepository;
        private IBloqueRepository? _bloqueRepository;
        private IPisosRepository? _pisosRepository;
        private IAulaRepository? _aulaRepository;
        private IHorarioRepository? _horarioRepository;
        private IAula_HorarioRepository? _aulaHorarioRepository;
        private IEdicion_AulaRepository? _edicionAulaRepository;

        public UnitOfWork(UniversidadDbContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            try
            {
                _transaction?.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                _transaction?.Dispose();
                _transaction = null;
            }
        }

        public void RollbackTransaction()
        {
            _transaction?.Rollback();
            _transaction?.Dispose();
            _transaction = null;
        }

        // Properties implementation with null-checking
        public IPersonaRepository Personas =>
            _personaRepository ??= new PersonaRepository(_context);

        public IUsuarioLoginRepository UsuarioLogins =>
            _usuarioLoginRepository ??= new UsuarioLoginRepository(_context);

        public IEstudianteRepository Estudiantes =>
            _estudianteRepository ??= new EstudianteRepository(_context);

        public IDocenteRepository Docentes =>
            _docenteRepository ??= new DocenteRepository(_context);

        public IAdministrativoRepository Administrativos =>
            _administrativoRepository ??= new AdministrativoRepository(_context);

        public IMateriaRepository Materias =>
            _materiaRepository ??= new MateriaRepository(_context);

        public IPlanEstudioRepository PlanEstudios =>
            _planEstudioRepository ??= new PlanEstudioRepository(_context);

        public ICarreraRepository Carreras =>
            _carreraRepository ??= new CarreraRepository(_context);

        public IFacultadRepository Facultades =>
            _facultadRepository ??= new FacultadRepository(_context);

        public IUniversidadRepository Universidades =>
            _universidadRepository ??= new UniversidadRepository(_context);

        public IEdicionRepository Ediciones =>
            _edicionRepository ??= new EdicionRepository(_context);

        public IGrupoRepository Grupos =>
            _grupoRepository ??= new GrupoRepository(_context);

        public IPlan_EstudianteRepository Plan_Estudiantes =>
            _planEstudianteRepository ??= new Plan_EstudianteRepository(_context);

        public IPlan_MateriaRepository Plan_Materias =>
            _planMateriaRepository ??= new Plan_MateriaRepository(_context);

        public IAuditoria_PersonaRepository Auditoria_Personas =>
            _auditoriaPersonaRepository ??= new Auditoria_PersonaRepository(_context);

        public IAsistenciaRepository Asistencias =>
            _asistenciaRepository ??= new AsistenciaRepository(_context);

        public IEst_EdNotaRepository Est_EdNotas =>
            _estEdNotaRepository ??= new Est_EdNotaRepository(_context);

        public IParticipa_AdministrativoRepository Participa_Administrativos =>
            _participaAdministrativoRepository ??= new Participa_AdministrativoRepository(_context);

        public IParticipa_DocenteRepository Participa_Docentes =>
            _participaDocenteRepository ??= new Participa_DocenteRepository(_context);

        public IGestionRepository Gestiones =>
            _gestionRepository ??= new GestionRepository(_context);

        public IBloqueRepository Bloques =>
            _bloqueRepository ??= new BloqueRepository(_context);

        public IPisosRepository Pisos =>
            _pisosRepository ??= new PisosRepository(_context);

        public IAulaRepository Aulas =>
            _aulaRepository ??= new AulaRepository(_context);

        public IHorarioRepository Horarios =>
            _horarioRepository ??= new HorarioRepository(_context);

        public IAula_HorarioRepository Aula_Horarios =>
            _aulaHorarioRepository ??= new Aula_HorarioRepository(_context);

        public IEdicion_AulaRepository Edicion_Aulas =>
            _edicionAulaRepository ??= new Edicion_AulaRepository(_context);

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _transaction?.Dispose();
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
