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

            // Seleccionar solo las columnas necesarias
            var adopcionesSeleccionadas = adopciones.Select(a => new { a.Estado }).ToList();

            // Configurar el origen de datos para el GridView
            dgvAdopciones.DataSource = adopcionesSeleccionadas;
            dgvAdopciones.DataBind();

            // Ocultar la columna "IDPublicacion"
            dgvAdopciones.Columns[2].Visible = false;
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
    }
}
