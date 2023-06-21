<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="formPublicacion.aspx.cs" Inherits="TP_Final.Publicar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Alta Publicacion</title>
    <link href="css/formPublicacion.css" rel="stylesheet" type="text/css" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server"></asp:ScriptManager>
     <section class="portada">
        <h1 id="titulo">Publicación de mascota en adopción</h1>
        <h4><em>Necesitaremos que completes algunos datos.</em></h4>
    </section>
    <section class="formulario">
        <div class="row">
            <div class="col-4">
                <asp:Label ID="lbTitulo" runat="server" CssClass="titulo">Formulario de alta de Publicación</asp:Label>

                <div class="mb-3">
                    <label class="form-label" >Nombre de la Mascota</label>
                    <asp:TextBox ID="tbNombre" runat="server" class="form-control" placeholder="Boby"></asp:TextBox>
                </div>
               
                <div class="mb-3">
                    <label class="form-label">Especie</label>
                    <asp:DropDownList ID="DropDownList1" runat="server" class="form-select" AutoPostBack="false">
                        <asp:ListItem Selected="True">Gato</asp:ListItem>
                        <asp:ListItem >Perro</asp:ListItem>
                        <asp:ListItem >Otro</asp:ListItem>
                    </asp:DropDownList>
                </div>
                 <div class="mb-3">
                    <label class="form-label" >Raza </label>
                    <asp:TextBox ID="tbEspecie" runat="server" class="form-control" placeholder="Chiguagua / Siamés"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Edad</label>
                    <asp:TextBox ID="TextBox1" runat="server" Type="number" min="1" class="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Seleccione unidad de tiempo</label>
                    <asp:DropDownList ID="ddlEdad" runat="server" class="form-select" AutoPostBack="false">
                        <asp:ListItem Selected="True">Años</asp:ListItem>
                        <asp:ListItem >Meses</asp:ListItem>
                    </asp:DropDownList>
                </div>
                  <div class="mb-3">
                    <label class="form-label">Sexo</label>
                    <asp:DropDownList ID="ddlSexo" runat="server" class="form-select" AutoPostBack="false">
                        <asp:ListItem Selected="True">Hembra</asp:ListItem>
                        <asp:ListItem >Macho</asp:ListItem>
                        <asp:ListItem >Desconoce</asp:ListItem>
                    </asp:DropDownList>
                </div>
                  <div class="mb-3">
                      <label class="form-label">Provincia</label>
                        <asp:UpdatePanel runat="server" ID="updatePanelProvincia">
                            <ContentTemplate>
                                <asp:DropDownList runat="server" ID="ddlProvincia" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged"></asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Localidad</label>
                        <asp:UpdatePanel runat="server" ID="updatePanelLocalidad">
                            <ContentTemplate>
                                <asp:DropDownList runat="server" ID="ddlLocalidad" CssClass="form-select"></asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                <div class="mb-3">
                    <label class="form-label">Descripción la publicación</label>
                    <asp:TextBox ID="TextBox2" runat="server" class="form-control" TextMode="MultiLine" Rows="5" MaxLength="500" placeholder="Características de la mascota, Condiciones de adopción, etc."></asp:TextBox>
                </div>
                <%--Botones--%>
                <div class="mb-3">
                    <input class="btn btn-light" type="submit" value="Enviar">
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn primary" />
                </div>
            </div>        
        </div>
    </section>
</asp:Content>
