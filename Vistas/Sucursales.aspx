<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Sucursales.aspx.cs" Inherits="Vistas.Sucursales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/sucursales.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <div class="contenedor">
        <div>
            <asp:ListView ID="Lvsucursales" runat="server" DataSourceID="sqldssucursales" GroupItemCount="2">
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td runat="server">
                        <asp:ImageButton CssClass="imgsucursales" PostBackUrl='<%# Eval("Url_pagina") %>' ID="imgsucursales" runat="server" ImageUrl='<%# Eval("URL_Sucursal") %>' />
                        <asp:Label runat="server" CssClass="lblsucursal" ID="lblsucursal" Text='<%# Eval("Nombre_Sucursal") %>'></asp:Label>
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
            <asp:SqlDataSource ID="sqldssucursales" runat="server" ConnectionString="<%$ ConnectionStrings:CinetecaConnectionString %>" SelectCommand="SELECT * FROM [Sucursales]"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>
