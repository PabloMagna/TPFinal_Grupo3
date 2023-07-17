<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdministrarUsuarios.aspx.cs" Inherits="TP_Final.AdministrarUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/admin.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="dgvUsuarios" runat="server" CssClass="table table-striped" AutoGenerateColumns="false"
        DataKeyNames="Id">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="true" />
            <asp:BoundField DataField="Tipo" HeaderText="Tipo" ReadOnly="true" />
            <asp:BoundField DataField="Password" HeaderText="Contraseña" ReadOnly="true" />
            <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="true" />
            <asp:TemplateField HeaderText="Estado">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged">
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Es Admin">
                <ItemTemplate>
                    <asp:CheckBox ID="cbEsAdmin" runat="server" AutoPostBack="true"
                        OnCheckedChanged="cbEsAdmin_CheckedChanged" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Publicaciones">
                <ItemTemplate>
                    <asp:HyperLink ID="hlPublicaciones" runat="server" CssClass="aspHyperLink"
                        NavigateUrl='<%# "AdministrarPublicaciones.aspx?ID=" + Eval("Id") %>'>
                        <iconify-icon icon="fluent-mdl2:storyboard" width="30px"></iconify-icon>
                    </asp:HyperLink>  
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Comentarios">
                <ItemTemplate>
                    <asp:HyperLink ID="hlComentarios" runat="server" CssClass="aspHyperLink"
                        NavigateUrl='<%# "AdministrarComentarios.aspx?IDU=" + Eval("ID") %>'>
                        <iconify-icon icon="ant-design:comment-outlined" width="30px"></iconify-icon>
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Historias">
                <ItemTemplate>
                    <asp:HyperLink ID="hlHistorias" runat="server" CssClass="aspHyperLink"
                        NavigateUrl='<%# "AdministrarHistorias.aspx?IDU=" + Eval("ID") %>'>
                        <iconify-icon icon="material-symbols:history-edu" width="30px"></iconify-icon>
                    </asp:HyperLink>                    
                </ItemTemplate>
            </asp:TemplateField>                        
        </Columns>
    </asp:GridView>
</asp:Content>
