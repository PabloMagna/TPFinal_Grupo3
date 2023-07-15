using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using static System.Net.WebRequestMethods;
using System.Web.Compilation;

namespace TP_Final
{
    public partial class Publicar : System.Web.UI.Page
    {
        protected Usuario usuarioLogin { set; get; }
        protected int IDPublicacion { get; set; }
        protected Publicacion Publicacion { get; set; }
        protected bool existeImagen = false;
        protected List<ImagenMascota> listaImg { get; set; }

        protected Publicacion publi;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Requiere inicio de sesión
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            usuarioLogin = (Dominio.Usuario)Session["Usuario"];

            if (Request.QueryString["ID"] != null)
            {
                IDPublicacion = Convert.ToInt32(Request.QueryString["ID"]);
                cargarImagenes(IDPublicacion);
                // CargarPublicacionEliminar();
            }

            try
            {
                if (!IsPostBack)
                {
                    CargarDropDownListProvincias();
                    CargarLocalidades(1);

                    altaExitosa.Visible = false;
                    formulario.Visible = true;
                    if (Request.QueryString["ID"] != null)
                    {
                        IDPublicacion = Convert.ToInt32(Request.QueryString["ID"]);
                        PublicacionNegocio negocio = new PublicacionNegocio();
                        Publicacion = negocio.ObtenerPorId(IDPublicacion);
                        CargarForm(Publicacion);
                        CargarPublicacionEliminar();
                        CargarOpcionesBaja();
                    }
                    else
                    {
                        IDPublicacion = 0;
                    }

                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            if (!ValidarForm())
            {
                return;
            }
            try
            {
                //Seteo publicacion: 
                Publicacion nueva = new Publicacion();
                nueva.Titulo = tbNombre.Text;
                nueva.Especie = (Especie)Enum.Parse(typeof(Especie), ddlEspecie.SelectedValue);
                nueva.Descripcion = tbDescripcion.Text;
                nueva.IDProvincia = int.Parse(ddlProvincia.SelectedValue);
                nueva.IDLocalidad = int.Parse(ddlLocalidad.SelectedValue);
                nueva.Sexo = ddlSexo.SelectedValue[0];
                nueva.IdUsuario = usuarioLogin.Id;
                nueva.FechaHora = DateTime.Now;

                if (ddlEdad.SelectedValue == "A")
                {
                    nueva.Edad = int.Parse(tbEdad.Text) * 12;
                }
                else
                {
                    nueva.Edad = int.Parse(tbEdad.Text);
                }

                if (tbRaza.Text.Length == 0 || tbRaza.Text == null)
                {
                    nueva.Raza = "Sin especificar";
                }
                else
                {
                    nueva.Raza = tbRaza.Text;
                }

                ImagenMascotaNegocio imagenNegocio = new ImagenMascotaNegocio();
                PublicacionNegocio publicacionNegocio = new PublicacionNegocio();

                //Insert Publicacion: 
                publicacionNegocio.AgregarConSP(nueva);

                //Seteo Imágenes: 
                ImagenMascota nuevaImg = new ImagenMascota();
                nuevaImg.IdPublicacion = publicacionNegocio.GetIdPublicacionCreada(usuarioLogin.Id);

                //Imagenes con URL
                /*
                if (!string.IsNullOrEmpty(tbImg.Text))
                {
                    nuevaImg.urlImagen = tbImg.Text;
                    //Insert Imágenes: 
                    imagenNegocio.Agregar(nuevaImg);
                }
                */

                //Imagenes con archivos
                if (!string.IsNullOrEmpty(tbImgFile.Value))
                {
                    string ruta = Server.MapPath("./imagenes/publicaciones/");
                    string nombre = nuevaImg.IdPublicacion.ToString();
                    DateTime fechaHora = DateTime.Now;
                    tbImgFile.PostedFile.SaveAs(ruta + "Mascota-" + nombre + "-" + fechaHora.ToString("yyyyMMdd_HHmmss") + ".jpg");
                    nuevaImg.urlImagen = "../imagenes/publicaciones/Mascota-" + nombre + "-" + fechaHora.ToString("yyyyMMdd_HHmmss") + ".jpg";

                    //Insert Imágenes: 
                    imagenNegocio.Agregar(nuevaImg);
                }

                formulario.Visible = false;
                altaExitosa.Visible = true;
            }

            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }


        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ddlProvincia.SelectedIndex;
            int idProvincia = index + 1;
            CargarLocalidades(idProvincia);
        }

