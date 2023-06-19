<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="TP_Final._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/home.css" rel="stylesheet" type="text/css" />
    <title>Home</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="slider">
        <div id="carouselExampleAutoplaying" class="carousel slide" data-bs-ride="carousel">
          <div class="carousel-inner">
            <div class="carousel-item active">
              <img src="imagenes/slider2.jpg" class="d-block w-100" alt="...">
            </div>
            <div class="carousel-item">
              <img src="imagenes/slider3.jpg" class="d-block w-100" alt="...">
            </div>
            <div class="carousel-item">
              <img src="imagenes/slider4.jpg" class="d-block w-100" alt="...">
            </div>            
          </div>
          <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleAutoplaying" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
          </button>
          <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleAutoplaying" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
          </button>
        </div>
    </section>
    <section class="quienes_somos">
        <h1 id="titulo1">Quiénes somos</h1>  
        <div class="about-us">
            <p>
                Somos un grupo de estudiantes de la Universidad Tecnológica Nacional (UTN) comprometidos con la causa de la adopción de mascotas. Nuestro objetivo principal es crear una plataforma en línea donde los dueños de mascotas que necesitan un nuevo hogar puedan conectarse con personas interesadas en adoptar.
            <p/>
            <p>
                Comenzamos este proyecto como un trabajo práctico, pero nuestra visión es que esta web se convierta en una herramienta útil y valiosa para la comunidad, facilitando la adopción responsable de mascotas y promoviendo el bienestar animal.
            </p>            
            <p>
                En nuestro sitio, los usuarios podrán crear perfiles de mascotas disponibles para adopción, buscar mascotas según sus preferencias y contactar a los dueños para iniciar el proceso de adopción. También ofrecemos recursos educativos y consejos para ayudar a los dueños de mascotas a cuidar y criar a sus nuevos compañeros de vida.
            <p/>
            <p>
                Valoramos la importancia de la adopción responsable y nos esforzamos por promover un ambiente seguro y amigable en nuestra comunidad. Trabajamos en colaboración con refugios de animales y organizaciones locales para fomentar la adopción ética y brindar apoyo a aquellos que deseen encontrar un nuevo hogar para sus mascotas.
            </p> 
            <iconify-icon icon="twemoji:black-cat" width="45px"></iconify-icon> &nbsp; <iconify-icon icon="twemoji:dog" width="50px"></iconify-icon>
            <hr/>
            <em>Únete a nuestra comunidad y sé parte del cambio. Juntos podemos hacer una diferencia en la vida de los animales y promover la adopción como un acto de amor y responsabildad.

            </em>                
        </div>
    </section>

</asp:Content>
