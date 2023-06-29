<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Historias.aspx.cs" Inherits="TP_Final.Historias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Historias</title>
    <link href="css/Historias.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="portada">
        <h1 id="titulo">Historias</h1>
        <h4><em>Relatos de adopciones a través de Pet Net.</em></h4>
    </section>
    <section class="historias_container" runat="server">
        <%foreach (Dominio.Historia item in ListaHistorias)
            {%>
            <div class="container div_historia">
                 <div class="nombre-fecha">
                    <%
                        foreach (Dominio.Usuario useritem in ListaUsuarios)
                        {
                            if(item.IDUsuario == useritem.Id)
                            {                        
                                NombreUsuario=GetUserName(useritem.Email);                        
                            }
                        }%>
                    <h3 id="nombreUsuario"><%: NombreUsuario %></h3>                      
                </div>
                <hr />
                <div class="divImagen">
                    <img src="<%: item.UrlImagen%>" class="rounded float-start" ID="imgHistoria" alt="Foto Historia" onerror="this.src='https://img.freepik.com/vector-gratis/adopta-concepto-mascota_23-2148523582.jpg?w=360'">
                </div>
               
                <div>
                    <h4 id="fecha"><%: item.FechaHora %></h4>
                    <hr />
                    <p id="textoDescripcion"><%: item.Descripcion %></p>
                </div>            
            </div>
           <% } %>
        
    </section>
</asp:Content>
