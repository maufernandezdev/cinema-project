<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Vistas.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/perfil.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <div class="cont-perfil">
        <asp:Label ID="lbluser" runat="server"></asp:Label>
        <asp:Label ID="lblpass" runat="server"></asp:Label>
        <h2>TUS DATOS</h2>
        <asp:ListView ID="lvDatosUsuario" runat="server" DataSourceID="sqldsDatosCliente" DataKeyNames="DNI_Usuario" GroupItemCount="1">
            <GroupTemplate>
                <tr runat="server" id="itemPlaceholderContainer">
                    <td runat="server" id="itemPlaceholder"></td>
                </tr>
            </GroupTemplate>
            <ItemTemplate>
                <td runat="server" class="items">Nombre:
                <asp:Label Text='<%# Eval("Nombre") %>' runat="server" ID="NombreLabel" /><br />
                    Apellido:
                <asp:Label Text='<%# Eval("Apellido") %>' runat="server" ID="ApellidoLabel" /><br />
                    Fecha Nacimiento:
                <asp:Label Text='<%# Eval("Fecha_Nac","{0:d}") %>' runat="server" ID="Fecha_NacLabel" /><br />
                    Correo:
                <asp:Label Text='<%# Eval("Correo") %>' runat="server" ID="CorreoLabel" /><br />

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
        <asp:SqlDataSource runat="server" ID="sqldsDatosCliente" ConnectionString='<%$ ConnectionStrings:CinetecaConnectionString %>' SelectCommand="spVerificarUsuario" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter SessionField="Correo_Ac"  Name="Correo" Type="String"></asp:SessionParameter>
                <asp:SessionParameter SessionField="Contrase&#241;a_Ac" Name="Contrase&#241;a" Type="String"></asp:SessionParameter>
            </SelectParameters>
        </asp:SqlDataSource>
        <div class="d-flex align-items-center h3">
            <button type="button" class="btn btn-lg w-25 purple-gradient msglbl" data-toggle="modal" data-target="#modalCorreo">Cambiar Correo</button>
            <asp:Label runat="server" ID="lblCorreo"></asp:Label>
        </div>
        <div class="d-flex align-items-center h3">
            <button type="button" class="btn btn-lg w-25 purple-gradient h3 msglbl" data-toggle="modal" data-target="#modalContra">Cambiar Contraseña</button>
            <asp:Label runat="server" ID="lblContra"></asp:Label>
        </div>
        <div class="d-flex align-items-center h3">
            <button type="button" class="btn btn-lg w-25 purple-gradient h3 msglbl" data-toggle="modal" data-target="#modalCuenta">Eliminar Cuenta</button>
            <asp:Label runat="server" ID="lblEliminar"></asp:Label>
        </div>
    </div>
    <div class="modal fade" id="modalCorreo" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header text-center">
                    <h4 class="modal-title w-100 font-weight-bold">Cambiar Correo Electrónico</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body mx-3">
                    <div class="md-form mb-5">
                        <asp:TextBox runat="server" ID="txtCorreo" CssClass="form-control p-4"></asp:TextBox>
                        <asp:RegularExpressionValidator runat="server" ID="reCorreo" ControlToValidate="txtCorreo" ValidationGroup="correo" Text="Ingrese un correo válido." CssClass="red-text msgerror" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator runat="server" ID="rfCorreo" ControlToValidate="txtCorreo" ValidationGroup="correo" Text="El campo no puede estar vacío." CssClass="red-text msgerror"></asp:RequiredFieldValidator>
                        <label for="txtCorreo">Nuevo Correo Electrónico</label>
                    </div>
                </div>
                <div class="modal-footer d-flex justify-content-center">
                    <asp:Button runat="server" ID="btnCambiarCorreo" ValidationGroup="correo" Text="Confirmar" CssClass="btn purple-gradient" OnClick="btnCambiarCorreo_Click" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalContra" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header text-center">
                    <h4 class="modal-title w-100 font-weight-bold">Cambiar Contraseña</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body mx-3">
                    <div class="md-form mb-5">
                        <asp:TextBox runat="server" ID="txtContra" CssClass="form-control p-4" TextMode="Password"></asp:TextBox>
                        <label for="txtContra">Nueva Contraseña</label>
                        <asp:RequiredFieldValidator runat="server" ID="rfContra" CssClass="red-text msgerror" ControlToValidate="txtContra" Text="La contraseña no puede estar vacía." ValidationGroup="contra"></asp:RequiredFieldValidator>
                        <asp:CustomValidator runat="server" ID="CuvContra" ControlToValidate="txtContra" CssClass="red-text" ValidationGroup="contra" OnServerValidate="CuvContra_ServerValidate"></asp:CustomValidator>
                    </div>
                    <div class="md-form mb-5">
                        <asp:TextBox runat="server" ID="txtContrarepeat" CssClass="form-control p-4" TextMode="Password"></asp:TextBox>
                        <label for="txtContrarepeat">Repita Contraseña</label>
                        <asp:CompareValidator runat="server" ID="cvContra" ControlToValidate="txtContra" ValidationGroup="contra" ControlToCompare="txtContrarepeat" CssClass="red-text msgerror" Text="Las contraseñas deben coincidir."></asp:CompareValidator>
                    </div>
                </div>
                <div class="modal-footer d-flex justify-content-center">
                    <asp:Button runat="server" ID="btnCambiarContraseña" Text="Confirmar" CssClass="btn purple-gradient" ValidationGroup="contra" OnClick="btnCambiarContraseña_Click" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalCuenta" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog modal-notify modal-danger" role="document">
            <!--Content-->
            <div class="modal-content">
                <!--Header-->
                <div class="modal-header">
                    <p class="heading lead">Modal Danger</p>

                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true" class="white-text">&times;</span>
                    </button>
                </div>

                <!--Body-->
                <div class="modal-body">
                    <div class="text-center">
                        <i class="fas fa-question fa-4x mb-3 animated swing infinite"></i>
                        <p>
                            ¿Está seguro? La cuenta se inhabilitará hasta que vuelva a iniciar sesión.
                        </p>
                    </div>
                </div>

                <!--Footer-->
                <div class="modal-footer justify-content-center">
                    <asp:Button runat="server" ID="btnConfirm" Text="Aceptar" CssClass="btn purple-gradient" OnClick="btnConfirm_Click" />
                    <a type="button" class="btn purple-gradient" data-dismiss="modal">Cancelar</a>
                    
                </div>
            </div>
            <!--/.Content-->
        </div>
    </div>
</asp:Content>
