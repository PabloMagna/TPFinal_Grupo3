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
                            <% if (adopcionList != null && adopcionList.Count > 0) { %>
                                <h5>Adopciones:</h5>
                                <% bool completadaHeaderShown = false; %>
                                <% bool enProcesoHeaderShown = false; %>
                                <% bool noCompletadaHeaderShown = false; %>
                                <% bool devueltaHeaderShown = false; %>
                                <% foreach (var adopcion in adopcionList) { %>
                                    <% if (adopcion.Estado == Dominio.EstadoAdopcion.Completada) { %>
                                        <% if (!completadaHeaderShown) { %>
                                            <h6>Adopciones exitosas:</h6>
                                            <% completadaHeaderShown = true; %>
                                        <% } %>
                                        <ul>
                                            <% if (!string.IsNullOrEmpty(adopcion.Comentario)) { %>
                                                <li>ID Publicación: <%= adopcion.IDPublicacion %>, Comentario: <%= adopcion.Comentario %></li>
                                            <% } else { %>
                                                <li>ID Publicación: <%= adopcion.IDPublicacion %></li>
                                            <% } %>
                                        </ul>
                                    <% } else if (adopcion.Estado == Dominio.EstadoAdopcion.Pendiente) { %>
                                        <% if (!enProcesoHeaderShown) { %>
                                            <h6>Adopciones en proceso:</h6>
                                            <% enProcesoHeaderShown = true; %>
                                        <% } %>
                                        <ul>
                                            <li>ID Publicación: <%= adopcion.IDPublicacion %></li>
                                        </ul>
                                    <% } else if (adopcion.Estado == Dominio.EstadoAdopcion.RechazadaPorDonante || adopcion.Estado == Dominio.EstadoAdopcion.EliminadaPorAdoptante) { %>
                                        <% if (!noCompletadaHeaderShown) { %>
                                            <h6>Adopciones no completadas:</h6>
                                            <% noCompletadaHeaderShown = true; %>
                                        <% } %>
                                        <ul>
                                            <% if (!string.IsNullOrEmpty(adopcion.Comentario)) { %>
                                                <li>ID Publicación: <%= adopcion.IDPublicacion %>, Comentario: <%= adopcion.Comentario %></li>
                                            <% } else { %>
                                                <li>ID Publicación: <%= adopcion.IDPublicacion %></li>
                                            <% } %>
                                        </ul>
                                    <% } else if (adopcion.Estado == Dominio.EstadoAdopcion.Devuelto) { %>
                                        <% if (!devueltaHeaderShown) { %>
                                            <h6>Animales devueltos luego de adopción:</h6>
                                            <% devueltaHeaderShown = true; %>
                                        <% } %>
                                        <ul>
                                            <% if (!string.IsNullOrEmpty(adopcion.Comentario)) { %>
                                                <li>ID Publicación: <%= adopcion.IDPublicacion %>, Comentario: <%= adopcion.Comentario %></li>
                                            <% } else { %>
                                                <li>ID Publicación: <%= adopcion.IDPublicacion %></li>
                                            <% } %>
                                        </ul>
                                    <% } %>
                                <% } %>
                            <% } %>
                            <% if (publicaciones != null && publicaciones.Count > 0) { %>
                                <h5>Publicaciones:</h5>
                                <ul>
                                    <% foreach (var publicacion in publicaciones) { %>
                                        <% if (publicacion.Estado != Dominio.Estado.EliminadaPorAdmin) { %>
                                            <li>
                                                Título: <%= publicacion.Titulo %>,
                                                <div style="width: 100px; height: 100px; border: 1px solid #ccc; display: flex; align-items: center; justify-content: center;">
                                                    <img src="<%= CargarPrimerImagenPublicacion(publicacion.Id) %>" alt="Imagen de la publicación" style="max-width: 100%; max-height: 100%;">
                                                </div>
                                            </li>
                                        <% } %>
                                    <% } %>
                                </ul>
                            <% } %>
                        <% } else if (refugio != null) { %>
                            <h5 class="card-title"><%= refugio.Nombre %></h5>
                            <p class="card-text">Información del refugio</p>
                            <% if (publicaciones != null && publicaciones.Count > 0) { %>
                                <h5>Publicaciones Históricas Del Usuario:</h5>
                                <ul>
                                    <% foreach (var publicacion in publicaciones) { %>
                                        <% if (publicacion.Estado != Dominio.Estado.EliminadaPorAdmin) { %>
                                            <li>
                                                 - <%= publicacion.Titulo %>,
                                                <div style="width: 100px; height: 100px; border: 1px solid #ccc; display: flex; align-items: center; justify-content: center;">
                                                    <img src="<%= CargarPrimerImagenPublicacion(publicacion.Id) %>" alt="Imagen de la publicación" style="max-width: 100%; max-height: 100%;">
                                                </div>
                                            </li>
                                        <% } %>
                                    <% } %>
                                </ul>
                            <% } %>
                        <% } %>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>
