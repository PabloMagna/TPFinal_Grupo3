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
    <br />
    <div class="container">
        <div class="row">
            <% foreach (var item in publicaciones)
                { %>
            <div class="col-md-4">
                <div class="card">
                    <img src="<%=obtenerPrimeraImagen(item.IdMascota) %>" style="max-height:19rem" class="card-img-top" alt="<% %>">
                    <div class="card-body">
                        <h5 class="card-title"><%= item.Titulo %></h5>
                        <p class="card-text"><%= item.Descripcion %></p>
                        <a href="publicacion.aspx?=<%= item.Id %>" class="btn btn-primary custom-btn">Ver más</a>

                        <style>
                            .custom-btn {
                                background-color: #C45F2E;
                                border-color: #C45F2E;
                            }

                                .custom-btn:hover {
                                    background-color: #FFA066;
                                    border-color: #FFA066;
                                }
                        </style>

                    </div>
                </div>
            </div>
            <% } %>
        </div>
    </div>
    <br />
</asp:Content>
