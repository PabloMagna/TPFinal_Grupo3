using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class LocalidadNegocio
    {
        public List<Localidad> listar()
        {
            List<Localidad> localidades = new List<Localidad>();
            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("select ID,Nombre from Provincias");
            datos.ejecutarLectura();

            try
            {
                while (datos.Lector.Read())
                {
                    Localidad aux = new Localidad();

                    aux.Id = datos.Lector.GetInt32(0);
                    aux.IdProvincia = (int)datos.Lector["IDProvincia"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    localidades.Add(aux);
                }
                return localidades;
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }
        }
    }
}
