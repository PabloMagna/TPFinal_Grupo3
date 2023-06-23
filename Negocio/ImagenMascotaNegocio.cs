using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ImagenMascotaNegocio
    {
        public List<ImagenMascota> listar(int idPublicacion)
        {
            List<ImagenMascota> lista = new List<ImagenMascota>();
             AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select ID, UrlImagen from ImagenesMascota where IDPublicacion =" + idPublicacion);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    ImagenMascota aux = new ImagenMascota();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.IdPublicacion = idPublicacion;
                    aux.urlImagen = (string)datos.Lector["UrlImagen"];

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
        public List<string> ObtenerUrlsImagenes(int idPublicacion)
        {
            List<string> listaUrls = new List<string>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT UrlImagen FROM ImagenesMascota WHERE IDPublicacion = @idPublicacion");
                datos.setearParametro("@idPublicacion", idPublicacion);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    string urlImagen = datos.Lector.GetString(0);
                    listaUrls.Add(urlImagen);
                }

                return listaUrls;
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

        public void Agregar(ImagenMascota nueva)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string query = "insert into ImagenesMascota values (" + nueva.IdPublicacion + "," +"'"+ nueva.urlImagen + "'" + ")";
                datos.setearConsulta(query);
                /*
                datos.setearParametro("@IDPublicaion", IDPublicacion);
                datos.setearParametro("@UrlImagen", nueva.urlImagen);               
                */
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
