<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Promociones.aspx.cs" Inherits="Vistas.Promociones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Promociones.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <div class="items">
        <asp:ListView ID="LvPromos" runat="server" DataSourceID="sqldspromos" GroupItemCount="2">
            <GroupTemplate>
                <tr id="itemPlaceholderContainer" runat="server">
                    <td id="itemPlaceholder" runat="server"></td>
                </tr>
            </GroupTemplate>
            <ItemTemplate>
                <td runat="server">
                    <div class="contenedor-item">
                        <asp:ImageButton CssClass="img-promo" ID="imgpromo" runat="server" ImageUrl='<%# Eval("Url_Imagen") %>' />
                        <br />
                        <div class="n-promo">
                            <asp:Label CssClass="nombre" ID="Nombre_PromocionLabel" runat="server" Text='<%# Eval("Nombre_Promocion") %>' />
                            <br />
                            <asp:Label ID="Descripcion_PromocionLabel" runat="server" Text='<%# Eval("Descripcion_Promocion") %>' />
                            <br />
                            <br />
                            <br />
                            <a href="#">Ver Bases y Condiciones</a>
                        </div>
                    </div>
                </td>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="groupPlaceholderContainer" runat="server" border="0">
                                <tr id="groupPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server"></td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:ListView>
    </div>
    <asp:SqlDataSource runat="server" ID="sqldspromos" ConnectionString="<%$ ConnectionStrings:CinetecaConnectionString %>" SelectCommand="Sp_Promos" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</asp:Content>
