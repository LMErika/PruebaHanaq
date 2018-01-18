using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDato
{
    public class datProducto
    {

        #region Singleton
        public static readonly datProducto instanciaConex = new datProducto();

        public static datProducto Instancia
        {
            get { return datProducto.instanciaConex; }
        }

        #endregion singleton

        #region metodos

        public List<Producto> ListaProducto()
        {
            SqlCommand cmd = null;
            List<Producto> lista = new List<Producto>();

            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("ListarProducto",cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Producto p = new Producto();
                    p.idProducto = Convert.ToInt32(dr["idp"]);
                    p.nombre = Convert.ToString(dr["nombrep"]);
                    p.descripcion = Convert.ToString(dr["descripcionp"]);
                    p.cantidad = Convert.ToInt32(dr["cantidadp"]);

                }

            }
            catch (Exception e)
            {

                throw e;
            }

            return lista;
        }


        public Boolean InsertarProducto(Producto p)
        {
            SqlCommand cmd = null;
            Boolean inserto = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("InsertarProdcuto",cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre",p.nombre);
                cmd.Parameters.AddWithValue("@descripcion",p.descripcion);
                cmd.Parameters.AddWithValue("@cantidad", p.cantidad);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { inserto = true; }

            }
            catch (Exception)
            {

                throw;
            }
            return inserto;
        }


        public Boolean EditarProducto(Producto p)
        {
            SqlCommand cmd = null;
            Boolean edito = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("editarProducto" ,cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", p.nombre);
                cmd.Parameters.AddWithValue("@descripcion", p.descripcion);
                cmd.Parameters.AddWithValue("@cantidad", p.cantidad);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { edito = true; }


            }
            catch (Exception)
            {

                throw;
            }
            return edito;
        }

        public Boolean EliminarProducto(Producto p)
        {
            SqlCommand cmd = null;
            Boolean elimino = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("EliminarProducto",cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idproducto",p.idProducto);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { elimino = true; }
            }
            catch (Exception)
            {

                throw;
            }
            return elimino;
        }

        public Producto BuscarProducto(Producto p)
        {
            SqlCommand cmd = null;
            Producto ppro = new Producto();

            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("BuscarProducto",cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idproducto", p.idProducto);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    p.nombre = Convert.ToString(dr["nombre"]);
                    p.descripcion = Convert.ToString(dr["descripcion"]);
                    p.cantidad = Convert.ToInt32(dr["cantidad"]);
                    p.estado = Convert.ToInt32(dr["estado"]);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return p;
        }

        #endregion metodos



    }
}
