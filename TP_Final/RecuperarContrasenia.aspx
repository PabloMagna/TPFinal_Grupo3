<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RecuperarContrasenia.aspx.cs" Inherits="TP_Final.RecuperarContrasenia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Recuperación de Contraseña</h2>
        <div class="alert alert-info" id="lblMessage" runat="server" visible="false"></div>
        <div class="mb-3">
            <label for="txtEmail" class="form-label">Ingresa tu correo electrónico</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Correo electrónico"></asp:TextBox>
        </div>
        <div class="mb-3">
            <asp:Button ID="btnSubmit" runat="server" Text="Enviar" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
        </div>
        <div id="divMessage" runat="server" visible="false">
            <asp:Label ID="Label1" runat="server" CssClass="alert" />
        </div>
    </div>
</asp:Content>
