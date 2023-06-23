<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdministrarPublicaciones.aspx.cs" Inherits="TP_Final.AdministrarPublicaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1>Administrar Publicaciones</h1>
        <div class="row">
            <div class="col">
                <asp:GridView ID="dgvPublicaciones" runat="server" CssClass="table table-striped" OnRowEditing="dgvPublicaciones_RowEditing">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="true" />
                        <asp:BoundField DataField="FechaHora" HeaderText="Fecha/Hora" ReadOnly="true" />
                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <%# Eval("Estado") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlEstado" runat="server">
                                    <asp:ListItem Text="Estado 1" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Estado 2" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Estado 3" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Título">
                            <ItemTemplate>
                                <%# Eval("Titulo") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTitulo" runat="server" Text='<%# Bind("Titulo") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Descripción">
                            <ItemTemplate>
                                <%# Eval("Descripcion") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="3" Text='<%# Bind("Descripcion") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
