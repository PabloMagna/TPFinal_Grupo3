<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AltaCuenta.aspx.cs" Inherits="TP_Final.AltaCuenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/AltaCuenta.css" rel="stylesheet" type="text/css" />
    <%--scripts para incluir jquery y jquery validation--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery.validate/1.19.1/jquery.validate.min.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery.validation.unobtrusive/3.2.11/jquery.validate.unobtrusive.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <section class="portada">
        <h1 id="titulo">Gracias por ser parte del cambio</h1>
        <h4><em>Vamos a necesitar que completes algunos datos.</em></h4>
    </section>
    <section class="formulario">
        <div class="row">
            <div class="col-4">
                <asp:Label ID="lbTitulo" runat="server" CssClass="titulo">Alta de Usuario</asp:Label>

                <div class="mb-3">
                    <label class="form-label">Email </label>
                    <asp:TextBox ID="tbEmail" runat="server" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="tbEmail" ForeColor="Cyan" ErrorMessage="Campo Obligatorio"></asp:RequiredFieldValidator>
                </div>
                <div class="mb-3">
                    <label class="form-label">Password </label>
                    <asp:TextBox ID="tbPassword" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="tbPassword" ForeColor="Cyan" ErrorMessage="Campo obligatorio"></asp:RequiredFieldValidator>
                </div>
                <%-- Opciones exclusivas para Persona   --%>
                <div id="formPersona" runat="server">
                    <div class="mb-3">
                        <label class="form-label">Nombre </label>
                        <asp:TextBox ID="tbNombre" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" Enabled="false" ControlToValidate="tbNombre" ForeColor="Cyan" ErrorMessage="Campo obligatorio"></asp:RequiredFieldValidator>
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Apellido</label>
                        <asp:TextBox ID="tbApellido" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvApellido" runat="server" Enabled="false" ControlToValidate="tbApellido" ForeColor="Cyan" ErrorMessage="Campo obligatorio"></asp:RequiredFieldValidator>
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Fecha de Nacimiento </label>
                        <asp:TextBox ID="tbFechaNac" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFechaNac" runat="server" ControlToValidate="tbFechaNac" ForeColor="Cyan" ErrorMessage="Campo obligatorio"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <%--Opciones exclusivas para Refugio--%>
                <div id="formRefugio" runat="server">
                    <div class="mb-3">
                        <label class="form-label">Nombre del Refugio </label>
                        <asp:TextBox ID="tbNombreRefugio" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNombreRefugio" runat="server" ControlToValidate="tbNombreRefugio" ForeColor="Cyan" ErrorMessage="Campo obligatorio"></asp:RequiredFieldValidator>
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Dirección </label>
                        <asp:TextBox ID="tbDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="tbDireccion" ForeColor="Cyan" ErrorMessage="Campo obligatorio" ></asp:RequiredFieldValidator>
                    </div>
                </div>
                
                <div class="mb-3">
                    <label class="form-label">Seleccione una Provincia</label>
                    <asp:DropDownList ID="ddlProvincia" runat="server" Autopostback="true" class="form-select" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged" >
                    </asp:DropDownList>
                    <asp:CustomValidator ID="cvProvincia" runat="server" ControlToValidate="ddlProvincia" ForeColor="Cyan" ErrorMessage="Por favor, seleccione una provincia" OnServerValidate="cvProvincia_ServerValidate"></asp:CustomValidator>
                </div>
                <div class="mb-3">
                    <label class="form-label">Seleccione una Localidad</label>                    

                        <asp:DropDownList ID="ddlLocalidad" runat="server" class="form-select" AutoPostBack="false" OnLoad="ddlLocalidad_Load">                   
                        <%--<asp:ListItem Selected="True">Localidad</asp:ListItem>--%>
                    </asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label class="form-label">Telefono</label>
                    <asp:TextBox ID="tbTelefono" runat="server" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="tbTelefono" ErrorMessage="Campo Obligatorio"></asp:RequiredFieldValidator>
                </div>
                <%--Botones--%>
                <div class="mb-3">
                    <asp:Button ID="btnEnviar" runat="server" Text="Enviar" class="btn btn-light" OnClick="btnEnviar_Click"/>
                    <%--<input class="btn btn-light" type="submit" value="Enviar">--%>
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn primary"/>
                </div>
            </div>

        </div>
    </section>
</asp:Content>
