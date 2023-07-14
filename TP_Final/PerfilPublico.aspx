<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PerfilPublico.aspx.cs" Inherits="TP_Final.PerfilPublico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <div class="card">
                    <div class="card-body">
                        <% if (persona != null) { %>
                            <h5 class="card-title"><%= persona.Nombre %></h5>
                            <p class="card-text">Información de la persona</p>
                        <% } else if (refugio != null) { %>
                            <h5 class="card-title"><%= refugio.Nombre %></h5>
                            <p class="card-text">Información del refugio</p>
                        <% } %>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>
