﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Final
{
    public partial class BorrarPublicacion : System.Web.UI.Page
    {
        protected Usuario usuarioLogin { set; get; }
        protected int IDPublicacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Requiere inicio de sesión
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            PublicacionNegocio negocio = new PublicacionNegocio();
            if (Request.QueryString["ID"] == null)
            {
                Response.Redirect("default.aspx");
            }
            //verifica que sea dueño de la publicacion el usuario
            else if (!negocio.EsPublicacionDelUsuario(int.Parse(Request.QueryString["ID"]), ((Usuario)Session["Usuario"]).Id))
            {
                Response.Redirect("Perfil.aspx");
            }

            usuarioLogin = (Dominio.Usuario)Session["Usuario"];
            IDPublicacion = Convert.ToInt32(Request.QueryString["ID"]);


            if (!IsPostBack)
            {
                if (ObtenerEstadoPublicacion() == Dominio.Estado.Pausada)
                {
                    mensajeSuspendido.Visible = true;
                }
                else if (ObtenerEstadoPublicacion() == Estado.Activa)
                {
                    btnActivar.Style["display"] = "none";
                    mensajeSuspendido.Visible = false;
                }
                else
                {
                    Response.Redirect("default.aspx");
                }
            }
        }

        protected void btnConfirmarAccion_Click(object sender, EventArgs e)
        {
            string opcionSeleccionada = rbOpcionesBaja.SelectedValue;
            PublicacionNegocio publicacionNego = new PublicacionNegocio();
            AdopcionNegocio adopcionNegocio = new AdopcionNegocio();
            int idPublicacion = int.Parse(Request.QueryString["ID"]);

            switch (opcionSeleccionada)
            {
                case "EliminarPublicacion":
                    publicacionNego.ActualizarEstado(idPublicacion, Estado.BorradaPorUsuario);
                    adopcionNegocio.BajarAdopcionPorPublicacion(idPublicacion, EstadoAdopcion.PublicacionBorrada);
                    // Mostrar mensaje emergente de confirmación y redirigir a Perfil.aspx
                    ScriptManager.RegisterStartupScript(this, GetType(), "DeleteConfirmation", "alert('La publicación ha sido eliminada.'); window.location = 'Perfil.aspx';", true);
                    break;

                case "EliminarAdopcion":
                    publicacionNego.ActualizarEstado(idPublicacion, Estado.FinalizadaConExito);
                    adopcionNegocio.CompletarAdopcionPendiente(idPublicacion);
                    // Mostrar mensaje emergente de confirmación y redirigir a Perfil.aspx
                    ScriptManager.RegisterStartupScript(this, GetType(), "DeleteConfirmation", "alert('La adopción ha sido eliminada.'); window.location = 'Perfil.aspx';", true);
                    break;

                case "SuspenderPublicacion":
                    publicacionNego.ActualizarEstado(idPublicacion, Estado.Pausada);
                    adopcionNegocio.BajarAdopcionPorPublicacion(idPublicacion, EstadoAdopcion.PublicacionBorrada);
                    // Mostrar mensaje de suspensión y actualizar la misma página
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuspensionMessage", "alert('La publicación ha sido suspendida.'); window.location = 'Perfil.aspx';", true);
                    break;

                default:
                    // Opción no válida
                    // ...
                    break;
            }

            FormBorrarPublicacion.Visible = false;
        }


        public Estado ObtenerEstadoPublicacion()
        {
            PublicacionNegocio publicacionNegocio = new PublicacionNegocio();
            Publicacion publicacion = publicacionNegocio.ObtenerPorId(int.Parse(Request.QueryString["ID"]));
            return publicacion.Estado;
        }

        protected void btnActivar_Click(object sender, EventArgs e)
        {
            int idPublicacion = int.Parse(Request.QueryString["ID"]);
            PublicacionNegocio publicacionNegocio = new PublicacionNegocio();
            AdopcionNegocio adopcionNegocio = new AdopcionNegocio();
            publicacionNegocio.ActualizarEstado(idPublicacion, Estado.Activa);
            adopcionNegocio.BajarAdopcionPorPublicacion(idPublicacion, EstadoAdopcion.EliminadaPorAdoptante);
            Response.Redirect(Request.RawUrl);
        }

        protected void btn_expandir_Click1(object sender, EventArgs e)
        {
            formularioH.Style["display"] = "block";
        }
    }
}