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
            IDPublicacion = Convert.ToInt32(Request.QueryString["ID"]);

            if (Session["Usuario"] != null)
            {
                userSession = (Usuario)Session["Usuario"];
                ComentarioNegocio negocioComentario = new ComentarioNegocio();
                camposSesion = new Campos();
                camposSesion=negocioComentario.CamposUsuarioComentario(userSession);
                if(camposSesion.UrlImg is null || camposSesion.UrlImg == string.Empty)
                {
                    camposSesion.UrlImg = ImgPlaceHolder;
                }
                ComprobarFavorito();
            }
            else
            {
                camposSesion = new Campos();
                camposSesion.Nombre = "Logeate para comentar";
                camposSesion.UrlImg = ImgPlaceHolder;
                btnEnviar.Enabled = false;
                tbNuevoComentario.ReadOnly = true;
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
                camposAux = comentarioNego.CamposUsuarioComentario(user);
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
            if(tbNuevoComentario.Text.Length > 0)
            {
                //Se puede enviar el comentario (Implementar validacion en front)
                ComentarioNegocio negocio = new ComentarioNegocio();
                Comentario nuevo = new Comentario
                {
                    IdUsuario = userSession.Id,
                    IdPublicacion = IDPublicacion,
                    Descripcion = tbNuevoComentario.Text,
                    Estado = EstadoComentario.Activo,
                    FechaHora = DateTime.Now
                };
                negocio.Agregar(nuevo);
                Response.Redirect("DetallePublicacion.aspx?ID="+IDPublicacion);
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
                    btnFavorito.Text = "Quitar de favoritos";
                else
                    btnFavorito.Text = "Agregar a favoritos";
            }
        }
        protected bool ComprobarAdopcion(int idUser, int idPublicacion)
        {
            AdopcionNegocio negocio = new AdopcionNegocio();
            return negocio.EnDataBase(idUser,idPublicacion);
        }
    }
}