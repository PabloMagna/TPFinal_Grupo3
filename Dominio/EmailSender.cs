using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class EmailSender
    {
        private const string SmtpHost = "smtp.gmail.com";
        private const int SmtpPort = 587;
        private const string SmtpUsername = "PetNetNoResponder@gmail.com";
        private const string SmtpPassword = "urimyhukiycpxxap";

        public void SendEmail(string toEmail, string toName, string subject, string body)
        {
            try
            {
                // Configurar los detalles del correo electrónico
                MailMessage message = new MailMessage(new MailAddress(SmtpUsername), new MailAddress(toEmail, toName))
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                // Configurar el cliente SMTP para enviar el correo electrónico
                SmtpClient smtpClient = new SmtpClient(SmtpHost, SmtpPort)
                {
                    Credentials = new NetworkCredential(SmtpUsername, SmtpPassword),
                    EnableSsl = true
                };

                // Enviar el correo electrónico
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EnviarCorreoRechazoAdopcion(string emailAdoptante, string motivoRechazo)
        {
            string asunto = "Adopción rechazada";
            string cuerpo = "<html><body>";
            cuerpo += "<h2>Adopción rechazada</h2>";
            cuerpo += "<p>El donante de la mascota ha rechazado tu adopción.</p>";
            cuerpo += "<p>Estas son las razones:</p>";
            cuerpo += "<p>" + motivoRechazo.Replace("\n", "<br>") + "</p>";
            cuerpo += "</body></html>";

            SendEmail(emailAdoptante, "", asunto, cuerpo);
        }


    }
}
