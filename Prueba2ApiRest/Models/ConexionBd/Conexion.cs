using Microsoft.Data.SqlClient;
using Prueba2ApiRest.Models.Response;
using System;

namespace Prueba2ApiRest.Models.ConexionBd
{
    public class Conexion
    {
        public SqlConnection Link { get; set; }

        public Conexion()
        {
            this.Link = new SqlConnection(Environment.GetEnvironmentVariable("Conexion").ToString());
        }
        public Respuesta Open()
        {
            Respuesta resp = new Respuesta();
            try
            {
                Link.Open();
                resp = new Respuesta()
                {
                    Codigo = "000",
                    Mensaje = "conexion a BD ",
                };
            }
            catch (Exception ex)
            {
                resp = new Respuesta()
                {
                    Codigo = "000",
                    Mensaje = "Error en la conexion a BD " + ex.Message + " " + ex.StackTrace,
                };
            }
            return resp;
        }
        public Respuesta Close()
        {
            Respuesta resp = new Respuesta();
            try
            {
                Link.Close();
                resp = new Respuesta()
                {
                    Codigo = "000",
                    Mensaje = "Exito al cerrar ConexionBD",
                };

            }
            catch (Exception ex)
            {
                resp = new Respuesta()
                {
                    Codigo = "000",
                    Mensaje = "Error al cerrar la conexion a BD " + ex.Message + " " + ex.StackTrace,
                };
            }
            return resp;
        }
    }
}
