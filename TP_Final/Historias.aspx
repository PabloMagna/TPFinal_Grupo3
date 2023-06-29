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
            <div class="container text-center div_historia">              
                <div class="row">
                    
                    <div class="col-md-6">
                        <img src="<%: item.UrlImagen%>" class="rounded float-start" ID="imgHistoria" alt="Foto Historia" onerror="this.src='https://st2.depositphotos.com/2926693/5217/v/450/depositphotos_52171865-stock-illustration-happy-cat-and-dog.jpg'">
                    </div>
                     <div class="col-md-6 contenido-texto">
                         <div class="row">
                            <%
                                foreach (Dominio.Usuario useritem in ListaUsuarios)
                                {
                                    if(item.IDUsuario == useritem.Id)
                                    {                        
                                        NombreUsuario=GetUserName(useritem.Email);                        
                                    }
                                }%>
                                <h3 id="nombreUsuario"> <b><%: NombreUsuario %></b> - <%: item.FechaHora %></h3>  
                                <hr />
                            </div>  
                            <div class="row">                              
                                
                                <p id="textoDescripcion"><%: item.Descripcion %></p>
                            </div>            
                        </div>
                        
                    </div>

                </div>
           <% } %>
           
               

              

        
    </section>
</asp:Content>
