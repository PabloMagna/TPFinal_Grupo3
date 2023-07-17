using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace TP_Final
{
    public partial class AdministrarPublicaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Usuario)Session["Usuario"] == null)
                Response.Redirect("Login.aspx");
            else if (!((Usuario)Session["Usuario"]).EsAdmin)
                Response.Redirect("Login.aspx");

            if (!IsPostBack)
            {
                CargarPublicaciones();
            }
        }

        private void CargarPublicaciones()
        {
            PublicacionNegocio negocio = new PublicacionNegocio();
            List<Publicacion> publicaciones = new List<Publicacion>();
            try
            {
                if (Request.QueryString["ID"] != null)
                {
                    publicaciones = negocio.ListarPorUsuarioAdmin(Convert.ToInt32(Request.QueryString["ID"]));
                }
                else if (Request.QueryString["IDP"] != null)
                {
                    publicaciones = negocio.ListarPorIDPublicacion(Convert.ToInt32(Request.QueryString["IDP"]));
                }
                else
                {
                    publicaciones = negocio.ListarAdmin();
                }
                dgvPublicaciones.DataSource = publicaciones;
                dgvPublicaciones.DataBind();

                foreach (GridViewRow row in dgvPublicaciones.Rows)
                {
                    Publicacion publicacion = publicaciones[row.RowIndex];
                    DropDownList ddlEstado = (DropDownList)row.FindControl("ddlEstado");
                    Label lblEstado = (Label)row.FindControl("lblEstado");

                    if (ddlEstado != null)
                    {
                        ddlEstado.DataSource = Enum.GetValues(typeof(Estado));
                        ddlEstado.DataBind();
                        ddlEstado.Enabled = true;
                        ddlEstado.SelectedValue = publicacion.Estado.ToString();

                        ddlEstado.Visible = true;
                        lblEstado.Visible = false;
                    }

                    // Obtener nombres de provincia y localidad
                    int idProvincia = publicacion.IDProvincia;
                    int idLocalidad = publicacion.IDLocalidad;
                    ProvinciaNegocio provinciaNegocio = new ProvinciaNegocio();
                    LocalidadNegocio localNegocio = new LocalidadNegocio();
                    string nombreProvincia = provinciaNegocio.ObtenerNombrePorId(idProvincia);
                    string nombreLocalidad = localNegocio.ObtnerNombrePorID(idLocalidad);

                    // Buscar las celdas correspondientes en la fila y asignar los nombres
                    row.Cells[10].Text = nombreLocalidad; // La columna 10 (celda 10) es la de Localidad
                    row.Cells[11].Text = nombreProvincia; // La columna 11 (celda 11) es la de Provincia
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAcciones_Click(object sender, EventArgs e)
        {
            Button btnAccion = (Button)sender;
            int idPublicacion = Convert.ToInt32(btnAccion.CommandArgument);

            PublicacionNegocio negocio = new PublicacionNegocio();
            AdopcionNegocio adopcionNegocio = new AdopcionNegocio();
            int idAdoptanteActivo = adopcionNegocio.BuscarAdoptanteActivoPorPublicacion(idPublicacion);
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Usuario adoptante = usuarioNegocio.BuscarxID(idAdoptanteActivo);
            string comentario;

            switch (btnAccion.CommandName)
            {
                case "Activar":
                    comentario = "Adopción eliminada por Administrador";
                    negocio.ActualizarEstado(idPublicacion, Estado.Activa);
                    // Si hay una adopción en proceso se da de baja
                    adopcionNegocio.ActualizarEstadoActivaActual(idPublicacion, EstadoAdopcion.EliminadoPorAdmin, comentario);
                    CargarPublicaciones();

                    if (adoptante != null && !string.IsNullOrEmpty(adoptante.Email))
                    {
                        EmailSender emailSender = new EmailSender();
                        emailSender.EnviarCorreoBajaAdopcion(adoptante.Email, comentario);
                    }

                    break;

                case "Eliminar":
                    comentario = "Publicación eliminada por Administrador";
                    negocio.ActualizarEstado(idPublicacion, Estado.EliminadaPorAdmin);
                    // Si hay una adopción en proceso se da de baja
                    adopcionNegocio.ActualizarEstadoActivaActual(idPublicacion, EstadoAdopcion.PublicacionBorrada, comentario);
                    CargarPublicaciones();

                    if (adoptante != null && !string.IsNullOrEmpty(adoptante.Email))
                    {
                        EmailSender emailSender = new EmailSender();
                        emailSender.EnviarCorreoBajaAdopcion(adoptante.Email, comentario);
                    }

                    break;
            }
        }
        protected bool MostrarBotonActivar(object estado)
        {
            if (estado != null && estado is Estado)
            {
                Estado estadoPublicacion = (Estado)estado;
                return estadoPublicacion != Estado.Activa;
            }
            return false;
        }

        protected bool MostrarBotonEliminar(object estado)
        {
            if (estado != null && estado is Estado)
            {
                Estado estadoPublicacion = (Estado)estado;
                return estadoPublicacion != Estado.EliminadaPorAdmin && estadoPublicacion != Estado.BorradaPorUsuario;
            }
            return false;
        }

    }
}
