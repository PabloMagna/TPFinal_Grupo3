using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class HistoriaNegocio
    {
        public void ActualizarEstado(int idHistoria, EstadoHistoria estadoHistoria)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update Historias set Estado = @Estado where ID = @IdHisotoria");
                datos.setearParametro("@Estado", estadoHistoria);
                datos.setearParametro("@IdHisotoria", idHistoria);
                datos.ejecutarLectura();
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

        public List<Historia> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Historia> lista = new List<Historia>();

            try
            {
                datos.setearConsulta("select ID, IDUsuario, Descripcion,UrlImagen,FechaHora,Estado from Historias");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Historia aux = new Historia();
                    aux.ID = datos.Lector.GetInt32(0);
                    aux.IDUsuario = datos.Lector.GetInt32(1);
                    aux.Descripcion = datos.Lector.GetString(2);
                    aux.UrlImagen = datos.Lector.GetString(3);
                    aux.FechaHora = datos.Lector.GetDateTime(4);
                    aux.Estado = (EstadoHistoria)datos.Lector.GetInt32(5);
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

        public List<Historia> ListarPorUsuario(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Historia> lista = new List<Historia>();

            try
            {
                datos.setearConsulta("select ID, IDUsuario, Descripcion,UrlImagen,FechaHora,Estado from Historias Where IdUsuario = @IdUsuario");
                datos.setearParametro("@IdUsuario", idUsuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Historia aux = new Historia();
                    aux.ID = datos.Lector.GetInt32(0);
                    aux.IDUsuario = datos.Lector.GetInt32(1);
                    aux.Descripcion = datos.Lector.GetString(2);
                    aux.UrlImagen = datos.Lector.GetString(3);
                    aux.FechaHora = datos.Lector.GetDateTime(4);
                    aux.Estado = (EstadoHistoria)datos.Lector.GetInt32(5);
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

        public Historia Buscar(int IDHistoria)
        {
            AccesoDatos datos = new AccesoDatos();
            Historia aux = new Historia();

            try
            {
                datos.setearConsulta("select ID, IDUsuario, Descripcion,UrlImagen,FechaHora,Estado from Historias Where Id = "+IDHistoria);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    aux.ID = datos.Lector.GetInt32(0);
                    aux.IDUsuario = datos.Lector.GetInt32(1);
                    aux.Descripcion = datos.Lector.GetString(2);
                    aux.UrlImagen = datos.Lector.GetString(3);
                    aux.FechaHora = datos.Lector.GetDateTime(4);
                    aux.Estado = (EstadoHistoria)datos.Lector.GetInt32(5);
                }
                return aux;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public bool Agregar(Historia nuevaHistoria)
        {
            AccesoDatos datos = new AccesoDatos();
            bool insertOk = false;
            try
            {
                datos.setearConsulta("insert into Historias (Estado, Descripcion, IDUsuario, UrlImagen, FechaHora) values (@Estado, @Descripcion,@IDUsuario,@UrlImagen,@FechaHora)");
                datos.setearParametro("@Estado", nuevaHistoria.Estado);
                datos.setearParametro("@Descripcion", nuevaHistoria.Descripcion);
                datos.setearParametro("@IDUsuario", nuevaHistoria.IDUsuario);
                datos.setearParametro("@UrlImagen", nuevaHistoria.UrlImagen);
                datos.setearParametro("@FechaHora", nuevaHistoria.FechaHora);

                datos.ejecutarAccion();
                insertOk = true;
                return insertOk;

            }
            catch (Exception ex)
            {
                return insertOk;
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool Actualizar(Historia historia)
        {
            AccesoDatos datos = new AccesoDatos();
            bool insertOk = false;
            try
            {
                datos.setearConsulta("update Historias set Descripcion = @Descripcion, UrlImagen = @UrlImagen, FechaHora = @FechaHora, " +
                    "Estado = @Estado where ID = "+historia.ID);
                datos.setearParametro("@Descripcion", historia.Descripcion);
                datos.setearParametro("@UrlImagen", historia.UrlImagen);
                datos.setearParametro("@FechaHora", historia.FechaHora);
                datos.setearParametro("@Estado", (int)historia.Estado);
                datos.ejecutarAccion();
                insertOk = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return insertOk;
        }

        public bool Eliminar(int idHistoria)
        {
            AccesoDatos datos = new AccesoDatos();
            bool deleteOk = false;
            try
            {
                datos.setearConsulta("Delete from Historias where ID="+idHistoria);
                datos.ejecutarAccion();
                deleteOk = true;
            }
            catch (Exception ex)
            {   
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return deleteOk;
        }

    }
}
