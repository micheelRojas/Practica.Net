using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.Net.Aplicacion.Personas
{
    public class PersonaCommand
    {   
        public int Id  {get; set; }
        public int Cedula { get; set; }
        public String Nombre { get; set; }
        public PersonaCommand(int cedula, string nombre)
        {
            Cedula = cedula;
            Nombre = nombre;
        }

        public PersonaCommand()
        {
        }

        public virtual IReadOnlyList<string> CanCrear()
        {
            var errors = new List<string>();

            if ((Cedula == 0))
                errors.Add("Cedula de la persona no especificada");

            if (string.IsNullOrEmpty(Nombre))
                errors.Add("Nombre de la persona no especificado");

            return errors;
        }
    }
}
