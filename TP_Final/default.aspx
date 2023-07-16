<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="TP_Final._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/home.css" rel="stylesheet" type="text/css" />
    <title>Home</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
   
    <section class="home">
        <%if (Session["Usuario"]!=null)
            {%>
        <div class="userlog d-flex align-self-center">
             <div id="userlog">                                     
                <p>¡Hola <%=GetUserName()%>!</p>
            </div>
            <div class="rounded-circle bg-secondary text-white d-flex align-items-center justify-content-center align-self-center" style="width: 4.0rem; height: 4.0rem;">
                <img src="<%=ObtenerUrl() %>" alt="Imagen de perfil" style="width: 100%; height: 100%; object-fit: cover; border-radius: 50%;" onerror="cargarImagenPredeterminada(this)" />                               
            </div>           
        </div>
            <% }%>
          
         
            <div class="btnGaleria">
                <a href="galeria.aspx">Ver mascotas en adopción</a>
            </div>

          
    </section>
    <section id="about" class="quienes_somos">
        <h1 id="titulo1">Quiénes somos</h1>  
        <div class="about-us">
            <p>
                Somos un grupo de estudiantes de la Universidad Tecnológica Nacional (UTN) comprometidos con la causa de la adopción de mascotas. <br /> Nuestro objetivo principal es crear una plataforma en línea donde los dueños de mascotas que necesitan un nuevo hogar puedan conectarse con personas interesadas en adoptar.
            <p/>
            <p>
                Comenzamos este proyecto como un trabajo práctico, pero nuestra visión es que esta web se convierta en una herramienta útil y valiosa para la comunidad, facilitando la adopción responsable de mascotas y promoviendo el bienestar animal en un entorno ético y seguro.
            </p>   
            <h3>Breve descripción de la plataforma</h3>
            <p>
                En nuestro sitio, los usuarios podrán crear publicaciones de mascotas disponibles para adopción, buscar mascotas según sus preferencias y contactar a los dueños para iniciar el proceso de adopción. También ofrecemos recursos para el seguimiento de adopciones concretadas a través de la web, para garantizar el bienestar de la mascota en su nuevo hogar.
            <p/> 
            <p class="iconos">
                <iconify-icon icon="twemoji:black-cat" width="45px"></iconify-icon> &nbsp; <iconify-icon icon="twemoji:dog" width="50px"></iconify-icon>
            </p>
            
            <hr/>
            <em>Unite a nuestra comunidad y sé parte del cambio. Juntos podemos hacer una diferencia en la vida de los animales y promover la adopción como un acto de amor y responsabildad.

            </em>                
        </div>
    </section>

</asp:Content>
