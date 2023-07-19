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
    public partial class BorrarComentario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] == null)
                    Response.Redirect("Default.aspx");
                if (Request.QueryString["ID"] == null)
                    Response.Redirect("Default.aspx");

                ComentarioNegocio comentarioNegocio = new ComentarioNegocio();
                if (comentarioNegocio.ExisteComentarioActivo(int.Parse(Request.QueryString["ID"]), ((Usuario)Session["Usuario"]).Id))
                {
                    comentarioNegocio.ActualizarEstado(int.Parse(Request.QueryString["ID"]), EstadoComentario.Inactivo);
                    ScriptManager.RegisterStartupScript(this, GetType(), "MensajeExito", "alert('Comentario borrado correctamente.');", true);
                    string urlPaginaAnterior = Request.UrlReferrer?.ToString();
                    Response.AddHeader("REFRESH", $"3;URL={urlPaginaAnterior}");
                }

            }
        }
    }
}