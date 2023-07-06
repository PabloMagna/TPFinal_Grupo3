<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TP_Final.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Perfil.css" rel="stylesheet" />
    <script src="https://kit.fontawesome.com/f9b631791e.js" crossorigin="anonymous"></script>
    <%--scripts para incluir jquery y jquery validation--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery.validate/1.19.1/jquery.validate.min.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery.validation.unobtrusive/3.2.11/jquery.validate.unobtrusive.min.js"></script>
    <%--GOOGLE FONTS--%>
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Roboto&display=swap');
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <aside>
        <button id="btnSideBar" class="btn btn-primary" type="button" data-bs-toggle="offcanvas"
            data-bs-target="#offcanvasScrolling" aria-controls="offcanvasScrolling">
            EditarPerfil</button>

        <div class="offcanvas offcanvas-start" data-bs-scroll="true" data-bs-backdrop="false" tabindex="-1"
            id="offcanvasScrolling" aria-labelledby="offcanvasScrollingLabel">
            <div class="offcanvas-header">
                <h5 class="offcanvas-title" id="offcanvasScrollingLabel">Perfil de Usuario</h5>
                <button type="button" class="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
            </div>
            <div class="offcanvas-body">
                <p>Estas son las opciones de navegacion del menú de usuario</p>
                <ul>
                    <li><a href="#">Editar datos de Perfil</a></li>
                    <li><a href="#">Foto de Perfil</a></li>
                    <li><a href="Perfil.aspx#Historias">Tus Historias</a></li>
                    <li><a href="Perfil.aspx#Publicaciones">Tus Publicaciones</a></li>
                </ul>
                <button class="btn btn-primary">Boton</button>
            </div>
        </div>
    </aside>
    <div class="container">

        <div class="row" id="Publicaciones">
            <asp:Label runat="server" ID="lbNombre"></asp:Label>
        </div>
        <div class="container">
            <h2>Tus Publicaciones</h2>
        </div>
        <div class="col-md-8">
            <asp:ScriptManager ID="smTarjetas" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel runat="server" ID="upTarjetas" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="row">
                        <% if (publicaciones == null || publicaciones.Count == 0)
                            {%>
                        <div class="col-md-12">
                            <h1>No tienes Mascotas publicadas </h1>
                        </div>
                        <%}%>

                        <%else
                            {%>
                        <% foreach (var item in publicaciones)
                            { %>
                        <div class="col-md-6">
                            <div class="card">
                                <img src="<%=obtenerPrimeraImagen(item.Id) %>" style="max-height: 19rem" class="card-img-top" alt="<% %>">
                                <div class="card-body">
                                    <h5 class="card-title"><%= item.Titulo %></h5>
                                    <p class="card-text"><%= item.Descripcion %></p>
                                    <a href="FormPublicacion.aspx?ID=<%= item.Id %>" class="btn btn-primary custom-btn">Editar</a>
                                </div>
                            </div>
                        </div>
                        <% }
                            } %>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <hr />

        <%--Este es solo un div para posicionar en historias con click en el Sidebar--%>
        <div id="Historias"></div>

        <% if (historias == null || historias.Count == 0)
            { %>
        <div class="col-md-12">
            <h1>Las historias están disponibles para quienes adopten Mascotas </h1>
        </div>
        <% }
            else
            { %>
        <asp:Repeater ID="rpHistorias" runat="server">
            <ItemTemplate>
                <div class="row Historias">
                    <h2>Tus Historias
                <iconify-icon icon="fluent-emoji-high-contrast:paw-prints" width="25px"></iconify-icon>
                    </h2>
                    <div class="card card-body">

                        <div class="mb-3">
                            <img id="imgHistoria" src="<%# Eval("UrlImagen") %>"></img>
                            <label class="form-label">Cambiar foto</label>
                            <input type="file" id="tbImgenFile" accept="image/jpeg, image/png, image/jpg" runat="server" class="form-control" />
                            <asp:Label ID="lblErrorImg" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="mb-3">
                            <asp:TextBox ID="tbDescripcion" runat="server" class="form-control" TextMode="MultiLine" Rows="5" MaxLength="300" Text='<%# Eval("Descripcion") %>'></asp:TextBox>
                            <asp:Label ID="lblErrorDescripcion" runat="server" Text=""></asp:Label>
                        </div>
                        <asp:Button ID="btnAceptar" runat="server" Text="Aplicar Cambios" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
                        <asp:HiddenField ID="hfIDHistoria" runat="server" Value='<%# Eval("ID") %>' />
                        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Eliminar" />
                    </div>
                </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <% }

        %>
        <hr />

        <%if (userLogeado.Tipo == Dominio.TipoUsuario.Persona)
            {
        %>
        <div class="container perfil">

            <div class="row">
                <div id="formPersona" runat="server">
                    <h2>Edita tus datos de perfil</h2>
                    <div class="mb-3">
                        <label class="form-label">Nombre </label>
                        <asp:TextBox ID="tbNombre" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="tbNombre" ForeColor="Cyan" ErrorMessage="Campo obligatorio" SetFocusOnError="true" ValidationGroup="ValPersona"></asp:RequiredFieldValidator>
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Apellido</label>
                        <asp:TextBox ID="tbApellido" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="tbApellido" ForeColor="Cyan" ErrorMessage="Campo obligatorio" SetFocusOnError="true" ValidationGroup="ValPersona"></asp:RequiredFieldValidator>
                    </div>
                    <div class="mb-3">
                        <label class="form-label">DNI</label>
                        <asp:TextBox ID="tbDni" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDni" runat="server" ControlToValidate="tbDni" ForeColor="Cyan" ErrorMessage="Campo Obligatorio" SetFocusOnError="true" ValidationGroup="ValPersona"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revDni" runat="server" ControlToValidate="tbDni" ForeColor="Cyan" ErrorMessage="Ingrese solo números, maximo 12 digitos" ValidationExpression="^\d{1,12}$" SetFocusOnError="true" ValidationGroup="ValPersona"></asp:RegularExpressionValidator>
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Fecha de Nacimiento </label>
                        <asp:TextBox ID="tbFechaNac" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFechaNac" runat="server" ControlToValidate="tbFechaNac" ForeColor="Cyan" ErrorMessage="Campo obligatorio" SetFocusOnError="true" ValidationGroup="ValPersona"></asp:RequiredFieldValidator>
                    </div>
                    <div class="mb-3">
                        <label class="form-label" for="tbTel">Telefono</label>
                        <asp:TextBox ID="tbTel" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="tbTel" ForeColor="Cyan" SetFocusOnError="true" ErrorMessage="Campo Obligatorio" ValidationGroup="ValPersona"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="tbTel" SetFocusOnError="true" ErrorMessage="El teléfono debe contener solo números y tener entre 10 y 20 dígitos" ValidationExpression="^\d{10,20}$" ValidationGroup="ValPersona"></asp:RegularExpressionValidator>
                    </div>
                </div>

            </div>
            <%}
                else
                { %>



            <%} %>

            <%--LOCALIDADES Y PROVINCIAS--%>
            <div class="mb-3">
                <label for="ddlProvincia" class="form-label">Provincia:</label>
                <asp:UpdatePanel ID="updatePanelProvincia" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlProvincia" runat="server" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged"></asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="mb-3">
                <label for="ddlLocalidad" class="form-label">Localidad:</label>
                <asp:UpdatePanel ID="updatePanelLocalidad" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlLocalidad" runat="server" CssClass="form-select"></asp:DropDownList>
                    </ContentTemplate>
                    <%--  <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddlProvincia" EventName="SelectedIndexChanged" />
                </Triggers>--%>
                </asp:UpdatePanel>
            </div>

            <%--IMAGEN DE USUARIO PERSONA O REFUGIO Implementar funcion para cambiar--%>
            <div class="mb-3 contenedorImgPerfil">
                <label id="lbImgPerfil" for="tbUrlImg" class="form-label">Imagen de Perfil</label>
                <img id="imgPerfil" runat="server" src="" class="imgPerfil" alt="foto de perfil" onerror="this.onerror=null; 
            this.src='<%:placeholderImg %>;'" />
            </div>
            <div class="mb-3">
                <label class="form-label">Subir desde el ordenador</label>
                <input type="file" id="tbImgFile" accept="image/jpeg, image/png, image/jpg" runat="server" class="form-control" />
            </div>
            <div class="mb-3">
                <asp:Button ID="Modificar" runat="server" Text="Guardar" OnClick="Modificar_Click" class="btn btn-light" CausesValidation="true" />
            </div>
        </div>
    
</asp:Content>
