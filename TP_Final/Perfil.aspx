<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TP_Final.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Perfil.css" rel="stylesheet" />
    <script src="https://kit.fontawesome.com/f9b631791e.js" crossorigin="anonymous"></script>
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
                    <li><a href="#">Tus Historias</a></li>
                    <li><a href="#">Tus Publicaciones</a></li>
                </ul>
                <button class="btn btn-primary">Boton</button>
            </div>
        </div>
    </aside>
    <div class="container">

        <div class="row">
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
                        <%}
                            else
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


        <% if (historias == null || historias.Count == 0)
            { %>
        <div class="col-md-12">
            <h1>Las historias están disponibles para quienes adopten Mascotas </h1>
        </div>
        <% }
            else
            { %>
        <asp:Repeater ID="rpHistorias" runat="server" OnItemCommand="rpHistorias_ItemCommand">
            <ItemTemplate>
                <div class="row Historias">
                    <h2>Tus Historias
                <iconify-icon icon="fluent-emoji-high-contrast:paw-prints" width="25px"></iconify-icon>
                    </h2>
                    <div class="card card-body">

                        <div class="mb-3">
                            <img src="<%# Eval("UrlImagen") %>"></img>
                            <label class="form-label">Cambiar foto</label>
                            <input type="file" id="tbImgenFile" accept="image/jpeg, image/png, image/jpg" runat="server" class="form-control" />
                            <asp:Label ID="lblErrorImg" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="mb-3">
                            <asp:TextBox ID="tbDescripcion" runat="server" class="form-control" TextMode="MultiLine" Rows="5" MaxLength="300" Text='<%# Eval("Descripcion") %>'></asp:TextBox>
                            <asp:Label ID="lblErrorDescripcion" runat="server" Text=""></asp:Label>
                        </div>
                        <asp:Button ID="btnAceptar" runat="server" Text="Aplicar Cambios" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
                        <asp:HiddenField id="hfIDHistoria" runat="server" Value='<%# Eval("ID") %>'/>
                        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Eliminar" />
                        <asp:LinkButton ID="lbtnDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("ID") %>' CssClass="fas fa-trash-alt" style="color: #e97a2f;"></asp:LinkButton>
                    </div>
                </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <% } %>
    </div>
</asp:Content>