        private void CargarLocalidades(int idProvincia)
        {
            LocalidadNegocio localidadNegocio = new LocalidadNegocio();
            List<KeyValuePair<int, string>> localidades = localidadNegocio.ListarClaveValor(idProvincia);

            ddlLocalidad.DataSource = localidades;
            ddlLocalidad.DataTextField = "Value";
            ddlLocalidad.DataValueField = "Key";
            ddlLocalidad.DataBind();
        }
        private void CargarDropDownListProvincias()
        {
            ProvinciaNegocio provinciaNegocio = new ProvinciaNegocio();
            List<KeyValuePair<int, string>> provincias = provinciaNegocio.ListarClaveValor();

            ddlProvincia.DataSource = provincias;
            ddlProvincia.DataTextField = "Value";
            ddlProvincia.DataValueField = "Key";
            ddlProvincia.DataBind();
        }


        //Validaciones

        public bool ValidarForm()
        {
            validarTitulo();
            validarEdad();
            validarDescripcion();

            if (!validarDescripcion() || !validarEdad() || !validarTitulo())
            {
                lblErrorForm.Text = ("(*) Los campos con asterisco son obligatorios.").ToUpper();
                lblErrorForm.ForeColor = System.Drawing.Color.Cyan;
                return false;
            }

            return true;
        }

        public bool validarEdad()
        {
            if (string.IsNullOrEmpty(tbEdad.Text))
            {
                lblErrorEdad.Text = "Debes indicar la edad.";
                lblErrorEdad.ForeColor = System.Drawing.Color.Cyan;
                return false;
            }
            else if (int.Parse(tbEdad.Text) < 1)
            {
                lblErrorEdad.Text = "La edad debe ser un valor positivo.";
                lblErrorEdad.ForeColor = System.Drawing.Color.Cyan;
                return false;
            }
            else
            {
                lblErrorEdad.Visible = false;
                return true;
            }
        }

        public bool validarTitulo()
        {
            if (string.IsNullOrEmpty(tbNombre.Text))
            {
                LblErrorTitulo.Text = "Se requiere el nombre de la mascota o un título que la identifique.";
                LblErrorTitulo.ForeColor = System.Drawing.Color.Cyan;
                return false;
            }
            else if (tbNombre.Text.Length < 3)
            {
                LblErrorTitulo.Text = "El nombre debe tener al menos 3 caracteres.";
                LblErrorTitulo.ForeColor = System.Drawing.Color.Cyan;
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool validarDescripcion()
        {
            if (string.IsNullOrEmpty(tbDescripcion.Text))
            {
                lblErrorDescripcion.Text = "Debe agregar una descripción.";
                lblErrorDescripcion.ForeColor = System.Drawing.Color.Cyan;
                lblErrorDescripcion.Visible = true;
                return false;
            }
            else if (tbDescripcion.Text.Length < 50)
            {
                lblErrorDescripcion.Text = "La descripción es demasiado corta.";
                lblErrorDescripcion.ForeColor = System.Drawing.Color.Cyan;
                lblErrorDescripcion.Visible = true;

                return false;
            }
            else
            {
                lblErrorDescripcion.Visible = false;
                return true;
            }

        }

        protected void CargarForm(Publicacion publicacion)
        {
            try
            {
                tbNombre.Text = publicacion.Titulo;
                ddlEspecie.SelectedValue = publicacion.Especie.ToString();
                tbDescripcion.Text = publicacion.Descripcion;
                ddlProvincia.SelectedValue = publicacion.IDProvincia.ToString();
                ddlLocalidad.SelectedValue = publicacion.IDLocalidad.ToString();
                ddlSexo.SelectedValue = publicacion.Sexo.ToString();
                tbRaza.Text = publicacion.Raza;
                if (publicacion.Edad >= 12)
                {
                    tbEdad.Text = (publicacion.Edad / 12).ToString();
                    ddlEdad.SelectedValue = "A";
                }
                else
                {
                    tbEdad.Text = publicacion.Edad.ToString();
                    ddlEdad.SelectedValue = "M";
                }

            }

            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }

        public void cargarImagenes(int id)
        {
            if (BuscarImagenesPublicacion(id).Count > 0)
            {
                listaImg = BuscarImagenesPublicacion(id);
                existeImagen = true;
            }
        }

        public List<ImagenMascota> BuscarImagenesPublicacion(int idPublicacion)
        {
            List<ImagenMascota> imagenesMascota = null;
            ImagenMascotaNegocio negocioImagenes = new ImagenMascotaNegocio();
            if (negocioImagenes.listar(idPublicacion) != null)
            {
                imagenesMascota = negocioImagenes.listar(idPublicacion);
            }

            return imagenesMascota;
        }

        public void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!ValidarForm())
            {
                return;
            }
            try
            {
                //Seteo publicacion: 
                Publicacion nueva = new Publicacion();
                nueva.Id = int.Parse(Request.QueryString["ID"]);
                nueva.Titulo = tbNombre.Text;
                nueva.Especie = (Especie)Enum.Parse(typeof(Especie), ddlEspecie.SelectedValue);
                nueva.Descripcion = tbDescripcion.Text;
                nueva.IDProvincia = int.Parse(ddlProvincia.SelectedValue);
                nueva.IDLocalidad = int.Parse(ddlLocalidad.SelectedValue);
                nueva.Sexo = ddlSexo.SelectedValue[0];
                nueva.IdUsuario = usuarioLogin.Id;
                nueva.FechaHora = DateTime.Now;

                if (ddlEdad.SelectedValue == "A")
                {
                    nueva.Edad = int.Parse(tbEdad.Text) * 12;
                }
                else
                {
                    nueva.Edad = int.Parse(tbEdad.Text);
                }

                if (tbRaza.Text.Length == 0 || tbRaza.Text == null)
                {
                    nueva.Raza = "Sin especificar";
                }
                else
                {
                    nueva.Raza = tbRaza.Text;
                }

                ImagenMascotaNegocio imagenNegocio = new ImagenMascotaNegocio();
                PublicacionNegocio publicacionNegocio = new PublicacionNegocio();

                //Insert Publicacion: 
                publicacionNegocio.Actualizar(nueva);

                //Seteo Imágenes: 
                ImagenMascota nuevaImg = new ImagenMascota();
                nuevaImg.IdPublicacion = int.Parse(Request.QueryString["ID"]);

                if (!string.IsNullOrEmpty(tbImgFile.Value))
                {
                    string ruta = Server.MapPath("./imagenes/publicaciones/");
                    string nombre = nuevaImg.IdPublicacion.ToString();
                    DateTime fechaHora = DateTime.Now;
                    tbImgFile.PostedFile.SaveAs(ruta + "Mascota-" + nombre + "-" + fechaHora.ToString("yyyyMMdd_HHmmss") + ".jpg");
                    nuevaImg.urlImagen = "../imagenes/publicaciones/Mascota-" + nombre + "-" + fechaHora.ToString("yyyyMMdd_HHmmss") + ".jpg";

                    //Insert Imágenes: 
                    imagenNegocio.Agregar(nuevaImg);
                }

                formulario.Visible = false;
                altaExitosa.Visible = true;
            }

            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }

