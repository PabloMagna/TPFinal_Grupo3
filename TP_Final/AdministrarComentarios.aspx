<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdministrarComentarios.aspx.cs" Inherits="TP_Final.AdministrarComentarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvComentarios" runat="server" CssClass="table table-striped" AutoGenerateColumns="false"
        DataKeyNames="Id">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="true" />
            <asp:BoundField DataField="IdPublicacion" HeaderText="Id Publicacion" ReadOnly="true" />
            <asp:BoundField DataField="IdUsuario" HeaderText="Id Usuario" ReadOnly="true" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" ReadOnly="true" />
            <asp:TemplateField HeaderText="Estado">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged">
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="FechaHora" HeaderText="Fecha/Hora" ReadOnly="true" />
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
