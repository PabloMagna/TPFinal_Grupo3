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
        public List<KeyValuePair<int, string>> ListarClaveValor()
        {
            List<KeyValuePair<int, string>> provincias = new List<KeyValuePair<int, string>>();
            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("SELECT ID, Nombre FROM Provincias");
            datos.ejecutarLectura();

            try
            {
                while (datos.Lector.Read())
                {
                    int id = datos.Lector.GetInt32(0);
                    string nombre = (string)datos.Lector["Nombre"];
                    provincias.Add(new KeyValuePair<int, string>(id, nombre));
                }
                return provincias;
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
        public List<string> cargarDropDownList()
        {
            List<string> provincias = new List<string>();
            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("select ID,Nombre from Provincias");
            datos.ejecutarLectura();
            bool bandera = true;
            try
            {
                while (datos.Lector.Read())
                {
                    if (bandera)
                    {
                        provincias.Add("Seleccionar");
                        bandera = false;
                    }
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


        public int BuscarNombre(string nombreProv)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("SELECT ID from Provincias where Nombre=" + nombreProv);
            datos.ejecutarLectura();
            int IDProvincia = (int)datos.Lector["ID"];
            datos.cerrarConexion();
            return IDProvincia;
        }
    }
}
