using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            AccesoDatos datos = new AccesoDatos();
            List<Publicacion> publicaciones = new List<Publicacion>();
            try
            {
                datos.setearConsulta("SELECT ID, Titulo, CONVERT(int, Especie) AS Especie, Raza, Edad, Sexo, IDUsuario, Descripcion, FechaHora, Estado, IDLocalidad, IDProvincia FROM Publicaciones");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Publicacion aux = new Publicacion();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.Titulo = datos.Lector.GetString(1);
                    aux.Especie = datos.Lector.GetInt32(2);
                    aux.Raza = datos.Lector.GetString(3);
                    aux.Edad = datos.Lector.GetInt32(4);
                    aux.Sexo = datos.Lector.GetString(5)[0];
                    aux.IdUsuario = datos.Lector.GetInt32(6);
                    aux.Descripcion = datos.Lector.GetString(7);
                    aux.FechaHora = datos.Lector.GetDateTime(8);
                    aux.Estado = datos.Lector.GetInt32(9);
                    aux.IDLocalidad = datos.Lector.GetInt32(10);
                    aux.IDProvincia = datos.Lector.GetInt32(11);

                    publicaciones.Add(aux);
                }
                return publicaciones;
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


        public List<Publicacion> Filtrar(int localidad, int especie, char sexo, int edad, string raza)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Publicacion> publicacionesFiltradas = new List<Publicacion>();
            try
            {
                string consulta = "SELECT ID, Titulo, CONVERT(int, Especie) AS Especie, Raza, Edad, Sexo, IDUsuario, Descripcion, FechaHora, Estado, IDLocalidad, IDProvincia FROM Publicaciones WHERE 1 = 1";

                if (localidad != 0)
                    consulta += " AND IDLocalidad = " + localidad;

                if (especie != 0)
                    consulta += " AND Especie = " + especie;

                if (!string.IsNullOrEmpty(raza))
                    consulta += " AND Raza LIKE '%" + raza + "%'";

                if (edad != 0)
                    consulta += " AND Edad <= " + edad;

                if (sexo != ' ')
                    consulta += " AND Sexo = '" + sexo + "'";

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Publicacion aux = new Publicacion();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.Titulo = datos.Lector.GetString(1);
                    aux.Especie = datos.Lector.GetInt32(2);
                    aux.Raza = datos.Lector.GetString(3);
                    aux.Edad = datos.Lector.GetInt32(4);
                    aux.Sexo = datos.Lector.GetString(5)[0];
                    aux.IdUsuario = datos.Lector.GetInt32(6);
                    aux.Descripcion = datos.Lector.GetString(7);
                    aux.FechaHora = datos.Lector.GetDateTime(8);
                    aux.Estado = datos.Lector.GetInt32(9);
                    aux.IDLocalidad = datos.Lector.GetInt32(10);
                    aux.IDProvincia = datos.Lector.GetInt32(11);

                    publicacionesFiltradas.Add(aux);
                }

                return publicacionesFiltradas;
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

        public void AgregarConSP(Publicacion publicacionNueva)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {               
                datos.setearProcedimiento("SP_alta_publicacion");
                datos.setearParametro("@titulo", publicacionNueva.Titulo);
                datos.setearParametro("@especie", publicacionNueva.Especie);
                datos.setearParametro("@Raza", publicacionNueva.Raza);
                datos.setearParametro("@edad", publicacionNueva.Edad);
                datos.setearParametro("@sexo", publicacionNueva.Sexo);
                datos.setearParametro("@idUsuario", publicacionNueva.IdUsuario);
                datos.setearParametro("@descripcion", publicacionNueva.Descripcion);
                datos.setearParametro("@fecha", publicacionNueva.FechaHora);
                datos.setearParametro("@idLocalidad", publicacionNueva.IDLocalidad);
                datos.setearParametro("@idProvincia", publicacionNueva.IDProvincia);
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

        public Publicacion ObtenerPorId(int IDPublicacion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT ID, Titulo, CONVERT(int, Especie) AS Especie, Raza, Edad, Sexo, IDUsuario, Descripcion, FechaHora, Estado, IDLocalidad, IDProvincia FROM Publicaciones WHERE ID = @ID");
                datos.setearParametro("@ID", IDPublicacion);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Publicacion publicacion = new Publicacion();
                    publicacion.Id = datos.Lector.GetInt32(0);
                    publicacion.Titulo = datos.Lector.GetString(1);
                    publicacion.Especie = datos.Lector.GetInt32(2);
                    publicacion.Raza = datos.Lector.GetString(3);
                    publicacion.Edad = datos.Lector.GetInt32(4);
                    publicacion.Sexo = datos.Lector.GetString(5)[0];
                    publicacion.IdUsuario = datos.Lector.GetInt32(6);
                    publicacion.Descripcion = datos.Lector.GetString(7);
                    publicacion.FechaHora = datos.Lector.GetDateTime(8);
                    publicacion.Estado = datos.Lector.GetInt32(9);
                    publicacion.IDLocalidad = datos.Lector.GetInt32(10);
                    publicacion.IDProvincia = datos.Lector.GetInt32(11);

                    return publicacion;
                }

                return null; 
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