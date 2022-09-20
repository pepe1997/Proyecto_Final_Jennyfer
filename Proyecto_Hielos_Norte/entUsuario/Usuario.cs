using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entUsuario
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string nombUsuario { get; set; }
        public string nickUsuario { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public int IdPermisos { get; set; }
    }
}
