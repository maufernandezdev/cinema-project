<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Sucursalunicenter.aspx.cs" Inherits="Vistas.Sucursalunicenter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/diseñosucursales.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <div id="contenedor-suc">
        <h1>Cineteca Unicenter</h1>
        <p id="direc">
            <strong>Dirección:</strong>&nbsp Paraná 3745, B1640FRB Martínez, Provincia de Buenos Aires
            <br />
            <br />
            Actualmente posee 8 salas con sonido y  proyección digital  en 2D, y 3D distribuidas en  dos edificios.
            Siempre apuesta a brindar a su público lo mejor del cine.
        </p>
        <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3287.7837922705753!2d-58.529381085055554!3d-34.50836515996551!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x95bcb0f96f5bd589%3A0x78136febdc15b1cf!2sUnicenter%20Falabella!5e0!3m2!1sen!2sar!4v1592608366896!5m2!1sen!2sar" width="600" height="450" style="border:0;"  aria-hidden="false" tabindex="0"></iframe>
    </div>
</asp:Content>
