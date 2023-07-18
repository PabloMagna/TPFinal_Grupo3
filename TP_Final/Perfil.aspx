<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TP_Final.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Perfil.css" rel="stylesheet" />
    <script src="https://kit.fontawesome.com/f9b631791e.js" crossorigin="anonymous"></script>
    <!--scripts para incluir jquery y jquery validation-->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery.validate/1.19.1/jquery.validate.min.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery.validation.unobtrusive/3.2.11/jquery.validate.unobtrusive.min.js"></script>

    <!--SCRIPTS DE VALIDACION(CLIENTE)-->
    <script>
        function soloLetras(event) {
            var charCode = event.keyCode || event.which;

            // Permitir tecla Backspace (8) y tecla Delete (46)
            if (charCode === 8 || charCode === 46) {
                return true;
            }

            var charStr = String.fromCharCode(charCode);
            var pattern = /^[A-Za-z]+$/;

            if (!pattern.test(charStr)) {
                event.preventDefault();
                return false;
            }
        }
    </script>
    <script>
        function soloNumeros(event) {
            var charCode = event.keyCode || event.which;

            // Permitir tecla Backspace (8) y tecla Delete (46)
            if (charCode === 8 || charCode === 46) {
                return true;
            }

            var charStr = String.fromCharCode(charCode);
            var pattern = /^\d+$/;

            if (!pattern.test(charStr)) {
                event.preventDefault();
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="portada">
        <h1 id="titulo">Editar datos de Perfil</h1>
    </section>

<section class="menu-tabs">
    <ul class="nav nav-tabs">
        <% if (userLogeado.Tipo == Dominio.TipoUsuario.PersonaCompleto || userLogeado.Tipo == Dominio.TipoUsuario.Refugio) { %>
        <li class="nav-item">
            <a class="nav-link" href="Perfil.aspx#DatosPerfil">Datos de Perfil</a>
        </li>
          <%  if (userLogeado.Tipo == Dominio.TipoUsuario.PersonaCompleto || userLogeado.Tipo == Dominio.TipoUsuario.Persona)
         {
        %>
        <li class="nav-item">
            <a class="nav-link" href="Perfil.aspx#Historias">Historias</a>
        </li>
        <%} %>
        <li class="nav-item">
            <a class="nav-link" href="Perfil.aspx#Publicaciones" tabindex="-1" aria-disabled="true">Tus Publicaciones</a>
        </li>
        <% } %>
        <% if (userLogeado.Tipo == Dominio.TipoUsuario.PersonaCompleto) { %>
        <li class="nav-item">
            <a class="nav-link" href="Adopciones.aspx">Adopciones</a>
        </li>
        <% } %>
    </ul>
</section>


    <section class="perfil-section">    
        <h2 class="titulo">Tus Publicaciones</h2>
        <!--SECCION PUBLICACIONES-->
        <div class="row">
            <asp:Label runat="server" ID="lbNombre"></asp:Label>
        </div>
        <div class="col-md-12">
            <asp:ScriptManager ID="smTarjetas" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel runat="server" ID="upTarjetas" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="row">
                        <% if (publicaciones == null || publicaciones.Count == 0)
                            {%>
                        <div class="col-md-12">
                            <h3 class="leyenda">No tienes Mascotas publicadas </h3>
                        </div>
                        <%}%>

                        <%else
                        {%>
                            <% foreach (var item in publicaciones)
                                { %>
                                <div class="col-md-4">
                                    <div class="card">
                                        <img src="<%=obtenerPrimeraImagen(item.Id) %>" style="max-height: 19rem" class="card-img-top" alt="Imagen mascota" onerror="this.src = '/imagenes/pet_placeholder.png'">
                                        <div class="card-body">
                                            <div class="content-text">
                                                <h5 class="card-title"><%= item.Titulo %></h5>
                                                <% if (item.Estado == Dominio.Estado.Pausada)
                                                    { %>
                                                <div class="card-text">
                                                    <div class="alert alert-warning" role="alert">
                                                        Publicación Pausada
                                                    </div>
                                                </div>
                                                <% } %>
                                                <% if (item.Estado == Dominio.Estado.FinalizadaConExito)
                                                    { %>
                                                <div class="card-text">
                                                    <div class="alert alert-success" role="alert">
                                                        Adopción Concretada
                                                    </div>
                                                </div>
                                                <% } %>
                                                <p class="card-text"><%= item.Descripcion %></p>
                                            </div>
                                            <div class="botonesPerfil">
                                                <a href="FormPublicacion.aspx?ID=<%= item.Id %>" class="btn btn-primary btn-perfil">Editar</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            <% }
                          } %>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </section>
    <hr />
   
      <%  if (userLogeado.Tipo != Dominio.TipoUsuario.Refugio)
         {
        %>
    <section class="perfil-section">
       

        <h2 id="Historias" class="titulo">Tus Historias 
            <iconify-icon icon="fluent-emoji-high-contrast:paw-prints" width="25px"></iconify-icon>
        </h2>
       

        <% if ((historias == null || historias.Count == 0) && userLogeado.Tipo == Dominio.TipoUsuario.PersonaCompleto )
            { %>
        <div class="col-md-12">
            <h3 class="leyenda">No tienes historias compartidas</h3>
        </div>
        <% }
            else if (userLogeado.Tipo == Dominio.TipoUsuario.PersonaCompleto )
            {
        %>
            <asp:Repeater ID="rpHistorias" runat="server">
                <ItemTemplate>
                    <div class="container Historias">

                        <div class="card-body">

                            <div class="row">
                                <img id="imgHistoria" class="imagenPreview" src='<%# Eval("UrlImagen") %>' alt="Imagen Mascota" onerror="this.src = '/imagenes/pet_placeholder.png'">
                                <label class="form-label">Cambiar foto</label>
                            </div>
                            <div class="mb-3">
                                <input type="file" id="tbImagenHistoria" runat="server" accept="image/jpeg, image/png, image/jpg" onchange="previewImageHistoria(this)" class="form-control" />
                            </div>
                            <script>
                                function previewImageHistoria(input) {
                                    if (input.files && input.files[0]) {
                                        var reader = new FileReader();

                                        reader.onload = function (e) {
                                            var imgElement = input.parentNode.previousElementSibling.querySelector(".imagenPreview");
                                            imgElement.src = e.target.result;
                                        };

                                        reader.readAsDataURL(input.files[0]);
                                    }
                                }
                            </script>
                            <div class="mb-3">
                                <asp:TextBox ID="tbDescripcion" runat="server" class="form-control" TextMode="MultiLine" Rows="5" MaxLength="300" Text='<%# Eval("Descripcion") %>'></asp:TextBox>
                                <asp:Label ID="lblErrorDescripcion" runat="server" Text=""></asp:Label>
                            </div>
                            <asp:HiddenField ID="hfIDHistoria" runat="server" Value='<%# Eval("ID") %>' />
                            <div class="contenedorBotones">
                                <asp:Button ID="btnAceptar" runat="server" Text="Aplicar Cambios" CssClass="btn btn-primary btn-perfil" OnClick="btnAceptar_Click" />
                                <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Eliminar" CssClass="btn btn-red btn-perfil" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <% }
            else if (userLogeado.Tipo == Dominio.TipoUsuario.Persona)
            {%>
        <div class="col-md-12">
            <h3 class="leyenda">Completa registro para poder acceder a todo el contenido del Sitio </h3>
        </div>
        <% } %>
    </section>
    <hr />
    <% }
        %>
    <section class="perfil-section" id="DatosPerfil">
        <h2 class="titulo">Datos del perfil</h2>
        <%  if (userLogeado.Tipo == Dominio.TipoUsuario.PersonaCompleto || userLogeado.Tipo == Dominio.TipoUsuario.Persona)
        {
        %>
    <div class="container perfil">
        <div class="row">
            <div id="formPersona" runat="server">                
                <div class="mb-3">
                    <label class="form-label smallCamp">Nombre </label>
                    <asp:TextBox ID="tbNombre" runat="server" class="form-control" MaxLength="20" onkeydown="return soloLetras(event);" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="tbNombre" ForeColor="Red" ErrorMessage="Campo obligatorio" SetFocusOnError="true" ValidationGroup="ValPersona"></asp:RequiredFieldValidator>
                </div>
                <div class="mb-3">
                    <label class="form-label">Apellido</label>
                    <asp:TextBox ID="tbApellido" runat="server" class="form-control" MaxLength="20" onkeydown="return soloLetras(event);"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="tbApellido" ForeColor="Red" ErrorMessage="Campo obligatorio" SetFocusOnError="true" ValidationGroup="ValPersona"></asp:RequiredFieldValidator>
                </div>
                <div class="mb-3">
                    <label class="form-label">DNI</label>
                    <asp:TextBox ID="tbDni" runat="server" class="form-control" MaxLength="10" onkeypress="return soloNumeros(event);"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDni" runat="server" ControlToValidate="tbDni" ForeColor="Red" ErrorMessage="Campo Obligatorio" SetFocusOnError="true" ValidationGroup="ValPersona"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revDni" runat="server" ControlToValidate="tbDni" ForeColor="Red" ErrorMessage="Ingrese solo números, maximo 10 digitos" ValidationExpression="^\d{1,10}$" SetFocusOnError="true" ValidationGroup="ValPersona"></asp:RegularExpressionValidator>
                </div>
                <div class="mb-3">
                    <label class="form-label">Fecha de Nacimiento </label>
                    <asp:TextBox ID="tbFechaNac" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFechaNac" runat="server" ControlToValidate="tbFechaNac" ForeColor="Red" ErrorMessage="Campo obligatorio" SetFocusOnError="true" ValidationGroup="ValPersona"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
    </div>
    <%}
        else
        {
    %>
    <div id="formRefugio" class="container divForm" runat="server">
        <div class="mb-3">
            <label class="form-label">Nombre del Refugio </label>
            <asp:TextBox ID="tbNombreRefugio" runat="server" CssClass="form-control" MaxLength="20" onkeydown="return soloLetras(event);"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNombreRefugio" runat="server" ControlToValidate="tbNombreRefugio" ForeColor="Red" ErrorMessage="Campo obligatorio" SetFocusOnError="true" ValidationGroup="ValRefugio"></asp:RequiredFieldValidator>
        </div>
        <div class="mb-3">
            <label class="form-label">Dirección </label>
            <asp:TextBox ID="tbDireccion" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="tbDireccion" ForeColor="Red" ErrorMessage="Campo obligatorio" SetFocusOnError="true" ValidationGroup="ValRefugio"></asp:RequiredFieldValidator>
        </div>
    </div>
    <%} %>
    <div class="container divForm">
        <div class="mb-3">
            <label class="form-label">Telefono</label>
            <asp:TextBox ID="tbTel" runat="server" class="form-control" MaxLength="20" onkeypress="return soloNumeros(event);"></asp:TextBox>
        </div>
        <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="tbTel" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Campo Obligatorio" ValidationGroup="ValAmbos"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="tbTel" SetFocusOnError="true" ForeColor="Red" ErrorMessage="Números entre 10 y 20 dígitos" ValidationExpression="^\d{10,20}$" ValidationGroup="ValAmbos"></asp:RegularExpressionValidator>
        <div class="mb-3">
            <label for="ddlProvincia" class="form-label">Provincia:</label>
            <asp:UpdatePanel ID="updatePanelProvincia" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlProvincia" runat="server" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged"></asp:DropDownList>
                    <asp:CustomValidator ID="cvProvincia" runat="server" ControlToValidate="ddlProvincia" ForeColor="Red" ErrorMessage="Por favor, seleccione una Provincia" SetFocusOnError="true" OnServerValidate="cvProvincia_ServerValidate" ValidationGroup="ValAmbos"></asp:CustomValidator>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="mb-3">
            <label for="ddlLocalidad" class="form-label">Localidad:</label>
            <asp:UpdatePanel ID="updatePanelLocalidad" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlLocalidad" runat="server" CssClass="form-select"></asp:DropDownList>
                    <asp:CustomValidator ID="cvLocalidad" runat="server" ControlToValidate="ddlLocalidad" ForeColor="Red" ErrorMessage="Por favor, seleccione una Localidad" SetFocusOnError="true" OnServerValidate="cvLocalidad_ServerValidate" ValidationGroup="ValAmbos"></asp:CustomValidator>
                </ContentTemplate>
            
            </asp:UpdatePanel>
        </div>
        <% if (userLogeado.Tipo != Dominio.TipoUsuario.Persona)
            { %>
        <asp:UpdatePanel ID="upImgPerfil" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="mb-3 contenedorImgPerfil">
                    <label id="lbImgPerfil" for="tbUrlImg" class="form-label">Imagen de Perfil</label>
                    <img id="imgPerfil" runat="server" src='<%=urlImgUser %>' class="imgPerfil" alt="foto de perfil" onerror="this.src=<%:placeholderImg %>;'" />
                    <script>
                        function previewImage(input) {
                            if (input.files && input.files[0]) {
                                var reader = new FileReader();

                                reader.onload = function (e) {
                                    document.getElementById('<%= imgPerfil.ClientID %>').setAttribute('src', e.target.result);
                                };

                                reader.readAsDataURL(input.files[0]);
                            }
                        }
                    </script>
                    <div class="mb-3">
                        <label class="form-label">Subir desde el ordenador</label>
                        <input type="file" id="tbImgFile" accept="image/jpeg, image/png, image/jpg" runat="server" onchange="previewImage(this)" class="form-control" />
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <% } %>
        <div class="mb-3">
            <asp:Button ID="Modificar" runat="server" Text="Guardar" OnClick="Modificar_Click" class="btn btn-primary btn-perfil" CausesValidation="true" />
        </div>
    </div>
    </section>
</asp:Content>