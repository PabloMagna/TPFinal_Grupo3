using Dominio;
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

        public Campos CamposUsuarioComentario(Usuario user)
        {
            Campos campos = new Campos();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (user.Tipo == TipoUsuario.Persona)
                {
                    PersonaNegocio negocioPersona = new PersonaNegocio();
                    Persona nueva = negocioPersona.BuscarporUsuario(user.Id);
                    campos.Nombre = nueva.Nombre + " " + nueva.Apellido;
                    campos.UrlImg = nueva.UrlImagen;
                }
                else
                {
                    RefugioNegocio negocioRefugio = new RefugioNegocio();
                    Refugio nuevo = new Refugio();
                    nuevo = negocioRefugio.BuscarporUsuario(user.Id);
                    campos.Nombre = nuevo.Nombre;
                    campos.UrlImg = nuevo.UrlImagen;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
            return campos;
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
    }
}
