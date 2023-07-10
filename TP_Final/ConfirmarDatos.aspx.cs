﻿using System;
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
            //Requiere inicio de sesión
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            //Requiere ID de publicación como parámetro
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
            // Validar los campos
            if (ValidarCampos())
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
                    persona.FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text + " 00:00");
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
                    persona.FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text + " 00:00");
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
                PublicacionNegocio publicacionNeg = new PublicacionNegocio();
                if (adopcionNegocio.EnDataBase(IdUsuario, idPublicacion))
                {
                    adopcionNegocio.ActualizarEstado(IdUsuario, idPublicacion, EstadoAdopcion.Pendiente);
                }
                else
                {
                    adopcionNegocio.Insertar(IdUsuario, idPublicacion);
                }
                publicacionNeg.ActualizarEstado(idPublicacion, Estado.EnProceso);
                Response.Redirect("ContactoAdopcion.aspx?ID=" + idPublicacion);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtDni.Text) || txtDni.Text.Length < 6 || txtDni.Text.Length > 7)
            {
                MostrarError("El DNI debe tener entre 6 y 7 caracteres.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text) || txtNombre.Text.Length < 2)
            {
                MostrarError("El nombre debe tener al menos 2 caracteres.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text) || txtApellido.Text.Length < 2)
            {
                MostrarError("El apellido debe tener al menos 2 caracteres.");
                return false;
            }

            DateTime fechaNacimiento;
            if (!DateTime.TryParse(txtFechaNacimiento.Text, out fechaNacimiento))
            {
                MostrarError("La fecha de nacimiento no es válida.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text) || txtTelefono.Text.Length < 10 || txtTelefono.Text.Length > 20)
            {
                MostrarError("El teléfono debe tener entre 10 y 20 caracteres.");
                return false;
            }

            if (ddlProvincia.SelectedIndex <= 0)
            {
                MostrarError("Debes seleccionar una provincia.");
                return false;
            }

            if (ddlLocalidad.SelectedIndex <= 0)
            {
                MostrarError("Debes seleccionar una localidad.");
                return false;
            }

            return true;
        }

        private void MostrarError(string mensaje)
        {
            lblMessage.InnerText = mensaje;
            lblMessage.Visible = true;
        }

    }
}
