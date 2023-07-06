using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using static System.Net.WebRequestMethods;

namespace TP_Final
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected List<Publicacion> publicaciones;
        protected List<Historia> historias;
        protected Usuario userLogeado = new Usuario();
        protected Persona persona = new Persona();
        protected Refugio refugio = new Refugio();
        protected int idProvinciaPreseleccionada;
        protected int idLocalidadPreseleccionada;
        protected const string placeholderImg = "https://img.freepik.com/vector-premium/historieta-divertida-cara-perrito-beagle_42750-489.jpg?w=2000";
        protected void Page_Load(object sender, EventArgs e)
        {
            userLogeado = (Usuario)Session["Usuario"];
            //No hace falta preguntar si hay usuario en sesion
            if (Session["Usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                HistoriaNegocio histoNegocio = new HistoriaNegocio();
                historias = new List<Historia>();
                historias = histoNegocio.ListarPorUsuario(usuario.Id);



                if (!IsPostBack)
                {
                    //Carga Publicaciones
                    PublicacionNegocio publiNegocio = new PublicacionNegocio();
                    publicaciones = publiNegocio.ListarPorUsuario(usuario.Id);
                    //Carga Datos perfil
                    if (usuario.Tipo == TipoUsuario.Persona)
                    {
                        PersonaNegocio negocio = new PersonaNegocio();
                        persona = negocio.BuscarporUsuario(usuario.Id);
                        cargarFormPersona(persona);
                    }
                    else
                    {
                        RefugioNegocio negocio = new RefugioNegocio();
                        refugio = negocio.BuscarporUsuario(usuario.Id);
                    }
                    CargarProvinciaYLocalidadPreseleccionadas(usuario.Tipo);
                }

            }
        }

        public string obtenerPrimeraImagen(int idPublicacion)
        {
            List<ImagenMascota> lista = new List<ImagenMascota>();
            ImagenMascotaNegocio negocio = new ImagenMascotaNegocio();
            lista = negocio.listar(idPublicacion);

            if (lista != null && lista.Count > 0 && !string.IsNullOrEmpty(lista[0].urlImagen))
            {
                return lista[0].urlImagen;
            }
            else
            {
                return "https://g.petango.com/shared/Photo-Not-Available-dog.gif";
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btnDelete = (Button)sender;
            RepeaterItem repeaterItem = (RepeaterItem)btnDelete.NamingContainer;

            if (repeaterItem != null)
            {
                HiddenField hfIDHistoria = (HiddenField)repeaterItem.FindControl("hfIDHistoria");
                if (hfIDHistoria != null)
                {
                    int idHistoria = Convert.ToInt32(hfIDHistoria.Value);

                    HistoriaNegocio negocio = new HistoriaNegocio();
                    negocio.Eliminar(idHistoria);

                }

            }
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProvincia = Convert.ToInt32(ddlProvincia.SelectedValue);
            CargarDropDownListLocalidad(idProvincia);
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDropDownListProvincia();
                CargarDropDownListLocalidad(idProvinciaPreseleccionada);
            }
        }
        protected void CargarProvinciaYLocalidadPreseleccionadas(TipoUsuario tipo)
        {
            if (tipo == TipoUsuario.Persona)
            {
                idProvinciaPreseleccionada = persona.IDProvincia;
                idLocalidadPreseleccionada = persona.IDLocalidad;
            }
            else
            {
                idProvinciaPreseleccionada = refugio.IDProvincia;
                idLocalidadPreseleccionada = refugio.IDLocalidad;
            }
        }

        //protected void Page_Init(object sender, EventArgs e)
        //{
        //    ddlProvincia.SelectedIndexChanged += ddlProvincia_SelectedIndexChanged;
        //}

        protected void CargarDropDownListProvincia()
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

        protected void CargarDropDownListLocalidad(int idProvincia)
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

        protected void cargarFormPersona(Persona persona)
        {
            tbNombre.Text = persona.Nombre;
            tbApellido.Text = persona.Apellido;
            tbDni.Text = persona.Dni.ToString();
            tbFechaNac.Text = persona.FechaNacimiento.ToString("yyyy-MM-dd");
            tbTel.Text = persona.Telefono;
            if (persona.UrlImagen != null && persona.UrlImagen != "")
            {
                imgPerfil.Src = persona.UrlImagen;
            }
            else { imgPerfil.Src = placeholderImg; }

        }

        protected void Modificar_Click(object sender, EventArgs e)
        {
            if (userLogeado.Tipo == TipoUsuario.Persona)
            {
                Page.Validate("ValPersona");
                if (Page.IsValid)
                {
                    PersonaNegocio negocio = new PersonaNegocio();
                    persona.Nombre = tbNombre.Text;
                    persona.Apellido = tbApellido.Text;
                    persona.Dni = int.Parse(tbDni.Text);
                    persona.IDProvincia = ddlProvincia.SelectedIndex + 1;
                    persona.IDLocalidad = ddlLocalidad.SelectedIndex + 1;
                    persona.Telefono = tbTel.Text;
                    //VALIDAR IMG Y TRAERLA PARA EL UPDATE
                    //persona.UrlImagen = ...

                    negocio.Modificar(persona);
                }
            }
        }

   
    }
}