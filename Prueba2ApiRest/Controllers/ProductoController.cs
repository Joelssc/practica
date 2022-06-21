using Microsoft.AspNetCore.Mvc;
using Prueba2ApiRest.Logica;
using Prueba2ApiRest.Models.Entidades;
using Prueba2ApiRest.Models.ReponseEntity;
using Prueba2ApiRest.Models.Response;
using System;
using System.Collections.Generic;

namespace Prueba2ApiRest.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductoController : Controller
    {
        [HttpGet("ok")]
        public List<EntidadProducto> Get()
        {
            Respuesta resp = new Respuesta();
            ProductoLogico producto = new ProductoLogico();
            ProductoRespuesta lproducto = new ProductoRespuesta();
            List<EntidadProducto> list = new List<EntidadProducto>();
            try
            {
                list = producto.ListarProducto();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en el control" + ex.Message + "" + ex.StackTrace);
            }
            return list;
        }

        [HttpPost("addProducto")]
        public void IngresarProducto(EntidadProducto producto)
        {

            try
            {
                ProductoLogico productoLogico = new ProductoLogico();
                productoLogico.InsertarProducto(producto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Error control" + ex.StackTrace);
            }
        }

        [HttpPut("actualizar")]
        public void ActualizarProducto(EntidadProducto producto)
        {
            try
            {
                ProductoLogico PL = new ProductoLogico();
                PL.ActualizarProducto(producto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Error Logico" + ex.StackTrace);
            }
        }
        [HttpDelete("borrar")]
        public void EliminarProducto(int codigo)
        {
            try
            {
                ProductoLogico PL = new ProductoLogico();
                PL.EliminarProducto(codigo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Error en control" + ex.StackTrace);
            }
        }
    }
}
