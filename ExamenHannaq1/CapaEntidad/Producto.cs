using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Producto
    {
       public int idProducto { get; set; }
        public String nombre { get; set; }
        public String descripcion { get; set; }
        public int cantidad { get; set; }
        public int estado{ get; set; }
}
}
