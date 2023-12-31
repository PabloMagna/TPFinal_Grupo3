﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Final
{
    public partial class AdministrarComentarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Usuario)Session["Usuario"] == null)
                Response.Redirect("Login.aspx");
            else if (!((Usuario)Session["Usuario"]).EsAdmin)
                Response.Redirect("Login.aspx");

            if (!IsPostBack)
            {
                CargarComentarios();
            }
        }
        private void CargarComentarios()
        {
            ComentarioNegocio negocio = new ComentarioNegocio();
            try
            {
                List<Comentario> lista = new List<Comentario>();
                if (Request.QueryString["IDU"] != null)
                {
                    lista = negocio.ListarPorIDUsuario(Convert.ToInt32(Request.QueryString["IDU"]));
                }else if (Request.QueryString["IDP"] != null)
                {
                    lista = negocio.ListarPorPublicacion(Convert.ToInt32(Request.QueryString["IDP"]));
                }
                else
                {
                    lista = negocio.Listar();
                }
                    gvComentarios.DataSource = lista;
                gvComentarios.DataBind();

                foreach (GridViewRow row in gvComentarios.Rows)
                {
                    Comentario comentario = lista[row.RowIndex];
                    DropDownList ddlEstado = (DropDownList)row.FindControl("ddlEstado");

                    ddlEstado.DataSource = Enum.GetValues(typeof(EstadoComentario));
                    ddlEstado.DataBind();
                    ddlEstado.SelectedValue = comentario.Estado.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlEstado = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlEstado.NamingContainer;
            int idComentario = Convert.ToInt32(gvComentarios.DataKeys[row.RowIndex].Value);
            EstadoComentario estado = (EstadoComentario)Enum.Parse(typeof(EstadoComentario), ddlEstado.SelectedValue);

            ComentarioNegocio negocio = new ComentarioNegocio();
            negocio.ActualizarEstado(idComentario, estado);
            CargarComentarios();
        }
    }
}
