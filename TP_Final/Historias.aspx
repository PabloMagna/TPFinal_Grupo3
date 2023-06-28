<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Historias.aspx.cs" Inherits="TP_Final.Historias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Historias</title>
    <link href="css/Historias.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="portada">
        <h1 id="titulo">Historias</h1>
        <h4><em>Relatos de adopciones a través de Pet Net.</em></h4>
    </section>
    <section class="historias_container" runat="server">
        <!--For each... -->
        <div class="container">
            <div>
                <asp:Image ID="imgHistoria" runat="server" />
            </div>
            <div>
                <asp:Label ID="lblUser" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblFecha" runat="server" Text=""></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblTexto" runat="server" Text=""></asp:Label>
            </div>
            
        </div>
    </section>
</asp:Content>
