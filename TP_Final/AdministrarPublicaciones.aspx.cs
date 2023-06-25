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
                    publicaciones = negocio.ListarPorUsuario(Convert.ToInt32(Request.QueryString["ID"]));
                }
                else
                {
                    publicaciones = negocio.Listar();
                }
                dgvPublicaciones.DataSource = publicaciones;
                dgvPublicaciones.DataBind();

                foreach (GridViewRow row in dgvPublicaciones.Rows)
                {
                    DropDownList ddlEstado = (DropDownList)row.FindControl("ddlEstado");
                    ddlEstado.DataSource = Enum.GetValues(typeof(Estado));
                    ddlEstado.DataBind();
                    ddlEstado.Enabled = true; // Habilitar el DDL

                    Publicacion publicacion = publicaciones[row.RowIndex];
                    ddlEstado.SelectedValue = publicacion.Estado.ToString();

                    // Obtener nombres de provincia y localidad
                    int idProvincia = publicacion.IDProvincia;
                    int idLocalidad = publicacion.IDLocalidad;
                    ProvinciaNegocio provinciaNegocio = new ProvinciaNegocio();
                    LocalidadNegocio localNegocio = new LocalidadNegocio();
                    string nombreProvincia = provinciaNegocio.ObtenerNombrePorId(idProvincia); // Llama a la función existente para obtener el nombre de provincia
                    string nombreLocalidad = localNegocio.ObtnerNombrePorID(idLocalidad); // Llama a la función existente para obtener el nombre de localidad

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


        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlEstado = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlEstado.NamingContainer;
            int idPublicacion = Convert.ToInt32(dgvPublicaciones.DataKeys[row.RowIndex].Value);
            Estado nuevoEstado = (Estado)Enum.Parse(typeof(Estado), ddlEstado.SelectedValue);

            // Actualizar el estado en la base de datos
            PublicacionNegocio negocio = new PublicacionNegocio();
            negocio.ActualizarEstado(idPublicacion, nuevoEstado);

            // Actualizar el DGV
            CargarPublicaciones();
        }
    }
}
