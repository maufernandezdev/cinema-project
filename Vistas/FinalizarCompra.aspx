<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="FinalizarCompra.aspx.cs" Inherits="Vistas.FinalizarCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/FinalizarVenta.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 30%;
            font-family: 'Kanit', sans-serif;
            color: #F8F8FF;
            font-size: 1.6rem;
            text-align: left;
            height: 29px;
        }
        .auto-style2 {
            width: 50%;
            font-family: 'Kanit', sans-serif;
            color: #F8F8FF;
            font-size: 1.6rem;
            text-align: center;
            height: 29px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
    <div class="center">
        <table class="table">
            <tr>
                <td class="td">Tipo de tarjeta:</td>
                <td class="td2">
                    <asp:DropDownList ID="ddlOp" runat="server" CssClass="ddlop" ValidationGroup="Pago">
                        <asp:ListItem>--Tipo</asp:ListItem>
                        <asp:ListItem>Credito</asp:ListItem>
                        <asp:ListItem>Debito</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvOp" runat="server" ControlToValidate="ddlOp" ErrorMessage="Seleccione un tipo de tarjeta" InitialValue="--Tipo" ValidationGroup="Pago">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Número</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtNumero" runat="server" CssClass="offset-sm-0" Width="150px" ViewStateMode="Enabled" ValidationGroup="Pago"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="rvNumero" runat="server" ErrorMessage="Ingrese 16 dígitos númericos" ValidationExpression="^\d{16}$" ControlToValidate="txtNumero" ValidationGroup="Pago">*</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rfvNumero" runat="server" ControlToValidate="txtNumero" ErrorMessage="Ingrese el número de su tarjeta" ValidationGroup="Pago">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Código de seguridad:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtCodigo" runat="server" Width="40px" ValidationGroup="Pago"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="rvCodigo" runat="server" ErrorMessage="Ingrese 3 dígitos numéricos" ValidationExpression="^\d{3}$" ControlToValidate="txtCodigo" ValidationGroup="Pago">*</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ControlToValidate="txtCodigo" ErrorMessage="Ingrese el código de seguridad" ValidationGroup="Pago">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="td">Vencimiento:</td>
                <td class="td2">&nbsp;<asp:DropDownList ID="ddlMes" runat="server" CssClass="ddlfecha" ValidationGroup="Pago">
                        <asp:ListItem>--Mes</asp:ListItem>
                        <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
&nbsp;<asp:RequiredFieldValidator ID="rfvMes" runat="server" ControlToValidate="ddlMes" ErrorMessage="Seleccione un mes" InitialValue="--Mes" ValidationGroup="Pago">*</asp:RequiredFieldValidator>
                    &nbsp;
                    <asp:DropDownList ID="ddlAnio" CssClass="ddlfecha" runat="server" ValidationGroup="Pago">
                        <asp:ListItem>--Año</asp:ListItem>
                        <asp:ListItem>2020</asp:ListItem>
                        <asp:ListItem>2021</asp:ListItem>
                        <asp:ListItem>2022</asp:ListItem>
                        <asp:ListItem>2023</asp:ListItem>
                        <asp:ListItem>2024</asp:ListItem>
                        <asp:ListItem>2025</asp:ListItem>
                        <asp:ListItem>2026</asp:ListItem>
                    </asp:DropDownList>
                &nbsp;<asp:RequiredFieldValidator ID="rfvAnio" runat="server" ControlToValidate="ddlAnio" ErrorMessage="Seleccione un año" InitialValue="--Año" ValidationGroup="Pago">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="td">Titular:</td>
                <td class="td2">
                    <asp:TextBox ID="txtTitular" runat="server" Width="250px" ValidationGroup="Pago"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="rvtTitular" runat="server" ValidationExpression="^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$" ControlToValidate="txtTitular" ValidationGroup="Pago" ErrorMessage="Ingrese solo datos alfabéticos">*</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rfvTitular" runat="server" ControlToValidate="txtTitular" ErrorMessage="Ingrese el titular de la tarjeta" ValidationGroup="Pago">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            </table>
            <h1 class="h3">
            <br />
                        <asp:Button ID="btnPagar" runat="server" CssClass="btnes" Text="Pagar" OnClick="btnPagar_Click" ValidationGroup="Pago" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnCancelar" runat="server" CssClass="btnes" Text="Cancelar" OnClick="btnCancelar_Click" />
                    <br />
        </h1>
         </div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="val" ValidationGroup="Pago" Font-Size="Medium" ForeColor="White" />
            <br />
</asp:Content>
