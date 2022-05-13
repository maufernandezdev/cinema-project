<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Funciones.aspx.cs" Inherits="Vistas.Funciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/funciones.css" type="text/css" />
    <link rel="stylesheet" href="css/inicio.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">

    <div class="d-flex justify-content-center mt-5">
        <asp:DropDownList CssClass="ddlsc" runat="server" ID="ddlSala" AutoPostBack="true" OnSelectedIndexChanged="ddlSala_SelectedIndexChanged"></asp:DropDownList>
    </div>
    <asp:Label runat="server" ID="lbliniciosesion" CssClass="d-none"><i class="fas fa-exclamation animated zoomIn infinite mr-3"></i>Debe iniciar sesión para realizar la compra.</asp:Label>

    <h2>FUNCIONES</h2>
    <asp:GridView ID="gvFunciones" runat="server" DataSourceID="sqldsfunciones" AutoGenerateColumns="False" CssClass="grid" OnSelectedIndexChanged="gvFunciones_SelectedIndexChanged" AutoGenerateSelectButton="True" DataKeyNames="Fecha_FuncionxSala,Hora_Inicio_FuncionxSala,Precio_FuncionxSala">
        <Columns>
            <asp:BoundField HeaderStyle-CssClass="header-gv" ItemStyle-CssClass="item-gv" DataField="Fecha_FuncionxSala" HeaderText="Fecha" SortExpression="Fecha_FuncionxSala" DataFormatString="{0:d}"></asp:BoundField>
            <asp:BoundField HeaderStyle-CssClass="header-gv" ItemStyle-CssClass="item-gv" DataField="Hora_Inicio_FuncionxSala" HeaderText="Horario" SortExpression="Hora_Inicio_FuncionxSala"></asp:BoundField>
            <asp:BoundField HeaderStyle-CssClass="header-gv" ItemStyle-CssClass="item-gv" DataField="Precio_FuncionxSala" HeaderText="Precio" SortExpression="Precio_FuncionxSala"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource runat="server" ID="sqldsfunciones" ConnectionString='<%$ ConnectionStrings:CinetecaConnectionString %>' SelectCommand="spSucursalesFuncion" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter SessionField="ID_Pelicula" Name="ID_Pelicula" Type="String"></asp:SessionParameter>
            <asp:SessionParameter SessionField="ID_Sucursal" Name="ID_Sucursal" Type="String"></asp:SessionParameter>
            <asp:SessionParameter SessionField="ID_t_Sala" Name="ID_TipoSala" Type="Int32"></asp:SessionParameter>
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
