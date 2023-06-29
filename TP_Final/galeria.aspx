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
                <section class="filtro mt-3">
                    <asp:UpdatePanel runat="server" ID="updatePanelProvincia">
                        <ContentTemplate>
                            <div class="bg-orange rounded p-3">
                                <h3 class="text-white">FILTROS</h3>
                                <div class="form-group mb-3">
                                    <asp:Label runat="server" ID="lblProvincia" Text="Elige Provincia:" CssClass="form-label text-white"></asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlProvincia" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <div class="form-group mb-3">
                                    <asp:Label runat="server" ID="lblLocalidad" Text="Elige Localidad:" CssClass="form-label text-white"></asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlLocalidad" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="ddlLocalidad_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <div class="form-group mb-3">
                                    <asp:Label runat="server" ID="lblEspecie" Text="Elige Especie:" CssClass="form-label text-white"></asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlEspecies" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="ddlEspecies_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <div class="form-group mb-3">
                                    <asp:Label runat="server" ID="lblSexo" Text="Elige Sexo:" CssClass="form-label text-white"></asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlSexo" CssClass="form-select" AutoPostBack="true" OnTextChanged="ddlSexo_TextChanged"></asp:DropDownList>
                                </div>
                                <div class="form-group mb-3">
                                    <asp:Label runat="server" ID="lblEdad" Text="Elige Edad:" CssClass="form-label text-white"></asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlEdad" CssClass="form-select" AutoPostBack="true" OnTextChanged="ddlEdad_TextChanged"></asp:DropDownList>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </section>
            </div>
            <div class="col-md-8">
                <asp:UpdatePanel runat="server" ID="updatePanelTarjetas" UpdateMode="Conditional">
                    <ContentTemplate>
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
                                    <img src="<%=obtenerPrimeraImagen(item.Id) %>" style="max-height: 19rem" class="card-img-top" alt="<% %>" onerror="this.src='https://static.vecteezy.com/system/resources/previews/007/301/664/non_2x/adopt-a-dog-help-the-homeless-animals-find-a-home-cartoon-illustration-vector.jpg'">
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
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <br />
</asp:Content>
