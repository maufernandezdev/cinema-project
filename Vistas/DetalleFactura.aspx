<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="DetalleFactura.aspx.cs" Inherits="Vistas.DetalleFactura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/funciones.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <br />
    <a href="FacturasCliente.aspx" class="h3 white-text text-light">Volver a Compras</a>
    <h2>DETALLE DE COMPRA</h2>
    <asp:GridView runat="server" ID="gvDetalleFactura" CssClass="grid" AutoGenerateColumns="False" DataKeyNames="ID Venta,ID Detalle" DataSourceID="sqldsDetalleFactura">
        <Columns>
            <asp:BoundField HeaderStyle-CssClass="header-gv" ItemStyle-CssClass="item-gv" DataField="ID Detalle" HeaderText="ID Detalle" ReadOnly="True" SortExpression="ID Detalle"></asp:BoundField>
            <asp:BoundField HeaderStyle-CssClass="header-gv" ItemStyle-CssClass="item-gv" DataField="Funci&#243;n" HeaderText="Funci&#243;n" SortExpression="Funci&#243;n"></asp:BoundField>
            <asp:BoundField HeaderStyle-CssClass="header-gv" ItemStyle-CssClass="item-gv" DataField="Pel&#237;cula" HeaderText="Pel&#237;cula" SortExpression="Pel&#237;cula"></asp:BoundField>
            <asp:BoundField HeaderStyle-CssClass="header-gv" ItemStyle-CssClass="item-gv" DataField="Sala" HeaderText="Sala" SortExpression="Sala"></asp:BoundField>
            <asp:BoundField HeaderStyle-CssClass="header-gv" ItemStyle-CssClass="item-gv" DataField="Asiento" HeaderText="Asiento" SortExpression="Asiento"></asp:BoundField>
            <asp:BoundField HeaderStyle-CssClass="header-gv" ItemStyle-CssClass="item-gv" DataField="Precio" HeaderText="Precio" SortExpression="Precio"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource runat="server" ID="sqldsDetalleFactura" ConnectionString='<%$ ConnectionStrings:CinetecaConnectionString %>' SelectCommand="sp_detalleVenta_nv" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter SessionField="ID_Venta" Name="id" Type="Int32"></asp:SessionParameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <h2>ARTÍCULOS</h2>
    <asp:GridView runat="server" ID="gvdvArt" CssClass="grid" DataSourceID="sqldsDetFacturaArt" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField HeaderStyle-CssClass="header-gv" ItemStyle-CssClass="item-gv" DataField="Nombre_Articulo" HeaderText="Artículo" SortExpression="Nombre_Articulo"></asp:BoundField>
            <asp:BoundField HeaderStyle-CssClass="header-gv" ItemStyle-CssClass="item-gv" DataField="Descripción_Articulo" HeaderText="Descripción" SortExpression="Descripción_Articulo"></asp:BoundField>
            <asp:BoundField HeaderStyle-CssClass="header-gv" ItemStyle-CssClass="item-gv" DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad"></asp:BoundField>
            <asp:BoundField HeaderStyle-CssClass="header-gv" ItemStyle-CssClass="item-gv" DataField="Precio" HeaderText="Precio" SortExpression="Precio"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource runat="server" ID="sqldsDetFacturaArt" ConnectionString='<%$ ConnectionStrings:CinetecaConnectionString %>' SelectCommand="spDetFacturaArt" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter SessionField="ID_Venta" Name="ID" Type="Int32"></asp:SessionParameter>
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
