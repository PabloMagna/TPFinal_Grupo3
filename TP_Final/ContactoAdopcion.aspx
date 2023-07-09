<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ContactoAdopcion.aspx.cs" Inherits="TP_Final.ContactoAdopcion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .card {
            width: 400px;
            padding: 20px;
            text-align: center;
        }

        .card-title {
            font-size: 24px;
            font-weight: bold;
            margin-bottom: 20px;
        }

        .card-text {
            margin-bottom: 10px;
        }

        .btn {
            margin-top: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <div class="container">
        <div class="card">
            <h5 class="card-title">Datos de la publicación</h5>
            <p class="card-text">Título: <%= publicacion.Titulo %></p>
            <p class="card-text">Descripción: <%= publicacion.Descripcion %></p>

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

            <a href="default.aspx" class="btn btn-primary">Volver al Menú</a>
        </div>
    </div>
</asp:Content>
