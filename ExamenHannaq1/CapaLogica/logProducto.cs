using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDato;
using CapaEntidad;

namespace CapaLogica
{
    public class logProducto
    {
        #region singleton
        public static readonly logProducto instanciaConex = new logProducto();

        public static logProducto Instacia
        {
            get { return logProducto.instanciaConex; }
        }
        #endregion singleton

        #region metodos

        public List<Producto> ListaProducto()
        {
            try
            {
                return datProducto.instanciaConex.ListaProducto();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
           
        #endregion metodos
    }
}
