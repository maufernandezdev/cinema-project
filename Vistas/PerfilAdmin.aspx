<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.Master" AutoEventWireup="true" CodeBehind="PerfilAdmin.aspx.cs" Inherits="Vistas.PerfilAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/Alta.css" type="text/css" />
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div class="contenido">
        <div class="perfil">

            <asp:ListView runat="server" ID="lvPerfilAdmin" DataSourceID="sqldspAdmin" GroupItemCount="3">
            <GroupTemplate>
                <tr runat="server" id="itemPlaceholderContainer">
                    <td runat="server" id="itemPlaceholder"></td>
                </tr>
            </GroupTemplate>
            <ItemTemplate>
                <td runat="server" style="">
                    <div class="foto">
                        <asp:Image runat="server" class="foto-perfil"  ID="imgPerfil" ImageUrl='<%# Eval("URL_fotoPerfil") %>' />
                        
                    </div>
                    <div class="datos-perfil">
                    <asp:Label class="label-perfil" Text='Nombre:' runat="server" ID="nombre_lbl" />
                    <asp:Label class="label-perfil" Text='<%# Eval("Nombre") %>' runat="server" ID="lbl_nombre" /><br />
                    <asp:Label class="label-perfil" Text='Apellido:' runat="server" ID="apellido_lbl" />
                    <asp:Label class="label-perfil" Text='<%# Eval("Apellido") %>' runat="server" ID="lbl_apellido" /><br />    
                    <asp:Label class="label-perfil" Text='Fecha de nacimiento:' runat="server" ID="fec_nac_lbl" />
                    <asp:Label class="label-perfil" Text='<%# Eval("Fecha_Nac","{0:d}") %>' runat="server" ID="Fecha_NacLabel" /><br />
                    <asp:Label class="label-perfil" Text='Mail:' runat="server" ID="mail_lbl" />
                    <asp:Label class="label-perfil" Text='<%# Eval("Correo") %>' runat="server" ID="CorreoLabel" /><br />
                    </div>
                    
                </td>
            </ItemTemplate>
        </asp:ListView>

        </div>
        
        <asp:SqlDataSource runat="server" ID="sqldspAdmin" ConnectionString='<%$ ConnectionStrings:CinetecaConnectionString %>' SelectCommand="spTraerAdmin" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter SessionField="Correo_Ac" Name="Correo" Type="String"></asp:SessionParameter>
                <asp:SessionParameter SessionField="Contrase&#241;a_Ac" Name="Contrase&#241;a" Type="String"></asp:SessionParameter>
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
