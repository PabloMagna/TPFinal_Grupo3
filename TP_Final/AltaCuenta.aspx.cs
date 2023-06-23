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
                
                AccesoDatos datos = new AccesoDatos();
                Usuario usuario = new Usuario();
                usuario.Email = tbEmail.Text;
                usuario.Password = tbPassword.Text;

                LocalidadNegocio localidades = new LocalidadNegocio();
                ProvinciaNegocio provincias = new ProvinciaNegocio();
                int idLocalidad = localidades.BuscarId(ddlLocalidad.SelectedItem.ToString());
                int idProvincia = provincias.BuscarID(ddlProvincia.SelectedItem.ToString());

                datos.setearConsulta("INSERT INTO Usuarios (IDTipoUsuario, Contrasenia, Email,Estado,EsAdmin) OUTPUT INSERTED.IDUsuario "
                    + "VALUES (@IDTipoUsuario, @Password,@Email,@Estado,@EsAdmin)");
                datos.setearParametro("@IDTipoUsuario", usuario.Tipo);
                datos.setearParametro("@Password", usuario.Password);
                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Estado", usuario.Estado);
                datos.setearParametro("@EsAdmin", usuario.EsAdmin);
                datos.ejecutarAccion();

                int idUsuario = 0;
                if (datos.Lector.Read())
                {
                    idUsuario = Convert.ToInt32(datos.Lector["IDUsuario"]);
                }
                datos.cerrarConexion();


                if (cuenta == "Persona") {

                    Persona persona = new Persona();
                    persona.IDUsuario = idUsuario;
                    persona.Nombre = tbNombre.Text;
                    persona.Apellido = tbApellido.Text;
                    persona.Dni = tbDni.Text;
                    persona.FechaNacimiento = DateTime.Parse(tbFechaNac.Text);
                    persona.IDProvincia = idProvincia;
                    persona.IDLocalidad = idLocalidad;
                    persona.UrlImagen = "";
                    persona.Telefono = tbTelefono.Text;
                    // Insertar en la tabla Personas
                    datos.setearConsulta("INSERT INTO Personas (IDUsuario,Dni,Nombre, Apellido, FechaNacimiento, UrlImagen, IDLocalidad, IDProvincia, Telefono) "
                        + "VALUES (@IDUsuario,@Dni,@Nombre, @Apellido,@FechaNacimiento, @UrlImagen, @IDLocalidad, @IDProvincia, @Telefono)");
                    datos.setearParametro("@IDUsuario", idUsuario);
                    datos.setearParametro("@Dni", persona.Dni);
                    datos.setearParametro("@Nombre", persona.Nombre);
                    datos.setearParametro("@Apellido", persona.Apellido);
                    datos.setearParametro("@FechaNacimiento", persona.FechaNacimiento);
                    datos.setearParametro("@UrlImagen", persona.UrlImagen);
                    datos.setearParametro("@IDLocalidad", persona.IDLocalidad);
                    datos.setearParametro("@IDProvincia", persona.IDProvincia);
                    datos.setearParametro("@Telefono", persona.Telefono);
                  
                    datos.ejecutarAccion();
                    datos.cerrarConexion();
                }
                else
                {
                    //Refugio
                }
                
  
                // Realizar cualquier otra acción necesaria o mostrar un mensaje de éxito
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

    
    }
}