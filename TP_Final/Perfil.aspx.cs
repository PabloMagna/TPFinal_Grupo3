﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TP_Final
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected List<Publicacion> publicaciones;
        protected List<Historias> historias;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                PublicacionNegocio publiNegocio = new PublicacionNegocio(); 
                Usuario usuario = (Usuario)Session["Usuario"];


                if (!IsPostBack)
                {
                    publicaciones=publiNegocio.ListarPorUsuario(usuario.Id);
                    //cargar historias
                    //cargar abm de perfil
                }
            }
            else { Response.Redirect("/default.aspx"); }
        }

        public string obtenerPrimeraImagen(int idPublicacion)
        {
            List<ImagenMascota> lista = new List<ImagenMascota>();
            ImagenMascotaNegocio negocio = new ImagenMascotaNegocio();
            lista = negocio.listar(idPublicacion);

            if (lista != null && lista.Count > 0 && !string.IsNullOrEmpty(lista[0].urlImagen))
            {
                return lista[0].urlImagen;
            }
            else
            {
                return "https://g.petango.com/shared/Photo-Not-Available-dog.gif";
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }
    }
}