using System;

namespace Entidades
{
    public class Cliente
    {
        public string Identidad { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool EstadoActivo { get; set; }

        public Cliente()
        {
        }

        public Cliente(string identidad, string nombre, string telefono, string correo, string direccion, DateTime fechaNacimiento, bool estadoActivo)
        {
            Identidad = identidad;
            Nombre = nombre;
            Telefono = telefono;
            Correo = correo;
            Direccion = direccion;
            FechaNacimiento = fechaNacimiento;
            EstadoActivo = estadoActivo;
        }
    }
}
