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
                <p class="card-text">DNI: <%= persona.Dni %></p>
                <p class="card-text">Teléfono: <%= persona.Telefono %></p>
                <p class="card-text">Localidad: <%= persona.IDLocalidad %></p>
                <p class="card-text">Provincia: <%= persona.IDProvincia %></p>
            <% } else if (usuario.Tipo == Dominio.TipoUsuario.Refugio) { %>
                <p class="card-text">Nombre: <%= refugio.Nombre %></p>
                <p class="card-text">Dirección: <%= refugio.Direccion %></p>
                <p class="card-text">Teléfono: <%= refugio.Telefono %></p>
                <p class="card-text">Localidad: <%= refugio.IDLocalidad %></p>
                <p class="card-text">Provincia: <%= refugio.IDProvincia %></p>
            <% } %>
        </div>
    </div>

    <button type="button" class="btn btn-primary mt-3">Confirmar adopción</button>
</asp:Content>
