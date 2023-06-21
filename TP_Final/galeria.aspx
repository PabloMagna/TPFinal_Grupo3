<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="galeria.aspx.cs" Inherits="TP_Final.galeria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>En Adopcion</title>
    <link href="css/galeria.css" rel="stylesheet" type="text/css" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server"></asp:ScriptManager>
    <section class="portada">
        <h1 id="titulo">Adoptá, salvá una vida</h1>
        <h4><em>- Ayudalos a encontrar un lugar donde pertenecer -</em></h4>
    </section>
    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <br />
                <section class="filtro mt-3">
                    <div class="form-group mb-3">
                        <asp:UpdatePanel runat="server" ID="updatePanelProvincia">
                            <ContentTemplate>
                                <asp:DropDownList runat="server" ID="ddlProvincia" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged"></asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="form-group mb-3">
                        <asp:UpdatePanel runat="server" ID="updatePanelLocalidad">
                            <ContentTemplate>
                                <asp:DropDownList runat="server" ID="ddlLocalidad" CssClass="form-select"></asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="form-group mb-3">
                        <asp:DropDownList runat="server" ID="ddlEspecies" CssClass="form-select"></asp:DropDownList>
                    </div>
                    <div class="form-group mb-3">
                        <asp:DropDownList runat="server" ID="ddlSexo" CssClass="form-select"></asp:DropDownList>
                    </div>
                    <div class="form-group mb-3 d-flex align-items-center">
                        <asp:DropDownList runat="server" ID="ddlMesAnio" CssClass="form-control me-2"></asp:DropDownList>
                        <asp:TextBox runat="server" ID="txtEdad" TextMode="Number" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group mb-3">
                        <asp:TextBox runat="server" ID="txtRaza" CssClass="form-control" placeholder="Buscar Por Raza"></asp:TextBox>
                    </div>
                    <div class="form-group mb-3">
                        <asp:Button runat="server" ID="btnFiltrar" Text="Filtrar" OnClick="btnFiltrar_Click" CssClass="btn btn-primary"></asp:Button>
                        <asp:Button runat="server" ID="btnRemoverFiltro" Text="Remover Filtro" OnClick="btnRemoverFiltro_Click" CssClass="btn btn-primary"></asp:Button>
                    </div>
                </section>
            </div>
            <div class="col-md-8">
                <div class="row">
                    <% if (publicaciones == null || publicaciones.Count == 0)
                        {%>
                    <div class="col-md-12">
                        <h1>No se encontraron resultados</h1>
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
                                <a href="DetallePublicacion.aspx?ID=<%= item.Id %>" class="btn btn-primary custom-btn">Ver más</a>
                            </div>
                        </div>
                    </div>
                    <% }
                        } %>
                </div>
            </div>
        </div>
    </div>
    <br />
</asp:Content>
