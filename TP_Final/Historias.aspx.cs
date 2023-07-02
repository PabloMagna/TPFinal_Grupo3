using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Final
{
    public partial class Historias : System.Web.UI.Page
    {
        protected List<Historia> ListaHistorias;
        protected List<Usuario> ListaUsuarios;
        protected List<string> NombresUsuarios;
        protected string NombreUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarHistorias();
            CargarUsuarios();
        }

        public void CargarHistorias()
        {
            HistoriaNegocio negocioH = new HistoriaNegocio();
            ListaHistorias = negocioH.Listar();
        }
        public void CargarUsuarios()
        {
            UsuarioNegocio negocioU = new UsuarioNegocio();
            ListaUsuarios = negocioU.Listar();
        }

        
        public string GetUserName(string email)
        {
            string username = "";

            string buscar = @"^(.*?)@";
            Regex regex = new Regex(buscar);
            Match encontrado = regex.Match(email);

            if (encontrado.Success)
            {
                for (int i = 0; i < encontrado.Length - 1; i++)
                {
                    username += email[i];
                }
            }
            return username;
        }

        public void btnAceptar_Click(object sender, EventArgs e)
        {
            HistoriaNegocio negocio = new HistoriaNegocio();
            if (!validarDescripcion())
            {
                return;
            }
            try
            {
                Dominio.Usuario usuarioSesion = (Dominio.Usuario)Session["Usuario"];
                //Seteo historia: 
                Historia nueva = new Historia();
                nueva.IDUsuario = usuarioSesion.Id;
                nueva.Descripcion = tbDescripcion.Text;
                nueva.FechaHora = DateTime.Now;
                nueva.Estado = EstadoHistoria.Activo;               
                nueva.FechaHora = DateTime.Now;



                //Imagenes con archivos
                if (!string.IsNullOrEmpty(tbImgFile.Value) || EsImagen(tbImgFile.Value))
                {
                    string ruta = Server.MapPath("./imagenes/Historias/");
                    string nombreFile = "Historia-IDUser-" + usuarioSesion.Id + "-" + DateTime.Now.ToString("yyyyMMdd_HHmmssfff") + ".jpg";
                    tbImgFile.PostedFile.SaveAs(ruta + nombreFile);
                    nueva.UrlImagen = "../imagenes/Historias/" + nombreFile;
                }
                else
                {
                    nueva.UrlImagen = "";
                }
                // altaExitosa.Visible = true;
                negocio.Agregar(nueva);
            }

            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }

        static bool EsImagen(string fileName)
        {
            string pattern = @"\.(jpg|png|jpeg)$";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(fileName);
        }

        public bool validarDescripcion()
        {
            if (string.IsNullOrEmpty(tbDescripcion.Text))
            {
                lblErrorDescripcion.Text = "Debe agregar una descripción.";
                lblErrorDescripcion.ForeColor = System.Drawing.Color.Cyan;
                return false;
            }
            else if (tbDescripcion.Text.Length < 50)
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
        /*
        public bool validarImagen()
        {
            if (EsImagen(tbImgFile.Value) == false)
            {
                lblErrorImg.Text = "El formato de imagen es incorrecto. Debe ser imagen .png, .jpg o .jpeg";
                lblErrorImg.ForeColor = System.Drawing.Color.Cyan;
                return false;
            }           
            else
            {
                lblErrorImg.Visible = false;
                return true;
            }

        }        
        */
    }
}