        public void btnBorrar_Click(object sender, EventArgs e)
        {
            int idPublicacion = int.Parse(Request.QueryString["ID"]);
            Response.Redirect("EditarImagenesMascota.aspx?ID=" + idPublicacion);
        }
        private void CargarPublicacionEliminar()
        {
            PublicacionNegocio publicacionNegocio = new PublicacionNegocio();
            Publicacion auxiliar = publicacionNegocio.ObtenerPorId(int.Parse(Request.QueryString["ID"]));
            if (auxiliar != null && auxiliar.Estado != Estado.BorradaPorUsuario && auxiliar.Estado != Estado.EliminadaPorAdmin)
            {
                publi = auxiliar;
            }
            else
            {
                publi = null;
            }
        }
        private void CargarOpcionesBaja()
        {
            List<ListItem> opcionesBaja = new List<ListItem>();
            if (publi != null)
            {
                switch (publi.Estado)
                {
                    case Dominio.Estado.Activa:
                        opcionesBaja.Add(new ListItem("Pausar Temportalmente (Cancela solicitudes)", "PausarPublicacion"));
                        opcionesBaja.Add(new ListItem("Eliminar Publicación definitivamente", "EliminarDefinitivamente"));
                        txtComentario.Visible = false;
                        break;
                    case Dominio.Estado.FinalizadaConExito:
                        opcionesBaja.Add(new ListItem("Reactivar Publicación - Devolución de la mascota", "DevolucionMascota"));
                        break;
                    case Dominio.Estado.EnProceso:
                        // para eliminar debe primero o confirmar adopción o dar de baja la  misma
                        opcionesBaja.Add(new ListItem("Rechazar Adoptante - Reactiva Publicacion", "RechazarAdoptante"));
                        opcionesBaja.Add(new ListItem("Finalizar por Adopción Concretada", "AdopcionConcretada"));
                        break;
                    case Dominio.Estado.Pausada:
                        opcionesBaja.Add(new ListItem("Reactivar Publicación", "ReactivarPublicacion"));
                        txtComentario.Visible = false;
                        break;
                }

                rbOpcionesBaja.DataSource = opcionesBaja;
                rbOpcionesBaja.DataBind();
            }
        }

