using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entPermisos;
using AccesoDatos.DataBase;

namespace AccesoDatos.DaoEntidades
{
    public class datPermisos
    {
        private static datPermisos _instancia = null;

        public datPermisos()
        {

        }

        public static datPermisos Instancia
        {

            get
            {
                if (_instancia == null) _instancia = new datPermisos();
                return _instancia;
            }
        }



        public Permisos Obtener(int idpermisos)
        {
            Permisos obj = new Permisos();
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();
                    string query = "select IdPermisos,Descripcion,Salidas,Entradas,Productos,Clientes,Proveedores,Inventario,Configuracion from PERMISOS where IdPermisos = @pid";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.Add(new SqlParameter("@pid", idpermisos));
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Permisos()
                            {
                                IdPermisos = int.Parse(dr["IdPermisos"].ToString()),
                                Descripcion = dr["Descripcion"].ToString(),
                                idSalidas = int.Parse(dr["Salidas"].ToString()),
                                idEntradas = int.Parse(dr["Entradas"].ToString()),
                                idProductos = int.Parse(dr["Productos"].ToString()),
                                idClientes = int.Parse(dr["Clientes"].ToString()),
                                idProveedores = int.Parse(dr["Proveedores"].ToString()),
                                idInventario = int.Parse(dr["Inventario"].ToString()),
                                idPedido = int.Parse(dr["Pedido"].ToString()),
                                Configuracion = int.Parse(dr["Configuracion"].ToString())
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                obj = new Permisos();
            }
            return obj;
        }

        public int Guardar(Permisos objeto, out string mensaje)
        {
            mensaje = string.Empty;
            int respuesta = 0;
            try
            {

                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {

                    conexion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update PERMISOS SET");
                    query.AppendLine("Salidas = @psalida,");
                    query.AppendLine("Entradas = @pentrada,");
                    query.AppendLine("Productos = @pproducto,");
                    query.AppendLine("Clientes = @pcliente,");
                    query.AppendLine("Proveedores = @pproveedor,");
                    query.AppendLine("Inventario = @pinventario,");
                    query.AppendLine("Configuracion = @pconfiguracion");
                    query.AppendLine("where IdPermisos = @pid;");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.Add(new SqlParameter("@psalida", objeto.idSalidas));
                    cmd.Parameters.Add(new SqlParameter("@pentrada", objeto.idEntradas));
                    cmd.Parameters.Add(new SqlParameter("@pproducto", objeto.idProductos));
                    cmd.Parameters.Add(new SqlParameter("@pcliente", objeto.idClientes));
                    cmd.Parameters.Add(new SqlParameter("@pproveedor", objeto.idProveedores));
                    cmd.Parameters.Add(new SqlParameter("@pinventario", objeto.idInventario));
                    cmd.Parameters.Add(new SqlParameter("@pedido", objeto.idPedido));
                    cmd.Parameters.Add(new SqlParameter("@pconfiguracion", objeto.Configuracion));
                    cmd.Parameters.Add(new SqlParameter("@pid", objeto.IdPermisos));
                    cmd.CommandType = System.Data.CommandType.Text;

                    respuesta = cmd.ExecuteNonQuery();
                    if (respuesta < 1)
                        mensaje = "No se pudo actualizar los permisos";

                }
            }
            catch (Exception ex)
            {

                respuesta = 0;
                mensaje = ex.Message;
            }

            return respuesta;
        }
    }
}
