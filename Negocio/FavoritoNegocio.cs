using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class FavoritoNegocio
    {
        public List<int> ListarIDPublicaciones(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            List<int> listaPublicaciones = new List<int>();
            try
            {
                datos.setearConsulta("SELECT IDPublicacion FROM favoritos WHERE IDUsuario = @IDUsuario AND Estado = 1");
                datos.setearParametro("@IDUsuario", idUsuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    int idPublicacion = Convert.ToInt32(datos.Lector["IDPublicacion"]);
                    listaPublicaciones.Add(idPublicacion);
                }
                return listaPublicaciones;
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
        public bool EsFavorito(int idUsuario, int idPublicacion)
        {
              AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select ID, IDUsuario, IDPublicacion, Estado from favoritos WHERE IDUsuario = @IDUsuario AND IDPublicacion = @IDPublicacion");
                datos.setearParametro("@IDUsuario", idUsuario);
                datos.setearParametro("@IDPublicacion", idPublicacion);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    if(datos.Lector.GetInt32(3) == 1)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
        public void ActivarDesactivar(int idUsuario, int idPublicacion, EstadoFavorito estadoFavorito)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM favoritos WHERE IDUsuario = @IDUsuario AND IDPublicacion = @IDPublicacion");
                datos.setearParametro("@IDUsuario", idUsuario);
                datos.setearParametro("@IDPublicacion", idPublicacion);
                datos.ejecutarLectura();

                int count = 0;
                if (datos.Lector.Read())
                {
                    count = datos.Lector.GetInt32(0);
                }

                datos.cerrarConexion();

                if (count > 0)
                {
                    // Realizar la actualización
                    datos.setearConsulta("UPDATE favoritos SET Estado = @Estado2 WHERE IDUsuario = @IDUsuario2 AND IDPublicacion = @IDPublicacion2");
                    datos.setearParametro("@IDUsuario2", idUsuario);
                    datos.setearParametro("@IDPublicacion2", idPublicacion);
                    datos.setearParametro("@Estado2", (int)estadoFavorito);
                    datos.ejecutarAccion();
                }
                else
                {
                    // Crear un nuevo registro
                    datos.setearConsulta("INSERT INTO favoritos (IDUsuario, IDPublicacion, Estado) VALUES (@IDUsuario3, @IDPublicacion3, @Estado3)");
                    datos.setearParametro("@IDUsuario3", idUsuario);
                    datos.setearParametro("@IDPublicacion3", idPublicacion);
                    datos.setearParametro("@Estado3", (int)estadoFavorito);
                    datos.ejecutarAccion();
                }
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
