using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
                    Usuario aux = new Usuario
                    {
                        Id = datos.Lector.GetInt32(0),
                        Email = email,
                        Password = contrasenia,
                        Tipo = (TipoUsuario)datos.Lector.GetInt32(1),
                        Estado = (EstadoUsuario)datos.Lector.GetInt32(2),
                        EsAdmin = datos.Lector.GetBoolean(3)
                    };
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

        public Usuario BuscarxID(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            Usuario aux = new Usuario();

            try
            {
                datos.setearConsulta("select ID, IDTipoUsuario, Estado, EsAdmin,Email,Contrasenia from Usuarios where ID=" + idUsuario);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.Email = (string)datos.Lector["Email"]; ;
                    aux.Password = (string)datos.Lector["Contrasenia"];
                    aux.Tipo = (TipoUsuario)datos.Lector.GetInt32(1);
                    aux.Estado = (EstadoUsuario)datos.Lector.GetInt32(2);
                    aux.EsAdmin = datos.Lector.GetBoolean(3);
                }
      
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
   
            return aux;
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
                    Usuario aux = new Usuario
                    {
                        Id = datos.Lector.GetInt32(0),
                        Tipo = (TipoUsuario)datos.Lector.GetInt32(1),
                        Password = datos.Lector.GetString(2),
                        Email = datos.Lector.GetString(3),
                        Estado = (EstadoUsuario)datos.Lector.GetInt32(4),
                        EsAdmin = datos.Lector.GetBoolean(5)
                    };
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
        public List<Usuario> ListarPorIDUsuario (int iDUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Usuario> lista = new List<Usuario>();
            try
            {
                datos.setearConsulta("select ID, IDTipoUsuario, Contrasenia, Email, Estado, EsAdmin from Usuarios where ID = @ID");
                datos.setearParametro("@ID", iDUsuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario
                    {
                        Id = datos.Lector.GetInt32(0),
                        Tipo = (TipoUsuario)datos.Lector.GetInt32(1),
                        Password = datos.Lector.GetString(2),
                        Email = datos.Lector.GetString(3),
                        Estado = (EstadoUsuario)datos.Lector.GetInt32(4),
                        EsAdmin = datos.Lector.GetBoolean(5)
                    };
                    lista.Add(aux);
                }
                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
        public Usuario BuscarPorEmail(string email)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                Usuario aux = new Usuario();
                datos.setearConsulta("select ID, IDTipoUsuario,Contrasenia, Email, Estado, EsAdmin, ResetToken, ResetTokenExpiracion from Usuarios where Email = @Email");
                datos.setearParametro("@Email", email);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.Tipo = (TipoUsuario)datos.Lector.GetInt32(1);
                    aux.Password = datos.Lector.GetString(2);
                    aux.Email = datos.Lector.GetString(3);
                    aux.Estado = (EstadoUsuario)datos.Lector.GetInt32(4);
                    aux.EsAdmin = datos.Lector.GetBoolean(5);

                    if (!datos.Lector.IsDBNull(6))
                    {
                        aux.Token = datos.Lector.GetString(6);
                    }

                    if (!datos.Lector.IsDBNull(7))
                    {
                        aux.TokenExpiracion = datos.Lector.GetDateTime(7);
                    }
                }
                return aux;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
        public void InsertarToken(int idUser, string token, DateTime tokenDate)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Usuarios SET ResetToken = @token, ResetTokenExpiracion = @tokenDate WHERE id = @id");
                datos.setearParametro("@id", idUser);
                datos.setearParametro("@token", token);
                datos.setearParametro("@tokenDate", tokenDate);
                datos.ejecutarLectura();

            }
            catch (Exception ex)
            {
                throw ex;
            } finally { datos.cerrarConexion(); }
        }

        public void CambiarContrasenia(int id, string newPassword)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Usuarios SET Contrasenia = @newPassword WHERE ID = @id");
                datos.setearParametro("@newPassword", newPassword);
                datos.setearParametro("@id", id);
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

        public void ActualizarToken(int id, string token, DateTime? tokenDate)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Usuarios SET ResetToken = @token, ResetTokenExpiracion = @tokenDate WHERE ID = @id");
                datos.setearParametro("@id", id);

                if (string.IsNullOrEmpty(token))
                {
                    datos.setearParametro("@token", DBNull.Value);
                }
                else
                {
                    datos.setearParametro("@token", token);
                }

                if (tokenDate.HasValue)
                {
                    datos.setearParametro("@tokenDate", tokenDate.Value);
                }
                else
                {
                    datos.setearParametro("@tokenDate", DBNull.Value);
                }

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
        public void ActualizarTipo(int idUsuario, TipoUsuario tipo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Usuarios SET IDTipoUsuario = @tipo WHERE ID = @idUsuario");
                datos.setearParametro("@tipo", (int)tipo);
                datos.setearParametro("@idUsuario", idUsuario);
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
