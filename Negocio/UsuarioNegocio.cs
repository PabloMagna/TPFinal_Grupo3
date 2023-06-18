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
                datos.setearConsulta("select ID, IDTipoUsuario, Estado, EsAdmin  from Usuarios where Contrasenia = @Contrasenia and Email = @Email");
                datos.setearParametro("@Contrasenia", contrasenia);
                datos.setearParametro("@Email", email);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.Email = email;
                    aux.Password = contrasenia;
                    aux.Tipo = int.Parse(datos.Lector["IDTipoUsuario"].ToString());
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
