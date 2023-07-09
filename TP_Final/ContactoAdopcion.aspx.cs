using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TP_Final
{
    public partial class ContactoAdopcion : System.Web.UI.Page
    {
        protected Publicacion publicacion = new Publicacion();
        protected Usuario usuario = new Usuario();
        protected Persona persona = new Persona();
        protected Refugio refugio = new Refugio();
        protected string provincia;
        protected string localidad;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if(Request.QueryString["ID"] == null)
            {
                Response.Redirect("Default.aspx");
            }

            if (!IsPostBack)
            {
                CargarPublicacion();
                CargarUsuario();
                CargarProvinciaYLocalidad();
            }
        }

        private void CargarPublicacion()
        {
            PublicacionNegocio publicacionNegocio = new PublicacionNegocio();
            publicacion = publicacionNegocio.ObtenerPorId(Convert.ToInt32(Request.QueryString["ID"]));
        }

        private void CargarUsuario()
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            usuario = usuarioNegocio.BuscarxID(publicacion.IdUsuario);
            if (usuario.Tipo == TipoUsuario.PersonaCompleto)
            {
                PersonaNegocio personaNegocio = new PersonaNegocio();
                persona = personaNegocio.BuscarporUsuario(usuario.Id);
            }
            else if (usuario.Tipo == TipoUsuario.Refugio)
            {
                RefugioNegocio refugioNegocio = new RefugioNegocio();
                refugio = refugioNegocio.BuscarporUsuario(usuario.Id);
            }
        }

        private void CargarProvinciaYLocalidad()
        {
            ProvinciaNegocio provinciaNegocio = new ProvinciaNegocio();
            LocalidadNegocio localidadNegocio = new LocalidadNegocio();

            if (usuario.Tipo == TipoUsuario.PersonaCompleto)
            {
                provincia = provinciaNegocio.ObtenerNombrePorId(persona.IDProvincia);
                localidad = localidadNegocio.ObtnerNombrePorID(persona.IDLocalidad);
            }
            else if (usuario.Tipo == TipoUsuario.Refugio)
            {
                provincia = provinciaNegocio.ObtenerNombrePorId(refugio.IDProvincia);
                localidad = localidadNegocio.ObtnerNombrePorID(refugio.IDLocalidad);
            }
        }
    }
}
