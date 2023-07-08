using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TP_Final
{
    public partial class Adopciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
                Response.Redirect("Login.aspx");
            if (!IsPostBack)
            {
                // Obtener el ID del usuario desde la sesión "Usuario"
                int idUsuario = ((Usuario)Session["Usuario"]).Id;

                // Cargar el GridView con las adopciones correspondientes al usuario y la publicación
                CargarAdopciones(idUsuario);
            }
        }

        private void CargarAdopciones(int idUsuario)
        {
            AdopcionNegocio adopcionNegocio = new AdopcionNegocio();

            // Obtener las adopciones correspondientes al usuario y la publicación
            List<Adopcion> adopciones = adopcionNegocio.ListarPorUsuario(idUsuario);

            // Configurar el origen de datos para el GridView
            dgvAdopciones.DataSource = adopciones;
            dgvAdopciones.DataBind();
        }

        protected void dgvAdopciones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Obtener el número de lista y establecerlo en la primera columna del GridView
                int numeroLista = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = numeroLista.ToString();
            }
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            // Obtener el IDAdopcion del LinkButton que se hizo clic
            LinkButton lnkEliminar = (LinkButton)sender;
            int idAdopcion = Convert.ToInt32(lnkEliminar.CommandArgument);

            // Actualizar el estado de la adopción a "eliminado" en la base de datos
            AdopcionNegocio adopcionNegocio = new AdopcionNegocio();
            adopcionNegocio.ActualizarEstado(idAdopcion, EstadoAdopcion.Eliminada);

            // Volver a cargar las adopciones del usuario en el GridView
            int idUsuario = ((Usuario)Session["Usuario"]).Id;
            CargarAdopciones(idUsuario);
        }
    }
}
