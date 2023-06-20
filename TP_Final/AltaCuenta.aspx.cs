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
    public partial class AltaCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
            ProvinciaNegocio provincias = new ProvinciaNegocio();
            LocalidadNegocio localidades = new LocalidadNegocio();
            string Cuenta = (string)Request.QueryString["Cuenta"];
            if (Cuenta == "Persona") { 
            
                formRefugio.Visible = false;
                formPersona.Visible = true;
            }
            else
            {
                formPersona.Visible = false;
                formRefugio.Visible = true;
            }

            if (!IsPostBack)
            {
                ddlProvincia.DataSource = provincias.cargarDropDownList();
                ddlProvincia.DataBind();

                ddlLocalidad.DataSource=localidades.CargarDropDownList(ddlProvincia.SelectedIndex+1);
                ddlLocalidad.DataBind();
            }
           
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocalidadNegocio localidades = new LocalidadNegocio();
            ddlLocalidad.DataSource = localidades.CargarDropDownList(ddlProvincia.SelectedIndex + 1);
            ddlLocalidad.DataBind();
        }
    }
}