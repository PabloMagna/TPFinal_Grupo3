﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class HistoriaNegocio
    {
        public void ActualizarEstado(int idHistoria, EstadoHistoria estadoHistoria)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update Historias set Estado = @Estado where ID = @IdHisotoria");
                datos.setearParametro("@Estado", estadoHistoria);
                datos.setearParametro("@IdHisotoria", idHistoria);
                datos.ejecutarLectura();
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

        public List<Historia> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Historia> lista = new List<Historia>();

            try
            {
                datos.setearConsulta("select ID, IDUsuario, Descripcion,UrlImagen,FechaHora,Estado from Historias");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Historia aux = new Historia();
                    aux.ID = datos.Lector.GetInt32(0);
                    aux.IDUsuario = datos.Lector.GetInt32(1);
                    aux.Descripcion = datos.Lector.GetString(2);
                    aux.UrlImagen = datos.Lector.GetString(3);
                    aux.FechaHora = datos.Lector.GetDateTime(4);
                    aux.Estado = (EstadoHistoria)datos.Lector.GetInt32(5);
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public List<Historia> ListarPorUsuario(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Historia> lista = new List<Historia>();

            try
            {
                datos.setearConsulta("select ID, IDUsuario, Descripcion,UrlImagen,FechaHora,Estado from Historias Where IdUsuario = @IdUsuario");
                datos.setearParametro("@IdUsuario", idUsuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Historia aux = new Historia();
                    aux.ID = datos.Lector.GetInt32(0);
                    aux.IDUsuario = datos.Lector.GetInt32(1);
                    aux.Descripcion = datos.Lector.GetString(2);
                    aux.UrlImagen = datos.Lector.GetString(3);
                    aux.FechaHora = datos.Lector.GetDateTime(4);
                    aux.Estado = (EstadoHistoria)datos.Lector.GetInt32(5);
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
    }
}