<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AltaCuenta.aspx.cs" Inherits="TP_Final.AltaCuenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/AltaCuenta.css" rel="stylesheet" type="text/css" />
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
                </div>
                <div class="mb-3">
                    <label class="form-label">Password </label>
                    <asp:TextBox ID="tbPassword" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                </div>
                <%-- Opciones exclusivas para Persona   --%>
                <div id="formPersona" runat="server">
                    <div class="mb-3">
                        <label class="form-label">Nombre </label>
                        <asp:TextBox ID="tbNombre" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Apellido</label>
                        <asp:TextBox ID="tbApellido" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Fecha de Nacimiento </label>
                        <asp:TextBox ID="tbFechaNac" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <%--Opciones exclusivas para Refugio--%>
                <div id="formRefugio" runat="server">
                    <div class="mb-3">
                        <label class="form-label">Nombre del Refugio </label>
                        <asp:TextBox ID="tbNombreRefugio" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Dirección </label>
                        <asp:TextBox ID="tbDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="mb-3">
                    <label class="form-label">Seleccione una Provincia</label>
                    <asp:DropDownList ID="ddlProvincia" runat="server" class="form-select" >
                        <asp:ListItem Selected="True">Provincia</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label class="form-label">Seleccione una Localidad</label>
                    <asp:DropDownList ID="ddlLocalidad" runat="server" class="form-select" AutoPostBack="false">
                        <asp:ListItem Selected="True">Localidad</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label class="form-label">Telefono</label>
                    <asp:TextBox ID="tbTelefono" runat="server" class="form-control"></asp:TextBox>
                </div>
                <%--Botones--%>
                <div class="mb-3">
                    <%--<asp:Button ID="btnEnviar" runat="server" Text="Enviar" class="btn btn-Primary"/>--%>
                    <input class="btn btn-light" type="submit" value="Enviar">
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn primary" />
                </div>
            </div>

        </div>
    </section>
</asp:Content>
