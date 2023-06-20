using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ProvinciaNegocio
    {   

        public List<string> cargarDropDownList()
        {
            List<string> provincias = new List<string>();
            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("select ID,Nombre from Provincias");
            datos.ejecutarLectura();

            try
            {
                while (datos.Lector.Read())
                {
                    string prov = (string)datos.Lector["Nombre"];
                    provincias.Add(prov);
                }
                return provincias;
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }

        }

        public List<Provincia> listar() {
            
            List<Provincia> provincias = new List<Provincia>();
            AccesoDatos datos = new AccesoDatos();

            datos.setearConsulta("select ID,Nombre from Provincias");
            datos.ejecutarLectura();

            try
            {
                while (datos.Lector.Read())
                {
                    Provincia prov = new Provincia();
                    prov.Id= datos.Lector.GetInt32(0);
                    prov.Nombre = (string)datos.Lector["Nombre"];

                    provincias.Add(prov);
                }
                return provincias;
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }
        }
    }
}
