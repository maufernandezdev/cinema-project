<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="FacturasCliente.aspx.cs" Inherits="Vistas.ComprasCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/funciones.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <h2>COMPRAS</h2>
    <asp:GridView runat="server" CssClass="grid" ID="gvFacturas" AutoGenerateColumns="False" DataKeyNames="ID_Venta" DataSourceID="sqldsFacturaCliente" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvFacturas_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="ID_Venta" HeaderText="ID Venta" HeaderStyle-CssClass="header-gv" ItemStyle-CssClass="item-gv" ReadOnly="True" InsertVisible="False" SortExpression="ID_Venta"></asp:BoundField>
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" HeaderStyle-CssClass="header-gv" ItemStyle-CssClass="item-gv" SortExpression="Fecha" DataFormatString="{0:d}"></asp:BoundField>
            <asp:BoundField DataField="ID_Promocion_Venta" HeaderStyle-CssClass="header-gv" ItemStyle-CssClass="item-gv" HeaderText="Promoción" SortExpression="ID_Promocion_Venta"></asp:BoundField>
            <asp:BoundField DataField="Total" HeaderText="Total" HeaderStyle-CssClass="header-gv" ItemStyle-CssClass="item-gv" SortExpression="Total"></asp:BoundField>
            <asp:BoundField DataField="Estado_Venta" HeaderStyle-CssClass="header-gv" ItemStyle-CssClass="item-gv" HeaderText="Estado" SortExpression="Estado_Venta"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource runat="server" ID="sqldsFacturaCliente" ConnectionString='<%$ ConnectionStrings:CinetecaConnectionString %>' SelectCommand="spVentaCliente" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter SessionField="Correo_Ac" Name="Correo" Type="String"></asp:SessionParameter>
            <asp:SessionParameter SessionField="Contrase&#241;a_Ac" Name="Contrase&#241;a" Type="String"></asp:SessionParameter>
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
