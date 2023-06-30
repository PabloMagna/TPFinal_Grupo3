<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="TP_Final.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Favoritos</title>
    <link href="css/galeria.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server"></asp:ScriptManager>
    <section class="portada">
        <h1 id="titulo">Mis Favoritos</h1>
    </section>
    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-8">
                <asp:UpdatePanel runat="server" ID="updatePanelTarjetas" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="row">
                            <% if (favoritos == null || favoritos.Count == 0)
                                {%>
                            <div class="col-md-12">
                                <h1>No tienes publicaciones guardadas en favoritos.</h1>
                            </div>
                            <%}
                                else
                                {%>
                            <% foreach (var item in favoritos)
                                {
                                    Session["idFav"] = item.Id;  %>
                            <div class="col-md-6">
                                <div class="card">
                                    <img src="<%= obtenerPrimeraImagen(item.Id) %>" style="max-height: 19rem" class="card-img-top" alt="<% %>">
                                    <div class="card-body">
                                        <h5 class="card-title"><%= item.Titulo %></h5>
                                        <p class="card-text"><%= item.Descripcion %></p>
                                        <a href="DetallePublicacion.aspx?ID=<%= item.Id %>" class="btn btn-primary custom-btn">Ver más</a>
                                        <asp:Button runat="server" ID="btnQuitarFavorito" Text="Quitar de favoritos" OnClick="btnQuitarFavorito_Click" CssClass="btn btn-primary custom-btn" Style="margin-top: 5px;" />
                                    </div>
                                </div>
                            </div>
                            <% }
                                } %>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <br />
</asp:Content>
