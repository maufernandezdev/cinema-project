<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.Master" AutoEventWireup="true" CodeBehind="dev_seleccionados.aspx.cs" Inherits="Vistas.dev_seleccionados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/Ventas.css" />
    <link rel="stylesheet" type="text/css" href="css/DetalleDeVenta.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div class="contenido-dv">
        
                <div class="filtro-sv">
             <div class="btn-item">
                 <asp:Button ID="btbVolver" runat="server" OnClick="Volver_Click" Text="Volver" Class="boton" />
                 <asp:Button ID="btnCancelarSeleccion" runat="server" OnClick="Cancelar_Click" Text="Cancelar selección" Class="boton" />
                 <asp:Button ID="btnCancelarVentas" runat="server" OnClick="Borrar_Click" Text="Cancelar ventas" Class="boton-rojo" />
                 
             </div>
           </div> 
            <div class="list-select">
                <asp:GridView ID="grdDetallesSelect" runat="server" class="grid-select" AllowPaging="True" OnPageIndexChanging="grdDetallesSelect_PageIndexChanging" PageSize="5"  >
                    <AlternatingRowStyle CssClass="alt" />
                    </asp:GridView>
            </div>
        </div>
</asp:Content>
