<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditarImagenesMascota.aspx.cs" Inherits="TP_Final.EditarImagenesMascota" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/EditarImagenesMascota.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="portada">
        <h1 id="titulo">Borrar imágenes</h1>
        <h4 id="subtitulo" runat="server"><em>Selecciona las imágenes que desees borrar.</em></h4>
    </section>
    <section class="listaImagenes" runat="server">     
          
        
          <%
        if (existeImagen == true)
        {
            int i = 0;
        %>                  
             <div class="container text-center">

            <%
            foreach (Dominio.ImagenMascota img in listaImg)
            {
                    
            %>
                <div class="row"> 
                    <div class="col-4">
                         <input type="checkbox" value="" id="<%=img.Id%>" >
                    </div>
                    <div class="col-4 divMascota">
                        <img class="imgMascota" src="<%=img.urlImagen%>" onerror="this.src='https://static.vecteezy.com/system/resources/previews/007/301/664/non_2x/adopt-a-dog-help-the-homeless-animals-find-a-home-cartoon-illustration-vector.jpg'"/>                  
                    </div>
                    <div class="col-4">
                        <label class="form-check-label" for="id" style="display: none;" ><%=img.Id %></label>
                        <button type="button" class="btn primary borrar">Borrar</button>
                    </div>    
                </div>
                            
            <%
                i++;
            }  %>
            </div>
         <% 
        }%>   
    </section>
</asp:Content>
