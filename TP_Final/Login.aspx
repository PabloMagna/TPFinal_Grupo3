<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TP_Final.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />   
    <%if (Session["Usuario"] == null)
        { %>
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="border rounded p-4">                    
                    <h2 class="fw-bold text-center py-5" style="background-color: #D2E3EB;">Bienvenid@ <iconify-icon icon="noto-v1:cat" width="45px"></iconify-icon></h2>
                    <div class="mb-4">
                        <label for="tbxEmail" class="form-label">Correo Electrónico</label>
                        <asp:TextBox runat="server" type="email" id="tbxEmail" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-4">
                        <label for="tbxContrasenia" class="form-label">Contraseña</label>
                        <asp:TextBox runat="server" type="password" id="tbxContrasenia" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-4">
                         <asp:Label runat="server" ID="lblLogueado" Visible="false" ForeColor="Red"><span></span></asp:Label>
                    </div>
                    <div class="d-grid">
                        <asp:Button runat="server" ID="btnInicioSesion" CssClass="btn btn-primary custom-btn" 
                            Text="Iniciar Sesión" type="button" OnClick="btnInicioSesion_Click"></asp:Button>
                        <style>
                            .custom-btn {
                                background-color: #C45F2E;
                                border-color: #C45F2E;
                            }

                                .custom-btn:hover {
                                    background-color: #FFA066;
                                    border-color: #FFA066;
                                }
                        </style>
                    </div>
                    <div class="my-3">
                        <span>No tienes cuenta? <a href="AltaCuenta.aspx">Registrate</a> / <a href="#">Registrar un refugio</a></span>
                        <span>No recuerdas tu contraseña? <a href="#">Recuperar Contraseña</a></span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <%} %>
</asp:Content>
