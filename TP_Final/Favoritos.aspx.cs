using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using System.Web.UI.HtmlControls;

namespace TP_Final
{
    public partial class Favoritos : System.Web.UI.Page
    {
        protected List<Publicacion> favoritos;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] == null)
                    Response.Redirect("Login.aspx");
                CargarFavoritos();
            }
        }

        public string ObtenerPrimeraImagen(int idPublicacion)
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
        protected void repeaterFavoritos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Acceder al control imgTarjeta dentro de cada tarjeta
                HtmlImage imgTarjeta = (HtmlImage)e.Item.FindControl("imgTarjeta");

                // Obtener los datos del favorito actual
                Publicacion publicacion = (Publicacion)e.Item.DataItem;

                // Obtener la URL de la primera imagen utilizando el método ObtenerPrimeraImagen
                string urlImagen = ObtenerPrimeraImagen(publicacion.Id);

                // Asignar la URL de la imagen al control imgTarjeta
                imgTarjeta.Src = urlImagen;
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
                repeaterFavoritos.DataSource = publicacionNegocio.ListarPorListaDeID(ints);
                repeaterFavoritos.DataBind();
            }
        }
        protected void btnQuitarFavorito_Click(object sender, EventArgs e)
        {
            Button btnQuitarFavorito = (Button)sender;
            RepeaterItem repeaterItem = (RepeaterItem)btnQuitarFavorito.NamingContainer;

            if (repeaterItem != null)
            {
                HiddenField hfIdPublicacion = (HiddenField)repeaterItem.FindControl("hfIdPublicacion");
                if (hfIdPublicacion != null)
                {
                    int idPublicacion = Convert.ToInt32(hfIdPublicacion.Value);

                    Usuario usuario = (Usuario)Session["Usuario"];
                    FavoritoNegocio favoritoNegocio = new FavoritoNegocio();
                    favoritoNegocio.ActivarDesactivar(usuario.Id, idPublicacion, EstadoFavorito.Inactivo);

                    // Actualizar la lista de favoritos
                    CargarFavoritos();
                }
            }
        }


    }
}
