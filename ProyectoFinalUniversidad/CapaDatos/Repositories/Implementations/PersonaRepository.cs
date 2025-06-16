using Microsoft.EntityFrameworkCore;
using ProyectoFinalUniversidad.CapaDatos.Entidades;
using ProyectoFinalUniversidad.CapaDatos.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoFinalUniversidad.CapaDatos.Repositories.Implementations
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly UniversidadDbContext _dbContext;

        public PersonaRepository(UniversidadDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Add(Persona persona)
        {
            if (persona == null) throw new ArgumentNullException(nameof(persona));
            _dbContext.Persona.Add(persona);
        }

        public IEnumerable<Persona> GetAll()
        {
            return _dbContext.Persona.ToList();
        }

        public Persona GetById(string ci)
        {
            if (string.IsNullOrEmpty(ci)) throw new ArgumentNullException(nameof(ci));
            return _dbContext.Persona.Find(ci);
        }

        public void Update(Persona persona)
        {
            if (persona == null) throw new ArgumentNullException(nameof(persona));
            _dbContext.Entry(persona).State = EntityState.Modified;
        }

        public void Delete(string ci)
        {
            if (string.IsNullOrEmpty(ci)) throw new ArgumentNullException(nameof(ci));
            var persona = _dbContext.Persona.Find(ci);
            if (persona != null)
            {
                _dbContext.Persona.Remove(persona);
            }
        }
    }
}