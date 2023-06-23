using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Final
{
	public partial class AdministrarPublicaciones : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if(!IsPostBack)
			{
                CargarPublicaciones();
            }
		}
		private void CargarPublicaciones()
		{
			PublicacionNegocio negocio = new PublicacionNegocio();
			try
			{
                dgvPublicaciones.DataSource = negocio.Listar();
				dgvPublicaciones.DataBind();
            }
            catch (Exception ex)
			{
                throw ex;
            }
		}

        protected void dgvPublicaciones_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvPublicaciones.EditIndex = e.NewEditIndex;
            CargarPublicaciones(); // Vuelve a cargar los datos después de habilitar la edición
        }
    }
}