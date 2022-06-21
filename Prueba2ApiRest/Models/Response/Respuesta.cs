using Prueba2ApiRest.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba2ApiRest.Models.Response
{
    public class Respuesta
    {
        public string Codigo { get; set; }
        public string Mensaje { get; set; }
        public object Dato { get; set; }
    }
}
