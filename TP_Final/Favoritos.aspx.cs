using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TP_Final
{
    public partial class Favoritos : System.Web.UI.Page
    {
        protected List<Publicacion> favoritos;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarFavoritos();
            }
        }

        public string obtenerPrimeraImagen(int idPublicacion)
        {
            List<ImagenMascota> lista = new List<ImagenMascota>();
            ImagenMascotaNegocio negocio = new ImagenMascotaNegocio();
            lista = negocio.listar(idPublicacion);

            if (lista != null && lista.Count > 0 && !string.IsNullOrEmpty(lista[0].urlImagen))
            {
                return lista[0].urlImagen;
            }
            else
            {
                return "https://g.petango.com/shared/Photo-Not-Available-dog.gif";
            }
        }

        private void CargarFavoritos()
        {
            Usuario usuario = (Usuario)Session["Usuario"];
            if (usuario != null)
            {
                FavoritoNegocio favoritoNegocio = new FavoritoNegocio();
                PublicacionNegocio publicacionNegocio = new PublicacionNegocio();
                List<int> ints = new List<int>();

                ints = favoritoNegocio.ListarIDPublicaciones(usuario.Id);
                favoritos = publicacionNegocio.ListarPorListaDeID(ints);
            }
        }

        protected void btnQuitarFavorito_Click(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["Usuario"];
            int idUsuario = usuario.Id;

            Button btnQuitarFavorito = (Button)sender;
            int idPublicacion = (int)Session["idFav"];

            FavoritoNegocio favoritoNegocio = new FavoritoNegocio();
            favoritoNegocio.ActivarDesactivar(idUsuario, idPublicacion, EstadoFavorito.Inactivo);
            Response.Redirect("Favoritos.aspx");
        }

    }
}
