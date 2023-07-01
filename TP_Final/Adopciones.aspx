<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Adopciones.aspx.cs" Inherits="TP_Final.Adopciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Adopciones</h1>
    <div class="table-responsive">
        <asp:GridView ID="dgvAdopciones" runat="server" CssClass="table table-striped table-bordered">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="IDPublicacion" HeaderText="ID Publicación" />
                <asp:BoundField DataField="IDUsuario" HeaderText="ID Usuario" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
