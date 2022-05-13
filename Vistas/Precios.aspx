<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Precios.aspx.cs" Inherits="Vistas.Precios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/precios.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <div class="contenedor">
        <h2 class="mb-5">PRECIOS DE SALAS</h2>
        <p>
            Encontrá aquí los precios de las entradas para tu película de boletería y venta web por tipo de sala 2D, 3D, PREMIUM o 4D.
            <br />
            Importante: No está permitido el ingreso a las salas con alimentos y bebidas adquiridos fuera de local.
        </p>
        <asp:ListView runat="server" ID="lvSalas" DataSourceID="sqldssalas" GroupItemCount="2">
            <GroupTemplate>
                <tr runat="server" id="itemPlaceholderContainer">
                    <td runat="server" id="itemPlaceholder"></td>
                </tr>
            </GroupTemplate>
            <ItemTemplate>
                <td runat="server">
                    <div class="items">
                        <asp:Label Text='<%# Eval("Descripcion_TipoSala") %>' runat="server" ID="Descripcion_TipoSalaLabel" /><br />
                        <asp:Label Text='<%# Eval("Precio_FuncionxSala") %>' runat="server" ID="Precio_FuncionxSalaLabel" /><br />
                    </div>
                </td>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table runat="server" id="groupPlaceholderContainer" style="" border="0">
                                <tr runat="server" id="groupPlaceholder"></tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style=""></td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:ListView>
        <asp:SqlDataSource runat="server" ID="sqldssalas" ConnectionString='<%$ ConnectionStrings:CinetecaConnectionString %>' SelectCommand="spSalas" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    </div>
    <div class="contenedor">
        <h2>PRECIOS DE ARTÍCULOS</h2>
        <asp:ListView runat="server" ID="lvArticulos" DataSourceID="sqldsArticulos" GroupItemCount="2">
            <GroupTemplate>
                <tr runat="server" id="itemPlaceholderContainer">
                    <td runat="server" id="itemPlaceholder"></td>
                </tr>
            </GroupTemplate>
            <ItemTemplate>
                <td runat="server" style="">
                    <div class="items-art">
                        <asp:Label Text='<%# Eval("Nombre_Articulo") %>' runat="server" ID="Nombre_ArticuloLabel" /><br />
                        <asp:ImageButton CssClass="img" runat="server" ID="ibArt" ImageUrl='<%# Eval("URL_Articulo") %>' />
                        <asp:Label Text='<%# Eval("Descripción_Articulo") %>' runat="server" ID="Descripción_ArticuloLabel" /><br />
                        <asp:Label Text='<%# Eval("Precio") %>' runat="server" ID="PrecioLabel" /><br />
                    </div>
                </td>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table runat="server" id="groupPlaceholderContainer" border="0">
                                <tr runat="server" id="groupPlaceholder"></tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style=""></td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:ListView>
        <asp:SqlDataSource runat="server" ID="sqldsArticulos" ConnectionString='<%$ ConnectionStrings:CinetecaConnectionString %>' SelectCommand="spArticulos" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    </div>
</asp:Content>
