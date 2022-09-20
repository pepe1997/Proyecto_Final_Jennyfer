using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entPermisos
{
    public class Permisos
    {
        public int IdPermisos { get; set; }
        public string Descripcion { get; set; }
        public int idSalidas { get; set; }
        public int idEntradas { get; set; }
        public int idProductos { get; set; }
        public int idClientes { get; set; }
        public int idProveedores { get; set; }
        public int idInventario { get; set; }
        public int idPedido { get; set; }
        public int Configuracion { get; set; }
    }
}
