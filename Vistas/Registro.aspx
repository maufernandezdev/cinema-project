<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Vistas.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/registro.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <div class="form-reg w-50">        
        <h2 class="subt">REGISTRARSE</h2>
        <div class="form-row mb-4">
            <div class="col d-flex">
                <asp:TextBox runat="server" ID="nombre" placeholder="Nombre" CssClass="form-control mr-2"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" CssClass="red-text msgerror" ID="rfNombre" ControlToValidate="nombre" Text="*" ValidationGroup="reg"></asp:RequiredFieldValidator>
            </div>
            <div class="col d-flex">
                <asp:TextBox runat="server" CssClass="form-control mr-2" placeholder="Apellido" ID="ape"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="rfApe" ControlToValidate="ape" CssClass="red-text msgerror" Text="*" ValidationGroup="reg"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="d-flex mb-4">
            <asp:TextBox placeholder="DNI" runat="server" CssClass="form-control mr-2" ID="dni"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfdni" CssClass="red-text msgerror" Text="*" ValidationGroup="reg" ControlToValidate="dni"></asp:RequiredFieldValidator>
        </div>
        <div class="d-flex">
            <asp:TextBox placeholder="Contraseña" runat="server" ID="contra" TextMode="Password" CssClass="form-control mr-2"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfContraseñareg" ControlToValidate="contra" ValidationGroup="reg" CssClass="red-text msgerror" Text="*"></asp:RequiredFieldValidator>
        </div>
        <asp:CustomValidator runat="server" ID="cvContra" ControlToValidate="contra" Text="La contraseña no debe pasar los 30 caracteres." CssClass="red-text" ValidationGroup="reg" OnServerValidate="cvContra_ServerValidate"></asp:CustomValidator>
        <div class="d-flex">
            <asp:TextBox placeholder="Repita Contraseña" runat="server" ID="contrarepeat" TextMode="Password" CssClass="form-control mr-2"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfcontrasiguales" CssClass="red-text msgerror" ControlToValidate="contrarepeat" Text="*" ValidationGroup="reg"></asp:RequiredFieldValidator>
        </div>
        <asp:CompareValidator runat="server" ID="contrasiguales" CssClass="red-text" ValidationGroup="reg" Text="Las contraseñas deben coincidir." ControlToCompare="contra" ControlToValidate="contrarepeat"></asp:CompareValidator>
        <div class="d-flex">
            <asp:TextBox placeholder="Correo Electrónico" runat="server" ID="email" CssClass="form-control mr-2"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfcorreoReg" ControlToValidate="email" CssClass="red-text msgerror" ValidationGroup="reg" Text="*"></asp:RequiredFieldValidator>
        </div>
        <asp:RegularExpressionValidator runat="server" CssClass="red-text" ID="recorreoReg" ValidationGroup="reg" ControlToValidate="email" Text="Ingrese un correo válido." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <div class="d-flex mb-3">
            <asp:TextBox placeholder="Fecha de Nacimiento" runat="server" ID="fecha" CssClass="form-control mr-2" TextMode="Date"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfFecha" CssClass="red-text msgerror" ValidationGroup="reg" ControlToValidate="fecha" Text="*"></asp:RequiredFieldValidator>
        </div>
        <asp:ValidationSummary runat="server" ID="vsReg" HeaderText="Complete los campos requeridos (*)" CssClass="red-text" ValidationGroup="reg" />
        <div class="d-flex justify-content-center align-items-center">
            <asp:Button runat="server" ID="btnregistro" class="btn purple-gradient" Text="Registrarse" ValidationGroup="reg" OnClick="btnregistro_Click" />
            <asp:Label runat="server" ID="lblReg"></asp:Label>
        </div>
    </div>
</asp:Content>
