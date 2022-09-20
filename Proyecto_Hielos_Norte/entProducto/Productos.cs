using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entProducto
{
    public class Productos
    {
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public string Almacen { get; set; }
        public int Stock { get; set; }
        public string PrecioVenta { get; set; }
    }
}
