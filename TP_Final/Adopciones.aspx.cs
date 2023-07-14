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
            LinkButton lnkEliminar = (LinkButton)sender;
            int idPublicacion = Convert.ToInt32(lnkEliminar.CommandArgument);
            PublicacionNegocio publicacionNeg = new PublicacionNegocio();
            Publicacion publicacion = publicacionNeg.ObtenerPorId(idPublicacion);

            // Obtener el ID del usuario desde la sesión "Usuario"
            int idUsuario = ((Usuario)Session["Usuario"]).Id;

            // Obtener el comentario ingresado por el usuario
            GridViewRow row = (GridViewRow)lnkEliminar.NamingContainer;
            TextBox txtComentario = (TextBox)row.FindControl("txtComentario");
            string comentario = txtComentario.Text.Trim();

            // Actualizar el estado de la adopción y la publicación en la base de datos
            AdopcionNegocio adopcionNegocio = new AdopcionNegocio();

            if (publicacion.Estado == Estado.FinalizadaConExito)
            {
                adopcionNegocio.ActualizarEstado(idUsuario, idPublicacion, EstadoAdopcion.Devuelto, comentario);
            }
            else if (publicacion.Estado == Estado.EnProceso)
            {
                adopcionNegocio.ActualizarEstado(idUsuario, idPublicacion, EstadoAdopcion.EliminadaPorAdoptante, comentario);
            }

            publicacionNeg.ActualizarEstado(idPublicacion, Estado.Activa);

            // Cargar las adopciones actualizadas
            CargarAdopciones(idUsuario);
        }


    }
}
