using Microsoft.Data.SqlClient;
using Prueba2ApiRest.Models.ConexionBd;
using Prueba2ApiRest.Models.Entidades;
using Prueba2ApiRest.Models.ReponseEntity;
using Prueba2ApiRest.Models.Response;
using System;
using System.Collections.Generic;
using System.Data;

namespace Prueba2ApiRest.Data
{
    public class MappeoDatoProducto
    {
        public List<EntidadProducto> ListarProducto()
        {
            Conexion con = new Conexion();

            SqlCommand cmd = new SqlCommand("Sp_Producto", con.Link);

            cmd.Parameters.Add(new SqlParameter("@option", SqlDbType.Int)).Value = 1;

            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Close();
            sda.Fill(dt);

            List<EntidadProducto> listp = new List<EntidadProducto>();

            if (dt.Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        listp.Add(new EntidadProducto()
                        {
                            CodProducto = int.Parse(dr["Codproducto"].ToString()),
                            Nombre = dr["Nombre"].ToString(),
                            Precio = float.Parse(dr["Precio"].ToString()),
                            Descripcion = dr["Descripcion"].ToString(),
                            Cantidad = int.Parse(dr["Cantidad"].ToString()),
                        });
                    }
                    if (listp.Count > 0)
                    {
                        return listp;
                    }
                    else
                    {
                        Console.WriteLine("Error al recolectar las listas");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "Error mapeo" + ex.StackTrace);
                }
            }
            else
            {
                Console.WriteLine("Error en mapeo no existe Datos");
            }
            return null;
        }

        public void IngrsearProducto(EntidadProducto Producto)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand("Sp_Producto", con.Link);

            cmd.Parameters.Add(new SqlParameter("@option", SqlDbType.Int)).Value = 2;
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 20)).Value = Producto.Nombre;
            cmd.Parameters.Add(new SqlParameter("@precio", SqlDbType.Float)).Value = Producto.Precio;
            cmd.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.VarChar, 50)).Value = Producto.Descripcion;
            cmd.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int)).Value = Producto.Cantidad;

            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Close();
            sda.Fill(dt);

            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Error Mapeo ingresar" + ex.StackTrace);
            }
        }
        public void ActualizarProducto(EntidadProducto producto)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand("Sp_Producto", con.Link);

            try
            {
                cmd.Parameters.Add(new SqlParameter("@option", SqlDbType.Int)).Value = 3;
                cmd.Parameters.Add(new SqlParameter("@codproducto", SqlDbType.Int)).Value = producto.CodProducto;
                cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 20)).Value = producto.Nombre;
                cmd.Parameters.Add(new SqlParameter("@precio", SqlDbType.Float)).Value = producto.Precio;
                cmd.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.VarChar, 50)).Value = producto.Descripcion;
                cmd.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int)).Value = producto.Cantidad;

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sda.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Error al Actualizar mapeo" + ex.StackTrace);
            }
        }

        public void EliminarProducto(int codigo)
        {
            Conexion con = new Conexion();
            EntidadProducto Ep = new EntidadProducto();
            SqlCommand cmd = new SqlCommand("Sp_Producto", con.Link);

            try
            {
                cmd.Parameters.Add(new SqlParameter("@option", SqlDbType.Int)).Value = 4;
                cmd.Parameters.Add(new SqlParameter("@codproducto", SqlDbType.Int)).Value = codigo;
                cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 20)).Value = Ep.Nombre;
                cmd.Parameters.Add(new SqlParameter("@precio", SqlDbType.Float)).Value = Ep.Precio;
                cmd.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.VarChar, 50)).Value = Ep.Descripcion;
                cmd.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int)).Value = Ep.Cantidad;

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sda.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Error en Eliminar mapeo" + ex.StackTrace);
            }
        }
    }
}