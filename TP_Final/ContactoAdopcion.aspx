<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ContactoAdopcion.aspx.cs" Inherits="TP_Final.ContactoAdopcion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card">
        <div class="card-body">
            <h5 class="card-title">Datos de la publicación</h5>
            <p class="card-text">Título: <%= publicacion.Titulo %></p>
            <p class="card-text">Descripción: <%= publicacion.Descripcion %></p>
        </div>
    </div>

    <div class="card mt-3">
        <div class="card-body">
            <h5 class="card-title">Datos del donante</h5>
            <% if (usuario.Tipo == Dominio.TipoUsuario.PersonaCompleto) { %>
                <p class="card-text">Nombre: <%= persona.Nombre %></p>
                <p class="card-text">Apellido: <%= persona.Apellido %></p>
                <p class="card-text">Teléfono: <%= persona.Telefono %></p>
                <p class="card-text">Provincia: <%= provincia %></p>
                <p class="card-text">Localidad: <%= localidad %></p>
            <% } else if (usuario.Tipo == Dominio.TipoUsuario.Refugio) { %>
                <p class="card-text">Nombre: <%= refugio.Nombre %></p>
                <p class="card-text">Teléfono: <%= refugio.Telefono %></p>
                <p class="card-text">Provincia: <%= provincia%></p>
                <p class="card-text">Localidad: <%= localidad %></p>
                <p class="card-text">Dirección: <%= refugio.Direccion %></p>
            <% } %>
        </div>
    </div>
    <a href="default.aspx" class="btn btn-primary mt-3">Volver Al Menú</a>
</asp:Content>
