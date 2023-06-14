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
                        <img src="<%https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRteDCJTNhFoqZxxumlkvXtuFfktSVlkCt-KavF5Gul&s %>" class="card-img-top" alt="<% %>">
                        <div class="card-body">
                            <h5 class="card-title"><%= item.Titulo %></h5>
                            <p class="card-text"><%= item.Descripcion %></p>
                            <a href="#" class="btn btn-primary">Ver más</a>
                        </div>
                    </div>
                </div>
            <% } %>
        </div>
    </div>
</asp:Content>
