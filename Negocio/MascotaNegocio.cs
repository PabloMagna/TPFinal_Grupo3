using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class MascotaNegocio
    {
        public Mascota Leer(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            Mascota aux = new Mascota();

            try
            {
                datos.setearConsulta("select ID, numeroEspecie,Raza,Edad,Sexo,Descripcion,Estado " +
                    "from Mascotas where IDMascota = " + id.ToString());
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    aux.Id = id;
                    aux.NumeroEspecie = (int)datos.Lector["numeroEspecie"];
                    aux.Raza = (string)datos.Lector["Raza"];
                    aux.Edad = (int)datos.Lector["Edad"];
                    aux.Sexo = (char)datos.Lector["Sexo"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }

            return aux;
        }


        public void Agregar(Mascota mascota)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert into Mascotas (numeroEspecie,Raza,Edad,Sexo,Descripcion,Estado) " +
                    "VALUES (@especie,@raza,@edad,@sexo,@descripcion,@estado)");
                datos.setearParametro("@especie", mascota.NumeroEspecie);
                datos.setearParametro("@raza", mascota.Raza);
                datos.setearParametro("@edad", mascota.Edad);
                datos.setearParametro("@sexo", mascota.Sexo);
                datos.setearParametro("@descripcion", mascota.Descripcion);
                datos.setearParametro("@estado", mascota.Estado);

                datos.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }
        }
        public List<int> Filtrar(char sexo, int especie, int edad, string raza)
        {
            AccesoDatos datos = new AccesoDatos();
            List<int> lista = new List<int>();
            try
            {
                string consulta = "SELECT ID FROM Mascotas WHERE Sexo = @sexo AND numeroEspecie = @especie AND Edad <= @edad";
                if (!string.IsNullOrEmpty(raza))
                {
                    consulta += " AND Raza LIKE '%' + @raza + '%'";
                    datos.setearParametro("@raza", raza);
                }
                datos.setearConsulta(consulta);
                datos.setearParametro("@sexo", sexo);
                datos.setearParametro("@especie", especie);
                datos.setearParametro("@edad", edad);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    lista.Add((int)datos.Lector["ID"]);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return lista;
        }
    }
}
