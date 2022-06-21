using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba2ApiRest.Models.Entidades
{
    public class EntidadUsuario
    {
        public int Codusuario { get; set; }
        public string Nombres { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Trabajo { get; set; }
        public string Domicilio { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
    }
}
