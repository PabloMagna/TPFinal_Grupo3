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
                datos.setearConsulta("select IDMascota,Especie,Raza,Edad,Sexo,Descripcion,Estado " +
                    "from Mascotas where IDMascota = "+id.ToString());
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    aux.Id = id;
                    aux.Especie = (string)datos.Lector["Especie"];
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


        public void Agregar(Mascota mascota) {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert into Mascotas (Especie,Raza,Edad,Sexo,Descripcion,Estado) " +
                    "VALUES (@especie,@raza,@edad,@sexo,@descripcion,@estado)");
                datos.setearParametro("@especie", mascota.Especie);
                datos.setearParametro("@raza", mascota.Raza);
                datos.setearParametro("@edad",mascota.Edad);
                datos.setearParametro("@",mascota.Sexo);
                datos.setearParametro("@",mascota.Descripcion);
                datos.setearParametro("@",mascota.Estado);

                datos.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion();  }
        }
    }
}
