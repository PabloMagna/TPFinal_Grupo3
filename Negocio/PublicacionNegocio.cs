﻿using System;
using System.Collections.Generic;
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
            List<Publicacion> publicaciones = new List<Publicacion>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select ID,IDUsuario,Descripcion,Titulo,Especie,Raza,Edad,Sexo,FechaHora,Estado,IDLocalidad,IDProvincia from Publicaciones");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Publicacion aux = new Publicacion();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.IdUsuario = (int)datos.Lector["IDUsuario"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.Especie = (int)datos.Lector["Especie"];
                    aux.Raza = (string)datos.Lector["Raza"];
                    aux.Edad = (int)datos.Lector["Edad"];
                    aux.Sexo = (char)datos.Lector["Sexo"];
                    aux.FechaHora = (DateTime)datos.Lector["FechaHora"];
                    aux.Estado = (int)datos.Lector["Estado"];
                    aux.IDLocalidad = (int)datos.Lector["IDLocalidad"];
                    aux.IDProvincia = (int)datos.Lector["IDProvincia"];

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

        public List<Publicacion> Listar(List<int> ints)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Publicacion> publicaciones = new List<Publicacion>();
            try
            {
                foreach (int i in ints)
                {
                    datos.setearConsulta("select ID, Titulo, Especie, Raza, Edad, Sexo, IDUsuario, Descripcion,FechaHora, Estado, IDLocalidad, IDProvincia from Publicaciones where ID = " + i.ToString());
                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {
                        Publicacion aux = new Publicacion();
                        aux.Id = datos.Lector.GetInt32(0);
                        aux.Titulo = (string)datos.Lector["Titulo"];
                        aux.Especie = (int)datos.Lector["Especie"];
                        aux.Raza = (string)datos.Lector["Raza"];
                        aux.Edad = (int)datos.Lector["Edad"];
                        aux.Sexo = (char)datos.Lector["Sexo"];
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                        aux.FechaHora = (DateTime)datos.Lector["FechaHora"];
                        aux.IDLocalidad = (int)datos.Lector["IDLocalidad"];
                        aux.IDProvincia = (int)datos.Lector["IDProvincia"];
                        aux.Estado = (int)datos.Lector["Estado"];
                        aux.IdUsuario = (int)datos.Lector["IDUsuario"];

                        publicaciones.Add(aux);
                    }
                    datos.cerrarConexion();
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
    }
}