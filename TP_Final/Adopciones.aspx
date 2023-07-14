<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Adopciones.aspx.cs" Inherits="TP_Final.Adopciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css">
    <script>
        function ConfirmarEliminar() {
            return confirm("¿Estás seguro de que quieres eliminar esta adopción?");
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Adopciones</h1>
    <div class="table-responsive">
        <asp:GridView ID="dgvAdopciones" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered" OnRowDataBound="dgvAdopciones_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Número de Lista">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
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
                        <a href='<%# "DetallePublicacion.aspx?ID=" + Eval("IDPublicacion") %>'>Ver detalle</a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Eliminar adopcion">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEliminar" runat="server" Text="Ya no quiero adoptarlo" OnClientClick="return ConfirmarEliminar();" OnClick="lnkEliminar_Click" CommandArgument='<%# Eval("IDPublicacion") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
