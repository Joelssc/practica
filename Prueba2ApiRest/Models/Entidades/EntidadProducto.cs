using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba2ApiRest.Models.Entidades
{
    public class EntidadProducto
    {
        public int CodProducto { get; set; }
        public string Nombre { get; set; }
        public float Precio { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
    }
}
