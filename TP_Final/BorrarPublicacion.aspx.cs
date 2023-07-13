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
                else
                {
                    mensajeSuspendido.Visible = false;                   
                }
                mensajeConformacion.Visible = false;
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
                    //mensaje
                    break;
                case "EliminarAdopcion":
                    publicacionNego.ActualizarEstado(idPublicacion, Estado.Finalizada);
                    adopcionNegocio.CompletarAdopcionPendiente(idPublicacion);
                    //mensaje
                    break;
                case "SuspenderPublicacion":
                    publicacionNego.ActualizarEstado(idPublicacion, Estado.Suspendida);
                    adopcionNegocio.BajarAdopcionPorPublicacion(idPublicacion, EstadoAdopcion.Rechazada);
                    // ...
                    break;
                default:
                    // Opción no válida
                    // ...
                    break;
                                    
            }
            FormBorrarPublicacion.Visible = false;
            mensajeConformacion.Visible = true;
        }
        /*
        protected void btn_expandir_Click(object sender, EventArgs e)
        {
            formularioH.Style["display"] = "block"; // Mostrar el formularioH estableciendo su estilo a "block"
        }
        */

        public Estado ObtenerEstadoPublicacion()
        {
            PublicacionNegocio publicacionNegocio = new PublicacionNegocio();
            Publicacion publicacion = publicacionNegocio.ObtenerPorId(int.Parse(Request.QueryString["ID"]));
            return publicacion.Estado;
        }
    }
}