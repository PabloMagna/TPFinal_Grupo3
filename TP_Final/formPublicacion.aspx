<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="formPublicacion.aspx.cs" Inherits="TP_Final.Publicar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Alta Publicacion</title>
    <link href="css/formPublicacion.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="portada">
        <h1 id="titulo">Publicación de mascota en adopción</h1>
        <h4><em>Necesitaremos que completes algunos datos.</em></h4>
    </section>
    <section class="formulario">
        <div class="row">
            <div class="col-4">
                <asp:Label ID="lbTitulo" runat="server" CssClass="titulo">Formulario de alta de Publicación</asp:Label>

                <div class="mb-3">
                    <label class="form-label" >Nombre de la Mascota </label>
                    <asp:TextBox ID="tbNombre" runat="server" class="form-control" placeholder="Boby"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label" >Especie </label>
                    <asp:TextBox ID="tbEspecie" runat="server" class="form-control" placeholder="Perro"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Raza</label>
                    <asp:DropDownList ID="DropDownList1" runat="server" class="form-select" AutoPostBack="false">
                        <asp:ListItem Selected="True">Gato</asp:ListItem>
                        <asp:ListItem >Perro</asp:ListItem>
                    </asp:DropDownList>
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
                    </asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label class="form-label">Breve descripción de la mascota</label>
                    <asp:TextBox ID="tbDescripcion" runat="server" class="form-control" TextMode="MultiLine" Rows="5" MaxLength="200"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Comentarios sobre la publicación</label>
                    <asp:TextBox ID="TextBox2" runat="server" class="form-control" TextMode="MultiLine" Rows="5" MaxLength="500" placeholder="Condiciones de adopción, necesidades de la mascota, etc."></asp:TextBox>
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
