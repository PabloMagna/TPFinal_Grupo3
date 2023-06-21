using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using static System.Net.WebRequestMethods;
using System.Diagnostics.Eventing.Reader;

namespace TP_Final
{
    public partial class galeria : System.Web.UI.Page
    {
        protected List<Publicacion> publicaciones;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarLista();
                CargarDDL();
                CargarDropDownListProvincias();
                CargarLocalidades(0);
            }
        }
        public string obtenerPrimeraImagen(int idPublicacion)
        {
            List<ImagenMascota> lista = new List<ImagenMascota>();
            ImagenMascotaNegocio negocio = new ImagenMascotaNegocio();
            lista = negocio.listar(idPublicacion);
            if (lista != null && lista.Count > 0)
            {
                return lista[0].urlImagen;
            }
            else
            {
                return "https://g.petango.com/shared/Photo-Not-Available-dog.gif";
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            Filtrar();
            Response.Redirect("galeria.aspx");
        }
        private void CargarLista()
        {
            if (Session["Publicaciones"] == null)
            {
                PublicacionNegocio publiNegocio = new PublicacionNegocio();
                publicaciones = publiNegocio.Listar();
            }
            else
            {
                publicaciones = (List<Publicacion>)Session["Publicaciones"];
            }
            
        }
        private void CargarDDL()
        {
            // Cargar DropDownList de especies
            ddlEspecies.Items.Clear();
            ddlEspecies.Items.Add(new ListItem("Perro", "1"));
            ddlEspecies.Items.Add(new ListItem("Gato", "2"));
            ddlEspecies.Items.Add(new ListItem("Otros", "3"));

            ddlEspecies.Items.Insert(0, new ListItem("TODOS", "0"));
            ddlEspecies.SelectedValue = "0";
            // Cargar DropDownList de sexo
            ddlSexo.Items.Clear();
            ddlSexo.Items.Add(new ListItem("Hembra", "H"));
            ddlSexo.Items.Add(new ListItem("Macho", "M"));
            ddlSexo.Items.Add(new ListItem("Desconocido", "D"));

            ddlSexo.Items.Insert(0, new ListItem("TODOS", "T"));
            ddlSexo.SelectedValue = "T";
            // Cargar DropDownList de mes y año
            // Aquí debes implementar la lógica para cargar el DropDownList de mes y año
            ddlMesAnio.Items.Clear();
            ddlMesAnio.Items.Add(new ListItem("Año/s (Máximo)", "A"));
            ddlMesAnio.Items.Add(new ListItem("Mes/es (Máximo)", "M"));
            ddlMesAnio.SelectedValue = "A";

            txtEdad.Text = "0";
        }
        private void Filtrar()
        {
            PublicacionNegocio negocio = new PublicacionNegocio();
            int meses = 0;
            if (ddlMesAnio.SelectedValue == "A")
            {
                meses = Convert.ToInt32(txtEdad.Text) * 12;
            }
            else
            {
                meses = Convert.ToInt32(txtEdad.Text);
            }

            int provincia = Convert.ToInt32(ddlProvincia.SelectedValue);
            int localidad = Convert.ToInt32(ddlLocalidad.SelectedValue);
            int especie = Convert.ToInt32(ddlEspecies.SelectedValue);
            char sexo = ddlSexo.SelectedValue[0];

            List<Publicacion> listaFiltrada = negocio.Filtrar(provincia, localidad, especie, sexo, meses);
            Session["Publicaciones"] = listaFiltrada;
            publicaciones = listaFiltrada;
            updatePanelTarjetas.Update();
        }


        protected void btnRemoverFiltro_Click(object sender, EventArgs e)
        {
            PublicacionNegocio publiNegocio = new PublicacionNegocio();
            Session["Publicaciones"] = publiNegocio.Listar();
            Response.Redirect("galeria.aspx");
        }
        private void CargarDropDownListProvincias()
        {
            ProvinciaNegocio provinciaNegocio = new ProvinciaNegocio();
            List<KeyValuePair<int, string>> provincias = provinciaNegocio.ListarClaveValor();

            ddlProvincia.DataSource = provincias;
            ddlProvincia.DataTextField = "Value"; // Nombre de la propiedad para mostrar (valor)
            ddlProvincia.DataValueField = "Key"; // Nombre de la propiedad para el valor (clave)
            ddlProvincia.DataBind();
            ddlProvincia.Items.Insert(0, new ListItem("TODAS", "0"));
            ddlProvincia.SelectedValue = "0";
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProvincia = Convert.ToInt32(ddlProvincia.SelectedValue);
            CargarLocalidades(idProvincia);
            Filtrar();
        }

        private void CargarLocalidades(int idProvincia)
        {
            if(idProvincia == 0)
            {
                ddlLocalidad.Items.Clear();
                ddlLocalidad.Items.Insert(0, new ListItem("TODAS", "0"));
                ddlLocalidad.SelectedValue = "0";
                return;
            }
            LocalidadNegocio localidadNegocio = new LocalidadNegocio();
            List<KeyValuePair<int, string>> localidades = localidadNegocio.ListarClaveValor(idProvincia);

            ddlLocalidad.DataSource = localidades;
            ddlLocalidad.DataTextField = "Value"; // Nombre de la propiedad para mostrar (valor)
            ddlLocalidad.DataValueField = "Key"; // Nombre de la propiedad para el valor (clave)
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, new ListItem("TODAS", "0"));
            ddlLocalidad.SelectedValue = "0";
          
        }

        protected void ddlLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        protected void ddlEspecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        protected void ddlSexo_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }
    }
}