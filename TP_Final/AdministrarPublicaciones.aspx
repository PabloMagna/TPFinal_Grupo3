<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdministrarPublicaciones.aspx.cs" Inherits="TP_Final.AdministrarPublicaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Nota: Los cambios en los Estados van a afectar a las Adopciones relacionadas dandolas de baja</h2>
    <asp:GridView ID="dgvPublicaciones" runat="server" CssClass="table table-striped" AutoGenerateColumns="false"
        DataKeyNames="Id">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="true" Visible="false" />
            <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" ReadOnly="true" Visible="false" />
            <asp:BoundField DataField="Titulo" HeaderText="Título" ReadOnly="true" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" ReadOnly="true" />
            <asp:BoundField DataField="Especie" HeaderText="Especie" ReadOnly="true" />
            <asp:BoundField DataField="Raza" HeaderText="Raza" ReadOnly="true" />
            <asp:BoundField DataField="Edad" HeaderText="Edad" ReadOnly="true" />
            <asp:BoundField DataField="Sexo" HeaderText="Sexo" ReadOnly="true" Visible="false" />
            <asp:BoundField DataField="FechaHora" HeaderText="Fecha y Hora" ReadOnly="true" />
            <asp:TemplateField HeaderText="Estado">
                <ItemTemplate>
                    <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("Estado") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="IDLocalidad" HeaderText="Localidad" ReadOnly="true" />
            <asp:BoundField DataField="IDProvincia" HeaderText="Provincia" ReadOnly="true" />
            <asp:TemplateField HeaderText="Detalle">
                <ItemTemplate>
                    <asp:HyperLink ID="hlDetalle" runat="server" Text="Detalle"
                        NavigateUrl='<%# "DetallePublicacion.aspx?ID=" + Eval("ID") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Usuario">
                <ItemTemplate>
                    <asp:HyperLink ID="hlUsuario" runat="server" Text="Usuario"
                        NavigateUrl='<%# "AdministrarUsuarios.aspx?IDU=" + Eval("IdUsuario") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Comentarios">
                <ItemTemplate>
                    <asp:HyperLink ID="hlComentarios" runat="server" Text="Comentarios"
                        NavigateUrl='<%# "AdministrarComentarios.aspx?IDP=" + Eval("ID") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:Button ID="btnActivar" runat="server" Text="Activar" CommandName="Activar" CommandArgument='<%# Eval("Id") %>'
                        CssClass="btn btn-success" OnClick="btnAcciones_Click" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>'
                        CssClass="btn btn-danger" OnClick="btnAcciones_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

