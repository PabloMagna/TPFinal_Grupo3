using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Final
{
    public partial class DetallePublicacion : System.Web.UI.Page
    {
        protected Publicacion publicacion;
        protected List<string> listaImagenes;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    CargaInicial();
                }
            }
        }
        private void CargaInicial()
        {
            int id = Convert.ToInt32(Request.QueryString["ID"]);
            PublicacionNegocio publiNegocio = new Negocio.PublicacionNegocio();
            publicacion = publiNegocio.ObtenerPorId(id);
            ImagenMascotaNegocio imagenNegocio = new ImagenMascotaNegocio();
            listaImagenes = imagenNegocio.ObtenerUrlsImagenes(id);
        }
        protected string CargarLocalidad()
        {
            LocalidadNegocio localidadNegocio = new LocalidadNegocio();
            return localidadNegocio.ObtnerNombrePorID(publicacion.IDLocalidad);
        }
        protected string CargarProvincia()
        {
            ProvinciaNegocio provinciaNegocio = new ProvinciaNegocio();
            return provinciaNegocio.ObtenerNombrePorId(publicacion.IDProvincia);
        }
        protected string CargarEspecie()
        {
            if (publicacion.Especie == 1)
                return "Perro";
            else if (publicacion.Especie == 2)
                return "Gato";
            else
                return "Otro";
        }
        protected string CargarSexo()
        {
            if (publicacion.Sexo == 'M')
                return "Macho";
            else if (publicacion.Sexo == 'H')
                return "Hembra";
            else
                return "Desconocido";
        }
        protected string CargarEdad()
        {
            if (publicacion.Edad == 1)
                return publicacion.Edad + " Mes";
            else if (publicacion.Edad < 12)
                return publicacion.Edad + " Meses";
            else
                return publicacion.Edad / 12 + " Año/s";
        }
    }
}