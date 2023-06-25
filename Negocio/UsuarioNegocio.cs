using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public Usuario Login(string contrasenia, string email)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select ID, IDTipoUsuario, Estado, EsAdmin  from Usuarios where Contrasenia = @Contrasenia and Email = @Email");
                datos.setearParametro("@Contrasenia", contrasenia);
                datos.setearParametro("@Email", email);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.Email = email;
                    aux.Password = contrasenia;
                    aux.Tipo = (TipoUsuario)datos.Lector.GetInt32(1);
                    aux.Estado = (EstadoUsuario)datos.Lector.GetInt32(2);
                    aux.EsAdmin = datos.Lector.GetBoolean(3);
                    return aux;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int Agregar(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            int id = 0;

            try
            {
                datos.setearConsulta("INSERT INTO Usuarios (IDTipoUsuario, Contrasenia, Email, Estado, EsAdmin) "
                        + "VALUES (@IDTipoUsuario, @Password, @Email, @Estado, @EsAdmin); SELECT SCOPE_IDENTITY() AS IDUsuario;");
                datos.setearParametro("@IDTipoUsuario", (int)usuario.Tipo);
                datos.setearParametro("@Password", usuario.Password);
                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Estado", (int)usuario.Estado);
                datos.setearParametro("@EsAdmin", usuario.EsAdmin);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    id = Convert.ToInt32(datos.Lector["IDUsuario"]);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return id;
        }
        public List<Usuario> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Usuario> lista = new List<Usuario>();
            try
            {
                datos.setearConsulta("select ID, IDTipoUsuario, Contrasenia, Email, Estado, EsAdmin from Usuarios");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.Tipo = (TipoUsuario)datos.Lector.GetInt32(1);
                    aux.Password = datos.Lector.GetString(2);
                    aux.Email = datos.Lector.GetString(3);
                    aux.Estado = (EstadoUsuario)datos.Lector.GetInt32(4);
                    aux.EsAdmin = datos.Lector.GetBoolean(5);
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void ActualizarEstado (int idPublicacion, EstadoUsuario estado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update Usuarios set Estado = @Estado where ID = @IdUsuario");
                datos.setearParametro("@IdUsuario", idPublicacion);
                datos.setearParametro("@Estado", estado);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void ActualizarAdmin(int idUsuario, bool esAdmin)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update Usuarios set EsAdmin = @EsAdmin where ID = @IdUsuario");
                datos.setearParametro("@IdUsuario", idUsuario);
                datos.setearParametro("@EsAdmin", esAdmin);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
