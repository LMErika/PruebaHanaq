using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CapaDato
{
    public class Conexion
    {


        #region singleton
        private static readonly Conexion instaConexion = new Conexion();
        public static Conexion Instancia
        {
            get { return Conexion.instaConexion; }
        }

        #endregion singleton

        #region metodos
        public SqlConnection conectar()
        {
            var cn = new SqlConnection
            {
                ConnectionString = "Data Source=DESKTOP-G7OSKDD\\SQLEXPRESS;Initial Catalog=BDExamenHannaq;Integrated Security=True"
            };
            //"Data Source=localhost;Initial Catalog=BDExamenTrabajo;Integrated Security=True";
            //\\Erika

            //cn.ConnectionString = "Data source=tcp:almacenevo.database.windows.net,1433;" +
            //    "Initial Catalog=sysAlmacenEVO; " +
            //    "ID=Administrador; Password=Erika123;";

            //cn.ConnectionString = "Data Source=sisalmacendb.cmdjfoqsbg9m.us-east-2.rds.amazonaws.com,1433;Initial Catalog=SisAlmacen;User ID=erika;Password=Admin123";


            return cn;
        }
        #endregion metodos
    }
}