        protected void btnConfirmarAccion_Click(object sender, EventArgs e)
        {
            string opcionSeleccionada = rbOpcionesBaja.SelectedValue;
            int idPublicacion = int.Parse(Request.QueryString["id"]);
            int idDonante = ((Usuario)Session["Usuario"]).Id;
            PublicacionNegocio publicacionNegocio = new PublicacionNegocio();
            AdopcionNegocio adopcionNegocio = new AdopcionNegocio();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            publi = publicacionNegocio.ObtenerPorId(idPublicacion);
            string mensajeExito = string.Empty;
            string redireccion = string.Empty;
            int idAdoptante;
           

            switch (opcionSeleccionada)
            {
                case "PausarPublicacion":
                    publicacionNegocio.ActualizarEstado(idPublicacion, Estado.Pausada);
                    mensajeExito = "La publicación ha sido pausada.";
                    redireccion = Request.Url.AbsoluteUri;
                    break;
                case "EliminarDefinitivamente":
                    publicacionNegocio.ActualizarEstado(idPublicacion, Estado.BorradaPorUsuario);
                    mensajeExito = "La publicación ha sido eliminada definitivamente.";
                    redireccion = "perfil.aspx";
                    break;
                case "DevolucionMascota":
                    if (!ValidarComentario())
                    {
                        updateEliminacion.Update();
                        return;
                    }
                    publicacionNegocio.ActualizarEstado(idPublicacion, Estado.Activa);
                    idAdoptante = adopcionNegocio.BuscarAdoptanteActivoPorPublicacion(idPublicacion);
                    adopcionNegocio.ActualizarEstadoActivaActual(idPublicacion, EstadoAdopcion.Devuelto, txtComentario.Text);
                    mensajeExito = "La devolución de la mascota ha sido registrada.";
                    redireccion = Request.Url.AbsoluteUri;
                    break;
                case "RechazarAdoptante":
                    if (!ValidarComentario())
                    {
                        updateEliminacion.Update();
                        return;
                    }

                    mensajeExito = "El adoptante ha sido rechazado y la publicación ha sido reactivada.";

                    // Enviar correo de rechazo al adoptante
                    idAdoptante = adopcionNegocio.BuscarAdoptanteActivoPorPublicacion(idPublicacion);
                    Usuario adoptante = usuarioNegocio.BuscarxID(idAdoptante);

                    string motivoRechazo = txtComentario.Text;
                    EmailSender emailSender = new EmailSender();
                    emailSender.EnviarCorreoRechazoAdopcion(adoptante.Email, motivoRechazo);
                    redireccion = Request.Url.AbsoluteUri;
                    publicacionNegocio.ActualizarEstado(idPublicacion, Estado.Activa);
                    adopcionNegocio.ActualizarEstadoActivaActual(idPublicacion, EstadoAdopcion.RechazadaPorDonante, txtComentario.Text);
                    break;
                case "AdopcionConcretada":
                    if (!ValidarComentario())
                    {
                        updateEliminacion.Update();
                        return;
                    }
                    publicacionNegocio.ActualizarEstado(idPublicacion, Estado.FinalizadaConExito);
                    adopcionNegocio.ActualizarEstadoActivaActual(idPublicacion, EstadoAdopcion.Completada, txtComentario.Text);
                    mensajeExito = "La adopción ha sido concretada y la publicación ha sido finalizada con éxito.";
                    redireccion = Request.Url.AbsoluteUri;
                    break;
                case "ReactivarPublicacion":
                    publicacionNegocio.ActualizarEstado(idPublicacion, Estado.Activa);
                    mensajeExito = "La publicación ha sido reactivada.";
                    redireccion = Request.Url.AbsoluteUri;
                    break;
            }

            // Llama a una función JavaScript para mostrar el mensaje emergente y redireccionar después de hacer clic en "Aceptar"
            string script = "<script>alert('" + mensajeExito + "'); window.location.href = '" + redireccion + "';</script>";
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", script, false);
        }

        public bool ValidarComentario()
        {
            if (string.IsNullOrEmpty(txtComentario.Text))
            {
                lblError.Text = "Se requiere un comentario.";
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Visible = true;  // Establecer la visibilidad en true
                return false;
            }
            else if (txtComentario.Text.Length < 20)
            {
                lblError.Text = "El comentario debe tener al menos 20 caracteres.";
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Visible = true;  // Establecer la visibilidad en true
                return false;
            }
            else
            {
                lblError.Visible = false;  // Establecer la visibilidad en false
                return true;
            }
        }


    }
}
