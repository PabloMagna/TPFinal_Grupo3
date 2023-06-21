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
        public List<KeyValuePair<int, string>> ListarClaveValor(int idProvincia)
        {
            List<KeyValuePair<int, string>> localidades = new List<KeyValuePair<int, string>>();
            AccesoDatos datos = new AccesoDatos();

            datos.setearConsulta("SELECT ID, Nombre FROM Localidades WHERE IDProvincia = @IdProvincia");
            datos.setearParametro("@IdProvincia", idProvincia);
            datos.ejecutarLectura();

            try
            {
                while (datos.Lector.Read())
                {
                    int id = datos.Lector.GetInt32(0);
                    string nombre = (string)datos.Lector["Nombre"];
                    localidades.Add(new KeyValuePair<int, string>(id, nombre));
                }
                return localidades;
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
        public List<string> CargarDropDownList(int IdProv)
        {
            List<string> localidades = new List<string>();
            AccesoDatos datos = new AccesoDatos();


            datos.setearConsulta("select ID,Nombre,IDProvincia from Localidades where IDProvincia=" + IdProv);
            datos.ejecutarLectura();
            bool bandera = false;

            try
            {
                while (datos.Lector.Read())
                {
                    if (!bandera)
                    {
                        localidades.Add("Seleccionar");
                        bandera = true;
                    }
                    else
                    {
                        string prov = (string)datos.Lector["Nombre"];
                        localidades.Add(prov);
                    }
                }
                return localidades;
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }

        }

        public List<Localidad> listar()
        {
            List<Localidad> localidades = new List<Localidad>();
            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("select ID,IDProvincia,Nombre from Localidades");
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
