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
    }
}
