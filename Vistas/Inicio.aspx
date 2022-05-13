<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Vistas.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/inicio.css" rel="stylesheet" type="text/css" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/OwlCarousel2/2.3.4/assets/owl.carousel.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/OwlCarousel2/2.3.4/assets/owl.theme.default.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/OwlCarousel2/2.3.4/owl.carousel.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <div class="ddls">
        <asp:DropDownList CssClass="ddlsc mr-5" ID="ddlSuc" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSuc_SelectedIndexChanged">
        </asp:DropDownList><br />
        <asp:DropDownList CssClass="ddlsc" ID="ddlFunc" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        <asp:Button ID="btnddls" runat="server" CssClass="btn purple-gradient btnddls" Text="Ver Funciones" ValidationGroup="ddl" OnClick="btnddls_Click" />
    </div>
    <div class="lblerror">
        <asp:Label runat="server" ID="lblddl"></asp:Label>
    </div>
    <div class="peliculas">
        <h2>TODAS LAS PELÍCULAS</h2>
        <div class="owl-carousel owl-theme">
            <asp:ListView ID="lvPeliculas" runat="server" DataSourceID="sqldsPelis" GroupItemCount="15">
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td>
                        <asp:ImageButton CssClass="imgpelis" ID="imgpeli" runat="server" ImageUrl='<%# Eval("URL_Portada") %>' CommandName="eventoLvPelis" CommandArgument='<%# Eval("ID_Pelicula_FuncionxSala") %>' OnCommand="imgpeli_Command" />
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <asp:PlaceHolder ID="groupPlaceholder" runat="server"></asp:PlaceHolder>
                </LayoutTemplate>
            </asp:ListView>
            <asp:SqlDataSource ID="sqldsPelis" runat="server" ConnectionString="<%$ ConnectionStrings:CinetecaConnectionString %>" SelectCommand="sp_pelis" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        </div>
        <h2>PELICULAS 2D</h2>
        <div class="owl-carousel owl-theme">
            <asp:ListView ID="Lvpelis2d" runat="server" DataSourceID="sqldspelis2d" GroupItemCount="15">
                <GroupTemplate>
                    <tr runat="server" id="itemPlaceholderContainer">
                        <td runat="server" id="itemPlaceholder"></td>
                    </tr>
                </GroupTemplate>

                <ItemTemplate>
                    <td runat="server">
                        <div class="cont-peli">
                            <asp:ImageButton CssClass="imgpelis_" ID="imgpelis2d" runat="server" ImageUrl='<%# Eval("URL_Portada") %>' CommandName="eventoLvPelis2d" CommandArgument='<%# Eval("ID_Pelicula_FuncionxSala") %>' OnCommand="imgpeli2d_Command" />
                        </div>
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <asp:PlaceHolder ID="groupPlaceholder" runat="server"></asp:PlaceHolder>
                </LayoutTemplate>
            </asp:ListView>
            <asp:SqlDataSource runat="server" ID="sqldspelis2d" ConnectionString='<%$ ConnectionStrings:CinetecaConnectionString %>' SelectCommand="url_2d" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        </div>
        <h2>PELICULAS 3D</h2>
        <div class="owl-carousel owl-theme">
            <asp:ListView ID="Lvpelis3d" runat="server" DataSourceID="sqldspelis3d" GroupItemCount="15">
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td runat="server">
                        <asp:ImageButton CssClass="imgpelis_" ID="imgpelis3d" runat="server" ImageUrl='<%# Eval("URL_Portada") %>' CommandName="eventoLvPelis3d" CommandArgument='<%# Eval("ID_Pelicula_FuncionxSala") %>' OnCommand="imgpeli3d_Command" />
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <asp:PlaceHolder ID="groupPlaceholder" runat="server"></asp:PlaceHolder>
                </LayoutTemplate>
            </asp:ListView>
            <asp:SqlDataSource ID="sqldspelis3d" runat="server" ConnectionString="<%$ ConnectionStrings:CinetecaConnectionString %>" SelectCommand="url_3d" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        </div>

        <h2>PELICULAS 4D</h2>
        <div class="owl-carousel owl-theme">
            <asp:ListView ID="Lvpelis4d" runat="server" DataSourceID="sqldspelis4d" GroupItemCount="15">
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td runat="server">
                        <asp:ImageButton CssClass="imgpelis_" ID="imgpelis4d" runat="server" ImageUrl='<%# Eval("URL_Portada") %>' CommandName="eventoLvPelis4d" CommandArgument='<%# Eval("ID_Pelicula_FuncionxSala") %>' OnCommand="imgpeli4d_Command" />
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <asp:PlaceHolder ID="groupPlaceholder" runat="server"></asp:PlaceHolder>
                </LayoutTemplate>
            </asp:ListView>
            <asp:SqlDataSource ID="sqldspelis4d" runat="server" ConnectionString="<%$ ConnectionStrings:CinetecaConnectionString %>" SelectCommand="url_4d" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        </div>

        <h2>PELICULAS PREMIUM</h2>
        <asp:ListView ID="Lvpelispremium" runat="server" DataSourceID="sqldspelispremium" GroupItemCount="3">
            <GroupTemplate>
                <tr id="itemPlaceholderContainer" runat="server">
                    <td id="itemPlaceholder" runat="server"></td>
                </tr>
            </GroupTemplate>
            <ItemTemplate>
                <td runat="server">
                    <asp:ImageButton CssClass="imgpelis_" ID="imgpelispremium" runat="server" ImageUrl='<%# Eval("URL_Portada") %>' CommandName="eventoLvPelisPr" CommandArgument='<%# Eval("ID_Pelicula_FuncionxSala") %>' OnCommand="imgpeliPr_Command" />
                </td>
            </ItemTemplate>
            <LayoutTemplate>
                <asp:PlaceHolder ID="groupPlaceholder" runat="server"></asp:PlaceHolder>
            </LayoutTemplate>
        </asp:ListView>
        <asp:SqlDataSource ID="sqldspelispremium" runat="server" ConnectionString="<%$ ConnectionStrings:CinetecaConnectionString %>" SelectCommand="url_premium" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    </div>
    <script>
        var owl = $('.owl-carousel');
        owl.owlCarousel({
            items: 6,
            loop: true,
            margin: 2,
            autoplay: true,
            autoplayTimeout: 3000,
            autoplayHoverPause: true
        });
    </script>
</asp:Content>
