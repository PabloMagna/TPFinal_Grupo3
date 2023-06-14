<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="formPublicacion.aspx.cs" Inherits="TP_Final.Publicar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Alta Publicacion</title>
    <link href="css/formPublicacion.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="portada">
        <h1 id="titulo">Formulario de alta de mascota en adopción</h1>
        <h4><em>Necesitaremos que completes los siguientes datos.</em></h4>
    </section>
    <section class="formulario">
        <div class="mb-3">
          <label for="exampleFormControlInput1" class="form-label">Nombre</label>
          <input type="text" class="form-control" id="" placeholder="">
        </div>
        <div class="mb-3">
          <label for="exampleFormControlInput1" class="form-label">Especie</label>
          <input type="text" class="form-control" id="" placeholder="">
        </div>
        <div class="mb-3">
          <label for="exampleFormControlInput1" class="form-label">Raza</label>
          <input type="text" class="form-control" id="" placeholder="">
        </div>
         <div class="mb-3">
          <label for="exampleFormControlInput1" class="form-label">Tamaño</label>
          <input type="text" class="form-control" id="" placeholder="">
        </div>
        <div class="mb-3">
          <label for="exampleFormControlInput1" class="form-label">Edad</label>
          <input type="number" class="form-control" id="" placeholder="">
        </div>
        <div class="mb-3">
          <label for="exampleFormControlTextarea1" class="form-label">Descripción</label>
          <textarea class="form-control" id="" rows="10"></textarea>
        </div>
    </section>
</asp:Content>
