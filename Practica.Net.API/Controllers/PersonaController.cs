using Dominio.Contracts;
using Microsoft.AspNetCore.Mvc;
using Practica.Net.Aplicacion.Personas;
using Practica.Net.Dominio.Contracts;
using Practica.Net.Infraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practica.Net.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PracticaNetContext _context;
        private readonly IPersonaRepository _personaRepository;
        public PersonaController(IUnitOfWork unitOfWork, IPersonaRepository personaRepository, PracticaNetContext context)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _personaRepository = personaRepository;

        }
        [HttpPost]
        public async Task<ActionResult> CreateTutor([FromBody] PersonaCommand command)
        {
            var service = new CrearPersonaCommandHandle(_unitOfWork, _personaRepository);
            var response = service.Handle(command);

            if (response.isOk())
            {
                await _context.SaveChangesAsync();
                return Ok(response);
            }
            return BadRequest(response.Mensaje);
        }
        [HttpGet]
        public ActionResult<List<PersonaCommand>> GetPersonas()
        {
            var result = new ConsultarPersonaQueryHandle(_personaRepository).Handle();

            return Ok(result.Personas);
        }
    }
}
