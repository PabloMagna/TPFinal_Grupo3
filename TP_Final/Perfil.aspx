<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TP_Final.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <div class="container">

        <div class="row">
            <asp:Label runat="server" ID="lbNombre"></asp:Label>
        </div>
        <div class="container">
            <h2>Tus Publicaciones</h2>
        </div>
        <div class="col-md-8">
            <asp:ScriptManager ID="smTarjetas" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel runat="server" ID="upTarjetas" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="row">
                            <% if (publicaciones == null || publicaciones.Count == 0)
                                {%>
                            <div class="col-md-12">
                                <h1>No tienes Mascotas publicadas </h1>
                            </div>
                            <%}
                                else
                                {%>
                            <% foreach (var item in publicaciones)
                                { %>
                            <div class="col-md-6">
                                <div class="card">
                                    <img src="<%=obtenerPrimeraImagen(item.Id) %>" style="max-height: 19rem" class="card-img-top" alt="<% %>">
                                    <div class="card-body">
                                        <h5 class="card-title"><%= item.Titulo %></h5>
                                        <p class="card-text"><%= item.Descripcion %></p>
                                        <a href="FormPublicacion.aspx?ID=<%= item.Id %>" class="btn btn-primary custom-btn">Editar</a>
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
</asp:Content>
