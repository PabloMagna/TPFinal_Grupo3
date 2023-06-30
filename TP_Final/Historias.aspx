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
    <section class="formularioOculto">
        <div class="contenidoForm">
             <p>
          <a class="btn btn-primary" data-bs-toggle="collapse" href="#collapseExample" role="button" aria-expanded="false" aria-controls="collapseExample">
           Contanos tu historia
          </a>
          
        </p>
        <div class="collapse" id="collapseExample">
            <div class="card card-body">
            Acá va el form
            </div>
            <button class="btn btn-primary" type="button" >
            Enviar
          </button>
        </div>
        </div>
       
    </section>
    <section class="contenidoHistorias" runat="server">
        <%foreach (Dominio.Historia item in ListaHistorias)
            {%>         
                 <%
                    foreach (Dominio.Usuario useritem in ListaUsuarios)
                    {
                        if(item.IDUsuario == useritem.Id)
                        {                        
                            NombreUsuario=GetUserName(useritem.Email);                        
                        }
                    }%>
                    <div class="card div_historia">                            
                    <img id="imgHistoria" src="<%: item.UrlImagen%>" class="card-img-top" alt="Foto Historia" onerror="this.src='https://st2.depositphotos.com/2926693/5217/v/450/depositphotos_52171865-stock-illustration-happy-cat-and-dog.jpg'">
                    <div class="card-body">
                        <h5 class="card-title"><%: NombreUsuario %></h5>
                        <p class="card-text"><%: item.Descripcion %></p>
                        <footer class="blockquote-footer"><cite title="Source Title">Publicado </cite><%: item.FechaHora %></footer>
                    </div>
                    <hr />
                </div>                
           <% } %>     
    </section>
</asp:Content>
