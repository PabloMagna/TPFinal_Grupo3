<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdministrarHistorias.aspx.cs" Inherits="TP_Final.AdministrarHistorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="dgvHistorias" runat="server" CssClass="table table-striped" AutoGenerateColumns="false"
    DataKeyNames="ID">
    <Columns>
        <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="true" />
        <a href="AdministrarHistorias.aspx">AdministrarHistorias.aspx</a>
        <asp:BoundField DataField="IDUsuario" HeaderText="ID Usuario" ReadOnly="true" />
        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" ReadOnly="true" />
        <asp:BoundField DataField="FechaHora" HeaderText="Fecha y Hora" ReadOnly="true" />
        <asp:TemplateField HeaderText="Estado">
            <ItemTemplate>
                <asp:DropDownList ID="ddlEstadoHistoria" runat="server" CssClass="form-control" AutoPostBack="true"
                    OnSelectedIndexChanged="ddlEstadoHistoria_SelectedIndexChanged">
                </asp:DropDownList>
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
