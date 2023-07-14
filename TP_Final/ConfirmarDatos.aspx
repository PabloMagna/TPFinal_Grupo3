<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ConfirmarDatos.aspx.cs" Inherits="TP_Final.ConfirmarDatos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/formPublicacion.css" rel="stylesheet" type="text/css" />    
    <%--scripts para incluir jquery y jquery validation--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery.validate/1.19.1/jquery.validate.min.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery.validation.unobtrusive/3.2.11/jquery.validate.unobtrusive.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="portada">
        <h1 id="titulo">Formulario de solicitud</h1>       
    </section>

    <section class="formulario" id="formulario" runat="server">
        <div class="container row">
            <h1>Confirmar Datos</h1>
            <div class="alert alert-danger" id="lblMessage" runat="server" visible="false"></div>
            <div class="mb-3">
                <label for="txtDni" class="form-label">DNI:</label>
                <asp:TextBox ID="txtDni" TextMode="Number" MaxLength="9" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revDni" runat="server" ControlToValidate="txtDni" ForeColor="Cyan" ErrorMessage="Ingrese solo números, máximo 9 dígitos" ValidationExpression="^\d{7,9}$" SetFocusOnError="true" ValidationGroup="Validaciones"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtDni" ForeColor="Cyan" ErrorMessage="Campo obligatorio" SetFocusOnError="true" ValidationGroup="Validaciones"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ForeColor="Cyan" ErrorMessage="Campo obligatorio" SetFocusOnError="true" ValidationGroup="Validaciones"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revNombre" runat="server" ControlToValidate="txtNombre" ForeColor="Cyan" ErrorMessage="Máximo 19 caracteres" ValidationExpression="^.{0,19}$" SetFocusOnError="true" ValidationGroup="Validaciones"></asp:RegularExpressionValidator>
            </div>
            <div class="mb-3">
                <label for="txtApellido" class="form-label">Apellido:</label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" ForeColor="Cyan" ErrorMessage="Campo obligatorio" SetFocusOnError="true" ValidationGroup="Validaciones"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revApellido" runat="server" ControlToValidate="txtApellido" ForeColor="Cyan" ErrorMessage="Máximo 19 caracteres" ValidationExpression="^.{0,19}$" SetFocusOnError="true" ValidationGroup="Validaciones"></asp:RegularExpressionValidator>
            </div>
            <div class="mb-3">
                <label for="txtFechaNacimiento" class="form-label">Fecha de Nacimiento:</label>
                <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvFechaNac" runat="server" ControlToValidate="txtFechaNacimiento" ForeColor="Cyan" ErrorMessage="Campo obligatorio" SetFocusOnError="true" ValidationGroup="Validaciones"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="cvFechaNac" runat="server" ControlToValidate="txtFechaNacimiento" ForeColor="Cyan" ErrorMessage="Ingrese una fecha válida (desde 1900)" SetFocusOnError="true" OnServerValidate="cvFechaNac_ServerValidate" ValidationGroup="Validaciones"></asp:CustomValidator>
            </div>
            <div class="mb-3">
                <label for="ddlProvincia" class="form-label">Provincia:</label>
                <asp:UpdatePanel ID="updatePanelProvincia" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlProvincia" runat="server" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged"></asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:CustomValidator ID="cvProvincia" runat="server" ControlToValidate="ddlProvincia" ForeColor="Cyan" ErrorMessage="Por favor, seleccione una Provincia" SetFocusOnError="true" OnServerValidate="cvProvincia_ServerValidate" ValidationGroup="Validaciones"></asp:CustomValidator>
            </div>
            <div class="mb-3">
                <label for="ddlLocalidad" class="form-label">Localidad:</label>
                <asp:UpdatePanel ID="updatePanelLocalidad" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlLocalidad" runat="server" CssClass="form-select"></asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlProvincia" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
                <asp:CustomValidator ID="cvLocalidad" runat="server" ControlToValidate="ddlLocalidad" ForeColor="Cyan" ErrorMessage="Por favor, seleccione una Localidad" SetFocusOnError="true" OnServerValidate="cvLocalidad_ServerValidate" ValidationGroup="Validaciones"></asp:CustomValidator>
            </div>
            <div class="mb-3">
                <label for="txtTelefono" class="form-label">Teléfono:</label>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" ForeColor="Cyan" SetFocusOnError="true" ErrorMessage="Campo Obligatorio" ValidationGroup="Validaciones"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txtTelefono" SetFocusOnError="true" ErrorMessage="El teléfono debe contener solo números y tener entre 10 y 20 dígitos" ValidationExpression="^\d{10,20}$" ValidationGroup="Validaciones"></asp:RegularExpressionValidator>
            </div>
            <div class="mb-3">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar y ver Datos de adopcion" CssClass="btn btn-primary" OnClick="btnGuardar_Click" ValidationGroup="Validaciones" />
            </div>
        </div>
    </section>
    
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap/5.0.2/js/bootstrap.bundle.min.js"></script>
</asp:Content>
