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
    public partial class galeria : System.Web.UI.Page
    {
        protected List<Publicacion> publicaciones;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PublicacionNegocio negocio = new PublicacionNegocio();
                publicaciones = negocio.Listar();
            }
        }
    }
}