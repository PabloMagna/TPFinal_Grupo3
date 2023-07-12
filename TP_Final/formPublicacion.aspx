﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="formPublicacion.aspx.cs" Inherits="TP_Final.Publicar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Alta Publicacion</title>
    <link href="css/formPublicacion.css" rel="stylesheet" type="text/css" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server"></asp:ScriptManager>

    <section class="portada">
        <h1 id="titulo">Publicación de mascota en adopción</h1>
        <h4 id="subtitulo" runat="server"><em>Necesitaremos que completes algunos datos.</em></h4>
    </section>
    <%if (Request.QueryString["ID"] != null && ObtenerEstadoPublicacion() == Dominio.Estado.Suspendida)
        {  %>
        <h4>Tu publicacion esta pausada clica aqui para Activarla</h4>
    <%} %>
    <section class="formulario" id="formulario" runat="server">
        <div class="row">
            <div class="col-4">
                <asp:Label ID="lbTitulo" runat="server" CssClass="titulo">Formulario de alta de Publicación</asp:Label>

                <div class="mb-3">
                    <asp:Label ID="lblErrorForm" runat="server" Text=""></asp:Label>
                </div>
                <div class="mb-3">
                    <label class="form-label">Nombre de la Mascota *</label>
                    <asp:TextBox ID="tbNombre" runat="server" class="form-control" placeholder="Wolfy"></asp:TextBox>
                    <asp:Label ID="LblErrorTitulo" runat="server" Text=""></asp:Label>
                </div>

                <div class="mb-3">
                    <label class="form-label">Especie *</label>
                    <asp:DropDownList ID="ddlEspecie" runat="server" class="form-select" AutoPostBack="false">
                        <asp:ListItem Selected="True" Text="Perro" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Gato" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Otro" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label class="form-label">Raza </label>
                    <asp:TextBox ID="tbRaza" runat="server" class="form-control" placeholder="Chiguagua / Siamés"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Edad *</label>
                    <asp:TextBox ID="tbEdad" runat="server" Type="number" min="1" class="form-control"></asp:TextBox>
                    <asp:Label ID="lblErrorEdad" runat="server" Text=""></asp:Label>
                </div>
                <div class="mb-3">
                    <label class="form-label">Seleccione unidad de tiempo *</label>
                    <asp:DropDownList ID="ddlEdad" runat="server" class="form-select" AutoPostBack="false">
                        <asp:ListItem Text="Años" Value="A"></asp:ListItem>
                        <asp:ListItem Text="Meses" Value="M"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label class="form-label">Sexo *</label>
                    <asp:DropDownList ID="ddlSexo" runat="server" class="form-select" AutoPostBack="false">
                        <asp:ListItem Text="Macho" Value="M"></asp:ListItem>
                        <asp:ListItem Selected="True" Text="Hembra" Value="H"></asp:ListItem>
                        <asp:ListItem Text="Desconoce" Value="D"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label class="form-label">Provincia *</label>
                    <asp:UpdatePanel runat="server" ID="updatePanelProvincia">
                        <ContentTemplate>
                            <asp:DropDownList runat="server" ID="ddlProvincia" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged"></asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="mb-3">
                    <label class="form-label">Localidad *</label>
                    <asp:UpdatePanel runat="server" ID="updatePanelLocalidad">
                        <ContentTemplate>
                            <asp:DropDownList runat="server" ID="ddlLocalidad" CssClass="form-select"></asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="mb-3">
                    <label class="form-label">Descripción la publicación *</label>
                    <asp:TextBox ID="tbDescripcion" runat="server" class="form-control" TextMode="MultiLine" Rows="5" MaxLength="500" placeholder="Características de la mascota, Condiciones de adopción, etc."></asp:TextBox>
                    <asp:Label ID="lblErrorDescripcion" runat="server" Text=""></asp:Label>
                </div>
                <hr />
                <div class="mb-3">
                    <label class="form-label">IMÁGENES DE LA MASCOTA</label>
                </div>

                <%
                    if (existeImagen == true)
                    {
                        int i = 0;
                        int j = 0;
                %>

                <div id="carouselExampleIndicators" class="carousel slide">
                    <div class="carousel-indicators">

                        <%
                            foreach (Dominio.ImagenMascota img in listaImg)
                            {
                        %>
                        <%if (i == 0)
                            {%>
                        <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="<%=i %>" class="active" aria-current="true" aria-label="Slide <%= i %>"></button>
                        <%}
                            else
                            {%>
                        <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="<%=i %>" aria-current="true" aria-label="Slide <%= i %>"></button>
                        <%}%>

                        <%
                                i++;
                            }%>
                    </div>
                    <div class="carousel-inner">
                        <%
                            foreach (Dominio.ImagenMascota img in listaImg)
                            {
                        %>
                        <%if (j == 0)
                            {%>
                        <div class="carousel-item active">
                            <img src="<%=img.urlImagen%>" class="d-block w-100" alt="Img Publicación <%=img.IdPublicacion %>" onerror="this.src='https://static.vecteezy.com/system/resources/previews/007/301/664/non_2x/adopt-a-dog-help-the-homeless-animals-find-a-home-cartoon-illustration-vector.jpg'">
                        </div>
                        <%}
                            else
                            {%>
                        <div class="carousel-item">
                            <img src="<%=img.urlImagen%>" class="d-block w-100" alt="Img Publicación <%=img.IdPublicacion %>" onerror="this.src='https://static.vecteezy.com/system/resources/previews/007/301/664/non_2x/adopt-a-dog-help-the-homeless-animals-find-a-home-cartoon-illustration-vector.jpg'">
                        </div>
                        <%}%>

                        <%
                                j++;
                            }%>
                    </div>
                    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </button>
                </div>
                <hr />
                <div class="mb-3">
                    <label class="form-label">¿QUERÉS BORRAR ALGUNA IMAGEN?</label>
                </div>
                <div class="mb-3">
                    <asp:Button ID="btnBorrar" runat="server" Text="Borrar imágenes" CssClass="btn primary borrar" OnClick="btnBorrar_Click" />
                </div>
                <hr />
                <div class="mb-3">
                    <label class="form-label">¿QUERÉS AGREGAR OTRA IMAGEN?</label>
                </div>
                <%}%>

                <div class="mb-3">
                    <label class="form-label">Subir desde el ordenador</label>
                    <input type="file" id="tbImgFile" accept="image/jpeg, image/png, image/jpg" runat="server" class="form-control" />
                </div>



                <!--Botones-->
                <div class="mb-3">
                    <%if (Request.QueryString["ID"] != null)
                        {%>
                    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn primary" OnClick="btnActualizar_Click" />
                    <%}
                        else
                        {%>
                    <asp:Button ID="btnAceptar" runat="server" Text="Enviar" CssClass="btn primary" OnClick="btnAceptar_Click" />

                    <%}%>
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn primary" OnClick="btnCancelar_Click" />
                </div>

            </div>
        </div>
    </section>
    <section id="altaExitosa" class="altaExitosa" runat="server">
        <h3 id="h3alta">¡Gracias!</h3>
        <p>
            La publicación se realizó correctamente.<br />
            Porás verta en la sección de mascotas <a href="galeria.aspx">en adopción</a>.
        </p>
    </section>
    <%if (Request.QueryString["ID"] != null) {  %>
        <section id="formularioOculto" class="formularioOculto" runat="server">
            <div class="contenidoForm">
                <asp:Button ID="btn_expandir" runat="server" Text="Borrar Publicacion" class="btn border-orange" OnClick="btn_expandir_Click" />
                <div class="formularioH" id="formularioH" runat="server" style="display: none;">
                    <div class="card card-body">
                        <h4>Opciones de baja:</h4>
                        <asp:RadioButtonList ID="rbOpcionesBaja" runat="server">
                            <asp:ListItem Text="Eliminar publicación" Value="EliminarPublicacion" />
                            <asp:ListItem Text="Eliminar por Adopción Concretada" Value="EliminarAdopcion" />
                            <asp:ListItem Text="Suspender Publicación (No se muestra en galería - cancela solicitudes)" Value="SuspenderPublicacion" />
                        </asp:RadioButtonList>
                        <asp:Button ID="btnConfirmarAccion" runat="server" Text="Confirmar Acción" CssClass="btn" OnClick="btnConfirmarAccion_Click" />
                    </div>
                </div>
            </div>
        </section>
    <%} %>


</asp:Content>
