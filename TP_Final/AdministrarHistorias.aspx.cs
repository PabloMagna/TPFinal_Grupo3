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
    public partial class AdministrarHistorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Usuario)Session["Usuario"] == null)
            {
                string script = "alert('Debes iniciar sesión para acceder.');";
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", script, true);

                Response.Redirect("Login.aspx");
            }
            else if (!((Usuario)Session["Usuario"]).EsAdmin)
            {
                string script = "alert('Debes ser administrador para acceder.');";
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", script, true);

                Response.Redirect("Login.aspx");
            }


            if (!IsPostBack)
            {
                CargarHistorias();
            }
        }

        private void CargarHistorias()
        {
            HistoriaNegocio negocio = new HistoriaNegocio();
            try
            {
                List<Historia> listaHistorias = new List<Historia>();
                if (Request.QueryString["IDU"] != null)
                {
                    listaHistorias = negocio.ListarPorUsuario(Convert.ToInt32(Request.QueryString["IDU"]));
                }
                else
                {
                    listaHistorias = negocio.Listar();
                }
                dgvHistorias.DataSource = listaHistorias;
                dgvHistorias.DataBind();

                foreach (GridViewRow row in dgvHistorias.Rows)
                {
                    Historia historia = listaHistorias[row.RowIndex];
                    DropDownList ddlEstadoHistoria = (DropDownList)row.FindControl("ddlEstadoHistoria");

                    ddlEstadoHistoria.DataSource = Enum.GetValues(typeof(EstadoHistoria));
                    ddlEstadoHistoria.DataBind();
                    ddlEstadoHistoria.SelectedValue = historia.Estado.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlEstadoHistoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlEstadoHistoria = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlEstadoHistoria.NamingContainer;
            int idHistoria = Convert.ToInt32(dgvHistorias.DataKeys[row.RowIndex].Value);
            EstadoHistoria estadoHistoria = (EstadoHistoria)Enum.Parse(typeof(EstadoHistoria), ddlEstadoHistoria.SelectedValue);

            HistoriaNegocio negocio = new HistoriaNegocio();
            negocio.ActualizarEstado(idHistoria, estadoHistoria);
            CargarHistorias();
        }
    }
}
