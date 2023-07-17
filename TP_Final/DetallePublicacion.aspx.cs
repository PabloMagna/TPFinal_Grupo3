using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Final
{
    public partial class DetallePublicacion : System.Web.UI.Page
    {
        protected List<string> listaImagenes;
        protected List<Comentario> comentarios { set; get; }
        protected Usuario userSession { set; get; }
        protected Publicacion publicacion;
        protected Campos camposSesion;
        protected List<Campos> camposUsuario;
        public int IDPublicacion;
        protected const string ImgPlaceHolder = "https://img.freepik.com/vector-gratis/ilustracion-icono-vector-dibujos-animados-lindo-gato-sentado-concepto-icono-naturaleza-animal-aislado-premium-vector-estilo-dibujos-animados-plana_138676-4148.jpg?w=2000";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Requiere inicio de sesión
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            //Requiere ID de publicación como parámetro
            if (Request.QueryString["ID"] == null)
            {
                Response.Redirect("Galeria.aspx");
            }

            IDPublicacion = Convert.ToInt32(Request.QueryString["ID"]);

            if (Session["Usuario"] == null)
            {
                camposSesion = new Campos();
                camposSesion.Nombre = "Logeate para comentar";
                camposSesion.UrlImg = ImgPlaceHolder;
                btnEnviar.Enabled = false;
                tbNuevoComentario.ReadOnly = true;
            }
            else if (((Usuario)Session["Usuario"]).Tipo == TipoUsuario.Persona)
            {
                camposSesion = new Campos();
                camposSesion.Nombre = "Completa tus datos personales para comentar";
                camposSesion.UrlImg = ImgPlaceHolder;
                btnEnviar.Enabled = false;
                tbNuevoComentario.ReadOnly = true;
            }
            else
            {
                userSession = (Usuario)Session["Usuario"];
                ComentarioNegocio negocioComentario = new ComentarioNegocio();
                camposSesion = CargarCampo();
                if (camposSesion.UrlImg is null || camposSesion.UrlImg == string.Empty)
                {
                    camposSesion.UrlImg = ImgPlaceHolder;
                }
                ComprobarFavorito();
            }


            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    CargaInicial();
                    CargaComentarios();
                }
            }
        }
        private Campos CargarCampo()
        {
            Campos campos = new Campos();
            if (((Usuario)Session["Usuario"]).Tipo == TipoUsuario.Persona)
                return null;
            if (((Usuario)Session["Usuario"]).Tipo == TipoUsuario.PersonaCompleto)
            {
                PersonaNegocio personaNegocio = new PersonaNegocio();
                Persona persona = personaNegocio.BuscarporUsuario(((Usuario)Session["Usuario"]).Id);
                campos.Nombre = persona.Nombre + " " + persona.Apellido;
                campos.UrlImg = persona.UrlImagen;
                return campos;
            }
            else
            {
                RefugioNegocio refugioNegocio = new RefugioNegocio();
                Refugio refugio = refugioNegocio.BuscarporUsuario(((Usuario)Session["Usuario"]).Id);
                campos.Nombre = refugio.Nombre;
                campos.UrlImg = refugio.UrlImagen;
                return campos;
            }
        }
        private void CargaInicial()
        {
            int id = Convert.ToInt32(Request.QueryString["ID"]);
            PublicacionNegocio publiNegocio = new Negocio.PublicacionNegocio();
            publicacion = publiNegocio.ObtenerPorId(id);
            ImagenMascotaNegocio imagenNegocio = new ImagenMascotaNegocio();
            listaImagenes = imagenNegocio.ObtenerUrlsImagenes(id);
        }


        private void CargaComentarios()
        {
            int id = Convert.ToInt32(Request.QueryString["ID"]);
            ComentarioNegocio comentarioNego = new ComentarioNegocio();
            UsuarioNegocio usuarioNego = new UsuarioNegocio();
            //usuarios = new List<Usuario>();
            comentarios = new List<Comentario>();
            comentarios = comentarioNego.ListarPorPublicacion(id);
            camposUsuario = new List<Campos>();

            foreach (var comentario in comentarios)
            {
                //Cargo Usuarios de comentarios
                int idUser = comentario.IdUsuario;
                Usuario user = new Usuario();
                user = usuarioNego.BuscarxID(idUser);
                Campos camposAux = new Campos();
                camposAux = CargarCampo();
                camposUsuario.Add(camposAux);
            }

        }
        protected string CargarLocalidad()
        {
            LocalidadNegocio localidadNegocio = new LocalidadNegocio();
            return localidadNegocio.ObtnerNombrePorID(publicacion.IDLocalidad);
        }
        protected string CargarProvincia()
        {
            ProvinciaNegocio provinciaNegocio = new ProvinciaNegocio();
            return provinciaNegocio.ObtenerNombrePorId(publicacion.IDProvincia);
        }
        protected string CargarEspecie()
        {
            return publicacion.Especie.ToString();
        }
        protected string CargarSexo()
        {
            return publicacion.Sexo == 'M' ? "Macho" : publicacion.Sexo == 'H' ? "Hembra" : "Desconocido";
        }
        protected string CargarEdad()
        {
            if (publicacion.Edad == 1)
                return publicacion.Edad + " Mes";
            else if (publicacion.Edad < 12)
                return publicacion.Edad + " Meses";
            else
                return publicacion.Edad / 12 + " Año/s";
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (tbNuevoComentario.Text.Length > 0)
            {
                //Se puede enviar el comentario (Implementar validacion en front)
                ComentarioNegocio negocio = new ComentarioNegocio();
                Comentario nuevo = new Comentario
                {
                    IdUsuario = ((Usuario)Session["Usuario"]).Id,
                    IdPublicacion = IDPublicacion,
                    Descripcion = tbNuevoComentario.Text,
                    Estado = EstadoComentario.Activo,
                    FechaHora = DateTime.Now
                };
                negocio.Agregar(nuevo);
                Response.Redirect("DetallePublicacion.aspx?ID=" + IDPublicacion);
            }
        }
        protected void btnFavorito_Click(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["Usuario"];
            int idUsuario = usuario.Id;
            int idPublicacion = Request.QueryString["ID"] != null ? Convert.ToInt32(Request.QueryString["ID"]) : 0;
            FavoritoNegocio favoritoNegocio = new FavoritoNegocio();
            bool esFavorito = favoritoNegocio.EsFavorito(idUsuario, idPublicacion);
            if (esFavorito)
                favoritoNegocio.ActivarDesactivar(idUsuario, idPublicacion, EstadoFavorito.Inactivo);
            else
                favoritoNegocio.ActivarDesactivar(idUsuario, idPublicacion, EstadoFavorito.Activo);
            Response.Redirect("DetallePublicacion.aspx?ID=" + idPublicacion);
        }
        public void ComprobarFavorito()
        {
            if (Session["Usuario"] != null)
            {

                btnFavorito.Visible = true;
                Usuario usuario = (Usuario)Session["Usuario"];
                int idUsuario = usuario.Id;
                int idPublicacion = Request.QueryString["ID"] != null ? Convert.ToInt32(Request.QueryString["ID"]) : 0;

                FavoritoNegocio favoritoNegocio = new FavoritoNegocio();
                bool esFavorito = favoritoNegocio.EsFavorito(idUsuario, idPublicacion);

                if (esFavorito)
                {
                    btnFavorito.Text = "Quitar de favoritos";
                    btnFavorito2.Text = "Quitar de favoritos";
                    btnFavorito3.Text = "Quitar de favoritos";
                }

                else
                {
                    btnFavorito.Text = "Agregar a favoritos";
                    btnFavorito2.Text = "Agregar a favoritos";
                    btnFavorito3.Text = "Agregar a favoritos";
                }
            }
        }
        protected bool ComprobarAdopcion(int idUser, int idPublicacion)
        {
            AdopcionNegocio negocio = new AdopcionNegocio();
            return negocio.EnDataBaseActivo(idUser, idPublicacion);
        }
        protected string obtenerNombrePorID(int iDusuario)
        {
            UsuarioNegocio negocioUsuario = new UsuarioNegocio();
            Usuario usuario = negocioUsuario.BuscarxID(iDusuario);
            if(usuario != null && usuario.Tipo == TipoUsuario.PersonaCompleto)
            {
                PersonaNegocio negocio = new PersonaNegocio();
                Persona persona = negocio.BuscarporUsuario(usuario.Id);
                return persona.Nombre + persona.Apellido;
            }else if(usuario != null && usuario.Tipo == TipoUsuario.Refugio)
            {
                RefugioNegocio negocio = new RefugioNegocio();
                Refugio refugio = negocio.BuscarporUsuario(usuario.Id);
                return refugio.Nombre;
            }
            return "Desconocido";
        }
        protected string obtenerImagenPorID(int iDusuario)
        {
            UsuarioNegocio negocioUsuario = new UsuarioNegocio();
            Usuario usuario = negocioUsuario.BuscarxID(iDusuario);
            if (usuario != null && usuario.Tipo == TipoUsuario.PersonaCompleto)
            {
                PersonaNegocio negocio = new PersonaNegocio();
                Persona persona = negocio.BuscarporUsuario(usuario.Id);
                return persona.UrlImagen;
            }
            else if (usuario != null && usuario.Tipo == TipoUsuario.Refugio)
            {
                RefugioNegocio negocio = new RefugioNegocio();
                Refugio refugio = negocio.BuscarporUsuario(usuario.Id);
                return refugio.UrlImagen;
            }
            else
            {
                return "";
            }
        }
    }
}