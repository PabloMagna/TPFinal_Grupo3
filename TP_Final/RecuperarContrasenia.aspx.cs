using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web.UI;
using Dominio;
using Negocio;

namespace TP_Final
{
    public partial class RecuperarContrasenia : Page
    {
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario usuario = negocio.BuscarPorEmail(email);

            if (usuario.Id > 0)
            {
                // Generar un token único para el enlace de recuperación
                string recoveryToken = GenerarToken();

                // Calcular la fecha de expiración del token (por ejemplo, 24 horas a partir de ahora)
                DateTime tokenExpiracion = DateTime.Now.AddHours(24);

                // Almacenar el token y su fecha de expiración en el objeto Usuario
                usuario.Token = recoveryToken;
                usuario.TokenExpiracion = tokenExpiracion;

                negocio.InsertarToken(usuario.Id, recoveryToken, tokenExpiracion);

                // Construir el enlace de recuperación de contraseña
                string recoveryLink = $"{Request.Url.Scheme}://{Request.Url.Authority}/ResetearContrasenia.aspx?email={email}&token={recoveryToken}";

                // Enviar un correo electrónico al usuario con el enlace de recuperación
                EnviarCorreoRecuperacion(email, recoveryLink);

                lblMessage.InnerText = "Se ha enviado un correo electrónico con las instrucciones para recuperar tu contraseña.";
               // lblMessage.CssClass = "alert alert-success";
                lblMessage.Visible = true;
            }
            else
            {
                lblMessage.InnerText = "La dirección de correo electrónico ingresada no está registrada.";
               // lblMessage.CssClass = "alert alert-danger";
                lblMessage.Visible = true;
            }
        }
        private void EnviarCorreoRecuperacion(string email, string recoveryLink)
        {
            // Configurar los detalles del correo electrónico
            string fromEmail = "PetNetNoResponder@gmail.com";
            string fromName = "PetNet";
            string subject = "Recuperación de Contraseña";
            string body = $"Hola,\n\nHaz clic en el siguiente enlace para restablecer tu contraseña:\n\n{recoveryLink} \n Tienes 24 horas para activarlo";

            // Crear el mensaje de correo electrónico
            MailMessage message = new MailMessage(new MailAddress(fromEmail, fromName), new MailAddress(email))
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = false
            };

            // Configurar el cliente SMTP para enviar el correo electrónico
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(fromEmail, "Programacion.3"),
                EnableSsl = true
            };

            // Enviar el correo electrónico
            smtpClient.Send(message);
        }


        private string GenerarToken()
        {
            // Generar un nuevo GUID
            Guid guid = Guid.NewGuid();

            // Convertir el GUID en una cadena de texto
            string token = guid.ToString();

            return token;
        }

    }
}
