using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using static System.Net.WebRequestMethods;

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
            }
        }
        public string obtenerPrimeraImagen(int idMascota)
        {
            List<ImagenMascota> lista = new List<ImagenMascota>();
            ImagenMascotaNegocio negocio = new ImagenMascotaNegocio();
            lista = negocio.listar(idMascota);
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

            ddlEspecies.SelectedValue = "1";
            // Cargar DropDownList de sexo
            ddlSexo.Items.Clear();
            ddlSexo.Items.Add(new ListItem("Hembra", "H"));
            ddlSexo.Items.Add(new ListItem("Macho", "M"));
            ddlSexo.Items.Add(new ListItem("Desconocido", "D"));

            ddlSexo.SelectedValue = "D";
            // Cargar DropDownList de mes y año
            // Aquí debes implementar la lógica para cargar el DropDownList de mes y año
            ddlMesAnio.Items.Clear();
            ddlMesAnio.Items.Add(new ListItem("Año/s", "A"));
            ddlMesAnio.Items.Add(new ListItem("Mes/es", "M"));
            ddlMesAnio.SelectedValue = "A";

            txtEdad.Text = "1";
        }
        private void Filtrar()
        {
            MascotaNegocio  mascotaNegocio = new MascotaNegocio();
            int meses = 0;
            if (ddlMesAnio.SelectedValue == "M")
                meses = int.Parse(txtEdad.Text);          
            else if (ddlMesAnio.SelectedValue == "A")           
                meses = int.Parse(txtEdad.Text) * 12;
                     
            List<int> ints = mascotaNegocio.Filtrar(ddlSexo.SelectedValue[0],int.Parse(ddlEspecies.SelectedValue)
                , meses, txtRaza.Text );
            PublicacionNegocio publiNegocio = new PublicacionNegocio();
            Session["Publicaciones"] = null;
            Session["Publicaciones"] = publiNegocio.Listar(ints);
        }

        protected void btnRemoverFiltro_Click(object sender, EventArgs e)
        {
            PublicacionNegocio publiNegocio = new PublicacionNegocio();
            Session["Publicaciones"] = publiNegocio.Listar();
            Response.Redirect("galeria.aspx");
        }
    }
}