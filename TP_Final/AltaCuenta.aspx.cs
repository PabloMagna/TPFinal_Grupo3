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
        protected Usuario usuario { get; set; }
        protected string Cuenta { get; set; }   
        protected void Page_Load(object sender, EventArgs e)
        {               
            ProvinciaNegocio provincias = new ProvinciaNegocio();
            LocalidadNegocio localidades = new LocalidadNegocio();
            Cuenta = (string)Request.QueryString["Cuenta"];
            if (Cuenta == "Persona") {

                formRefugio.Visible = false;
                rfvNombreRefugio.Enabled = false;
                rfvDireccion.Enabled = false;
                cvLocalidad.Enabled = false;
                cvProvincia.Enabled = false;
                rfvTelefono.Enabled = false;
            }
            else
            {
                formRefugio.Visible = true;
                //*
                rfvNombreRefugio.Enabled = true;
                rfvDireccion.Enabled = true;
            }

            if (!IsPostBack)
            {
                usuario = new Usuario();
                if (Cuenta == "Refugio")
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
            int filasAfectadas = 0;

            Page.Validate("Validaciones");
            if (Page.IsValid)
            {   //acciones a tomar si es valido el ingreso de datos
                AccesoDatos datos = new AccesoDatos();
                UsuarioNegocio usuarios = new UsuarioNegocio();
                usuario = new Usuario();
                int idUsuario=0;

                if (cuenta == "Persona")
                {
                    usuario.Email = tbEmail.Text;
                    usuario.Password = tbPassword.Text;
                    usuario.Tipo = TipoUsuario.Persona;
                    usuario.EsAdmin = false;
                    usuario.Estado = EstadoUsuario.Activo;
                    filasAfectadas = usuarios.Agregar(usuario);

                }
                else
                {   
                    //Datos de usuario
                    usuario.Email = tbEmail.Text;
                    usuario.Password = tbPassword.Text;
                    usuario.Tipo = TipoUsuario.Persona;
                    usuario.EsAdmin = false;
                    usuario.Estado = EstadoUsuario.Activo;
                    idUsuario = usuarios.Agregar(usuario);
                    //Localidad y Provincia
                    LocalidadNegocio localidades = new LocalidadNegocio();
                    ProvinciaNegocio provincias = new ProvinciaNegocio();
                    int idLocalidad = localidades.BuscarId(ddlLocalidad.SelectedItem.ToString());
                    int idProvincia = provincias.BuscarID(ddlProvincia.SelectedItem.ToString());
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
                }
             
                    if(filasAfectadas > 0)
                    {
                        //Alta De Refugio o Persona Exitoso
                        // Realizar cualquier otra acción necesaria o mostrar un mensaje de éxito
                        //Autologin
                        Session["Usuario"] = usuario;
                        Response.Redirect("default.aspx");
                    }
  
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

    
    }
}