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
    public partial class PerfilPublico : System.Web.UI.Page
    {
        protected Usuario usuario;
        protected Persona persona;
        protected Refugio refugio;
        protected List<Adopcion> adopcionList;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            CargarUsuario();
            CargarPersonaORefugio();
            CargarAdopciones();

        }
        private void CargarUsuario()
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            usuario = usuarioNegocio.BuscarxID(int.Parse(Request.QueryString["ID"]));
        }
        private void CargarPersonaORefugio()
        {
            if(usuario.Tipo == TipoUsuario.PersonaCompleto || usuario.Tipo == TipoUsuario.Persona)
            {
                PersonaNegocio personaNegocio = new PersonaNegocio();
                persona = personaNegocio.BuscarporUsuario(usuario.Id);
            }
            else
            {
                RefugioNegocio refugioNegocio = new RefugioNegocio();
                refugio = refugioNegocio.BuscarporUsuario(usuario.Id);
            }
        }
        private void CargarAdopciones()
        {
            AdopcionNegocio adopcionNegocio = new AdopcionNegocio();
            adopcionList = adopcionNegocio.ListarPorUsuario(usuario.Id);
        }
    }
}