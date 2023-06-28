using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ImagenUsuarioNegocio
    {

        public ImagenUsuario Obtener(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select ID,IDUsuario,UrlImagen from ImagenesUsuarios where IDUsuario =" + idUsuario);
                datos.ejecutarLectura();

                ImagenUsuario img= new ImagenUsuario();
                if (datos.Lector.Read())
                {
                    
                    img.Id = datos.Lector.GetInt32(0);
                    img.IdUsuario = idUsuario;
                    img.urlImagen = (string)datos.Lector["UrlImagen"];

                }
                return img;
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

        public void Agregar(ImagenUsuario nueva)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string query = "insert into ImagenesUsuario values (" + nueva.IdUsuario + "," + "'" + nueva.urlImagen + "'" + ")";
                datos.setearConsulta(query);
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
