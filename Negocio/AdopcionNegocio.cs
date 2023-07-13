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
                datos.setearConsulta("select ID, IDPublicacion, IDUsuario, Estado, FechaHora from adopciones");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Adopcion aux = new Adopcion();
                    aux.ID = datos.Lector.GetInt32(0);
                    aux.IDPublicacion = datos.Lector.GetInt32(1);
                    aux.IDUsuario = datos.Lector.GetInt32(2);
                    aux.Estado = (EstadoAdopcion)datos.Lector.GetInt32(3);
                    aux.FechaHora = datos.Lector.GetDateTime(4);
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
        public List<Adopcion> ListarPorUsuario(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Adopcion> lista = new List<Adopcion>();

            try
            {
                datos.setearConsulta("select ID, IDPublicacion, IDUsuario, Estado, FechaHora from adopciones WHERE IDUsuario = @IDUsuario and Estado = 1");
                datos.setearParametro("@IDUsuario", idUsuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Adopcion aux = new Adopcion();
                    aux.ID = datos.Lector.GetInt32(0);
                    aux.IDPublicacion = datos.Lector.GetInt32(1);
                    aux.IDUsuario = datos.Lector.GetInt32(2);
                    aux.Estado = (EstadoAdopcion)datos.Lector.GetInt32(3);
                    aux.FechaHora = datos.Lector.GetDateTime(4);
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
        public List<Adopcion> ListarPorUsuarioAdmin(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Adopcion> lista = new List<Adopcion>();

            try
            {
                datos.setearConsulta("select ID, IDPublicacion, IDUsuario, Estado, FechaHora from adopciones WHERE IDUsuario = @IDUsuario and Estado <> 4");
                datos.setearParametro("@IDUsuario", idUsuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Adopcion aux = new Adopcion();
                    aux.ID = datos.Lector.GetInt32(0);
                    aux.IDPublicacion = datos.Lector.GetInt32(1);
                    aux.IDUsuario = datos.Lector.GetInt32(2);
                    aux.Estado = (EstadoAdopcion)datos.Lector.GetInt32(3);
                    aux.FechaHora = datos.Lector.GetDateTime(4);
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
        public List<Adopcion> ListarPorPublicacion(int idPublicacion)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Adopcion> lista = new List<Adopcion>();

            try
            {
                datos.setearConsulta("select ID, IDPublicacion, IDUsuario, Estado, FechaHora from adopciones WHERE IDPublicacion = @IDPublicacion");
                datos.setearParametro("@IDPublicacion", idPublicacion);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Adopcion aux = new Adopcion();
                    aux.ID = datos.Lector.GetInt32(0);
                    aux.IDPublicacion = datos.Lector.GetInt32(1);
                    aux.IDUsuario = datos.Lector.GetInt32(2);
                    aux.Estado = (EstadoAdopcion)datos.Lector.GetInt32(3);
                    aux.FechaHora = datos.Lector.GetDateTime(4);
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

        public void ActualizarEstado(int idAdopcion, EstadoAdopcion estado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update adopciones set Estado = @Estado where ID = @ID");
                datos.setearParametro("@ID", idAdopcion);
                datos.setearParametro("@Estado", estado);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
        public void ActualizarEstado(int idUsuario, int idPublicacion, EstadoAdopcion estado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update adopciones set Estado = @Estado where IDUsuario = @IDUsuario and IDPublicacion = @IDPublicacion");
                datos.setearParametro("@IDUsuario", idUsuario);
                datos.setearParametro("@IDPublicacion", idPublicacion);
                datos.setearParametro("@Estado", estado);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
        public void Insertar(int idUsuario, int IdPublicacion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into adopciones (IDPublicacion, IDUsuario, Estado, FechaHora) values (@IDPublicacion, @IDUsuario, @Estado, @FechaHora)");
                datos.setearParametro("@IDPublicacion", IdPublicacion);
                datos.setearParametro("@IDUsuario", idUsuario);
                datos.setearParametro("@Estado", EstadoAdopcion.Pendiente);
                datos.setearParametro("@FechaHora", DateTime.Now);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
        public bool EnDataBaseActivo(int idUsuario, int idPublicacion){
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select ID from adopciones where IDUsuario = @IDUsuario and IDPublicacion = @IDPublicacion AND Estado = 1");
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
            finally { datos.cerrarConexion(); }
        }
        public bool EnDataBase(int idUsuario, int idPublicacion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select ID from adopciones where IDUsuario = @IDUsuario and IDPublicacion = @IDPublicacion");
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
            finally { datos.cerrarConexion(); }
        }
        public void BajarAdopcionPorPublicacion(int idPublicacion, EstadoAdopcion estado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update adopciones set Estado = @Estado where IDPublicacion = @IDPublicacion");
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
                datos.setearConsulta("update adopciones set Estado = 2 where IDPublicacion = @IDPublicacion AND Estado = 1");
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
        public Adopcion ObtenerAdopcionPorID(int idAdopcion)
        {
            AccesoDatos datos = new AccesoDatos();
            Adopcion adopcion = null;

            try
            {
                datos.setearConsulta("select ID, IDPublicacion, IDUsuario, Estado, FechaHora from adopciones WHERE ID = @ID");
                datos.setearParametro("@ID", idAdopcion);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    adopcion = new Adopcion();
                    adopcion.ID = datos.Lector.GetInt32(0);
                    adopcion.IDPublicacion = datos.Lector.GetInt32(1);
                    adopcion.IDUsuario = datos.Lector.GetInt32(2);
                    adopcion.Estado = (EstadoAdopcion)datos.Lector.GetInt32(3);
                    adopcion.FechaHora = datos.Lector.GetDateTime(4);
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

    }
}
