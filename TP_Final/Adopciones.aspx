﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Adopciones.aspx.cs" Inherits="TP_Final.Adopciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/adopciones.css" rel="stylesheet" type="text/css" />
    <script>
        function ConfirmarEliminar() {
            return confirm("¿Estás seguro de que quieres eliminar esta adopción?");
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <section class="portada">
        <h1 id="titulo">Mis Adopciones</h1>
    </section>

    <div class="table-responsive">
        <asp:GridView ID="dgvAdopciones" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered" OnRowDataBound="dgvAdopciones_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate>
                        <%# ((Dominio.EstadoAdopcion)Eval("Estado")).ToString() %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Comentario">
                    <ItemTemplate>
                        <asp:TextBox ID="txtComentario" runat="server" MaxLength="200" CssClass="form-control"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Detalle Publicación">
                    <ItemTemplate>
                        <a class="enlace" href='<%# "DetallePublicacion.aspx?ID=" + Eval("IDPublicacion") %>'>
                             <iconify-icon icon="fluent-mdl2:storyboard" width="30px"></iconify-icon>
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Eliminar adopcion">
                    <ItemTemplate>
                        <asp:LinkButton class="enlace" ID="lnkEliminar" runat="server" OnClientClick="return ConfirmarEliminar();" OnClick="lnkEliminar_Click" CommandArgument='<%# Eval("IDPublicacion") %>'>
                            <iconify-icon icon="emojione:cross-mark-button" width="30px"></iconify-icon>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
