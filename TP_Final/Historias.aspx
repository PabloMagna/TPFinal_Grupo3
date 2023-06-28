<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Historias.aspx.cs" Inherits="TP_Final.Historias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Historias</title>
    <link href="css/Historias.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="portada">
        <h1 id="titulo">Historias</h1>
        <h4><em>Relatos de adopciones a través de Prt Net.</em></h4>
    </section>
    <section class="historias_container" runat="server">
        <asp:GridView runat="server" ID="dvgHistorias" CssClass="table table-bordered">

        </asp:GridView>
    </section>
</asp:Content>
