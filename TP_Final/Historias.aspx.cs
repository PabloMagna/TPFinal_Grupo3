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
        public void ListarNombesUsuarios()
        {
            foreach (var item in ListaHistorias)
            {
                foreach (var useritem in ListaUsuarios)
                {
                    if(item.IDUsuario == useritem.Id)
                    {                        
                        NombresUsuarios.Add(GetUserName(useritem.Email));                        
                    }
                }
            }
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

    }
}