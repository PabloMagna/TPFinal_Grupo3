using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TP_Final
{
    public partial class ConfirmarDatos : System.Web.UI.Page
    {
        protected Usuario usuario;
        protected Persona persona;
        protected int idProvinciaPreseleccionada;
        protected int idLocalidadPreseleccionada;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Requiere inicio de sesión
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            // Requiere ID de publicación como parámetro
            if (Request.QueryString["ID"] == null)
            {
                Response.Redirect("Galeria.aspx");
            }
            if (!IsPostBack)
            {
                CargarUsuario();
                CargarDatosPersona();
                CargarProvinciaYLocalidadPreseleccionadas();
            }
        }

        private void CargarUsuario()
        {
            // Obtener el usuario de la sesión
            usuario = (Usuario)Session["Usuario"];
        }

        private void CargarDatosPersona()
        {
            if (usuario != null)
            {
                PersonaNegocio personaNegocio = new PersonaNegocio();
                persona = personaNegocio.BuscarporUsuario(usuario.Id);

                if (persona != null)
                {
                    // Se encontraron los datos de la persona, completar los controles
                    txtDni.Text = persona.Dni.ToString();
                    txtNombre.Text = persona.Nombre;
                    txtApellido.Text = persona.Apellido;
                    txtFechaNacimiento.Text = persona.FechaNacimiento.ToString("yyyy-MM-dd");

                    txtTelefono.Text = persona.Telefono;
                }
            }
        }

        private void CargarProvinciaYLocalidadPreseleccionadas()
        {
            PersonaNegocio negocio = new PersonaNegocio();

            persona = negocio.BuscarporUsuario(((Usuario)Session["Usuario"]).Id);
            if (persona != null)
            {
                idProvinciaPreseleccionada = persona.IDProvincia;
                idLocalidadPreseleccionada = persona.IDLocalidad;
            }
            else
            {
                idProvinciaPreseleccionada = 1;
                idLocalidadPreseleccionada = 1;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            ddlProvincia.SelectedIndexChanged += ddlProvincia_SelectedIndexChanged;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDropDownListProvincia();
                CargarDropDownListLocalidad(idProvinciaPreseleccionada);
            }
        }

        private void CargarDropDownListProvincia()
        {
            ProvinciaNegocio provinciaNegocio = new ProvinciaNegocio();
            List<KeyValuePair<int, string>> provincias = provinciaNegocio.ListarClaveValor();
            ddlProvincia.DataSource = provincias;
            ddlProvincia.DataTextField = "Value";
            ddlProvincia.DataValueField = "Key";
            ddlProvincia.DataBind();

            // Obtener el índice de la provincia preseleccionada
            int index = idProvinciaPreseleccionada - 1;
            if (index >= 0 && index < ddlProvincia.Items.Count)
            {
                ddlProvincia.SelectedIndex = index;
            }
        }

        private void CargarDropDownListLocalidad(int idProvincia)
        {
            LocalidadNegocio localidadNegocio = new LocalidadNegocio();
            List<KeyValuePair<int, string>> localidades = localidadNegocio.ListarClaveValor(idProvincia);
            ddlLocalidad.DataSource = localidades;
            ddlLocalidad.DataTextField = "Value";
            ddlLocalidad.DataValueField = "Key";
            ddlLocalidad.DataBind();

            // Obtener el índice de la localidad preseleccionada
            int index = idLocalidadPreseleccionada - 1;
            if (index >= 0 && index < ddlLocalidad.Items.Count)
            {
                ddlLocalidad.SelectedIndex = index;
            }
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProvincia = Convert.ToInt32(ddlProvincia.SelectedValue);
            CargarDropDownListLocalidad(idProvincia);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            PersonaNegocio personaNegocio = new PersonaNegocio();
            usuario = (Usuario)Session["Usuario"];
            persona = personaNegocio.BuscarporUsuario(usuario.Id);
            int idUsuario = usuario.Id;
            Page.Validate("Validaciones");
            if (Page.IsValid)
            {
                if (persona == null)
                {
                    // Persona es null, realizar inserción
                    persona = new Persona();
                    persona.IDUsuario = usuario.Id;
                    persona.Dni = Convert.ToInt32(txtDni.Text);
                    persona.Nombre = txtNombre.Text;
                    persona.Apellido = txtApellido.Text;
                    persona.FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text + " 00:00");
                    persona.Telefono = txtTelefono.Text;
                    persona.IDLocalidad = Convert.ToInt32(ddlLocalidad.SelectedValue);
                    persona.IDProvincia = Convert.ToInt32(ddlProvincia.SelectedValue);
                    persona.IDUsuario = idUsuario;

                    // Establecer el valor del parámetro @UrlImagen como cadena vacía
                    persona.UrlImagen = "";

                    personaNegocio.Agregar(persona);
                    UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                    usuarioNegocio.ActualizarTipo(idUsuario, TipoUsuario.PersonaCompleto);

                }
                else
                {
                    // Persona no es null, realizar modificación
                    persona.Dni = Convert.ToInt32(txtDni.Text);
                    persona.Nombre = txtNombre.Text;
                    persona.Apellido = txtApellido.Text;
                    persona.FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text + " 00:00");
                    persona.Telefono = txtTelefono.Text;
                    persona.IDLocalidad = Convert.ToInt32(ddlLocalidad.SelectedValue);
                    persona.IDProvincia = Convert.ToInt32(ddlProvincia.SelectedValue);
                    persona.IDUsuario = idUsuario;
                    // Verificar si la UrlImagen es nula antes de establecer el valor del parámetro
                    if (persona.UrlImagen == null)
                    {
                        // Establecer el valor del parámetro @UrlImagen
                        persona.UrlImagen = ""; // Puedes asignar otro valor si es necesario
                    }

                    personaNegocio.Modificar(persona);
                }

                int idPublicacion = Convert.ToInt32(Request["ID"]);
                AdopcionNegocio adopcionNegocio = new AdopcionNegocio();
                PublicacionNegocio publicacionNeg = new PublicacionNegocio();
                if (adopcionNegocio.EnDataBase(idUsuario, idPublicacion))
                {
                    adopcionNegocio.ActualizarEstado(idUsuario, idPublicacion, EstadoAdopcion.Pendiente);
                }
                else
                {
                    adopcionNegocio.Insertar(idUsuario, idPublicacion, null);
                }
                publicacionNeg.ActualizarEstado(idPublicacion, Estado.EnProceso);

                EnviarCorreoAdopcion(usuario.Email, idPublicacion);
                EnviarCorreoDonante(idPublicacion, usuario.Id);
                Response.Redirect("ContactoAdopcion.aspx?ID=" + idPublicacion);
            }
        }

        private void EnviarCorreoAdopcion(string emailUsuario, int idPublicacion)
        {
            // Obtener la información de la publicación
            PublicacionNegocio publicacionNegocio = new PublicacionNegocio();
            Publicacion publicacion = publicacionNegocio.ObtenerPorId(idPublicacion);

            // Obtener los datos del donante
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Usuario donante = usuarioNegocio.BuscarxID(publicacion.IdUsuario);
            string donanteInfo = "";

            if (donante != null)
            {
                if (donante.Tipo == TipoUsuario.PersonaCompleto)
                {
                    PersonaNegocio personaNegocio = new PersonaNegocio();
                    Persona persona = personaNegocio.BuscarporUsuario(donante.Id);
                    if (persona != null)
                    {
                        string perfilPublicoUrl = GetAbsoluteUrl($"PerfilPublico.aspx?ID={donante.Id}");
                        donanteInfo = $"<div style=\"font-family: Arial, sans-serif; text-align: center;\">" +
                                      $"<div style=\"background-color: #f2f2f2; border: 1px solid #ccc; padding: 20px;\">" +
                                      $"<h2>¡Mandamos tu solicitud de Adopción!</h2>" +
                                      $"<h3>Detalles de la adopción:</h3>" +
                                      $"<strong>Publicación:</strong> {publicacion.Titulo}<br>" +
                                      $"<strong>Donante</strong><br>" +
                                      $"<strong>Nombre:</strong> {persona.Nombre} {persona.Apellido}<br>" +
                                      $"<strong>Email:</strong> {donante.Email}<br>" +
                                      $"<strong>Teléfono:</strong> {persona.Telefono}<br>" +
                                      $"<a href=\"{perfilPublicoUrl}\">Ver Perfil Público con Historial</a>" +
                                      $"</div></div>";
                    }
                }
                else if (donante.Tipo == TipoUsuario.Refugio)
                {
                    RefugioNegocio refugioNegocio = new RefugioNegocio();
                    Refugio refugio = refugioNegocio.BuscarporUsuario(donante.Id);
                    if (refugio != null)
                    {
                        string perfilPublicoUrl = GetAbsoluteUrl($"PerfilPublico.aspx?ID={donante.Id}");
                        donanteInfo = $"<div style=\"font-family: Arial, sans-serif; text-align: center;\">" +
                                      $"<div style=\"background-color: #f2f2f2; border: 1px solid #ccc; padding: 20px;\">" +
                                      $"<h2>¡Mandamos tu solicitud de Adopción!</h2>" +
                                      $"<h3>Detalles de la adopción:</h3>" +
                                      $"<strong>Publicación:</strong> {publicacion.Titulo}<br>" +
                                      $"<strong>Donante:</strong> {refugio.Nombre}<br>" +
                                      $"<strong>Email:</strong> {donante.Email}<br>" +
                                      $"<strong>Teléfono:</strong> {refugio.Telefono}<br>" +
                                      $"<strong>Dirección:</strong> {refugio.Direccion}<br>" +
                                      $"<a href=\"{perfilPublicoUrl}\">Ver Perfil Público con Historial</a>" +
                                      $"</div></div>";
                    }
                }
            }

            // Crear el cuerpo del correo electrónico en formato HTML
            string body = $"<html><body>" +
                          $"{donanteInfo}" +
                          $"</body></html>";

            // Enviar el correo electrónico
            EmailSender emailSender = new EmailSender();
            emailSender.SendEmail(emailUsuario, "PetNet", "Tu solicitud de adopción fue enviada", body);
        }


        private void EnviarCorreoDonante(int idPublicacion, int idUsuarioAdoptante)
        {
            // Obtener los datos del adoptante
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Usuario adoptante = usuarioNegocio.BuscarxID(idUsuarioAdoptante);
            string adoptanteInfo = "";

            if (adoptante != null)
            {
                PersonaNegocio personaNegocio = new PersonaNegocio();
                Persona persona = personaNegocio.BuscarporUsuario(adoptante.Id);
                if (persona != null)
                {
                    string perfilPublicoUrl = GetAbsoluteUrl($"PerfilPublico.aspx?ID={adoptante.Id}");
                    adoptanteInfo = $"<div style=\"font-family: Arial, sans-serif; text-align: center;\">" +
                                    $"<div style=\"background-color: #f2f2f2; border: 1px solid #ccc; padding: 20px;\">" +
                                    $"<h2>¡Hay un Interesado en tu Mascota!</h2>" +
                                    $"<h3>Detalles de la adopción:</h3>" +
                                    $"<strong>Adoptante:</strong> {persona.Nombre} {persona.Apellido}<br>" +
                                    $"<strong>Email:</strong> {adoptante.Email}<br>" +
                                    $"<strong>Teléfono:</strong> {persona.Telefono}<br>" +
                                    $"<a href=\"{perfilPublicoUrl}\">Ver Perfil Público con Historial</a>" +
                                    $"</div></div>";
                }
            }

            // Crear el cuerpo del correo electrónico en formato HTML
            string body = $"<html><body>" +
                          $"{adoptanteInfo}" +
                          $"</body></html>";

            // Obtener el correo electrónico del donante
            PublicacionNegocio publicacionNegocio = new PublicacionNegocio();
            int idUsuarioDonante = publicacionNegocio.BuscarIdUsuario(idPublicacion);
            Usuario donante = usuarioNegocio.BuscarxID(idUsuarioDonante);

            if (donante != null)
            {
                // Enviar el correo electrónico
                EmailSender emailSender = new EmailSender();
                emailSender.SendEmail(donante.Email, "PetNet", "Tu publicación tiene un Interesado", body);
            }
        }



        protected void cvProvincia_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Comprueba si se seleccionó una provincia en el ddl de provincia.
            args.IsValid = (ddlProvincia.SelectedIndex >= 0);
        }

        protected void cvLocalidad_ServerValidate(Object source, ServerValidateEventArgs args)
        {
            args.IsValid = (ddlLocalidad.SelectedValue != "");
        }

        protected void cvFechaNac_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime fechaNacimiento;
            bool isValid = DateTime.TryParse(args.Value, out fechaNacimiento);

            if (isValid && fechaNacimiento.Year >= 1900)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        private string GetAbsoluteUrl(string relativeUrl)
        {
            var httpContext = HttpContext.Current;
            if (httpContext != null)
            {
                var request = httpContext.Request;
                var baseUrl = request.Url.Scheme + "://" + request.Url.Authority + request.ApplicationPath.TrimEnd('/');
                return new Uri(new Uri(baseUrl), relativeUrl).AbsoluteUri;
            }
            return relativeUrl;
        }
    }
}
