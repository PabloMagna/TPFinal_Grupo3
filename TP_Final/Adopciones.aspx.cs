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

                // Cargar el DataGridView con las adopciones correspondientes al usuario y la publicación
                CargarAdopciones(idUsuario);
            }
        }

        private void CargarAdopciones(int idUsuario)
        {
            AdopcionNegocio adopcionNegocio = new AdopcionNegocio();

            // Obtener las adopciones correspondientes al usuario y la publicación
            List<Adopcion> adopciones = adopcionNegocio.ListarPorUsuario(idUsuario);

            // Cargar el DataGridView con las adopciones
            dgvAdopciones.DataSource = adopciones;
            dgvAdopciones.DataBind();
        }
    }
}
