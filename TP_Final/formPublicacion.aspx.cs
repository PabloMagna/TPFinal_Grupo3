using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using static System.Net.WebRequestMethods;


namespace TP_Final
{
    public partial class Publicar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {               
                CargarDropDownListProvincias();      
            }
        }
        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ddlProvincia.SelectedIndex;
            int idProvincia = index + 1;
            CargarLocalidades(idProvincia);
        }

        private void CargarLocalidades(int idProvincia)
        {
            LocalidadNegocio localidadNegocio = new LocalidadNegocio();
            List<string> localidades = localidadNegocio.CargarDropDownList(idProvincia);
            ddlLocalidad.DataSource = localidades;
            ddlLocalidad.DataBind();
        }
        private void CargarDropDownListProvincias()
        {
            ProvinciaNegocio provinciaNegocio = new ProvinciaNegocio();
            List<string> provincias = provinciaNegocio.cargarDropDownList();
            ddlProvincia.DataSource = provincias;            
            ddlProvincia.DataBind();            
        }
    }
}