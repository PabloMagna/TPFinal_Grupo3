using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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
        protected string urlImgUser;
        protected int idProvinciaPreseleccionada=1;
        protected int idLocalidadPreseleccionada=1;
        protected const string placeholderImg = "https://img.freepik.com/vector-premium/historieta-divertida-cara-perrito-beagle_42750-489.jpg?w=2000";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Para prevenir que entren sin logearse por url
            if (Session["Usuario"] != null)
            {
                userLogeado = (Usuario)Session["Usuario"];
                if (!IsPostBack)
                {

                    if(userLogeado.Tipo != TipoUsuario.Persona)
                    {
                        cargarHistorias();
                        cargarPublicaciones();
                        if (userLogeado.Tipo == TipoUsuario.PersonaCompleto)
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

            }
            else { Response.Redirect("default.aspx"); }
        }

        protected void cargarHistorias()
        {
            HistoriaNegocio histoNegocio = new HistoriaNegocio();
            historias = histoNegocio.ListarPorUsuario(userLogeado.Id);
            rpHistorias.DataSource = historias;
            rpHistorias.DataBind();
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
            Button btnAceptar = (Button)sender;
            RepeaterItem repeaterItem = (RepeaterItem)btnAceptar.NamingContainer;

            if (repeaterItem != null)
            {
                HiddenField hfIDHistoria = (HiddenField)repeaterItem.FindControl("hfIDHistoria");
                TextBox tbDescripcion = (TextBox)repeaterItem.FindControl("tbDescripcion");
                HtmlInputFile tbImgenFile = (HtmlInputFile)repeaterItem.FindControl("tbImagenHistoria");

                if (hfIDHistoria != null && tbDescripcion != null)
                {
                    int idHistoria = Convert.ToInt32(hfIDHistoria.Value);
                    string descripcion = tbDescripcion.Text;
                   
                    // Obtener el objeto Historia y actualizar los campos
                    HistoriaNegocio negocio = new HistoriaNegocio();
                    Historia nueva = negocio.Buscar(idHistoria);
                    
                    if (nueva != null)
                    {
                        nueva.Descripcion = descripcion;
                        // si el cliente cargo una img, la actualizo, sino queda la que ya tenia.
                        string urlAux =ObtenerUrlImagenHistoria(nueva.ID, tbImgenFile);
                        if (urlAux != null)
                        {
                            nueva.UrlImagen = urlAux;
                        }
                        // Actualizar el objeto en tu lógica de negocio o base de datos
                        negocio.Actualizar(nueva);

                        // Actualizar datos por postback
                        historias = negocio.ListarPorUsuario(userLogeado.Id);
                        rpHistorias.DataBind();
                        cargarHistorias();
                        cargarPublicaciones();
                    }
                }
            }
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
                    // Actualizar datos por postback
                    historias = negocio.ListarPorUsuario(userLogeado.Id);
                    rpHistorias.DataBind();
                    cargarHistorias();
                    cargarPublicaciones();

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
            if (tipo == TipoUsuario.PersonaCompleto)
            {
                idProvinciaPreseleccionada = persona.IDProvincia;
                idLocalidadPreseleccionada = persona.IDLocalidad;
            }
            else if(tipo == TipoUsuario.Persona)
            {
                idProvinciaPreseleccionada = 1;
                idLocalidadPreseleccionada = 1;
            }
            else
            {   //Es Refugio
                idProvinciaPreseleccionada = refugio.IDProvincia;
                idLocalidadPreseleccionada = refugio.IDLocalidad;
            }
        }

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

        static bool EsImagen(string fileName)
        {
            string pattern = @"\.(jpg|png|jpeg)$";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(fileName);
        }

        protected string ObtenerUrlImagenHistoria(int idHistoria, HtmlInputFile inputFile)
        {
            string imageUrl = string.Empty;

            // Verificar si se cargó una nueva imagen
            if (inputFile.PostedFile != null && inputFile.PostedFile.ContentLength > 0)
            {
                string nombreArchivo = Path.GetFileName(inputFile.PostedFile.FileName);
                string extension = Path.GetExtension(nombreArchivo);
                if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                {
                    string carpeta = Server.MapPath("~/imagenes/Historias/");
                    string ruta = carpeta + "Historia-IDUser-" + idHistoria + extension;
                    inputFile.PostedFile.SaveAs(ruta);
                    imageUrl="../imagenes/Historias/"+ "Historia-IDUser-" + idHistoria + extension;
                }
            }
            return imageUrl;
        }


        protected string ObtenerUrlImagenPerfil()
        {
            string imageUrl = string.Empty;

            // Verificar si se cargó una nueva imagen de perfil
            if (tbImgFile.PostedFile != null && tbImgFile.PostedFile.ContentLength > 0)
            {
                string nombreArchivo = Path.GetFileName(tbImgFile.PostedFile.FileName);
                string extension = Path.GetExtension(nombreArchivo);
                if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                {
                    string carpeta = Server.MapPath("~/imagenes/Perfiles/");
                    string ruta = carpeta + "Usuario-" + userLogeado.Id + extension;
                    tbImgFile.PostedFile.SaveAs(ruta);
                    imageUrl = "../imagenes/Perfiles/Usuario-" + userLogeado.Id + extension;
                }
            }

            return imageUrl;
        }

        protected void Modificar_Click(object sender, EventArgs e)
        {   


            if(userLogeado.Tipo != TipoUsuario.Persona)
            {
                if (userLogeado.Tipo == TipoUsuario.PersonaCompleto)
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

                        //CargarImagenPerfil();
                        string urlAux = ObtenerUrlImagenPerfil();
                        if(!string.IsNullOrEmpty(urlAux))
                        {
                            persona.UrlImagen = urlAux;
                        }
           
                        negocio.Modificar(persona);
                        imgPerfil.Src = persona.UrlImagen;
                        Session["Persona"] = persona;
                        //Se actualizan las otras listas por postback
                        cargarHistorias();
                        cargarPublicaciones();
                        Session["ImagenPerfilActualizada"] = true;
                    }
                }
                else
                {   //Es Refugio
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
                        string urlAux = ObtenerUrlImagenPerfil();
                        if (!string.IsNullOrEmpty(urlAux))
                        {
                            refugio.UrlImagen = urlAux;
                        }
                        negocio.Modificar(refugio);
                        Session["Refugio"]=refugio;
                        //Se actualizan las otras listas por postback
                        cargarHistorias();
                        cargarPublicaciones();
                        Session["ImagenPerfilActualizada"] = true;
                    }

                }
            }
            else
            {   //Es Persona incompleta
                Page.Validate("ValPersona");
                Page.Validate("ValAmbos");
                if (Page.IsValid)
                {
                    PersonaNegocio negocio = new PersonaNegocio();
                    Persona persona = new Persona();
                    persona.IDUsuario = userLogeado.Id;
                    persona.Nombre = tbNombre.Text;
                    persona.Apellido = tbApellido.Text;
                    persona.Dni = int.Parse(tbDni.Text);
                    persona.IDProvincia = ddlProvincia.SelectedIndex + 1;
                    persona.IDLocalidad = ddlLocalidad.SelectedIndex + 1;
                    persona.Telefono = tbTel.Text;
                    persona.FechaNacimiento = DateTime.Parse(tbFechaNac.Text);
                    //Placeholder imagen url
                    persona.UrlImagen = placeholderImg;
                    int filasAfectadas = negocio.Agregar(persona);
                    if(filasAfectadas > 0)
                    {
                        //Informar alta exitoso, actualizo tipoUser, Persona en session y recargar pagina

                        //userLogeado.Tipo = TipoUsuario.PersonaCompleto;
                        //Session["Usuario"] = userLogeado;
                        UsuarioNegocio userNego = new UsuarioNegocio();
                        userNego.ActualizarTipo(userLogeado.Id, TipoUsuario.PersonaCompleto);
                        Session["Usuario"]=userNego.BuscarxID(userLogeado.Id);
                        Session["Persona"] = persona;
                        Response.Redirect("Perfil.aspx");
                        Session["ImagenPerfilActualizada"] = true;
                        Response.Redirect(Request.Url.ToString());
                    }
                }
            }
        }

        protected void cvLocalidad_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (ddlLocalidad.SelectedIndex >= 0);
        }

        protected void cvProvincia_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (ddlProvincia.SelectedIndex >= 0);
        }

    }
}