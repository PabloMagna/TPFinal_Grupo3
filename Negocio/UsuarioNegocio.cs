using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioNegocio
    {
       public Usuario Login(string contrasenia, string email)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select IDUsuario,IDTipoUsuario,UrlImagen,Localidad,Provincia,Telefono,Estado,EsAdmin from " +
                    "Usuarios where Contrasenia = @Contrasenia and Email = @Email");
                datos.setearParametro("@Contrasenia", contrasenia);
                datos.setearParametro("@Email", email);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.Tipo = int.Parse(datos.Lector["IDTipoUsuario"].ToString());
                    aux.UrlImagen = (string)datos.Lector["UrlImagen"];
                    aux.Localidad = (string)datos.Lector["Localidad"];
                    aux.Provincia = (string)datos.Lector["Provincia"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.Estado = (int)datos.Lector["Estado"];
                    aux.EsAdmin = (bool)datos.Lector["EsAdmin"];
                    return aux;
                }
                else { return null; }
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
