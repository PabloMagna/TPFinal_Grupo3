﻿using System;
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
                CargarDropDownListProvincias();
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
            PublicacionNegocio negocio = new PublicacionNegocio();
        }

        protected void btnRemoverFiltro_Click(object sender, EventArgs e)
        {
            PublicacionNegocio publiNegocio = new PublicacionNegocio();
            Session["Publicaciones"] = publiNegocio.Listar();
            Response.Redirect("galeria.aspx");
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