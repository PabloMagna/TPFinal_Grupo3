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
       
                <asp:Repeater ID="repImagenes" runat="server">
                    <ItemTemplate>
                        <div class="row"> 
                            <div class="col-2">                         
                            </div>
                            <div class="col-4 divMascota">
                                <img class="imgMascota" src="<%#Eval("urlImagen")%>" onerror="this.src='https://static.vecteezy.com/system/resources/previews/007/301/664/non_2x/adopt-a-dog-help-the-homeless-animals-find-a-home-cartoon-illustration-vector.jpg'"/>                  
                            </div>
                            <div class="col-4">
                                <asp:Button ID="btnBorrar" runat="server" Text="Borrar" cssclass="btn primary borrar" OnClick="btnBorrar_Click" CommandArgument='<%#Eval("Id")%>'  CommandName="ImgID" />
                            </div>  
                            <div class="col-2">                         
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
        <!--
         <asp:UpdatePanel runat="server" ID="updateImagenes" >
            <ContentTemplate>
            </ContentTemplate>
         </asp:UpdatePanel>
        -->
        <div>
            <asp:Button ID="btnVolver" runat="server" Text="Volver a la publicación" cssclass="btn primary borrar" OnClick="btnVolver_Click"/>
        </div>
    </section>

</asp:Content>
