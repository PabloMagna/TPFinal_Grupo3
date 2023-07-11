using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class PersonaNegocio
    {
        public int Agregar(Persona persona)
        {
            AccesoDatos datos = new AccesoDatos();
            int filas = 0;
            try
            {
                datos.setearConsulta("INSERT INTO PERSONAS(IDUsuario,Dni,Nombre,Apellido,FechaNacimiento,UrlImagen,IDLocalidad,IDProvincia,Telefono)" +
                    "VALUES(@IDUsuario,@Dni,@Nombre,@Apellido,@FechaNacimiento,@urlDefault,@IDLocalidad,@IDProvincia,@Telefono)");

                datos.setearParametro("@IDUsuario", persona.IDUsuario);
                datos.setearParametro("@Nombre", persona.Nombre);
                datos.setearParametro("@Apellido", persona.Apellido);
                datos.setearParametro("@Dni", persona.Dni);
                datos.setearParametro("@FechaNacimiento", persona.FechaNacimiento);
                //Imagen por default " "
                datos.setearParametro("@urlDefault", "");
                datos.setearParametro("@IDLocalidad", persona.IDLocalidad);
                datos.setearParametro("@IDProvincia", persona.IDProvincia);
                datos.setearParametro("@Telefono", persona.Telefono);

                filas = datos.ejecutar_FilasAfectadas();

            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }
            return filas;
        }
        public void Modificar(Persona persona)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE PERSONAS SET Dni = @Dni, Nombre = @Nombre, Apellido = @Apellido, FechaNacimiento = @FechaNacimiento, UrlImagen = @UrlImagen, IDLocalidad = @IDLocalidad, IDProvincia = @IDProvincia, Telefono = @Telefono WHERE IDUsuario = @IDUsuario");

                datos.setearParametro("@Dni", persona.Dni);
                datos.setearParametro("@Nombre", persona.Nombre);
                datos.setearParametro("@Apellido", persona.Apellido);
                datos.setearParametro("@FechaNacimiento", persona.FechaNacimiento);
                datos.setearParametro("@UrlImagen", persona.UrlImagen);
                datos.setearParametro("@IDLocalidad", persona.IDLocalidad);
                datos.setearParametro("@IDProvincia", persona.IDProvincia);
                datos.setearParametro("@Telefono", persona.Telefono);
                datos.setearParametro("@IDUsuario", persona.IDUsuario);
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


        public Persona BuscarporUsuario(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            Persona persona = new Persona();
            try
            {
                datos.setearConsulta("SELECT ID, IDUsuario, Dni, Nombre, Apellido, FechaNacimiento, " +
                    "UrlImagen, IDLocalidad, IDProvincia, " +
                    "Telefono FROM PERSONAS WHERE IDUsuario =" + idUsuario);

                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    persona.ID = datos.Lector.GetInt32(0);
                    persona.IDUsuario = idUsuario;
                    persona.Dni = datos.Lector.GetInt32(2);
                    persona.Nombre = datos.Lector.GetString(3);
                    persona.Apellido = datos.Lector.GetString(4);
                    persona.FechaNacimiento = datos.Lector.GetDateTime(5);
                    persona.UrlImagen = datos.Lector.GetString(6);
                    persona.IDLocalidad = datos.Lector.GetInt32(7);
                    persona.IDProvincia = datos.Lector.GetInt32(8);
                    persona.Telefono = datos.Lector.GetString(9);

                    return persona;
                }
                else
                {
                    return null;
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

    }
}
