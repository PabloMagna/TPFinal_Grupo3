
<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdministrarPublicaciones.aspx.cs" Inherits="TP_Final.AdministrarPublicaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="dgvPublicaciones" runat="server" CssClass="table table-striped" AutoGenerateColumns="false" 
    DataKeyNames="Id">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="true" />
            <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" ReadOnly="true" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" ReadOnly="true" />
            <asp:BoundField DataField="Titulo" HeaderText="Título" ReadOnly="true" />
            <asp:BoundField DataField="Especie" HeaderText="Especie" ReadOnly="true" />
            <asp:BoundField DataField="Raza" HeaderText="Raza" ReadOnly="true" />
            <asp:BoundField DataField="Edad" HeaderText="Edad" ReadOnly="true" />
            <asp:BoundField DataField="Sexo" HeaderText="Sexo" ReadOnly="true" />
            <asp:BoundField DataField="FechaHora" HeaderText="Fecha y Hora" ReadOnly="true" />
            <asp:TemplateField HeaderText="Estado">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control" Enabled="true" 
                        OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="IDLocalidad" HeaderText="Localidad" ReadOnly="true" />
            <asp:BoundField DataField="IDProvincia" HeaderText="Provincia" ReadOnly="true" />
        </Columns>
    </asp:GridView>
</asp:Content>
