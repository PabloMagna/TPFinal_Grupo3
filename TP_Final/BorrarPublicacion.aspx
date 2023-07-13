<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BorrarPublicacion.aspx.cs" Inherits="TP_Final.BorrarPublicacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="mensajeSuspendido" runat="server">         
        <h4>Tu publicacion esta pausada clica <a href="#">aqui</a> para Activarla</h4>   
    </section>

    <section id="mensajeConformacion" runat="server">       
        <h4>La operación se realizó correctamente.</h4>   
    </section>

    <section id="FormBorrarPublicacion" runat="server" visible="true">       
        <div id="formBorrar" class="formularioOculto" runat="server">
            <div class="contenidoForm">                
                <div>
                    <h3>Baja de publicación</h3>
                </div>
                <div class="formularioH" id="formularioH" runat="server" style="display: none;">
                    <div class="card card-body">
                        <h4>Opciones de baja:</h4>
                        <asp:RadioButtonList ID="rbOpcionesBaja" runat="server">
                            <asp:ListItem Text="Eliminar publicación" Value="EliminarPublicacion" />
                            <asp:ListItem Text="Eliminar por Adopción Concretada" Value="EliminarAdopcion" />
                            <asp:ListItem Text="Suspender Publicación (No se muestra en galería - cancela solicitudes)" Value="SuspenderPublicacion" />
                        </asp:RadioButtonList>
                        <asp:Button ID="btnConfirmarAccion" runat="server" Text="Confirmar Acción" CssClass="btn" OnClick="btnConfirmarAccion_Click" />
                    </div>
                </div>
            </div>
        </div>
       
    </section>
       

</asp:Content>
