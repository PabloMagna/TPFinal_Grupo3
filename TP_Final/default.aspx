<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="TP_Final._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/home.css" rel="stylesheet" type="text/css" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
</asp:Content>
