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
        protected List<string> imagenesUsuario { set; get; }
        protected List<Comentario> comentarios { set; get; }
        protected List<Usuario> usuarios { set; get; }
        protected Usuario userSession { set; get; }
        protected Publicacion publicacion;
        protected Campos camposSesion;
        protected List<Campos> camposUsuario;
        protected const string ImgPlaceHolder = "https://img.freepik.com/vector-gratis/ilustracion-icono-vector-dibujos-animados-lindo-gato-sentado-concepto-icono-naturaleza-animal-aislado-premium-vector-estilo-dibujos-animados-plana_138676-4148.jpg?w=2000";
        protected void Page_Load(object sender, EventArgs e)
        {   
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
            imagenesUsuario = new List<string>();
            //usuarios = new List<Usuario>();
            comentarios = new List<Comentario>();
            comentarios = comentarioNego.ListarPorPublicacion(id);

            foreach (var comentario in comentarios)
            {
                //Carga Imagenes de Perfil de Usuarios
                int idUser = comentario.IdUsuario;
                string url = ObtenerImagenUsuario(idUser);

                if(url is null || url == string.Empty)
                {
                    //PLACEOLDER
                    url = ImgPlaceHolder;
                }
                imagenesUsuario.Add(url);
                //Cargo Usuarios de comentarios
                Usuario user = new Usuario();
                user = usuarioNego.BuscarxID(idUser);
                camposUsuario = new List<Campos>();
                Campos camposAux = new Campos();
                camposAux = comentarioNego.CamposUsuarioComentario(user);
                camposUsuario.Add(camposAux);
                //usuarios.Add(user);
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


        //REVISAR SI SE PASA ESTA FUNCON A USUARIONEGOCIO
        private string ObtenerImagenUsuario(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            string url = "";

            try
            {
                datos.setearConsulta("select urlImagen from Personas where IDUsuario=@IDUsuario union all select UrlImagen from Refugios where IDUsuario=@IDUsuario");
                datos.setearParametro("@IDUsuario", idUsuario);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    url = (string)datos.Lector["urlImagen"];
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

            return url;
        }

        protected void btAdoptar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if(tbNuevoComentario.Text.Length > 0)
            {
                //Se puede enviar el comentario (Implementar validacion en front)

            }
        }
    }
}