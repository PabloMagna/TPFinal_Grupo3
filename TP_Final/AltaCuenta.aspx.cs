using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
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
                rfvNombreRefugio.Enabled = false;
                rfvDireccion.Enabled = false;
            }
            else
            {
                formPersona.Visible = false;
                formRefugio.Visible = true;
                rfvApellido.Enabled = false;
                rfvNombre.Enabled = false;
                rfvFechaNac.Enabled = false;
            }

            if (!IsPostBack)
            {
                ddlProvincia.Items.Clear();
                ddlProvincia.DataSource = provincias.cargarDropDownList();
                ddlProvincia.DataBind();
                ddlProvincia.SelectedIndex = 0;

                ddlLocalidad.DataSource = localidades.CargarDropDownList(ddlProvincia.SelectedIndex);
                ddlLocalidad.DataBind();
                ddlLocalidad.SelectedIndex = 0;
            }
           
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocalidadNegocio localidades = new LocalidadNegocio();
            ddlLocalidad.DataSource = localidades.CargarDropDownList(ddlProvincia.SelectedIndex);
            ddlLocalidad.DataBind();
        }

        protected void cvProvincia_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //Comprueba si se seleccionó una provincia en el ddl de provincia.
            args.IsValid = (ddlProvincia.SelectedItem.Text != "Seleccionar");
        }

        protected void cvLocalidad_ServerValidate(Object source, ServerValidateEventArgs args)
        {
            args.IsValid = (ddlLocalidad.SelectedIndex != 0);
        }

        protected void ddlLocalidad_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlLocalidad.Items.Clear();
                ddlLocalidad.Items.Add("Seleccionar");
            }
            
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //Acciones a tomar si todos los campos del form son validos (cargar a db)
            }
        }
    }
}