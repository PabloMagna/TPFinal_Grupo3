using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
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
            listaImg = BuscarImagenesPublicacion(IDPublicacion);
            

            if (!IsPostBack)
            {
                repImagenes.DataSource = listaImg;
                repImagenes.DataBind();
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

        public void btnBorrar_Click(object sender, EventArgs e)
        {
            string valorId = ((Button)sender).CommandArgument;
            int idImg = int.Parse(valorId);
            
            ImagenMascotaNegocio negocio = new ImagenMascotaNegocio();
            negocio.Borrar(idImg);

            
            int idPublicacion = int.Parse(Request.QueryString["ID"]);
            Response.Redirect("EditarImagenesMascota.aspx?ID=" + idPublicacion);
            
        }

        public void btnVolver_Click(object sender, EventArgs e)
        {
            int idPublicacion = int.Parse(Request.QueryString["ID"]);
            Response.Redirect("formPublicacion.aspx?ID=" + idPublicacion);
        }
        

    }
}