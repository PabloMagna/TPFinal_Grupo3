<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DetallePublicacion.aspx.cs" Inherits="TP_Final.DetallePublicacion" %>

<%@ Import Namespace="Dominio" %>
<%@ Import Namespace="Negocio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/DetallePublicacion.css" rel="stylesheet" type="text/css" />
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
                    </div>
                </div>
                <div class="col-md-6">
                    <div id="carouselExample" class="carousel slide" data-bs-ride="carousel">
                        <div class="carousel-inner">
                            <% foreach (var imagen in listaImagenes) { %>
                                <div class="carousel-item <% if (imagen == listaImagenes[0]) { %>active<% } %>">
                                    <img src="<%= imagen %>" class="d-block w-100" alt="Imagen de mascota">
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
</asp:Content>
