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
    public partial class AdministrarUsuarios : System.Web.UI.Page
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
                CargarUsuarios();
            }
        }

        private void CargarUsuarios()
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                List<Usuario> lista = new List<Usuario>();
                if (Request.QueryString["IDU"] != null)
                {
                    lista = negocio.ListarPorIDUsuario(Convert.ToInt32(Request.QueryString["IDU"]));
                }
                else
                {
                    lista = negocio.Listar();
                }
                dgvUsuarios.DataSource = lista;
                dgvUsuarios.DataBind();

                foreach (GridViewRow row in dgvUsuarios.Rows)
                {
                    Usuario usuario = lista[row.RowIndex];
                    DropDownList ddlEstado = (DropDownList)row.FindControl("ddlEstado");
                    CheckBox cbEsAdmin = (CheckBox)row.FindControl("cbEsAdmin");

                    ddlEstado.DataSource = Enum.GetValues(typeof(EstadoUsuario));
                    ddlEstado.DataBind();
                    ddlEstado.SelectedValue = usuario.Estado.ToString();

                    cbEsAdmin.Checked = usuario.EsAdmin;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlEstado = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlEstado.NamingContainer;
            int idUsuario = Convert.ToInt32(dgvUsuarios.DataKeys[row.RowIndex].Value);
            EstadoUsuario estado = (EstadoUsuario)Enum.Parse(typeof(EstadoUsuario), ddlEstado.SelectedValue);

            UsuarioNegocio negocio = new UsuarioNegocio();
            negocio.ActualizarEstado(idUsuario, estado);
            CargarUsuarios();
        }
        protected void cbEsAdmin_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbEsAdmin = (CheckBox)sender;
            GridViewRow row = (GridViewRow)cbEsAdmin.NamingContainer;
            int usuarioId = Convert.ToInt32(dgvUsuarios.DataKeys[row.RowIndex].Value);
            bool esAdmin = cbEsAdmin.Checked;

            UsuarioNegocio negocio = new UsuarioNegocio();
            negocio.ActualizarAdmin(usuarioId, esAdmin);
            CargarUsuarios();
        }
    }
}