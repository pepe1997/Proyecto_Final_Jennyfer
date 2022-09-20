using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.DataBase;
using entUsuario;
using Microsoft.Data.Sqlite;

namespace AccesoDatos.DaoEntidades
{
    public class datUsuario
    {
        private static datUsuario _instancia = null;

        public datUsuario()
        {

        }

        public static datUsuario Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new datUsuario();
                return _instancia;
            }
        }

        public int resetear()
        {
            int respuesta = 0;
            try
            {
                using (SqliteConnection conexion = new SqliteConnection(Conexion.cadena))
                {
                    conexion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update USUARIO set NombreUsuario = 'Admin', Clave = '123' where IdUsuario = 1;");
                    SqliteCommand cmd = new SqliteCommand(query.ToString(), conexion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    respuesta = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                respuesta = 0;
            }

            return respuesta;
        }


        public List<Usuario> Listar(out string mensaje)
        {
            mensaje = string.Empty;
            List<Usuario> oLista = new List<Usuario>();

            try
            {
                using (SqliteConnection conexion = new SqliteConnection(Conexion.cadena))
                {


                    conexion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select u.IdUsuario,u.NombreCompleto,u.NombreUsuario,u.Clave,u.IdPermisos,p.Descripcion from USUARIO u");
                    query.AppendLine("inner join PERMISOS p on p.IdPermisos = u.IdPermisos;");

                    SqliteCommand cmd = new SqliteCommand(query.ToString(), conexion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SqliteDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new Usuario()
                            {
                                IdUsuario = int.Parse(dr["IdUsuario"].ToString()),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                NombreUsuario = dr["NombreUsuario"].ToString(),
                                Clave = dr["Clave"].ToString(),
                                IdPermisos = Convert.ToInt32(dr["IdPermisos"].ToString()),
                                Descripcion = dr["Descripcion"].ToString(),
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                oLista = new List<Usuario>();
                mensaje = ex.Message;
            }
            return oLista;
        }

        public int Existe(string usuario, int defaultid, out string mensaje)
        {
            mensaje = string.Empty;
            int respuesta = 0;
            using (SqliteConnection conexion = new SqliteConnection(Conexion.cadena))
            {
                try
                {
                    conexion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select count(*)[resultado] from USUARIO where upper(NombreUsuario) = upper(@pnombreusuario) and IdUsuario != @defaultid");

                    SqliteCommand cmd = new SqliteCommand(query.ToString(), conexion);
                    cmd.Parameters.Add(new SqliteParameter("@pnombreusuario", usuario));
                    cmd.Parameters.Add(new SqliteParameter("@defaultid", defaultid));
                    cmd.CommandType = System.Data.CommandType.Text;

                    respuesta = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    if (respuesta > 0)
                        mensaje = "El usuario ya existe";

                }
                catch (Exception ex)
                {
                    respuesta = 0;
                    mensaje = ex.Message;
                }

            }
            return respuesta;
        }

        public int Guardar(Usuario objeto, out string mensaje)
        {
            mensaje = string.Empty;
            int respuesta = 0;

            using (SqliteConnection conexion = new SqliteConnection(Conexion.cadena))
            {
                try
                {
                    conexion.Open();
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("insert into USUARIO(NombreCompleto,NombreUsuario,Clave,IdPermisos) values (@pnombrecompleto,@pnombreusuario,@pclave,@pidpermisos);");
                    query.AppendLine("select last_insert_rowid();");

                    SqliteCommand cmd = new SqliteCommand(query.ToString(), conexion);
                    cmd.Parameters.Add(new SqliteParameter("@pnombrecompleto", objeto.NombreCompleto));
                    cmd.Parameters.Add(new SqliteParameter("@pnombreusuario", objeto.NombreUsuario));
                    cmd.Parameters.Add(new SqliteParameter("@pclave", objeto.Clave));
                    cmd.Parameters.Add(new SqliteParameter("@pidpermisos", objeto.IdPermisos));
                    cmd.CommandType = System.Data.CommandType.Text;

                    respuesta = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    if (respuesta < 1)
                        mensaje = "No se pudo registrar el usuario";
                }
                catch (Exception ex)
                {
                    respuesta = 0;
                    mensaje = ex.Message;
                }
            }

            return respuesta;
        }

        public int Editar(Usuario objeto, out string mensaje)
        {
            mensaje = string.Empty;
            int respuesta = 0;

            using (SqliteConnection conexion = new SqliteConnection(Conexion.cadena))
            {
                try
                {
                    conexion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update USUARIO set NombreCompleto = @pnombrecompleto,NombreUsuario = @pnombreusuario,Clave = @pclave,IdPermisos = @pidpermisos  where IdUsuario = @pid");

                    SqliteCommand cmd = new SqliteCommand(query.ToString(), conexion);
                    cmd.Parameters.Add(new SqliteParameter("@pnombrecompleto", objeto.NombreCompleto));
                    cmd.Parameters.Add(new SqliteParameter("@pnombreusuario", objeto.NombreUsuario));
                    cmd.Parameters.Add(new SqliteParameter("@pclave", objeto.Clave));
                    cmd.Parameters.Add(new SqliteParameter("@pidpermisos", objeto.IdPermisos));
                    cmd.Parameters.Add(new SqliteParameter("@pid", objeto.IdUsuario));
                    cmd.CommandType = System.Data.CommandType.Text;

                    respuesta = cmd.ExecuteNonQuery();
                    if (respuesta < 1)
                        mensaje = "No se pudo editar el usuario";
                }
                catch (Exception ex)
                {
                    respuesta = 0;
                    mensaje = ex.Message;
                }
            }
            return respuesta;
        }


        public int Eliminar(int id)
        {
            int respuesta = 0;
            try
            {
                using (SqliteConnection conexion = new SqliteConnection(Conexion.cadena))
                {
                    conexion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("delete from USUARIO where IdUsuario= @id;");
                    SqliteCommand cmd = new SqliteCommand(query.ToString(), conexion);
                    cmd.Parameters.Add(new SqliteParameter("@id", id));
                    cmd.CommandType = System.Data.CommandType.Text;
                    respuesta = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                respuesta = 0;
            }
            return respuesta;
        }
    }
}
