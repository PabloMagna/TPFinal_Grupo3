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

            if (Request.QueryString["ID"] == null)
            {
                Response.Redirect("default.aspx");
            }

            usuarioLogin = (Dominio.Usuario)Session["Usuario"];
            IDPublicacion = Convert.ToInt32(Request.QueryString["ID"]);


            if (!IsPostBack)
            {
                if (ObtenerEstadoPublicacion() == Dominio.Estado.Suspendida)
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
                    publicacionNego.ActualizarEstado(idPublicacion, Estado.Borrada);
                    adopcionNegocio.BajarAdopcionPorPublicacion(idPublicacion, EstadoAdopcion.Eliminada);
                    // Mostrar mensaje emergente de confirmación y redirigir a Perfil.aspx
                    ScriptManager.RegisterStartupScript(this, GetType(), "DeleteConfirmation", "alert('La publicación ha sido eliminada.'); window.location = 'Perfil.aspx';", true);
                    break;

                case "EliminarAdopcion":
                    publicacionNego.ActualizarEstado(idPublicacion, Estado.Finalizada);
                    adopcionNegocio.CompletarAdopcionPendiente(idPublicacion);
                    // Mostrar mensaje emergente de confirmación y redirigir a Perfil.aspx
                    ScriptManager.RegisterStartupScript(this, GetType(), "DeleteConfirmation", "alert('La adopción ha sido eliminada.'); window.location = 'Perfil.aspx';", true);
                    break;

                case "SuspenderPublicacion":
                    publicacionNego.ActualizarEstado(idPublicacion, Estado.Suspendida);
                    adopcionNegocio.BajarAdopcionPorPublicacion(idPublicacion, EstadoAdopcion.Rechazada);
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
            adopcionNegocio.BajarAdopcionPorPublicacion(idPublicacion, EstadoAdopcion.Rechazada);
            Response.Redirect(Request.RawUrl);
        }

        protected void btn_expandir_Click1(object sender, EventArgs e)
        {
            formularioH.Style["display"] = "block";
        }
    }
}