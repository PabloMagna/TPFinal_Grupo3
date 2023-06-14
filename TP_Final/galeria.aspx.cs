using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using static System.Net.WebRequestMethods;

namespace TP_Final
{
    public partial class galeria : System.Web.UI.Page
    {
        protected List<Publicacion> publicaciones;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PublicacionNegocio publiNegocio = new PublicacionNegocio();
                publicaciones = publiNegocio.Listar();
            }
        }
        public string obtenerPrimeraImagen(int idMascota)
        {
            List<ImagenesMascota> lista = new List<ImagenesMascota>();
            ImagenMascotaNegocio negocio = new ImagenMascotaNegocio();
            lista = negocio.listar(idMascota);
            if(lista!=null && lista.Count > 0)
            {
                return lista[0].urlImagen;
            }
            else
            {
                return "https://g.petango.com/shared/Photo-Not-Available-dog.gif";
            }
        }
    }
}