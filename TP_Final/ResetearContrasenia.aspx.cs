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
    public partial class ResetearContrasenia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Request.QueryString["email"];
            string token = Request.QueryString["token"];

            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario usuario = negocio.BuscarPorEmail(email);

            if (usuario == null || usuario.Token != token || usuario.TokenExpiracion <= DateTime.Now)
            {
                lblMessage.InnerText = "No estás autorizado a esta página.";
                lblMessage.Visible = true;

                txtNewPassword.Visible = false;
                txtConfirmPassword.Visible = false;
                btnChangePassword.Visible = false;
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            string email = Request.QueryString["email"];
            string token = Request.QueryString["token"];
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Verificar si el token y la fecha de expiración son válidos
            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario usuario = negocio.BuscarPorEmail(email);

            if (usuario != null && usuario.Token == token && usuario.TokenExpiracion > DateTime.Now)
            {
                if (newPassword.Length >= 8 && confirmPassword.Length >= 8)
                {
                    if (newPassword == confirmPassword)
                    {
                        // Cambiar la contraseña del usuario
                        negocio.CambiarContrasenia(usuario.Id, newPassword);

                        // Restablecer el token y la fecha de expiración a null
                        negocio.ActualizarToken(usuario.Id, null, null);

                        // Mostrar un mensaje emergente (popup) en el cliente
                        string script = "alert('Contraseña cambiada correctamente.'); window.location.href = 'Default.aspx';";
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessMessage", script, true);
                    }
                    else
                    {
                        lblMessage.InnerText = "Las contraseñas no coinciden.";
                        lblMessage.Visible = true;
                    }
                }
                else
                {
                    lblMessage.InnerText = "La contraseña debe tener al menos 8 caracteres.";
                    lblMessage.Visible = true;
                }
            }
            else
            {
                lblMessage.InnerText = "No estás autorizado a esta página - Token expirado";
                lblMessage.Visible = true;
            }
        }
    }
}