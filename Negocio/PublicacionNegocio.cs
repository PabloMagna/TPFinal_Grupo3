using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class PublicacionNegocio
    {
        public List<Publicacion> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Publicacion> publicaciones = new List<Publicacion>();
            try
            {
                datos.setearConsulta("SELECT ID, Titulo, CONVERT(int, Especie) AS Especie, Raza, Edad, Sexo, IDUsuario, Descripcion, FechaHora, Estado, IDLocalidad, IDProvincia FROM Publicaciones");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Publicacion aux = new Publicacion();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.Titulo = datos.Lector.GetString(1);
                    aux.Especie = datos.Lector.GetInt32(2);
                    aux.Raza = datos.Lector.GetString(3);
                    aux.Edad = datos.Lector.GetInt32(4);
                    aux.Sexo = datos.Lector.GetString(5)[0];
                    aux.IdUsuario = datos.Lector.GetInt32(6);
                    aux.Descripcion = datos.Lector.GetString(7);
                    aux.FechaHora = datos.Lector.GetDateTime(8);
                    aux.Estado = datos.Lector.GetInt32(9);
                    aux.IDLocalidad = datos.Lector.GetInt32(10);
                    aux.IDProvincia = datos.Lector.GetInt32(11);

                    publicaciones.Add(aux);
                }
                return publicaciones;
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



        //public List<Publicacion> Listar(List<int> ints)
        //{
        //    AccesoDatos datos = new AccesoDatos();
        //    List<Publicacion> publicaciones = new List<Publicacion>();
        //    try
        //    {
        //        foreach (int i in ints)
        //        {
        //            datos.setearConsulta("select ID, Titulo, Especie, Raza, Edad, Sexo, IDUsuario, Descripcion,FechaHora, Estado, IDLocalidad, IDProvincia from Publicaciones where ID = " + i.ToString());
        //            datos.ejecutarLectura();

        //            while (datos.Lector.Read())
        //            {
        //                Publicacion aux = new Publicacion();
        //                aux.Id = datos.Lector.GetInt32(0);
        //                aux.Titulo = (string)datos.Lector["Titulo"];
        //                aux.Especie = (int)datos.Lector["Especie"];
        //                aux.Raza = (string)datos.Lector["Raza"];
        //                aux.Edad = (int)datos.Lector["Edad"];
        //                aux.Sexo = (char)datos.Lector["Sexo"];
        //                aux.Descripcion = (string)datos.Lector["Descripcion"];
        //                aux.FechaHora = (DateTime)datos.Lector["FechaHora"];
        //                aux.IDLocalidad = (int)datos.Lector["IDLocalidad"];
        //                aux.IDProvincia = (int)datos.Lector["IDProvincia"];
        //                aux.Estado = (int)datos.Lector["Estado"];
        //                aux.IdUsuario = (int)datos.Lector["IDUsuario"];

        //                publicaciones.Add(aux);
        //            }
        //            datos.cerrarConexion();
        //        }
        //        return publicaciones;

        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }
        //}
    }
}