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
    public partial class MisPublicaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if(!IsPostBack)
            {
                CargarPublicaciones();
            }
        }
        private void CargarPublicaciones()
        {
            PublicacionNegocio negocio = new PublicacionNegocio();
            List<Publicacion> publicaciones = new List<Publicacion>();
            publicaciones = negocio.ListarPorUsuario(((Usuario)Session["Usuario"]).Id);

            dgvPublicaciones.DataSource = publicaciones;
            dgvPublicaciones.DataBind();
        }

    }
}