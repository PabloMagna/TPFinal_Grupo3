using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Final
{
    public partial class AltaCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
            ProvinciaNegocio provincias = new ProvinciaNegocio();
            LocalidadNegocio localidades = new LocalidadNegocio();
            string Cuenta = (string)Request.QueryString["Cuenta"];
            if (Cuenta == "Persona") {

                formRefugio.Visible = false;
                formPersona.Visible = true;
                rfvNombreRefugio.Enabled = false;
                rfvDireccion.Enabled = false;
                
            }
            else
            {
                formPersona.Visible = false;
                formRefugio.Visible = true;
                rfvApellido.Enabled = false;
                rfvNombre.Enabled = false;
                rfvFechaNac.Enabled = false;
                rfvDni.Enabled = false;
                revDni.Enabled = false;
            }

            if (!IsPostBack)
            {
                ddlProvincia.Items.Clear();
                ddlProvincia.DataSource = provincias.cargarDropDownList();
                ddlProvincia.DataBind();
                ddlProvincia.SelectedIndex = 0;

                ddlLocalidad.DataSource = localidades.CargarDropDownList(ddlProvincia.SelectedIndex);
                ddlLocalidad.DataBind();
                ddlLocalidad.SelectedIndex = 0;
            }
            
           
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocalidadNegocio localidades = new LocalidadNegocio();
            ddlLocalidad.DataSource = localidades.CargarDropDownList(ddlProvincia.SelectedIndex);
            ddlLocalidad.DataBind();
        }

        protected void cvProvincia_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //Comprueba si se seleccionó una provincia en el ddl de provincia.
            args.IsValid = (ddlProvincia.SelectedIndex!=0);
        }

        protected void cvLocalidad_ServerValidate(Object source, ServerValidateEventArgs args)
        {
            args.IsValid = (ddlLocalidad.SelectedIndex != 0);
        }

        protected void ddlLocalidad_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlLocalidad.Items.Clear();
                ddlLocalidad.Items.Add("Seleccionar");
                ddlLocalidad.SelectedIndex = 0;
            }
            
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            string cuenta = (string)Request.QueryString["Cuenta"];
            Page.Validate("Validaciones");
            if (Page.IsValid)
            {   //acciones a tomar si es valido el ingreso de datos
                int filasAfectadas = 0;
                AccesoDatos datos = new AccesoDatos();
                UsuarioNegocio usuarios = new UsuarioNegocio();
                Usuario usuario = new Usuario();
                usuario.Email = tbEmail.Text;
                usuario.Password = tbPassword.Text;
                usuario.Tipo = (TipoUsuario)Enum.Parse(typeof(TipoUsuario), cuenta);
                usuario.EsAdmin = false;
                usuario.Estado = EstadoUsuario.Activo;
                int idUsuario = usuarios.Agregar(usuario);

                LocalidadNegocio localidades = new LocalidadNegocio();
                ProvinciaNegocio provincias = new ProvinciaNegocio();
                int idLocalidad = localidades.BuscarId(ddlLocalidad.SelectedItem.ToString());
                int idProvincia = provincias.BuscarID(ddlProvincia.SelectedItem.ToString());

                if (cuenta == "Persona") {
                    PersonaNegocio personas = new PersonaNegocio();
                    Persona persona = new Persona();
                    persona.IDUsuario = idUsuario;
                    persona.Nombre = tbNombre.Text;
                    persona.Apellido = tbApellido.Text;
                    persona.Dni = int.Parse(tbDni.Text);
                    persona.FechaNacimiento = DateTime.Parse(tbFechaNac.Text);
                    persona.IDProvincia = idProvincia;
                    persona.IDLocalidad = idLocalidad;
                    persona.UrlImagen = "";
                    persona.Telefono = tbTelefono.Text;
                    // Insertar en DB
                    filasAfectadas=personas.Agregar(persona);
                }
                else
                {
                    //Refugio
                    Refugio refugio = new Refugio();
                    RefugioNegocio refugios = new RefugioNegocio();
                    refugio.IdUsuario = idUsuario;
                    refugio.Nombre = tbNombreRefugio.Text;
                    refugio.Direccion = tbDireccion.Text;
                    refugio.UrlImagen = "";
                    refugio.IDProvincia = idProvincia;
                    refugio.IDLocalidad = idLocalidad;
                    refugio.Telefono = tbTelefono.Text;
                    // Insertar en DB
                    filasAfectadas = refugios.Agregar(refugio);

                    if(filasAfectadas > 0)
                    {
                        //Alta De Refugio o Persona Exitoso
                        // Realizar cualquier otra acción necesaria o mostrar un mensaje de éxito
                        //Autologin
                    }
                }              
  
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

    
    }
}