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
        public List<ImagenesMascota> listar(int idMascota)
        {
            List<ImagenesMascota> lista = new List<ImagenesMascota>();
             AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select IDImagen, UrlImagen from ImagenesMascota where IDMascota =" + idMascota);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    ImagenesMascota aux = new ImagenesMascota();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.IdMascota = idMascota;
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
