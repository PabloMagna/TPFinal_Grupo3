using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace TP_Final
{
    public partial class Site1 : System.Web.UI.MasterPage
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

        public void btnsalir_Click(object sender, EventArgs e)
        {
            Session.Remove("Usuario");
            Response.Redirect("default.aspx");
        }

        public void btnperfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx");
        }
    }
    
}