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
              <img src="https://c.pxhere.com/photos/5f/75/dogs_bernese_puppies_purebred_mountain_pet_animal_canine-701568.jpg!d" class="d-block w-100" alt="...">
            </div>
            <div class="carousel-item">
              <img src="https://c.pxhere.com/photos/bf/9d/dogs_puppies_watching_outside_park_puppy_animal_pet-1173210.jpg!d" class="d-block w-100" alt="...">
            </div>
            <div class="carousel-item">
              <img src="https://c.pxhere.com/photos/f4/e7/cats_kittens_animals_mammals_playing_playful_furry_wildlife-1009458.jpg!d" class="d-block w-100" alt="...">
            </div>
               <div class="carousel-item">
              <img src="https://c.pxhere.com/photos/97/7d/cats_pets_animals_kittens_domestic_tabby_sitting_next-265073.jpg!d" class="d-block w-100" alt="...">
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
        <p>Somos un grupo de estudiantes de la Universidad Tecnológica Nacional (UTN) comprometidos con la causa de la adopción de mascotas. Nuestro objetivo principal es crear una plataforma en línea donde los dueños de mascotas que necesitan un nuevo hogar puedan conectarse con personas interesadas en adoptar.

Comenzamos este proyecto como un trabajo práctico, pero nuestra visión es que esta web se convierta en una herramienta útil y valiosa para la comunidad, facilitando la adopción responsable de mascotas y promoviendo el bienestar animal.

En nuestro sitio, los usuarios podrán crear perfiles de mascotas disponibles para adopción, buscar mascotas según sus preferencias y contactar a los dueños para iniciar el proceso de adopción. También ofrecemos recursos educativos y consejos para ayudar a los dueños de mascotas a cuidar y criar a sus nuevos compañeros de vida.

Valoramos la importancia de la adopción responsable y nos esforzamos por promover un ambiente seguro y amigable en nuestra comunidad. Trabajamos en colaboración con refugios de animales y organizaciones locales para fomentar la adopción ética y brindar apoyo a aquellos que deseen encontrar un nuevo hogar para sus mascotas.

Únete a nuestra comunidad y sé parte del cambio. Juntos podemos hacer una diferencia en la vida de los animales y promover la adopción como una opción responsable y amorosa.</p>
        <h3>Nuestra misión</h3>
        <p>
            Nulla at maximus dolor. Vestibulum ut ultrices erat. Phasellus tristique varius porta. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Maecenas viverra volutpat risus vel tincidunt. Duis sollicitudin in est vitae congue. In pulvinar turpis eu erat porttitor, at hendrerit nunc pulvinar. Suspendisse sed condimentum turpis, a rhoncus libero.
        </p>          
        
    </section>

</asp:Content>
