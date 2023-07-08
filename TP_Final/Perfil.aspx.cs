using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
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
        protected List<Historia> historias = new List<Historia>();
        protected Usuario userLogeado = new Usuario();
        protected Persona persona;
        protected Refugio refugio;
        protected int idProvinciaPreseleccionada;
        protected int idLocalidadPreseleccionada;
        protected const string placeholderImg = "https://img.freepik.com/vector-premium/historieta-divertida-cara-perrito-beagle_42750-489.jpg?w=2000";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Para prevenir que entren sin logearse por url
            if (Session["Usuario"] != null)
            {
                userLogeado = (Usuario)Session["Usuario"];
                if (!IsPostBack)
                {
                    cargarHistorias();
                    cargarPublicaciones();

                    if (userLogeado.Tipo == TipoUsuario.Persona)
                    {   
                        PersonaNegocio negocio = new PersonaNegocio();
                        persona = negocio.BuscarporUsuario(userLogeado.Id);
                        Session["Persona"] = persona;
                        cargarFormPersona(persona);
                    }
                    else
                    {
                        RefugioNegocio negocio = new RefugioNegocio();
                        refugio = negocio.BuscarporUsuario(userLogeado.Id);
                        Session["Refugio"] = refugio;
                        cargarFormRefugio(refugio);
                    }
                    CargarProvinciaYLocalidadPreseleccionadas(userLogeado.Tipo);
                }

            }
            else { Response.Redirect("default.aspx"); }
        }

        protected void cargarHistorias()
        {
            HistoriaNegocio histoNegocio = new HistoriaNegocio();
            historias = histoNegocio.ListarPorUsuario(userLogeado.Id);
        }

        protected void cargarPublicaciones()
        {
            PublicacionNegocio publiNegocio = new PublicacionNegocio();
            publicaciones = publiNegocio.ListarPorUsuario(userLogeado.Id);
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

        protected void cargarFormRefugio(Refugio refugio)
        {
            tbNombreRefugio.Text = refugio.Nombre;
            tbDireccion.Text = refugio.Direccion;
            tbTel.Text = refugio.Telefono;
            if (refugio.UrlImagen != null && refugio.UrlImagen != "")
            {
                imgPerfil.Src = refugio.UrlImagen;
            }
            else { imgPerfil.Src = placeholderImg; }
        }

        protected void CargarImagenPerfil()
        {
            if (!string.IsNullOrEmpty(tbImgFile.Value))
            {
                string ruta = Server.MapPath("./imagenes/Perfiles/");
                string nombreArchivo = ruta + "Usuario-" + userLogeado.Id + ".jpg";
                // Piso la imagen anterior si es que tiene una
                EliminarImgExistente(ruta,nombreArchivo);
                tbImgFile.PostedFile.SaveAs(nombreArchivo);
                string url = "../imagenes/Perfiles/Usuario-" + userLogeado.Id + ".jpg";

                //Update Imagen en objeto Persona logeada:
                if (userLogeado.Tipo == TipoUsuario.Persona)
                {
                    persona = (Persona)Session["Persona"];
                    persona.UrlImagen = url;
                    Session["Persona"] = persona;
                }
                else {
                    Refugio refugio = (Refugio)Session["Refugio"];
                    refugio.UrlImagen = url;
                    Session["Refugio"] = refugio;
                }
                //PersonaNegocio negocio = new PersonaNegocio();
                //negocio.Modificar(persona);
            }
        }

        protected void EliminarImgExistente(string carpeta,string nombreArchivo)
        {
            // Ruta completa de la imagen anterior
            string rutaImagenAnterior = Path.Combine(carpeta, nombreArchivo);

            // Verifico si la imagen anterior existe y eliminarla si es así
            if (System.IO.File.Exists(rutaImagenAnterior))
            {
                System.IO.File.Delete(rutaImagenAnterior);
            }
        }

        protected void Modificar_Click(object sender, EventArgs e)
        {
            if (userLogeado.Tipo == TipoUsuario.Persona)
            {   
                Page.Validate("ValPersona");
                Page.Validate("ValAmbos");
                if (Page.IsValid)
                {
                    PersonaNegocio negocio = new PersonaNegocio();
                    Persona persona = (Persona)Session["Persona"];
                    persona.Nombre = tbNombre.Text;
                    persona.Apellido = tbApellido.Text;
                    persona.Dni = int.Parse(tbDni.Text);
                    persona.IDProvincia = ddlProvincia.SelectedIndex + 1;
                    persona.IDLocalidad = ddlLocalidad.SelectedIndex + 1;
                    persona.Telefono = tbTel.Text;
                    persona.FechaNacimiento = DateTime.Parse(tbFechaNac.Text);

                    //VALIDAR IMG Y TRAERLA PARA EL UPDATE
                    CargarImagenPerfil();
                    negocio.Modificar(persona);
                    imgPerfil.Src = persona.UrlImagen;
                    Session["Persona"] = persona;
                    //Se actualizan las otras listas por postback
                    cargarHistorias();
                    cargarPublicaciones();
                }
            }
            else
            {
                Page.Validate("ValRefugio");
                Page.Validate("ValAmbos");
                if (Page.IsValid)
                {
                    RefugioNegocio negocio = new RefugioNegocio();
                    Refugio refugio = (Refugio)Session["Refugio"]; 
                    refugio.Nombre = tbNombreRefugio.Text;
                    refugio.Direccion = tbDireccion.Text;
                    refugio.Telefono = tbTel.Text;
                    refugio.IDProvincia = ddlProvincia.SelectedIndex + 1;
                    refugio.IDLocalidad = ddlLocalidad.SelectedIndex + 1;
                    //VALIDAR IMG Y TRAERLA PARA EL UPDATE
                    CargarImagenPerfil();
                    refugio.UrlImagen = imgPerfil.Src;
                    negocio.Modificar(refugio);
                    Session["Refugio"]=refugio;
                    //Se actualizan las otras listas por postback
                    cargarHistorias();
                    cargarPublicaciones();
                }

            }
        }


    }
}