﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ComentarioNegocio
    {
        public void ActualizarEstado(int idComentario, EstadoComentario estado)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE Comentarios SET Estado = @Estado WHERE Id = @Id");
                datos.setearParametro("@Estado", estado);
                datos.setearParametro("@Id", idComentario);
                datos.ejecutarAccion();
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

        public List<Comentario> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Comentario> lista = new List<Comentario>();

            try
            {
                datos.setearConsulta("SELECT Id, IdPublicacion, IdUsuario, Descripcion, Estado, FechaHora FROM Comentarios");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Comentario aux = new Comentario();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.IdPublicacion = datos.Lector.GetInt32(1);
                    aux.IdUsuario = datos.Lector.GetInt32(2);
                    aux.Descripcion = datos.Lector.GetString(3);
                    aux.Estado = (EstadoComentario)Enum.Parse(typeof(EstadoComentario), datos.Lector.GetInt32(4).ToString());
                    aux.FechaHora = datos.Lector.GetDateTime(5);
                    lista.Add(aux);
                }
                return lista;
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

        public List<Comentario> ListarPorIDUsuario(int IDUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Comentario> lista = new List<Comentario>();
            try
            {
                datos.setearConsulta("SELECT Id, IdPublicacion, IdUsuario, Descripcion, Estado, FechaHora FROM Comentarios where IdUsuario = @IDUsuario");
                datos.setearParametro("@IDUsuario", IDUsuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Comentario aux = new Comentario();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.IdPublicacion = datos.Lector.GetInt32(1);
                    aux.IdUsuario = datos.Lector.GetInt32(2);
                    aux.Descripcion = datos.Lector.GetString(3);
                    aux.Estado = (EstadoComentario)Enum.Parse(typeof(EstadoComentario), datos.Lector.GetInt32(4).ToString());
                    aux.FechaHora = datos.Lector.GetDateTime(5);
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

        public List<Comentario> ListarPorPublicacion(int IDPublicacion)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Comentario> lista = new List<Comentario>();

            try
            {
                datos.setearConsulta("SELECT Id, IdPublicacion, IdUsuario, Descripcion, Estado, FechaHora FROM Comentarios WHERE IdPublicacion = @IDPublicacion");
                datos.setearParametro("@IDPublicacion", IDPublicacion);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Comentario aux = new Comentario();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.IdPublicacion = datos.Lector.GetInt32(1);
                    aux.IdUsuario = datos.Lector.GetInt32(2);
                    aux.Descripcion = datos.Lector.GetString(3);
                    aux.Estado = (EstadoComentario)Enum.Parse(typeof(EstadoComentario), datos.Lector.GetInt32(4).ToString());
                    aux.FechaHora = datos.Lector.GetDateTime(5);
                    lista.Add(aux);
                }
                return lista;
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
        public List<Comentario> ListarPorPublicacionActivas(int IDPublicacion)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Comentario> lista = new List<Comentario>();

            try
            {
                datos.setearConsulta("SELECT Id, IdPublicacion, IdUsuario, Descripcion, Estado, FechaHora FROM Comentarios WHERE IdPublicacion = @IDPublicacion AND Estado = 1");
                datos.setearParametro("@IDPublicacion", IDPublicacion);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Comentario aux = new Comentario();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.IdPublicacion = datos.Lector.GetInt32(1);
                    aux.IdUsuario = datos.Lector.GetInt32(2);
                    aux.Descripcion = datos.Lector.GetString(3);
                    aux.Estado = (EstadoComentario)Enum.Parse(typeof(EstadoComentario), datos.Lector.GetInt32(4).ToString());
                    aux.FechaHora = datos.Lector.GetDateTime(5);
                    lista.Add(aux);
                }
                return lista;
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
        public List<Comentario> ListarPorUsuario(int IDUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Comentario> lista = new List<Comentario>();

            try
            {
                datos.setearConsulta("SELECT Id, IdPublicacion, IdUsuario, Descripcion, Estado, FechaHora FROM Comentarios WHERE IdUsuario = @IDUsuario");
                datos.setearParametro("@IDUsuario", IDUsuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Comentario aux = new Comentario();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.IdPublicacion = datos.Lector.GetInt32(1);
                    aux.IdUsuario = datos.Lector.GetInt32(2);
                    aux.Descripcion = datos.Lector.GetString(3);
                    aux.Estado = (EstadoComentario)Enum.Parse(typeof(EstadoComentario), datos.Lector.GetInt32(4).ToString());
                    aux.FechaHora = datos.Lector.GetDateTime(5);
                    lista.Add(aux);
                }
                return lista;
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

        public void Agregar(Comentario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert into Comentarios (IDPublicacion, Descripcion, Estado, FechaHora, IDUsuario) values(@IDPublicacion,@Descripcion,1,GETDATE(),@IdUsuario)");
                datos.setearParametro("@IDPublicacion", nuevo.IdPublicacion);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@IdUsuario", nuevo.IdUsuario);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
        public bool ExisteComentarioActivo(int idComentario, int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Comentarios WHERE Id = @IDComentario AND IdUsuario = @IDUsuario AND Estado = @EstadoActivo");
                datos.setearParametro("@IDComentario", idComentario);
                datos.setearParametro("@IDUsuario", idUsuario);
                datos.setearParametro("@EstadoActivo", EstadoComentario.Activo);
                datos.ejecutarLectura();

                // Verificar si hay algún resultado (si existe un comentario activo con el ID y el ID de usuario proporcionados)
                if (datos.Lector.Read())
                {
                    return true; // Devolver true si existe al menos un comentario activo con el ID y el ID de usuario
                }

                return false; // Si no se encontró ningún resultado, no existe comentario activo con esos valores
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
