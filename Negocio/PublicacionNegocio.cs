using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
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
                datos.setearConsulta("SELECT ID, Titulo, CONVERT(int, Especie) AS Especie, Raza, Edad, Sexo, IDUsuario, Descripcion, FechaHora, Estado, IDLocalidad, IDProvincia FROM Publicaciones WHERE Estado = 1");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Publicacion aux = new Publicacion();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.Titulo = datos.Lector.GetString(1);
                    aux.Especie = (Especie)Enum.ToObject(typeof(Especie), datos.Lector.GetInt32(2));
                    aux.Raza = datos.Lector.GetString(3);
                    aux.Edad = datos.Lector.GetInt32(4);
                    aux.Sexo = datos.Lector.GetString(5)[0];
                    aux.IdUsuario = datos.Lector.GetInt32(6);
                    aux.Descripcion = datos.Lector.GetString(7);
                    aux.FechaHora = datos.Lector.GetDateTime(8);
                    aux.Estado = (Estado)Enum.Parse(typeof(Estado), datos.Lector.GetInt32(9).ToString());
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
        public List<Publicacion> ListarAdmin()
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
                    aux.Especie = (Especie)Enum.ToObject(typeof(Especie), datos.Lector.GetInt32(2));
                    aux.Raza = datos.Lector.GetString(3);
                    aux.Edad = datos.Lector.GetInt32(4);
                    aux.Sexo = datos.Lector.GetString(5)[0];
                    aux.IdUsuario = datos.Lector.GetInt32(6);
                    aux.Descripcion = datos.Lector.GetString(7);
                    aux.FechaHora = datos.Lector.GetDateTime(8);
                    aux.Estado = (Estado)Enum.Parse(typeof(Estado), datos.Lector.GetInt32(9).ToString());
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

        public List<Publicacion> Filtrar(int provincia, int localidad, int especie, char sexo, int edad)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Publicacion> publicacionesFiltradas = new List<Publicacion>();
            try
            {
                string consulta = "SELECT ID, Titulo, CONVERT(int, Especie) AS Especie, Raza, Edad, Sexo, IDUsuario, Descripcion, FechaHora, Estado, IDLocalidad, IDProvincia FROM Publicaciones WHERE 1 = 1";

                if (localidad != 0)
                    consulta += " AND IDLocalidad = " + localidad;

                if (provincia != 0)
                    consulta += " AND IDProvincia = " + provincia;

                if (especie != 0)
                    consulta += " AND Especie = " + especie;

                if (sexo != 'T')
                    consulta += " AND Sexo = '" + sexo + "'";

                if (edad != 0)
                {
                    if (edad == 1) // Bebé (menor al año)
                    {
                        // Consulta para filtrar bebés (menores a 12 meses)
                        consulta += " AND Edad < 12";
                    }
                    else if (edad == 2) // Joven (1 a 10 años)
                    {
                        // Consulta para filtrar animales jóvenes (entre 12 meses y 10 años)
                        consulta += " AND Edad >= 12 AND Edad <= 10*12";
                    }
                    else if (edad == 3) // Adulto (más de 10)
                    {
                        // Consulta para filtrar animales adultos (mayores a 10 años)
                        consulta += " AND Edad > 10*12";
                    }
                }


                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Publicacion aux = new Publicacion();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.Titulo = datos.Lector.GetString(1);
                    aux.Especie = (Especie)Enum.ToObject(typeof(Especie), datos.Lector.GetInt32(2));
                    aux.Raza = datos.Lector.GetString(3);
                    aux.Edad = datos.Lector.GetInt32(4);
                    aux.Sexo = datos.Lector.GetString(5)[0];
                    aux.IdUsuario = datos.Lector.GetInt32(6);
                    aux.Descripcion = datos.Lector.GetString(7);
                    aux.FechaHora = datos.Lector.GetDateTime(8);
                    aux.Estado = (Estado)Enum.Parse(typeof(Estado), datos.Lector.GetInt32(9).ToString());
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

        public int GetIdPublicacionCreada(int IDSession)
        {
           
            AccesoDatos datos = new AccesoDatos();
            int idPublicacionCreada = 0;
            try
            {
                string consulta = "SELECT TOP 1 ID FROM Publicaciones WHERE IDUsuario = " + IDSession + " order by FechaHora Desc";
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    idPublicacionCreada = datos.Lector.GetInt32(0);
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
            return idPublicacionCreada;
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
                    publicacion.Especie = (Especie)Enum.ToObject(typeof(Especie), datos.Lector.GetInt32(2));
                    publicacion.Raza = datos.Lector.GetString(3);
                    publicacion.Edad = datos.Lector.GetInt32(4);
                    publicacion.Sexo = datos.Lector.GetString(5)[0];
                    publicacion.IdUsuario = datos.Lector.GetInt32(6);
                    publicacion.Descripcion = datos.Lector.GetString(7);
                    publicacion.FechaHora = datos.Lector.GetDateTime(8);
                    publicacion.Estado = (Estado)Enum.Parse(typeof(Estado), datos.Lector.GetInt32(9).ToString());
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
        public void Actualizar(Publicacion publicacion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Publicaciones SET Titulo = @Titulo, Especie = @Especie, Raza = @Raza, Edad = @Edad, Sexo = @Sexo, IDUsuario = @IDUsuario, Descripcion = @Descripcion, FechaHora = @FechaHora, IDLocalidad = @IDLocalidad, IDProvincia = @IDProvincia WHERE ID = @ID");
                datos.setearParametro("@Titulo", publicacion.Titulo);
                datos.setearParametro("@Especie", publicacion.Especie);
                datos.setearParametro("@Raza", publicacion.Raza);
                datos.setearParametro("@Edad", publicacion.Edad);
                datos.setearParametro("@Sexo", publicacion.Sexo);
                datos.setearParametro("@IDUsuario", publicacion.IdUsuario);
                datos.setearParametro("@Descripcion", publicacion.Descripcion);
                datos.setearParametro("@FechaHora", publicacion.FechaHora);
                datos.setearParametro("@IDLocalidad", publicacion.IDLocalidad);
                datos.setearParametro("@IDProvincia", publicacion.IDProvincia);
                datos.setearParametro("@ID", publicacion.Id);

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
       
        public void ActualizarEstado(int idPublicacion, Estado nuevoEstado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Publicaciones SET Estado = @Estado WHERE ID = @ID");
                datos.setearParametro("@Estado", nuevoEstado);
                datos.setearParametro("@ID", idPublicacion);

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
        public List<Publicacion> ListarPorUsuario(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Publicacion> lista = new List<Publicacion>();
            try
            {
                datos.setearConsulta("SELECT ID, Titulo, CONVERT(int, Especie) AS Especie, Raza, Edad, Sexo, IDUsuario, Descripcion, FechaHora, Estado, IDLocalidad, IDProvincia FROM Publicaciones where IDUsuario ="+idUsuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Publicacion aux = new Publicacion();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.Titulo = datos.Lector.GetString(1);
                    aux.Especie = (Especie)Enum.ToObject(typeof(Especie), datos.Lector.GetInt32(2));
                    aux.Raza = datos.Lector.GetString(3);
                    aux.Edad = datos.Lector.GetInt32(4);
                    aux.Sexo = datos.Lector.GetString(5)[0];
                    aux.IdUsuario = datos.Lector.GetInt32(6);
                    aux.Descripcion = datos.Lector.GetString(7);
                    aux.FechaHora = datos.Lector.GetDateTime(8);
                    aux.Estado = (Estado)Enum.Parse(typeof(Estado), datos.Lector.GetInt32(9).ToString());
                    aux.IDLocalidad = datos.Lector.GetInt32(10);
                    aux.IDProvincia = datos.Lector.GetInt32(11);
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
        public List<Publicacion> ListarPorIDPublicacion(int IdPublicacion)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Publicacion> lista = new List<Publicacion>();

            try
            {
                datos.setearConsulta("SELECT ID, Titulo, CONVERT(int, Especie) AS Especie, Raza, Edad, Sexo, IDUsuario, Descripcion, FechaHora, Estado, IDLocalidad, IDProvincia FROM Publicaciones WHERE ID = @ID");
                datos.setearParametro("@ID", IdPublicacion);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Publicacion publicacion = new Publicacion();
                    publicacion.Id = datos.Lector.GetInt32(0);
                    publicacion.Titulo = datos.Lector.GetString(1);
                    publicacion.Especie = (Especie)Enum.ToObject(typeof(Especie), datos.Lector.GetInt32(2));
                    publicacion.Raza = datos.Lector.GetString(3);
                    publicacion.Edad = datos.Lector.GetInt32(4);
                    publicacion.Sexo = datos.Lector.GetString(5)[0];
                    publicacion.IdUsuario = datos.Lector.GetInt32(6);
                    publicacion.Descripcion = datos.Lector.GetString(7);
                    publicacion.FechaHora = datos.Lector.GetDateTime(8);
                    publicacion.Estado = (Estado)Enum.Parse(typeof(Estado), datos.Lector.GetInt32(9).ToString());
                    publicacion.IDLocalidad = datos.Lector.GetInt32(10);
                    publicacion.IDProvincia = datos.Lector.GetInt32(11);
                    lista.Add(publicacion);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
        public List<Publicacion> ListarPorListaDeID(List<int> listaId)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Publicacion> listaPublicaciones = new List<Publicacion>();

            try
            {
                if (listaId.Count == 0 || listaId ==null)
                    return listaPublicaciones;

                string consulta = "SELECT ID, Titulo, CONVERT(int, Especie) AS Especie, Raza, Edad, Sexo, IDUsuario, Descripcion, FechaHora, Estado, IDLocalidad, IDProvincia FROM Publicaciones WHERE ID IN ({0})";
                string parametros = string.Join(",", listaId);

                consulta = string.Format(consulta, parametros);

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Publicacion publicacion = new Publicacion();
                    publicacion.Id = datos.Lector.GetInt32(0);
                    publicacion.Titulo = datos.Lector.GetString(1);
                    publicacion.Especie = (Especie)Enum.ToObject(typeof(Especie), datos.Lector.GetInt32(2));
                    publicacion.Raza = datos.Lector.GetString(3);
                    publicacion.Edad = datos.Lector.GetInt32(4);
                    publicacion.Sexo = datos.Lector.GetString(5)[0];
                    publicacion.IdUsuario = datos.Lector.GetInt32(6);
                    publicacion.Descripcion = datos.Lector.GetString(7);
                    publicacion.FechaHora = datos.Lector.GetDateTime(8);
                    publicacion.Estado = (Estado)Enum.Parse(typeof(Estado), datos.Lector.GetInt32(9).ToString());
                    publicacion.IDLocalidad = datos.Lector.GetInt32(10);
                    publicacion.IDProvincia = datos.Lector.GetInt32(11);

                    listaPublicaciones.Add(publicacion);
                }

                return listaPublicaciones;
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
        public int BuscarIdUsuario(int idPublicacion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                int idUsuario = 0;
                datos.setearConsulta("SELECT IDUsuario FROM Publicaciones WHERE ID = @ID");
                datos.setearParametro("@ID", idPublicacion);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    idUsuario = datos.Lector.GetInt32(0);
                }
                return idUsuario;
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