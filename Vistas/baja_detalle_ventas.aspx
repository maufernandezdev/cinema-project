<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.Master" AutoEventWireup="true" CodeBehind="baja_detalle_ventas.aspx.cs" Inherits="Vistas.baja_detalle_ventas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/Ventas.css" />
    <link rel="stylesheet" type="text/css" href="css/DetalleDeVenta.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div class="contenido">
    
         
                <div class="filtro-cv">
                    <h1>Buscar</h1>
               <div class="item"><asp:TextBox  runat="server" placeholder="Número de venta" Class="input" ID="txt_num_venta"></asp:TextBox>
                   <asp:RegularExpressionValidator ID="RegVenta" runat="server" ValidationGroup="busqueda" ControlToValidate="txt_num_venta" ValidationExpression="^[0-9]*$" Class="validator-rojo" Text="Ingrese solo números"></asp:RegularExpressionValidator>
                   <asp:RequiredFieldValidator ID="regCampos" runat="server" text="*Campo obligatorio para la busqueda." ControlToValidate="txt_num_venta" ValidationGroup="busqueda" Class="validator-rojo"></asp:RequiredFieldValidator>
               </div>
             <div class="btn-item">
                 <asp:Button ID="btnBuscar" runat="server" ValidationGroup="busqueda" OnClick="Buscar_Click" Text="Buscar" Class="boton" /> 
                 <asp:Button ID="btbVolver" runat="server" OnClick="Volver_Click" Text="Volver" Class="boton" />
                 <asp:Button ID="BtnSeleccionados" runat="server" OnClick="Seleccion_Click" Text="Ver Selección" Class="boton" />
                 <asp:Button ID="btnBorrar" runat="server" OnClick="Borrar_Click" Text="Cancelar ventas" Class="boton-rojo" />
             </div>

           </div> 
            <div class="listado">
                <asp:GridView ID="grdDetalleVentas" runat="server" class="grid" AllowPaging="True" OnPageIndexChanging="grdDetalleVentas_PageIndexChanging" PageSize="5" AutoGenerateSelectButton="True"  AutoGenerateColumns="False" DataKeyNames="ID Venta,ID Detalle,Fecha,Precio" DataSourceID="dsDetalleVentas" OnSelectedIndexChanged="grdDetalleVentas_SelectedIndexChanged" >
                    <AlternatingRowStyle CssClass="alt" />

              
                    <Columns>
                        <asp:BoundField DataField="ID Venta" HeaderText="ID Venta" ReadOnly="True" SortExpression="ID Venta" />
                        <asp:BoundField DataField="ID Detalle" HeaderText="ID Detalle" InsertVisible="False" ReadOnly="True" SortExpression="ID Detalle" />
                        <asp:BoundField DataField="Función" HeaderText="Función" SortExpression="Función" />
                        <asp:BoundField DataField="Película" HeaderText="Película" SortExpression="Película" />
                        <asp:BoundField DataField="Sala" HeaderText="Sala" SortExpression="Sala" />
                        <asp:BoundField DataField="Asiento" HeaderText="Asiento" SortExpression="Asiento" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" />
                    </Columns>

        </asp:GridView>

            </div>
            
        <asp:SqlDataSource ID="dsDetalleVentas" runat="server" ConnectionString="<%$ ConnectionStrings:CinetecaConnectionString %>" SelectCommand="Select ID_Venta_DV[ID Venta],ID_DetalleVenta[ID Detalle],ID_Funcion_DV[Función],ID_Pelicula_DV[Película],ID_Sala_DV[Sala],ID_Asiento_DV[Asiento],Fecha_DV[Fecha],Precio from DetalleVentas WHERE Estado_DV='Realizado' ORDER BY ID_Venta_DV"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dsDetalleVentas_nv" runat="server" ConnectionString="<%$ ConnectionStrings:CinetecaConnectionString %>" SelectCommand="sp_detalleVenta_nv" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="txt_num_venta" Name="id" PropertyName="Text" Type="Int32" />
            </SelectParameters>
                </asp:SqlDataSource>
    </div>
</asp:Content>
