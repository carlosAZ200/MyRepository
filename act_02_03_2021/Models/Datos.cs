using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace act_02_03_2021.Models
{
    public class Datos
    {
        public string Correo { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string RepetirClave { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string PaisOrigen { get; set; }
        public string Provincia { get; set; }
        public string CodigoPostal { get; set; }
        public string Sexo { get; set; }
        public string FechaNacimiento { get; set; }
        public string Comentarios { get; set; }
        public string AceptoTerminos { get; set; }
    }
}