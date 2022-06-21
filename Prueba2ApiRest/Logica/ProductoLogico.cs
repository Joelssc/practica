using Prueba2ApiRest.Data;
using Prueba2ApiRest.Models.Entidades;
using Prueba2ApiRest.Models.ReponseEntity;
using Prueba2ApiRest.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba2ApiRest.Logica
{
    public class ProductoLogico
    {
        MappeoDatoProducto mappeoDatoProducto = new MappeoDatoProducto();
        public List<EntidadProducto> ListarProducto()
        {
            List<EntidadProducto> list = new List<EntidadProducto>();
            try
            {
                list = mappeoDatoProducto.ListarProducto();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Eorror logico" + ex.Message + " " + ex.StackTrace);
            }
            return list;
        }
        public void InsertarProducto(EntidadProducto producto)
        {
            try
            {
                EntidadProducto product = new EntidadProducto();
                mappeoDatoProducto.IngrsearProducto(producto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Error en Logica insert" + ex.StackTrace);
            }
        }
        public void ActualizarProducto(EntidadProducto producto)
        {
            try
            {
                mappeoDatoProducto.ActualizarProducto(producto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Error Logico" + ex.StackTrace);
            }
        }
        public void EliminarProducto(int codigo)
        {
            try
            {
                mappeoDatoProducto.EliminarProducto(codigo);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message + "Error logico" + ex.StackTrace);
            }
        }
    }
}
