using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TP_Final
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected List<Publicacion> publicaciones;
        protected List<Historia> historias;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                PublicacionNegocio publiNegocio = new PublicacionNegocio();
                HistoriaNegocio histoNegocio = new HistoriaNegocio();
                historias = new List<Historia>();
                historias = histoNegocio.ListarPorUsuario(usuario.Id);

                publicaciones = publiNegocio.ListarPorUsuario(usuario.Id);
                //cargar historias
                rpHistorias.DataSource = historias;
                rpHistorias.DataBind();

                if (!IsPostBack)
                {

                }
                else { Response.Redirect("/default.aspx"); }
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

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btnDelete = (Button)sender;
            RepeaterItem repeaterItem = (RepeaterItem)btnDelete.NamingContainer;

            if (repeaterItem != null)
            {
                HiddenField hfIDHistoria = (HiddenField)repeaterItem.FindControl("hfIDHistoria");
                if (hfIDHistoria != null)
                {
                    int idHistoria = Convert.ToInt32(hfIDHistoria.Value);

                    HistoriaNegocio negocio = new HistoriaNegocio();
                    negocio.Eliminar(idHistoria);

                }

            }
        }

       
    }
}