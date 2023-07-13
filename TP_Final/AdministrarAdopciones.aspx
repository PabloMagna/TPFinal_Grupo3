<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdministrarAdopciones.aspx.cs" Inherits="TP_Final.AdministrarAdopciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    <h3>Nota: Los cambios en las Adopciones pueden afectar la visibilidad de las publicaciones en la web, activandolas en caso de baja y viceversa</h3>
    <asp:GridView ID="gvAdopciones" runat="server" CssClass="table table-striped" AutoGenerateColumns="false" DataKeyNames="ID" OnRowDataBound="gvAdopciones_RowDataBound">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="true" />
            <asp:BoundField DataField="IDPublicacion" HeaderText="ID Publicación" ReadOnly="true" />
            <asp:BoundField DataField="IDUsuario" HeaderText="ID Usuario" ReadOnly="true" />
            <asp:TemplateField HeaderText="Estado">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlEstado" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged"></asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Publicacion">
                <ItemTemplate>
                    <asp:HyperLink ID="hlPublicacion" runat="server" Text="Publicacion"
                        NavigateUrl='<%# "AdministrarPublicaciones.aspx?IDP=" + Eval("IdPublicacion") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
                         <asp:TemplateField HeaderText="Usuario">
                <ItemTemplate>
                    <asp:HyperLink ID="hlUsuario" runat="server" Text="Usuario"
                        NavigateUrl='<%# "AdministrarUsuarios.aspx?IDU=" + Eval("IdUsuario") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
