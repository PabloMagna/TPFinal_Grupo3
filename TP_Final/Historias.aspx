<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Historias.aspx.cs" Inherits="TP_Final.Historias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Historias</title>
    <link href="css/Historias.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="portada">
        <h1 id="titulo">Relatos de adopciones a través de Pet Net.</h1>       
    </section>
     <section id="altaExitosa" class="altaExitosa" runat="server">
        <h3 id="h3alta">¡Gracias por compartirnos tu historia!</h3>
        <p>La publicación se realizó correctamente.<br /> Porás verla en esta misma sección de <a href="Historias.aspx">historias</a>.</p>
    </section>
    
    <section id="formularioOculto" class="formularioOculto" runat="server">
        <%if (Session["Usuario"] != null && ((Dominio.Usuario)Session["Usuario"]).Tipo != Dominio.TipoUsuario.Refugio)
        {%>
            <div class="contenidoForm">
                <asp:Button ID="btn_expandir" runat="server" Text="Contanos tu historia" class="btn border-orange" Onclick="btnExpandir_Click" />
                  
                
                <div class="formularioH" id="formularioH" runat="server">
                    <div class="card card-body">                     
                            <div class="mb-3">
                                <asp:TextBox ID="tbDescripcion" runat="server" class="form-control" TextMode="MultiLine" Rows="5" MaxLength="300" placeholder="Compartinos tu experiencia luego de la adopción..."></asp:TextBox>
                                <asp:Label ID="lblErrorDescripcion" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="mb-3">
                                <label class="form-label">Añadir una foto</label>
                                <input type="file" id="tbImgFile" accept="image/jpeg, image/png, image/jpg" runat="server" class="form-control"/>  
                                <asp:Label ID="lblErrorImg" runat="server" Text=""></asp:Label>
                            </div>
                        <asp:Button ID="btnAceptar" runat="server" Text="Enviar" CssClass="btn" OnClick="btnAceptar_Click"/>   
                    </div>
                </div>
            </div> 
         <%
        } %>  
    
        </section>
    
        <section class="contenidoHistorias" runat="server" id="contenidoHistorias">
            <%for (var i = ListaHistorias.Count()-1; i>=0; i--)
                {%>         
                     <%
                         Dominio.Historia item = ListaHistorias[i];
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
