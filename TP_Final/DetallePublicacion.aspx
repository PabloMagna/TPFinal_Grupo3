<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DetallePublicacion.aspx.cs" Inherits="TP_Final.DetallePublicacion" %>

<%@ Import Namespace="Dominio" %>
<%@ Import Namespace="Negocio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/DetallePublicacion.css" rel="stylesheet" type="text/css" />
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Roboto:wght@300&display=swap');
    </style>
    <style>
        /* Estilos personalizados */
        .carousel-item img {
            max-height: 30rem;
            max-width: 30rem;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="portada">
        <h1 id="titulo">Detalles de la publicación</h1>
        <h4><em>- Ofrece un hogar, recibe felicidad. -</em></h4>
    </section>
    <br />
    <div class="container">
        <section class="Detalle">
            <div class="btnVolver">
                <a href="/galeria.aspx">
                    <img src="imagenes/leftarrow.png" class="volver" /></a>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="card-body">
                        <h5 class="card-title"><%= publicacion.Titulo %></h5>
                        <p class="card-text"><%= publicacion.Descripcion %></p>
                        <p class="card-text">Especie: <%= CargarEspecie() %></p>
                        <p class="card-text">Raza: <%= publicacion.Raza %></p>
                        <p class="card-text">Edad: <%= CargarEdad() %></p>
                        <p class="card-text">Sexo: <%= CargarSexo() %></p>
                        <p class="card-text">Localidad: <%= CargarLocalidad() %></p>
                        <p class="card-text">Provincia: <%= CargarProvincia() %></p>
                        <p class="card-text">Fecha y hora: <%= publicacion.FechaHora.ToString() %></p>
                        <p class="card-text">Estado: <%= publicacion.Estado %></p>
                        <%if (Session["Usuario"] != null)
                            {
                                if (ComprobarAdopcion(((Usuario)Session["Usuario"]).Id, publicacion.Id))
                                { %>
                        <div>
                            <h5>Ya estás en Proceso de Adopción con este animal</h5>
                        </div>
                        <asp:Button ID="btnFavorito" runat="server" CssClass="btn btn-primary" OnClick="btnFavorito_Click" Text="Agregar a favoritos" />
                        <%}
                            else if (publicacion.Estado == Estado.EnProceso)
                            {%>
                        <div>
                            <h5>Publicacion Pausada por estar en proceso de Adopcion</h5>
                        </div>
                        <asp:Button ID="btnFavorito2" runat="server" CssClass="btn btn-primary" OnClick="btnFavorito_Click" Text="Agregar a favoritos" />
                        <%}
                            else
                            {%>
                        <a href="ConfirmarDatos.aspx?ID=<%= publicacion.Id %>" class="btn btn-primary">Adoptar</a>
                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" OnClick="btnFavorito_Click" Text="Agregar a favoritos" />
                        <%}
                            }
                            else
                            {%>
                        <a href="Login.aspx" class="btn btn-primary">Adoptar</a>
                        <a href="Login.aspx" class="btn btn-primary">Agregar a Favoritos</a>
                        <%} %>
                    </div>
                </div>
                <div class="col-md-6">
                    <div id="carouselExample" class="carousel slide" data-bs-ride="carousel">
                        <div class="carousel-inner">
                            <% foreach (var imagen in listaImagenes)
                                { %>
                            <div class="carousel-item <% if (imagen == listaImagenes[0])
                                { %>active<% } %>">
                                <img src="<%= imagen %>" class="d-block w-100" alt="Imagen de mascota" onerror="this.src='https://static.vecteezy.com/system/resources/previews/007/301/664/non_2x/adopt-a-dog-help-the-homeless-animals-find-a-home-cartoon-illustration-vector.jpg'">
                            </div>
                            <% } %>
                        </div>
                        <a class="carousel-control-prev" href="#carouselExample" role="button" data-bs-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Anterior</span>
                        </a>
                        <a class="carousel-control-next" href="#carouselExample" role="button" data-bs-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Siguiente</span>
                        </a>
                    </div>
                </div>
            </div>
        </section>
    </div>

    <%--COMENTARIOS--%>

    <%if (comentarios.Count() > 0)
        {
            int i = 0;%>
    <% foreach (var coment in comentarios)
        {
    %>
    <section class="container-sm comentarios">
        <div class="cabecera">
            <img class="imgUser" src="<%:camposUsuario[i].UrlImg %>" onerror="this.onerror=null; 
            this.src='<%:ImgPlaceHolder %>;'" />
            <label name="Nombre-Usuario" class="lbNombre"><%:camposUsuario[i].Nombre %></label>
            <label class="fecha"><%=coment.FechaHora.ToString()%></label>
        </div>
        <div class="comentario">
            <p id="pComentario"><%=coment.Descripcion %></p>
        </div>
    </section>

    <% i++;
        } %>
    <%} %>

    <%--INSERTAR COMENTARIO--%>
    <div class="row-cols-4">
    </div>
    <section class="container-sm nuevoComent">
        <div class="cabecera Usuario">
            <img id="imgComentador" class="imgUser" src="<%:camposSesion.UrlImg %>" onerror="this.onerror=null; 
            this.src='<%:ImgPlaceHolder %>;'" />
            <label id="lbNombreLogeado" class="lbNombre"><%:camposSesion.Nombre %></label>
        </div>
        <asp:TextBox ID="tbNuevoComentario" runat="server" TextMode="MultiLine" Rows="5" CssClass="form-control Campo" MaxLength="300"></asp:TextBox>
        <div class="containerBtn">
            <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" CssClass="btn btn-primary" />
        </div>
    </section>

</asp:Content>
