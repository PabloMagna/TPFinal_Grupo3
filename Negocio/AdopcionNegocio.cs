using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class AdopcionNegocio
    {
        public List<Adopcion> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Adopcion> lista = new List<Adopcion>();

            try
            {
                datos.setearConsulta("SELECT IDPublicacion, IDUsuario, Estado, FechaHora, Comentario FROM Adopciones");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Adopcion aux = new Adopcion();
                    aux.IDPublicacion = datos.Lector.GetInt32(0);
                    aux.IDUsuario = datos.Lector.GetInt32(1);
                    aux.Estado = (EstadoAdopcion)datos.Lector.GetInt32(2);
                    aux.FechaHora = datos.Lector.GetDateTime(3);
                    aux.Comentario = datos.Lector.IsDBNull(4) ? null : datos.Lector.GetString(4);
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

        public List<Adopcion> ListarPorUsuario(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Adopcion> lista = new List<Adopcion>();

            try
            {
                datos.setearConsulta("SELECT IDPublicacion, IDUsuario, Estado, FechaHora, Comentario FROM Adopciones WHERE IDUsuario = @IDUsuario AND Estado = 1");
                datos.setearParametro("@IDUsuario", idUsuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Adopcion aux = new Adopcion();
                    aux.IDPublicacion = datos.Lector.GetInt32(0);
                    aux.IDUsuario = datos.Lector.GetInt32(1);
                    aux.Estado = (EstadoAdopcion)datos.Lector.GetInt32(2);
                    aux.FechaHora = datos.Lector.GetDateTime(3);
                    aux.Comentario = datos.Lector.IsDBNull(4) ? null : datos.Lector.GetString(4);
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
        public List<Adopcion> ListarPorUsuarioPerfil(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Adopcion> lista = new List<Adopcion>();

            try
            {
                datos.setearConsulta("SELECT IDPublicacion, IDUsuario, Estado, FechaHora, Comentario FROM Adopciones WHERE IDUsuario = @IDUsuario AND Estado IN (1,2,3,4,5)");
                datos.setearParametro("@IDUsuario", idUsuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Adopcion aux = new Adopcion();
                    aux.IDPublicacion = datos.Lector.GetInt32(0);
                    aux.IDUsuario = datos.Lector.GetInt32(1);
                    aux.Estado = (EstadoAdopcion)datos.Lector.GetInt32(2);
                    aux.FechaHora = datos.Lector.GetDateTime(3);
                    aux.Comentario = datos.Lector.IsDBNull(4) ? null : datos.Lector.GetString(4);
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
        public List<Adopcion> ListarPorUsuarioActivas(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Adopcion> lista = new List<Adopcion>();

            try
            {
                datos.setearConsulta("SELECT IDPublicacion, IDUsuario, Estado, FechaHora, Comentario FROM Adopciones WHERE IDUsuario = @IDUsuario AND Estado = 1 OR Estado = 2");
                datos.setearParametro("@IDUsuario", idUsuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Adopcion aux = new Adopcion();
                    aux.IDPublicacion = datos.Lector.GetInt32(0);
                    aux.IDUsuario = datos.Lector.GetInt32(1);
                    aux.Estado = (EstadoAdopcion)datos.Lector.GetInt32(2);
                    aux.FechaHora = datos.Lector.GetDateTime(3);
                    aux.Comentario = datos.Lector.IsDBNull(4) ? null : datos.Lector.GetString(4);
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

        public List<Adopcion> ListarPorUsuarioAdmin(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Adopcion> lista = new List<Adopcion>();

            try
            {
                datos.setearConsulta("SELECT IDPublicacion, IDUsuario, Estado, FechaHora, Comentario FROM Adopciones WHERE IDUsuario = @IDUsuario AND Estado <> 4");
                datos.setearParametro("@IDUsuario", idUsuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Adopcion aux = new Adopcion();
                    aux.IDPublicacion = datos.Lector.GetInt32(0);
                    aux.IDUsuario = datos.Lector.GetInt32(1);
                    aux.Estado = (EstadoAdopcion)datos.Lector.GetInt32(2);
                    aux.FechaHora = datos.Lector.GetDateTime(3);
                    aux.Comentario = datos.Lector.IsDBNull(4) ? null : datos.Lector.GetString(4);
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

        public List<Adopcion> ListarPorPublicacion(int idPublicacion)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Adopcion> lista = new List<Adopcion>();

            try
            {
                datos.setearConsulta("SELECT IDPublicacion, IDUsuario, Estado, FechaHora, Comentario FROM Adopciones WHERE IDPublicacion = @IDPublicacion");
                datos.setearParametro("@IDPublicacion", idPublicacion);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Adopcion aux = new Adopcion();
                    aux.IDPublicacion = datos.Lector.GetInt32(0);
                    aux.IDUsuario = datos.Lector.GetInt32(1);
                    aux.Estado = (EstadoAdopcion)datos.Lector.GetInt32(2);
                    aux.FechaHora = datos.Lector.GetDateTime(3);
                    aux.Comentario = datos.Lector.IsDBNull(4) ? null : datos.Lector.GetString(4);
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

        public void ActualizarEstado(int idUsuario, int idPublicacion, EstadoAdopcion estado)
        {
            ActualizarEstado(idUsuario, idPublicacion, estado, null);
        }

        public void ActualizarEstado(int idUsuario, int idPublicacion, EstadoAdopcion estado, string comentario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Adopciones SET Estado = @Estado, Comentario = @Comentario WHERE IDUsuario = @IDUsuario AND IDPublicacion = @IDPublicacion");
                datos.setearParametro("@IDUsuario", idUsuario);
                datos.setearParametro("@IDPublicacion", idPublicacion);
                datos.setearParametro("@Estado", estado);

                if (comentario != null)
                    datos.setearParametro("@Comentario", comentario);
                else
                    datos.setearParametro("@Comentario", DBNull.Value);

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

        public void Insertar(int idUsuario, int idPublicacion, string comentario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Adopciones (IDPublicacion, IDUsuario, Estado, FechaHora, Comentario) VALUES (@IDPublicacion, @IDUsuario, @Estado, @FechaHora, @Comentario)");
                datos.setearParametro("@IDPublicacion", idPublicacion);
                datos.setearParametro("@IDUsuario", idUsuario);
                datos.setearParametro("@Estado", EstadoAdopcion.Pendiente);
                datos.setearParametro("@FechaHora", DateTime.Now);

                if (comentario != null)
                    datos.setearParametro("@Comentario", comentario);
                else
                    datos.setearParametro("@Comentario", DBNull.Value);

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


        public bool EnDataBaseActivo(int idUsuario, int idPublicacion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT IDUsuario FROM Adopciones WHERE IDUsuario = @IDUsuario AND IDPublicacion = @IDPublicacion AND Estado = 1");
                datos.setearParametro("@IDUsuario", idUsuario);
                datos.setearParametro("@IDPublicacion", idPublicacion);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return true;
                }
                else
                {
                    return false;
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

        public bool EnDataBase(int idUsuario, int idPublicacion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT IDUsuario FROM Adopciones WHERE IDUsuario = @IDUsuario AND IDPublicacion = @IDPublicacion");
                datos.setearParametro("@IDUsuario", idUsuario);
                datos.setearParametro("@IDPublicacion", idPublicacion);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return true;
                }
                else
                {
                    return false;
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

        public void BajarAdopcionPorPublicacion(int idPublicacion, EstadoAdopcion estado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Adopciones SET Estado = @Estado WHERE IDPublicacion = @IDPublicacion");
                datos.setearParametro("@Estado", estado);
                datos.setearParametro("@IDPublicacion", idPublicacion);
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

        public void CompletarAdopcionPendiente(int idPublicacion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Adopciones SET Estado = 2 WHERE IDPublicacion = @IDPublicacion AND Estado = 1");
                datos.setearParametro("@IDPublicacion", idPublicacion);
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

        public Adopcion ObtenerAdopcionPorID(int idPublicacion, int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            Adopcion adopcion = null;

            try
            {
                datos.setearConsulta("SELECT IDPublicacion, IDUsuario, Estado, FechaHora, Comentario FROM Adopciones WHERE IDUsuario = @IDUsuario AND IDPublicacion = @IDPublicacion");
                datos.setearParametro("@IDUsuario", idUsuario);
                datos.setearParametro("@IDPublicacion", idPublicacion);
                datos.ejecutarAccion();

                if (datos.Lector.Read())
                {
                    adopcion = new Adopcion();
                    adopcion.IDPublicacion = datos.Lector.GetInt32(0);
                    adopcion.IDUsuario = datos.Lector.GetInt32(1);
                    adopcion.Estado = (EstadoAdopcion)datos.Lector.GetInt32(2);
                    adopcion.FechaHora = datos.Lector.GetDateTime(3);
                    adopcion.Comentario = datos.Lector.IsDBNull(4) ? null : datos.Lector.GetString(4);
                }

                return adopcion;
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
        public void ActualizarEstadoActivaActual(int idPublicacion, EstadoAdopcion estadoAdopcion, string comentario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Adopciones SET Estado = @Estado, Comentario = @Comentario WHERE IDPublicacion = @IDPublicacion AND Estado = 1");
                datos.setearParametro("@Estado", estadoAdopcion);
                datos.setearParametro("@IDPublicacion", idPublicacion);
                if (comentario != null)
                    datos.setearParametro("@Comentario", comentario);
                else
                    datos.setearParametro("@Comentario", DBNull.Value);
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
