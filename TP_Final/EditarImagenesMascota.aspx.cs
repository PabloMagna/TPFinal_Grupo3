using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Final
{
    public partial class EditarImagenesMascota : System.Web.UI.Page
    {
        protected List<ImagenMascota> listaImg { get; set; }
        protected bool existeImagen = false;
        protected int IDPublicacion { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] == null)
            {
                Response.Redirect("default.aspx");
            }

            IDPublicacion = int.Parse(Request.QueryString["ID"]);           

            if (!IsPostBack)
            {
                cargarImagenes(IDPublicacion);
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



    }
}