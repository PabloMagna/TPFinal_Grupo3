<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ConfirmarDatos.aspx.cs" Inherits="TP_Final.ConfirmarDatos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap/5.0.2/css/bootstrap.min.css">
        <link href="css/formPublicacion.css" rel="stylesheet" type="text/css" />    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
    <section class="portada">
        <h1 id="titulo">Formulario de solicitud</h1>
        <h4 id="subtitulo" runat="server"><em>Necesitaremos que confirmes y/o completes tus datos para comenzar el proceso de adopción.</em></h4>
    </section>

    <section class="formulario" id="formulario" runat="server">
        <div class="container row">
            <h1>Confirmar Datos</h1>
            <div class="mb-3">
                <label for="txtDni" class="form-label">DNI:</label>
                <asp:TextBox ID="txtDni" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtApellido" class="form-label">Apellido:</label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtFechaNacimiento" class="form-label">Fecha de Nacimiento:</label>
                <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
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
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlProvincia" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
            <div class="mb-3">
                <label for="txtTelefono" class="form-label">Teléfono:</label>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar y ver Datos de adopcion" CssClass="btn btn-primary" OnClick="btnGuardar_Click"/>
            </div>
        </div>
    </section>
    
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap/5.0.2/js/bootstrap.bundle.min.js"></script>
</asp:Content>
