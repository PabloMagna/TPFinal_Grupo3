using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Final
{
    public partial class DetallePublicacion : System.Web.UI.Page
    {
        protected Publicacion publicacion;
        protected List<string> listaImagenes;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["ID"]);
                    PublicacionNegocio publiNegocio = new Negocio.PublicacionNegocio();
                    publicacion = publiNegocio.ObtenerPorId(id);
                    ImagenMascotaNegocio imagenNegocio = new ImagenMascotaNegocio();
                    listaImagenes = imagenNegocio.ObtenerUrlsImagenes(id);
                }
            }
        }
    }
}