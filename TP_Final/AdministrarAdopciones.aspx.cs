using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace TP_Final
{
    public partial class AdministrarAdopciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Usuario)Session["Usuario"] == null)
                Response.Redirect("Login.aspx");
            else if (!((Usuario)Session["Usuario"]).EsAdmin)
                Response.Redirect("Login.aspx");

            if (!IsPostBack)
            {
                CargarAdopciones();
            }
        }

        private void CargarAdopciones()
        {
            AdopcionNegocio negocio = new AdopcionNegocio();
            try
            {
                List<Adopcion> lista = new List<Adopcion>();
                if (Request.QueryString["IDU"] != null)
                {
                    lista = negocio.ListarPorUsuarioAdmin(Convert.ToInt32(Request.QueryString["IDU"]));
                }
                else if (Request.QueryString["IDP"] != null)
                {
                    lista = negocio.ListarPorPublicacion(Convert.ToInt32(Request.QueryString["IDP"]));
                }
                else
                {
                    lista = negocio.Listar();
                }
                gvAdopciones.DataSource = lista;
                gvAdopciones.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvAdopciones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Adopcion adopcion = (Adopcion)e.Row.DataItem;
                DropDownList ddlEstado = (DropDownList)e.Row.FindControl("ddlEstado");

                // Obtener los valores posibles para el estado de la adopción
                Array enumValues = Enum.GetValues(typeof(EstadoAdopcion));
                ddlEstado.DataSource = enumValues;
                ddlEstado.DataBind();

                // Establecer el valor seleccionado en el DropDownList
                ddlEstado.SelectedValue = adopcion.Estado.ToString();
            }
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMensaje.Visible = false;
            DropDownList ddlEstado = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlEstado.NamingContainer;
            int idAdopcion = Convert.ToInt32(gvAdopciones.DataKeys[row.RowIndex].Value);
            EstadoAdopcion estado = (EstadoAdopcion)Enum.Parse(typeof(EstadoAdopcion), ddlEstado.SelectedValue);

            // Actualizar el estado de la adopción en el negocio
            AdopcionNegocio negocio = new AdopcionNegocio();
            PublicacionNegocio publicacionNegocio = new PublicacionNegocio();
            Adopcion adopcion = negocio.ObtenerAdopcionPorID(idAdopcion);
            Publicacion publicacion = publicacionNegocio.ObtenerPorId(adopcion.IDPublicacion);

            if(estado == EstadoAdopcion.Pendiente && (publicacion.Estado == Estado.Activa || publicacion.Estado == Estado.Suspendida || publicacion.Estado == Estado.Borrada || publicacion.Estado == Estado.Finalizada))
            {
                negocio.ActualizarEstado(idAdopcion, estado);
                publicacionNegocio.ActualizarEstado(adopcion.IDPublicacion, Estado.EnProceso);
            }
            else if(estado == EstadoAdopcion.Completada && publicacion.Estado == Estado.EnProceso) {
                negocio.ActualizarEstado(idAdopcion, estado);
                publicacionNegocio.ActualizarEstado(adopcion.IDPublicacion, Estado.Finalizada);
            }
            else if((estado == EstadoAdopcion.Eliminada || estado == EstadoAdopcion.Rechazada) && publicacion.Estado == Estado.EnProceso)
            {
                negocio.ActualizarEstado(idAdopcion, estado);
                publicacionNegocio.ActualizarEstado(adopcion.IDPublicacion, Estado.Activa);
            }
            else 
            {
                lblMensaje.Text = "No se pueden realizar los cambios, por incompatibilidad de las publicaciones";
                lblMensaje.Visible = true;
            }

            // Volver a cargar las adopciones en el GridView
            CargarAdopciones();
        }
    }
}
