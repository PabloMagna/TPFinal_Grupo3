﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class AdopcionNegocio
    {
        public List<Adopcion> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Adopcion> lista = new List<Adopcion>();

            try
            {
                datos.setearConsulta("select ID, IDPublicacion, IDUsuario, Estado from adopciones");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Adopcion aux = new Adopcion();
                    aux.ID = datos.Lector.GetInt32(0);
                    aux.IDPublicacion = datos.Lector.GetInt32(1);
                    aux.IDUsuario = datos.Lector.GetInt32(2);
                    aux.Estado = (EstadoAdopcion)datos.Lector.GetInt32(3);
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
        public List<Adopcion> ListarPorUsuario(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Adopcion> lista = new List<Adopcion>();

            try
            {
                datos.setearConsulta("select ID, IDPublicacion, IDUsuario, Estado from adopciones WHERE IDUsuario = @IDUsuario and Estado <> 4");
                datos.setearParametro("@IDUsuario", idUsuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Adopcion aux = new Adopcion();
                    aux.ID = datos.Lector.GetInt32(0);
                    aux.IDPublicacion = datos.Lector.GetInt32(1);
                    aux.IDUsuario = datos.Lector.GetInt32(2);
                    aux.Estado = (EstadoAdopcion)datos.Lector.GetInt32(3);
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
        public List<Adopcion> ListarPorPublicacion(int idPublicacion)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Adopcion> lista = new List<Adopcion>();

            try
            {
                datos.setearConsulta("select ID, IDPublicacion, IDUsuario, Estado from adopciones WHERE IDPublicacion = @IDPublicacion");
                datos.setearParametro("@IDPublicacion", idPublicacion);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Adopcion aux = new Adopcion();
                    aux.ID = datos.Lector.GetInt32(0);
                    aux.IDPublicacion = datos.Lector.GetInt32(1);
                    aux.IDUsuario = datos.Lector.GetInt32(2);
                    aux.Estado = (EstadoAdopcion)datos.Lector.GetInt32(3);
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
        public List<Adopcion> ListarPorID(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Adopcion> lista = new List<Adopcion>();

            try
            {
                datos.setearConsulta("select ID, IDPublicacion, IDUsuario, Estado from adopciones WHERE ID = @ID");
                datos.setearParametro("@ID", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Adopcion aux = new Adopcion();
                    aux.ID = datos.Lector.GetInt32(0);
                    aux.IDPublicacion = datos.Lector.GetInt32(1);
                    aux.IDUsuario = datos.Lector.GetInt32(2);
                    aux.Estado = (EstadoAdopcion)datos.Lector.GetInt32(3);
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

        public void ActualizarEstado(int idAdopcion, EstadoAdopcion estado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update adopciones set Estado = @Estado where ID = @ID");
                datos.setearParametro("@ID", idAdopcion);
                datos.setearParametro("@Estado", estado);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
        public void ActualizarEstado(int idUsuario, int idPublicacion, EstadoAdopcion estado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update adopciones set Estado = @Estado where IDUsuario = @IDUsuario and IDPublicacion = @IDPublicacion");
                datos.setearParametro("@IDUsuario", idUsuario);
                datos.setearParametro("@IDPublicacion", idPublicacion);
                datos.setearParametro("@Estado", estado);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
        public void Insertar(int idUsuario, int IdPublicacion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into adopciones (IDPublicacion, IDUsuario, Estado) values (@IDPublicacion, @IDUsuario, @Estado)");
                datos.setearParametro("@IDPublicacion", IdPublicacion);
                datos.setearParametro("@IDUsuario", idUsuario);
                datos.setearParametro("@Estado", EstadoAdopcion.Pendiente);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
        public bool EnDataBase(int idUsuario, int idPublicacion){
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select ID from adopciones where IDUsuario = @IDUsuario and IDPublicacion = @IDPublicacion AND Estado <> 4");
                datos.setearParametro("@IDUsuario", idUsuario);
                datos.setearParametro("@IDPublicacion", idPublicacion);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
    }
}
