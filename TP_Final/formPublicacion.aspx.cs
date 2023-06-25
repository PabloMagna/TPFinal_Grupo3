using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using static System.Net.WebRequestMethods;


namespace TP_Final
{
    public partial class Publicar : System.Web.UI.Page
    {
        protected Usuario usuarioLogin { set; get; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            usuarioLogin = (Dominio.Usuario)Session["Usuario"];
            try
            {
                if (!IsPostBack)
                {
                    CargarDropDownListProvincias();
                    CargarLocalidades(1);    
                }

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
           
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
                if (string.IsNullOrEmpty(nuevaImg.urlImagen))
                {
                    nuevaImg.urlImagen = tbImg.Text;
                    //Insert Imágenes: 
                    imagenNegocio.Agregar(nuevaImg);
                }
                //Imagenes con archivos

                string ruta = Server.MapPath("./imagenes/publicaciones/");
                string nombre = nuevaImg.IdPublicacion.ToString();
                DateTime fechaHora = DateTime.Now;
                txtImagen.PostedFile.SaveAs(ruta + "Mascota-" + nombre + "-" + fechaHora.ToString("yyyyMMdd_HHmmss") + ".jpg");
                nuevaImg.urlImagen = "../imagenes/publicaciones/Mascota-" + nombre + "-" + fechaHora.ToString("yyyyMMdd_HHmmss") + ".jpg"; 

                //Insert Imágenes: 
                imagenNegocio.Agregar(nuevaImg);


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
            ddlLocalidad.DataTextField = "Value"; // Nombre de la propiedad para mostrar (valor)
            ddlLocalidad.DataValueField = "Key"; // Nombre de la propiedad para el valor (clave)
            ddlLocalidad.DataBind();
        }
        private void CargarDropDownListProvincias()
        {           
            ProvinciaNegocio provinciaNegocio = new ProvinciaNegocio();
            List<KeyValuePair<int, string>> provincias = provinciaNegocio.ListarClaveValor();

            ddlProvincia.DataSource = provincias;
            ddlProvincia.DataTextField = "Value"; // Nombre de la propiedad para mostrar (valor)
            ddlProvincia.DataValueField = "Key"; // Nombre de la propiedad para el valor (clave)
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
                return false;
            }
            else if (tbDescripcion.Text.Length < 100)
            {
                lblErrorDescripcion.Text = "La descripción es demasiado corta.";
                lblErrorDescripcion.ForeColor = System.Drawing.Color.Cyan;
                return false;
            }
            else
            {
                lblErrorDescripcion.Visible = false;
                return true;
            }

        }


    }
}