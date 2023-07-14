using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Final
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string GetUserName()
        {
            string username = "";
            if (Session["Usuario"] != null)
            {
                Dominio.Usuario Mailusuario = (Dominio.Usuario)Session["Usuario"];
                string buscar = @"^(.*?)@";
                Regex regex = new Regex(buscar);
                Match encontrado = regex.Match(Mailusuario.Email);

                if (encontrado.Success)
                {
                    for (int i = 0; i < encontrado.Length - 1; i++)
                    {
                        username += Mailusuario.Email[i];
                    }
                }
            }
            return username;
        }
        public string ObtenerUrl()
        {
            Usuario usuario = (Usuario)Session["Usuario"];
            PersonaNegocio negocio = new PersonaNegocio();
            if (usuario.Tipo == TipoUsuario.PersonaCompleto)
            {
                Persona persona = negocio.BuscarporUsuario(usuario.Id);
                return persona.UrlImagen;
            }
            else if (usuario.Tipo == TipoUsuario.Refugio)
            {
                RefugioNegocio negociorefugio = new RefugioNegocio();
                Refugio refugio = negociorefugio.BuscarporUsuario(usuario.Id);
                return refugio.UrlImagen;
            }
            else
            {
                return "https://img.freepik.com/vector-premium/historieta-divertida-cara-perrito-beagle_42750-489.jpg?w=2000";
            }

        }
    }
}