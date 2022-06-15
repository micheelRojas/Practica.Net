using Practica.Net.Dominio.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.Net.Aplicacion.Personas
{
   public class ConsultarPersonaQueryHandle
    {
        private IPersonaRepository _personaRepository;
        public ConsultarPersonaQueryHandle(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }
        public ConsultarPersonasQueryResponse Handle()
        {
            var personas = _personaRepository.GetAll().Select(t => new PersonaCommand
            {
                Id = t.Id,
                Cedula = t.Cedula,
                Nombre = t.Nombre,
            }).ToList();
            return new ConsultarPersonasQueryResponse(personas);
        }
    }
    public class ConsultarPersonasQueryResponse
    {
        public ConsultarPersonasQueryResponse(List<PersonaCommand> personas)
        {
            Personas = personas;
        }
        public List<PersonaCommand> Personas { get; set; }
    }
}
