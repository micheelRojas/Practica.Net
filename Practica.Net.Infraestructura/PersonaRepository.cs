using OrganicSoft.Infraestructura.Base;
using Practica.Net.Dominio;
using Practica.Net.Dominio.Contracts;
using System;

namespace Practica.Net.Infraestructura
{
    public class PersonaRepository : GenericRepository<Persona>, IPersonaRepository
    {
        public PersonaRepository(IDbContext context) : base(context)
        {

        }
    }
}
