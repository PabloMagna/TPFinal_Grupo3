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
        <p>
            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut quis turpis dui. Morbi tristique nisl velornareauctor.Sedvulputate magna et nisi vestibulum, nec vulputate nibh commodo. Cras fermentum eros id sagittis semper. Integer vulputate, massa at dignissim gravida, felis enim ultrices nunc, vel aliquet dui quam ut ex. Donec arcu dolor, placerat eu velit ac, gravida consequat neque. Proin porta sagittis condimentum. Nulla sit amet imperdiet purus. Suspendisse ullamcorper justo aliquet mollis laoreet.<br />
            Ut augue eros, mollis sed scelerisque ac, bibendum sit amet diam. Phasellus ut metus non ante tempor dignissim. Duis fringilla quis enim sed feugiat. Suspendisse sit amet diam quis nunc molestie commodo in ullamcorper diam. Nullam eget eros elementum, pharetra eros eget, luctus tortor. Nulla non est orci. Vestibulum tempus libero at neque sagittis, a iaculis erat rhoncus. Fusce ut fringilla lectus. Etiam a mi eget eros eleifend tincidunt sed ullamcorper lacus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur sagittis hendrerit ligula, aliquam finibus tellus pellentesque sit amet. Sed sagittis blandit arcu a dapibus. Etiam mollis et diam a viverra.
        </p>
        <h3>Nuestra misión</h3>
        <p>
            Nulla at maximus dolor. Vestibulum ut ultrices erat. Phasellus tristique varius porta. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Maecenas viverra volutpat risus vel tincidunt. Duis sollicitudin in est vitae congue. In pulvinar turpis eu erat porttitor, at hendrerit nunc pulvinar. Suspendisse sed condimentum turpis, a rhoncus libero.
        </p>          
        
    </section>

</asp:Content>
