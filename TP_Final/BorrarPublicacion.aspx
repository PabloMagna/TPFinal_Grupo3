<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BorrarPublicacion.aspx.cs" Inherits="TP_Final.BorrarPublicacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Historias.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="mensajeSuspendido" runat="server">         
        <h4>Tu publicacion esta pausada clica aqui para Activarla</h4>
        <asp:Button ID="btnActivar" Text="Activar" runat="server" OnClick="btnActivar_Click"/>
    </section>
    <%if (ObtenerEstadoPublicacion() == Dominio.Estado.Activa)
        { %>
    <section id="FormBorrarPublicacion" runat="server" visible="true">       
        <div id="formBorrar" class="formularioOculto" runat="server">
            <div class="contenidoForm">                
                <div>
                    <h3>Baja de publicación</h3>
                </div>
                <asp:Button ID="btn_expandir" runat="server" Text="Opciones De Eliminación / Suspención" class="btn border-orange" OnClick="btn_expandir_Click1"/>
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
       <%} %>

</asp:Content>
