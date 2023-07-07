using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class RefugioNegocio
    {
        public int Agregar(Refugio refugio)
        {
            AccesoDatos datos = new AccesoDatos();
            int registrosAfectados = 0;
            try
            {
                datos.setearConsulta("INSERT INTO REFUGIOS(IDUsuario,Direccion,Nombre,UrlImagen,IDLocalidad,IDProvincia,Telefono)" +
                        "VALUES(@IDUsuario,@Direccion,@Nombre,@urlDefault,@IDLocalidad,@IDProvincia,@Telefono)");
                datos.setearParametro("@IDUsuario", refugio.IdUsuario);
                datos.setearParametro("@Direccion", refugio.Direccion);
                datos.setearParametro("@Nombre", refugio.Nombre);
                datos.setearParametro("@urlDefault", refugio.UrlImagen);
                datos.setearParametro("@IDLocalidad", refugio.IDLocalidad);
                datos.setearParametro("@IDProvincia", refugio.IDProvincia);
                datos.setearParametro("@Telefono", refugio.Telefono);
                registrosAfectados=datos.ejecutar_FilasAfectadas();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
            return registrosAfectados;
        }

        public bool Modificar(Refugio refugio)
        {
            AccesoDatos datos = new AccesoDatos();
            bool registrosAfectados = false;
            try
            {
                datos.setearConsulta("UPDATE REFUGIOS SET IDUsuario=@IDUsuario,Direccion=@Direccion,Nombre=@Nombre" +
                    ",UrlImagen=@UrlImagen,IDLocalidad=@IDLocalidad,IDProvincia=@IDProvincia,Telefono=@Telefono");
                datos.setearParametro("@IDUsuario", refugio.IdUsuario);
                datos.setearParametro("@Direccion", refugio.Direccion);
                datos.setearParametro("@Nombre", refugio.Nombre);
                datos.setearParametro("@urlImagen", refugio.UrlImagen);
                datos.setearParametro("@IDLocalidad", refugio.IDLocalidad);
                datos.setearParametro("@IDProvincia", refugio.IDProvincia);
                datos.setearParametro("@Telefono", refugio.Telefono);
                datos.ejecutarAccion();
                registrosAfectados = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
            return registrosAfectados;
        }

        public Refugio BuscarporUsuario(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            Refugio refugio = new Refugio();
            datos.setearConsulta("SELECT ID, IDUsuario, Nombre," +
                "UrlImagen, IDLocalidad, IDProvincia, " +
                "Telefono, Direccion FROM REFUGIOS WHERE IDUsuario =" + idUsuario);

            datos.ejecutarLectura();
            try
            {
                if (datos.Lector.Read())
                {
                    refugio.Id= datos.Lector.GetInt32(0);
                    refugio.IdUsuario = idUsuario;              
                    refugio.Nombre = (string)datos.Lector["Nombre"];
                    refugio.UrlImagen = (string)datos.Lector["UrlImagen"];
                    refugio.IDLocalidad = (int)datos.Lector["IDLocalidad"];
                    refugio.IDProvincia = (int)datos.Lector["IDProvincia"];
                    refugio.Telefono = (string)datos.Lector["Telefono"];
                    refugio.Direccion = (string)datos.Lector["Direccion"];

                }

            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }
            return refugio;
        }
    }
}
