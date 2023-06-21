<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DetallePublicacion.aspx.cs" Inherits="TP_Final.DetallePublicacion" %>
<%@ Import Namespace="Dominio" %>
<%@ Import Namespace="Negocio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/DetallePublicacion.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="portada">
        <h1 id="titulo">Detalles de la publicación</h1>
        <h4><em>- Ofrece un hogar, recibe felicidad. -</em></h4>
    </section>
    <section class="contenido">   
        <h4>Próximamente... <iconify-icon icon="fluent-emoji-flat:dog" width="48px"></iconify-icon></h4>
    </section>
    <section class="Detalle">
        <div class="card text-center">
            <div id="carouselExample" class="carousel slide" data-bs-ride="carousel">
                <div class="carousel-inner">
                    <% foreach (var imagen in listaImagenes) { %>
                        <div class="carousel-item <% if (imagen == listaImagenes[0]) { %>active<% } %>">
                            <img src="<%= imagen %>" class="d-block w-100" alt="Imagen de mascota" style="max-height:20rem; max-width:20rem">
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
            <div class="card-body">
                <h5 class="card-title"><%= publicacion.Titulo %></h5>
                <p class="card-text"><%= publicacion.Descripcion %></p>
                <p class="card-text">ID: <%= publicacion.Id %></p>
                <p class="card-text">Especie: <%= publicacion.Especie %></p>
                <p class="card-text">Raza: <%= publicacion.Raza %></p>
                <p class="card-text">Edad: <%= publicacion.Edad %></p>
                <p class="card-text">Sexo: <%= publicacion.Sexo %></p>
                <p class="card-text">Fecha y hora: <%= publicacion.FechaHora.ToString() %></p>
                <p class="card-text">Estado: <%= publicacion.Estado %></p>
                <p class="card-text">ID Localidad: <%= publicacion.IDLocalidad %></p>
                <p class="card-text">ID Provincia: <%= publicacion.IDProvincia %></p>
            </div>
        </div>
    </section>
</asp:Content>
