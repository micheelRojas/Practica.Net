using Dominio.Contracts;
using Practica.Net.Dominio;
using Practica.Net.Dominio.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.Net.Aplicacion.Personas
{
   
    public class CrearPersonaCommandHandle
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPersonaRepository _personaRepository;
        public CrearPersonaCommandHandle(IUnitOfWork unitOfWork, IPersonaRepository personaRepository)
        {
            _unitOfWork = unitOfWork;
            _personaRepository = personaRepository;

        }
        public CrearPersonaResponse Handle(PersonaCommand command)
        {
            Persona persona = _personaRepository.FindFirstOrDefault(t => t.Cedula == command.Cedula);
            if (persona != null)
            {
                return new CrearPersonaResponse("La persona ya existe");
            }
            IReadOnlyList<string> errors = command.CanCrear();
            if (errors.Any())
            {
                string ListaErrors = "Errores: " + string.Join(",", errors);
                return new CrearPersonaResponse(ListaErrors);
            }

            Persona personaNuevo = new Persona(
                                            command.Cedula,
                                            command.Nombre

                                            );

            _personaRepository.Add(personaNuevo);
            _unitOfWork.Commit();
            return new CrearPersonaResponse("Se creó con exito la persona.");
        }
    }

    public class CrearPersonaResponse
    {
        public CrearPersonaResponse()
        {

        }

        public CrearPersonaResponse(string mensaje)
        {
            Mensaje = mensaje;
        }

        public string Mensaje { get; set; }
        public bool isOk()
        {
            return this.Mensaje.Equals("Se creó con exito la persona.");
        }
    }
}
