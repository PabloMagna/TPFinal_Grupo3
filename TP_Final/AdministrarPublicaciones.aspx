<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdministrarPublicaciones.aspx.cs" Inherits="TP_Final.AdministrarPublicaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/admin.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 id="nota"> <iconify-icon icon="jam:triangle-danger-f" style="color: red;"></iconify-icon> Los cambios en los estados afectarán a las Adopciones vinculadas dándolas de baja</h2>
    <asp:GridView ID="dgvPublicaciones" runat="server" CssClass="table table-striped" AutoGenerateColumns="false" DataKeyNames="Id">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="true" Visible="false" />
            <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" ReadOnly="true" Visible="false" />
            <asp:BoundField DataField="Titulo" HeaderText="Título" ReadOnly="true" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" ReadOnly="true" Visible="false" />
            <asp:BoundField DataField="Especie" HeaderText="Especie" ReadOnly="true" />
            <asp:BoundField DataField="Raza" HeaderText="Raza" ReadOnly="true" Visible="false" />
            <asp:BoundField DataField="Edad" HeaderText="Edad" ReadOnly="true" Visible="false"/>
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
                    <asp:HyperLink ID="hlDetalle" runat="server" Text="Detalle" CssClass="aspHyperLink" NavigateUrl='<%# "DetallePublicacion.aspx?ID=" + Eval("ID") %>'>
                        <iconify-icon icon="pajamas:details-block" width="30px"></iconify-icon>
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Usuario">
                <ItemTemplate>
                    <asp:HyperLink ID="hlUsuario" runat="server" Text="Usuario" CssClass="aspHyperLink" NavigateUrl='<%# "AdministrarUsuarios.aspx?IDU=" + Eval("IdUsuario") %>'>
                        <iconify-icon icon="majesticons:user-box-line" width="30px"></iconify-icon>
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Comentarios">
                <ItemTemplate>
                    <asp:HyperLink ID="hlComentarios" runat="server" CssClass="aspHyperLink" NavigateUrl='<%# "AdministrarComentarios.aspx?IDU=" + Eval("ID") %>'>
                        <iconify-icon icon="ant-design:comment-outlined" width="30px"></iconify-icon>
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:Button ID="btnActivar" runat="server" Text="Activar" CommandName="Activar" CommandArgument='<%# Eval("Id") %>'
                        CssClass="btn btn-estado" OnClick="btnAcciones_Click" Visible='<%# MostrarBotonActivar(Eval("Estado")) %>' />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>'
                        CssClass="btn btn-red btn-estado" OnClick="btnAcciones_Click" Visible='<%# MostrarBotonEliminar(Eval("Estado")) %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>