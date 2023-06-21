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
            try
            {
                if (!IsPostBack)
                {
                    CargarDropDownListProvincias();
                    CargarLocalidades(1);
                }

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
           
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Publicacion nueva = new Publicacion();
                nueva.Titulo = tbNombre.Text;
                nueva.Raza = tbRaza.Text;
                nueva.Descripcion = tbDescripcion.Text;
                nueva.IDProvincia = int.Parse(ddlProvincia.SelectedValue);
                nueva.IDLocalidad = int.Parse(ddlLocalidad.SelectedValue);
                nueva.Especie = int.Parse(ddlEspecie.SelectedValue);
                nueva.Sexo = ddlSexo.SelectedValue[0];
                //nueva.IdUsuario = //usuario de la sesión
                nueva.FechaHora = DateTime.Now;

                ImagenMascota nuevaImg = new ImagenMascota();
                //nuevaImg.IdPublicacion = get id de la publicación que acabo de crear

                //Insertar registro - Crear método en PublicacionNegocio


            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
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
            List<KeyValuePair<int, string>> localidades = localidadNegocio.ListarClaveValor(idProvincia);

            ddlLocalidad.DataSource = localidades;
            ddlLocalidad.DataTextField = "Value"; // Nombre de la propiedad para mostrar (valor)
            ddlLocalidad.DataValueField = "Key"; // Nombre de la propiedad para el valor (clave)
            ddlLocalidad.DataBind();
        }
        private void CargarDropDownListProvincias()
        {           
            ProvinciaNegocio provinciaNegocio = new ProvinciaNegocio();
            List<KeyValuePair<int, string>> provincias = provinciaNegocio.ListarClaveValor();

            ddlProvincia.DataSource = provincias;
            ddlProvincia.DataTextField = "Value"; // Nombre de la propiedad para mostrar (valor)
            ddlProvincia.DataValueField = "Key"; // Nombre de la propiedad para el valor (clave)
            ddlProvincia.DataBind();
        }
    }
}