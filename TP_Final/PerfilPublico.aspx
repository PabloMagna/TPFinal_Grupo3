<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PerfilPublico.aspx.cs" Inherits="TP_Final.PerfilPublico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/perfilPublico.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex justify-content-center">
        <div class="row">
            <div class="col-md-12 container d-flex justify-content-center">
                <div class="card">
                    <div class="card-body">
                        <% if (persona != null)
                        { %>
                        <h2 class="card-title"><%=persona.Nombre +" "+ persona.Apellido %></h2>
                        <%if (persona.UrlImagen != null)
                            { %>
                        <img style="max-height:300px; max-width:300px" src="<%=persona.UrlImagen %>" alt="Alternate Text" onerror="this.src='https://static.vecteezy.com/system/resources/previews/007/301/664/non_2x/adopt-a-dog-help-the-homeless-animals-find-a-home-cartoon-illustration-vector.jpg'" /> <%--PONER PLAHCEHOLDER IMAGEN SI ES NULL, TAMBIEN MAS ABAJO EN REFUGIO--%>
                        <%} %>
                        <h5 class="card-text">Provincia: <%=BuscarProvinciaPorID(persona.IDProvincia)%></h5>
                        <h5 class="card-text">Localidad: <%=BuscarLocalidadPorID(persona.IDLocalidad)%></h5>
                        
                        

                        <% if (adopcionList != null && adopcionList.Count > 0)
                            { %>
                        <hr />

                        <h3>Adopciones:</h3>
                        <% bool completadaHeaderShown = false; %>
                        <% bool enProcesoHeaderShown = false; %>
                        <% bool noCompletadaHeaderShown = false; %>
                        <% bool devueltaHeaderShown = false; %>
                        <% foreach (var adopcion in adopcionList)
                            { %>
                        <% if (adopcion.Estado == Dominio.EstadoAdopcion.Completada)
                            { %>
                        <% if (!completadaHeaderShown)
                            { %>
                        <h4>Adopciones exitosas:</h4>
                        <% completadaHeaderShown = true; %>
                        <% } %>
                        <ul>
                            <% if (!string.IsNullOrEmpty(adopcion.Comentario))
                                { %>
                            <li> <%= BuscarNombrePublicacionPorId(adopcion.IDPublicacion) %>- Comentario: <%= adopcion.Comentario %></li>
                            <% }
                            else
                            { %>
                            <li><%= BuscarNombrePublicacionPorId(adopcion.IDPublicacion) %></li>
                            <% } %>
                        </ul>
                        <% }
                            else if (adopcion.Estado == Dominio.EstadoAdopcion.Pendiente)
                            { %>
                        <% if (!enProcesoHeaderShown)
                            { %>
                        <h6>Adopciones en proceso:</h6>
                        <% enProcesoHeaderShown = true; %>
                        <% } %>
                        <ul>
                            <li> <%= BuscarNombrePublicacionPorId(adopcion.IDPublicacion) %></li>
                        </ul>
                        <% }
                            else if (adopcion.Estado == Dominio.EstadoAdopcion.RechazadaPorDonante || adopcion.Estado == Dominio.EstadoAdopcion.EliminadaPorAdoptante)
                            { %>
                        <% if (!noCompletadaHeaderShown)
                            { %>
                        <h6>Adopciones no completadas:</h6>
                        <% noCompletadaHeaderShown = true; %>
                        <% } %>
                        <ul>
                            <% if (!string.IsNullOrEmpty(adopcion.Comentario))
                                { %>
                            <li> <%= BuscarNombrePublicacionPorId(adopcion.IDPublicacion)%>- Comentario: <%= adopcion.Comentario %></li>
                            <% }
                            else
                            { %>
                            <li> <%= BuscarNombrePublicacionPorId(adopcion.IDPublicacion)%></li>
                            <% } %>
                        </ul>
                        <% }
                            else if (adopcion.Estado == Dominio.EstadoAdopcion.Devuelto)
                            { %>
                        <% if (!devueltaHeaderShown)
                            { %>
                        <h6>Animales devueltos luego de adopción:</h6>
                        <% devueltaHeaderShown = true; %>
                        <% } %>
                        <ul>
                            <% if (!string.IsNullOrEmpty(adopcion.Comentario))
                                { %>
                            <li> <%= BuscarNombrePublicacionPorId(adopcion.IDPublicacion) %>- Comentario: <%= adopcion.Comentario %></li>
                            <% }
                            else
                            { %>
                            <li> <%= BuscarNombrePublicacionPorId(adopcion.IDPublicacion) %></li>
                            <% } %>
                        </ul>
                        <% } %>
                        <% } %>
                        <% } %>
                        <% if (publicaciones != null && publicaciones.Count > 0)
                            { %>

                        <hr />

                        <h5>Publicaciones:</h5>
                        <ul>
                            <% foreach (var publicacion in publicaciones)
                                { %>
                            <% if (publicacion.Estado != Dominio.Estado.EliminadaPorAdmin)
                                { %>
                            <li>Título: <%= publicacion.Titulo %>,
                                                <div style="height: 150px; border: 1px solid #ccc; display: flex; align-items: center; justify-content: center; background-color: #D2E3EB;">
                                                    <img src="<%= CargarPrimerImagenPublicacion(publicacion.Id) %>" alt="Imagen de la publicación" style="max-width: 100%; max-height: 100%;" onerror="this.src='https://static.vecteezy.com/system/resources/previews/007/301/664/non_2x/adopt-a-dog-help-the-homeless-animals-find-a-home-cartoon-illustration-vector.jpg'"/>
                                                </div>
                            </li>
                            <% } %>
                            <% } %>
                        </ul>
                        <% } %>
                        <% }
                        else if (refugio != null)
                        { %>
                        <h2 class="card-title"><%=refugio.Nombre%></h2>
                        <%if (refugio.UrlImagen != null)
                            { %>
                        <img style="max-height:300px; max-width:300px" src="<%=refugio.UrlImagen %>" alt="Alternate Text" onerror="this.src='https://static.vecteezy.com/system/resources/previews/007/301/664/non_2x/adopt-a-dog-help-the-homeless-animals-find-a-home-cartoon-illustration-vector.jpg'"/>
                        <%} %>
                        <h5 class="card-text">Provincia: <%=BuscarProvinciaPorID(refugio.IDProvincia)%></h5>
                        <h5 class="card-text">Localidad: <%=BuscarLocalidadPorID(refugio.IDLocalidad)%></h5>
                        <% if (publicaciones != null && publicaciones.Count > 0)
                            { %>
                        <hr />
                        <h5>Publicaciones Históricas Del Usuario:</h5>
                        <ul>
                            <% foreach (var publicacion in publicaciones)
                                { %>
                            <% if (publicacion.Estado != Dominio.Estado.EliminadaPorAdmin)
                                { %>
                            <li>- <%= publicacion.Titulo %>,
                                                <div style="height: 150px; border: 1px solid #ccc; display: flex; align-items: center; justify-content: center; background-color: #D2E3EB;">
                                                    <img src="<%= CargarPrimerImagenPublicacion(publicacion.Id) %>" alt="Imagen de la publicación" style="max-width: 100%; max-height: 100%;" onerror="this.src='https://static.vecteezy.com/system/resources/previews/007/301/664/non_2x/adopt-a-dog-help-the-homeless-animals-find-a-home-cartoon-illustration-vector.jpg'"/>
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
