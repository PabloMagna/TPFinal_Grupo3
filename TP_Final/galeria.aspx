<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="galeria.aspx.cs" Inherits="TP_Final.galeria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>En Adopcion</title>
    <link href="css/galeria.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="portada">
        <h1 id="titulo">Adoptá, salvá una vida</h1>
        <h4><em>- Ayudalos a encontrar un lugar donde pertenecer -</em></h4>
    </section>
      <div class="container">
        <div class="row">
            <% foreach (var item in publicaciones) { %>
                <div class="col-md-4">
                    <div class="card">
                        <img src="<%=obtenerPrimeraImagen(item.IdMascota) %>" class="card-img-top" alt="<% %>">
                        <div class="card-body">
                            <h5 class="card-title"><%= item.Titulo %></h5>
                            <p class="card-text"><%= item.Descripcion %></p>
                            <a href="#" class="btn btn-primary" style="background-color:#C45F2E">Ver más</a> 
                        </div>
                    </div>
                </div>
            <% } %>
        </div>
    </div>
</asp:Content>
