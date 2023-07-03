using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TP_Final
{
    public partial class ConfirmarDatos : System.Web.UI.Page
    {
        protected Usuario usuario = new Usuario();
        protected Persona persona = new Persona();
        protected int idProvinciaPreseleccionada;
        protected int idLocalidadPreseleccionada;

        protected void Page_Load(object sender, EventArgs e)
        {
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
            if (persona != null)
            {
                idProvinciaPreseleccionada = persona.IDProvincia;
                idLocalidadPreseleccionada = persona.IDLocalidad;
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
            int IdUsuario = ((Usuario)Session["Usuario"]).Id;

            if (persona == null)
            {
                // Persona es null, realizar inserción
                persona = new Persona();
                persona.IDUsuario = usuario.Id;
                persona.Dni = Convert.ToInt32(txtDni.Text);
                persona.Nombre = txtNombre.Text;
                persona.Apellido = txtApellido.Text;
                persona.FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
                persona.Telefono = txtTelefono.Text;
                persona.IDLocalidad = Convert.ToInt32(ddlLocalidad.SelectedValue);
                persona.IDProvincia = Convert.ToInt32(ddlProvincia.SelectedValue);
                persona.IDUsuario = IdUsuario;

                // Establecer el valor del parámetro @UrlImagen como cadena vacía
                persona.UrlImagen = "";

                personaNegocio.Agregar(persona);
            }
            else
            {
                // Persona no es null, realizar modificación
                persona.Dni = Convert.ToInt32(txtDni.Text);
                persona.Nombre = txtNombre.Text;
                persona.Apellido = txtApellido.Text;
                persona.FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
                persona.Telefono = txtTelefono.Text;
                persona.IDLocalidad = Convert.ToInt32(ddlLocalidad.SelectedValue);
                persona.IDProvincia = Convert.ToInt32(ddlProvincia.SelectedValue);
                persona.IDUsuario = IdUsuario;
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
            if (adopcionNegocio.EnDataBase(IdUsuario, idPublicacion))
            {
                adopcionNegocio.ActualizarEstado(IdUsuario, idPublicacion, EstadoAdopcion.Pendiente);
            }
            else
            {
                adopcionNegocio.Insertar(IdUsuario, idPublicacion);
            }
            Response.Redirect("ContactoAdopcion.aspx?ID=" + idPublicacion);
        }

    }
}
