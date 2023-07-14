<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AltaCuenta.aspx.cs" Inherits="TP_Final.AltaCuenta" EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/AltaCuenta.css" rel="stylesheet" type="text/css" />
    <%--scripts para incluir jquery y jquery validation--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery.validate/1.19.1/jquery.validate.min.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery.validation.unobtrusive/3.2.11/jquery.validate.unobtrusive.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="smUbicacion" runat="server"></asp:ScriptManager>
    <section class="portada">
        <h1 id="titulo">Gracias por ser parte del cambio</h1>        
    </section>
    <section class="formulario">
        <div class="row">
            <div class="col-4">
                <asp:Label ID="lbTitulo" runat="server" CssClass="titulo">Alta de Usuario</asp:Label>

                <div class="mb-3">
                    <asp:UpdatePanel ID="upEmail" runat="server">
                        <ContentTemplate>

                            <label class="form-label">Email </label>
                            <asp:TextBox ID="tbEmail" runat="server" AutoPostBack="true" class="form-control"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="tbEmail" ForeColor="Cyan" ErrorMessage="Campo Obligatorio" SetFocusOnError="true" ValidationGroup="Validaciones"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="tbEmail" ForeColor="Cyan" ErrorMessage="Formato inválido" SetFocusOnError="true" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" ValidationGroup="Validaciones"></asp:RegularExpressionValidator>
                </div>
                <div class="mb-3">
                    <label class="form-label">Password </label>
                    <asp:TextBox ID="tbPassword" runat="server" class="form-control" AutoPostBack="false" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="tbPassword" ForeColor="Cyan" ErrorMessage="Campo obligatorio" SetFocusOnError="true" ValidationGroup="Validaciones"></asp:RequiredFieldValidator>
                </div>     

                <%if (Cuenta=="Refugio")
            { %>


                <%--Opciones exclusivas para Refugio--%>
                <div id="formRefugio" runat="server">
                    <div class="mb-3">
                        <label class="form-label">Nombre del Refugio </label>
                        <asp:TextBox ID="tbNombreRefugio" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNombreRefugio" runat="server" ControlToValidate="tbNombreRefugio" ForeColor="Cyan" ErrorMessage="Campo obligatorio" SetFocusOnError="true" ValidationGroup="Validaciones"></asp:RequiredFieldValidator>
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Dirección </label>
                        <asp:TextBox ID="tbDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="tbDireccion" ForeColor="Cyan" ErrorMessage="Campo obligatorio" SetFocusOnError="true" ValidationGroup="Validaciones"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <%--Drop down's de Provincias y Localidades--%>
                <asp:UpdatePanel ID="upUbicacion" runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <label class="form-label">Seleccione una Provincia</label>
                            <asp:DropDownList ID="ddlProvincia" runat="server" AutoPostBack="true" class="form-select" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:CustomValidator ID="cvProvincia" runat="server" ControlToValidate="ddlProvincia" ForeColor="Cyan" ErrorMessage="Por favor, seleccione una Provincia" SetFocusOnError="true" OnServerValidate="cvProvincia_ServerValidate" ValidationGroup="Validaciones"></asp:CustomValidator>
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Seleccione una Localidad</label>
                            <asp:DropDownList ID="ddlLocalidad" runat="server" class="form-select" AutoPostBack="false" OnLoad="ddlLocalidad_Load">
                            </asp:DropDownList>
                            <asp:CustomValidator ID="cvLocalidad" runat="server" ControlToValidate="ddlLocalidad" ForeColor="Cyan" ErrorMessage="Por favor, seleccione una Localidad" SetFocusOnError="true" OnServerValidate="cvLocalidad_ServerValidate" ValidationGroup="Validaciones"></asp:CustomValidator>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <div class="mb-3">
                    <label class="form-label">Telefono</label>
                    <asp:TextBox ID="tbTelefono" runat="server" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="tbTelefono" ForeColor="Cyan" SetFocusOnError="true" ErrorMessage="Campo Obligatorio" ValidationGroup="Validaciones"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="tbTelefono" SetFocusOnError="true" ErrorMessage="El teléfono debe contener solo números y tener entre 10 y 20 dígitos" ValidationExpression="^\d{10,20}$" ValidationGroup="Validaciones"></asp:RegularExpressionValidator>
                </div>
            <% } %>

                <%--Botones--%>
                <div class="mb-3">
                    <%--Enviar--%>
                    <asp:Button ID="btnEnviar" runat="server" Text="Enviar" class="btn btn-light" OnClick="btnEnviar_Click" CausesValidation="true" ValidationGroup="Validaciones" />
                    <%--Cancelar--%>
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn primary" OnClick="btnCancelar_Click" CausesValidation="false" />
                </div>
            </div>

        </div>
    </section>
</asp:Content>
