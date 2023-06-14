using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class PublicacionNegocio
    {
        public List<Publicacion> Listar()
        {
            List<Publicacion> publicaciones = new List<Publicacion>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select IDPublicacion, IDMascota,IDUsuario,Descripcion,Titulo, FechaHora, Estado from Publicacion");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Publicacion aux = new Publicacion();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.IdMascota = (int)datos.Lector["IdMascota"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.FechaHora = (DateTime)datos.Lector["FechaHora"];

                    publicaciones.Add(aux);
                }
                return publicaciones;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
    }
}
