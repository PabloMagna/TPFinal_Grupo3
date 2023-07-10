<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ResetearContrasenia.aspx.cs" Inherits="TP_Final.ResetearContrasenia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6 offset-md-3">
                <h2 class="text-center">Cambiar contraseña</h2>
                <div class="alert alert-success" id="lblMessage" runat="server" visible="false"></div>
                <div class="mb-3">
                    <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Nueva contraseña"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Confirmar contraseña"></asp:TextBox>
                </div>
                <div class="text-center">
                    <asp:Button ID="btnChangePassword" runat="server" CssClass="btn btn-primary" Text="Cambiar contraseña" OnClick="btnChangePassword_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
