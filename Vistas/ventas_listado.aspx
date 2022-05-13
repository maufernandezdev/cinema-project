<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.Master" AutoEventWireup="true" CodeBehind="ventas_listado.aspx.cs" Inherits="Vistas.ventas_listado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/Ventas.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">

    <div class="contenido">
       <section class="filtros">
           
             <div class="item"><asp:TextBox  runat="server" placeholder="Dni" Class="input" ID="txt_dni"></asp:TextBox>
                 <asp:RegularExpressionValidator ID="regExpNumero" runat="server" ValidationGroup="busqueda"  ControlToValidate="txt_dni" ValidationExpression="^[0-9]*$" Class="validator-rojo" Text="Ingrese solo números"></asp:RegularExpressionValidator>
                 
             </div>           
             <div class="item"><asp:TextBox runat="server" placeholder="Número de venta" class="input" ID="txt_venta"></asp:TextBox>
                 <asp:RegularExpressionValidator ID="RegVenta" runat="server" ValidationGroup="busqueda" ControlToValidate="txt_venta" ValidationExpression="^[0-9]*$" Class="validator-rojo" Text="Ingrese solo números"></asp:RegularExpressionValidator>

             </div> 
           <div class="item"><asp:TextBox  runat="server" placeholder="dd/mm/aa" type="date" class="input" ID="txt_fecha">    </asp:TextBox></div>
            
             <div class="btn-item">
                 <asp:Button ID="btnFiltrar" runat="server" ValidationGroup="busqueda" OnClick="Filtrar_Click" Text="Filtrar" Class="boton" />
                 <asp:Button ID="btnQuitarFiltro" runat="server" OnClick="Reset_Click" Text="Mostrar todas" Class="boton" />
            </div>

           <div class="campoVacio"><asp:Label ID="lbl_campoObligatorio" runat="server" Text="*Es obligatorio llenar un campo para la busqueda." /></div>
           
                
            
        </section>
        <div class="listado">
                <asp:GridView ID="grdVentas" runat="server" class="grid" AllowPaging="True" OnPageIndexChanging="grdVentas_PageIndexChanging" PageSize="5">
                    <AlternatingRowStyle CssClass="alt" />
                             
        </asp:GridView>
            </div>
   
        
    
    </div>

</asp:Content>
