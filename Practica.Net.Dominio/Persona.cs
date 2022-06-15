using OrganicSoft.Dominio.Base;
using System;

namespace Practica.Net.Dominio
{
    public class Persona : Entity<int>
    {
        public int Cedula { get; private set; }
        public String Nombre { get; private set; }
        public Persona(int cedula, string nombreCurso)
        {
            Cedula = cedula;
            Nombre = nombreCurso;
        }

        public Persona()
        {
        }
    }
}
