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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPublicacion();
                CargarUsuario();
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
            if(usuario.Tipo == TipoUsuario.PersonaCompleto)
            {
                PersonaNegocio personaNegocio = new PersonaNegocio();
                persona = personaNegocio.BuscarporUsuario(usuario.Id);

            }else if(usuario.Tipo == TipoUsuario.Refugio)
            {
                RefugioNegocio refugioNegocio = new RefugioNegocio();
                refugio = refugioNegocio.BuscarporUsuario(usuario.Id);

                 
            }
        }
    }
}