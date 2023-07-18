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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
                lblLogueado.Visible = true;
        }

        protected void btnInicioSesion_Click(object sender, EventArgs e)
        {
            string contrasenia = tbxContrasenia.Text;
            string email = tbxEmail.Text;

            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario usuario = negocio.Login(contrasenia, email);
            if(usuario != null)
            {
                if(usuario.Estado == EstadoUsuario.EliminadoPorUsuario)
                {
                    lblLogueado.Text = "Usuario Eliminado";
                    lblLogueado.Visible = true;
                }else if(usuario.Estado == EstadoUsuario.EliminadoPorAdmin)
                {
                    lblLogueado.Text = "Usuario Baneado por Admin";
                    lblLogueado.Visible = true;
                }
                else
                {
                    Session["Usuario"] = usuario;
                    Response.Redirect("default.aspx");
                }             
            }
            else
            {
                lblLogueado.Text = "Usuario o contraseña incorrectos";
                lblLogueado.Visible = true;
            }
        }
    }
}