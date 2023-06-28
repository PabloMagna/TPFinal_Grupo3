<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DetallePublicacion.aspx.cs" Inherits="TP_Final.DetallePublicacion" %>

<%@ Import Namespace="Dominio" %>
<%@ Import Namespace="Negocio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/DetallePublicacion.css" rel="stylesheet" type="text/css" />
    <style>
    @import url('https://fonts.googleapis.com/css2?family=Roboto:wght@300&display=swap');
    </style>
    <style>
        /* Estilos personalizados */
        .carousel-item img {
            max-height: 30rem;
            max-width: 30rem;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="portada">
        <h1 id="titulo">Detalles de la publicación</h1>
        <h4><em>- Ofrece un hogar, recibe felicidad. -</em></h4>
    </section>
    <br />
    <div class="container">
        <section class="Detalle">
            <div class="btnVolver">
                <a href="/galeria.aspx">
                <img src="imagenes/leftarrow.png" class="volver" /></a>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="card-body">
                        <h5 class="card-title"><%= publicacion.Titulo %></h5>
                        <p class="card-text"><%= publicacion.Descripcion %></p>
                        <p class="card-text">Especie: <%= CargarEspecie() %></p>
                        <p class="card-text">Raza: <%= publicacion.Raza %></p>
                        <p class="card-text">Edad: <%= CargarEdad() %></p>
                        <p class="card-text">Sexo: <%= CargarSexo() %></p>
                        <p class="card-text">Localidad: <%= CargarLocalidad() %></p>
                        <p class="card-text">Provincia: <%= CargarProvincia() %></p>
                        <p class="card-text">Fecha y hora: <%= publicacion.FechaHora.ToString() %></p>
                        <p class="card-text">Estado: <%= publicacion.Estado %></p>
                        <asp:Button id="btAdoptar" runat="server" CssClass="btn btn-primary custom-btn" Text="Adoptar" OnClick="btAdoptar_Click"/>
                    </div>
                </div>
                <div class="col-md-6">
                    <div id="carouselExample" class="carousel slide" data-bs-ride="carousel">
                        <div class="carousel-inner">
                            <% foreach (var imagen in listaImagenes) { %>
                                <div class="carousel-item <% if (imagen == listaImagenes[0]) { %>active<% } %>">
                                    <img src="<%= imagen %>" class="d-block w-100" alt="Imagen de mascota">
                                </div>
                            <% } %>
                        </div>
                        <a class="carousel-control-prev" href="#carouselExample" role="button" data-bs-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Anterior</span>
                        </a>
                        <a class="carousel-control-next" href="#carouselExample" role="button" data-bs-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Siguiente</span>
                        </a>
                    </div>
                </div>
            </div>
        </section>
    </div>

    <%--COMENTARIOS--%>
    <section class="container-sm comentarios">
        <div class="cabecera">
            <asp:Image ID="imgUsuario" runat="server" CssClass="imgUser" ImageUrl="https://img.freepik.com/vector-premium/historieta-divertida-cara-perrito-beagle_42750-489.jpg?w=2000" />
            <asp:Label ID="lbNombreUsuario" CssClass="lbNombre" runat="server">Joaquin pepe</asp:Label>
                <asp:Label ID="fechaComentario" runat="server" CssClass="fecha">28/06/2023 01:12</asp:Label>
        </div>
      <div class="comentario">
          <%--<asp:TextBox ID="tbComentario" runat="server" CssClass="form-control tbComentario" TextMode="MultiLine">
              Qué hermoso perro, espero que encuentre un hogar pronto Lorem ipsum,
          dolor sit amet consectetur adipisicing elit. Nobis inventore quisquam
          quas? Illum officia voluptate fugiat voluptatibus non nobis doloribus
          eligendi. Dolorum animi, possimus illum dolores at delectus nobis
          nemo!          </asp:TextBox>--%>

          <p id="pComentario" runat="server"> Qué hermoso perro, espero que encuentre un hogar pronto Lorem ipsum,
          dolor sit amet consectetur adipisicing elit. Nobis inventore quisquam
          quas? Illum officia voluptate fugiat voluptatibus non nobis doloribus
          eligendi. Dolorum animi, possimus illum dolores at delectus nobis</p>
        <%--<p>
          Qué hermoso perro, espero que encuentre un hogar pronto Lorem ipsum,
          dolor sit amet consectetur adipisicing elit. Nobis inventore quisquam
          quas? Illum officia voluptate fugiat voluptatibus non nobis doloribus
          eligendi. Dolorum animi, possimus illum dolores at delectus nobis
          nemo!
        </p>--%>
      </div>

      <%--<div class="cabecera">
            <img 
                src=""
              />
            <label>Nombre Usuario<label>
                <span id="fecha">28/06/2023 01:00</span>
        </div>
      <div class="comentario">
        <p>
          Qué hermoso perro, espero que encuentre un hogar pronto Lorem ipsum,
          dolor sit amet consectetur adipisicing elit. Nobis inventore quisquam
          quas? Illum officia voluptate fugiat voluptatibus non nobis doloribus
          eligendi. Dolorum animi, possimus illum dolores at delectus nobis
          nemo!
        </p>
      </div>--%>
     
    </section>

    <%--INSERTAR COMENTARIO--%>
    <div class="row-cols-4">
    </div>
    <section class="container-sm nuevoComent">
      <div class="cabecera Usuario">
       <%-- <img 
            src="https://img.freepik.com/vector-gratis/ilustracion-icono-vector-dibujos-animados-lindo-gato-sentado-concepto-icono-naturaleza-animal-aislado-premium-vector-estilo-dibujos-animados-plana_138676-4148.jpg?w=2000"
          />--%>
          <asp:Image id="imgComentador" runat="server" CssClass="imgUser" ImageUrl="https://img.freepik.com/vector-gratis/ilustracion-icono-vector-dibujos-animados-lindo-gato-sentado-concepto-icono-naturaleza-animal-aislado-premium-vector-estilo-dibujos-animados-plana_138676-4148.jpg?w=2000"/>
          <asp:Label ID="lbNombreComentador" runat="server" CssClass="lbNombre">Nombre Usuario</asp:Label>
        <%--<label>Nombre Usuario</label>--%>
    </div>
        <asp:TextBox ID="tbNuevoComentario" runat="server" TextMode="MultiLine" Rows="5" CssClass="form-control Campo" ></asp:TextBox>
    <div class="containerBtn">
     <%-- <button  ID="btnEnviar" type="button" class="btn btn-primary">Enviar</button>--%>
        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="btn btn-primary"/>
    </div>
    </section>

</asp:Content>
