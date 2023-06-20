using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ImagenMascotaNegocio
    {
        public List<ImagenMascota> listar(int idMascota)
        {
            List<ImagenMascota> lista = new List<ImagenMascota>();
             AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select ID, UrlImagen from ImagenesMascota where IDMascota =" + idMascota);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    ImagenMascota aux = new ImagenMascota();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.IdPublicacion = idMascota;
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
    }
}
