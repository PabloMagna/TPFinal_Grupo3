<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditarImagenesMascota.aspx.cs" Inherits="TP_Final.EditarImagenesMascota" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/EditarImagenesMascota.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <asp:ScriptManager ID="scriptManager" runat="server"></asp:ScriptManager>


     <section class="portada">
        <h1 id="titulo">Borrar imágenes</h1>
        <h4 id="subtitulo" runat="server"><em>Selecciona las imágenes que desees borrar.</em></h4>
    </section>
   
    <section class="repetidor listaImagenes">
        <div class="container text-center">
            <asp:Repeater ID="repImagenes" runat="server">
                <ItemTemplate>
                    <div class="row content">                             
                        <div class="col text-center">
                            <div class="divMascota">
                                <img class="imgMascota" src="<%#Eval("urlImagen")%>" onerror="this.src='https://static.vecteezy.com/system/resources/previews/007/301/664/non_2x/adopt-a-dog-help-the-homeless-animals-find-a-home-cartoon-illustration-vector.jpg'"/> 
                            </div>                                                 
                        </div>
                        <div class="col text-center">
                            <asp:Button ID="btnBorrar" runat="server" Text="Borrar" CssClass="btn btn-primary" OnClick="btnBorrar_Click" CommandArgument='<%#Eval("Id")%>'  CommandName="ImgID" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        
            <div class="row container text-center">
                <asp:Button ID="btnVolver" runat="server" Text="Volver a la publicación" CssClass="btn btn-primary" OnClick="btnVolver_Click"/>
            </div>
        </div>
    </section>

</asp:Content>
