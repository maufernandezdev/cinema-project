<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.Master" AutoEventWireup="true" CodeBehind="peliculas_alta.aspx.cs" Inherits="Vistas.peliculas_alta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <link rel="stylesheet" type="text/css" href="css/Alta.css" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div class="contenido">
        <section class="registro">
            <h4>Agregar película</h4>
            <asp:TextBox Class="controles" runat="server" name="id" placeholder="ID"  ID="txt_id_peli"></asp:TextBox>
            <asp:CustomValidator ID="cv_id_peli" runat="server" Text="Máximo 4 caracteres" ControlToValidate="txt_id_peli" Class="validator-rojo" OnServerValidate="CustomValidator11_ServerValidate" ValidationGroup="Agreg"></asp:CustomValidator>
            <asp:RequiredFieldValidator ID="req_id" runat="server" Text="*Campo obligatorio" ControlToValidate="txt_id_peli" Class="valid-rojo" ValidationGroup="Agreg"></asp:RequiredFieldValidator>

            <asp:TextBox Class="controles" runat="server" name="estado" placeholder="Estado"  ID="txt_estado_peli"></asp:TextBox>
            <asp:CustomValidator ID="cv_estado_peli" runat="server" Text="Máximo 20 caracteres" ControlToValidate="txt_estado_peli" Class="validator-rojo" OnServerValidate="CustomValidator12_ServerValidate" ValidationGroup="Agreg"></asp:CustomValidator>
            <asp:RequiredFieldValidator ID="req_estado" runat="server" Text="*Campo obligatorio" ControlToValidate="txt_estado_peli" Class="valid-rojo" ValidationGroup="Agreg"></asp:RequiredFieldValidator>
            
            <asp:TextBox Class="controles" runat="server" name="titulo" placeholder="Título"  ID="txt_titulo_peli"></asp:TextBox>
            <asp:CustomValidator ID="cv_titulo" runat="server" Text="Máximo 50 caracteres" ControlToValidate="txt_titulo_peli" Class="validator-rojo" OnServerValidate="CustomValidator13_ServerValidate" ValidationGroup="Agreg"></asp:CustomValidator>
            <asp:RequiredFieldValidator ID="req_titulo" runat="server" Text="*Campo obligatorio" ControlToValidate="txt_titulo_peli" Class="valid-rojo" ValidationGroup="Agreg"></asp:RequiredFieldValidator>
            
            
            <asp:TextBox Class="controles" runat="server" name="duracion" placeholder="Duración"  ID="txt_duracion_peli"></asp:TextBox>
            <asp:RangeValidator ID="rg_durac_peli" runat="server" Text="Expresión invalida" ControlToValidate="txt_duracion_peli" Class="validator-rojo" ValidationGroup="Agreg" MaximumValue="300" MinimumValue="0" Type="Integer" ></asp:RangeValidator>
            <asp:RequiredFieldValidator ID="req_durac" runat="server" Text="*Campo obligatorio" ControlToValidate="txt_duracion_peli" Class="valid-rojo" ValidationGroup="Agreg"></asp:RequiredFieldValidator>    
            
            <asp:TextBox Class="controles" runat="server" name="clasif" placeholder="Clasificación"  ID="txt_clasif_peli"></asp:TextBox>
            <asp:CustomValidator ID="cv_clasif" runat="server" Text="Máximo 50 caracteres" ControlToValidate="txt_clasif_peli" Class="validator-rojo" OnServerValidate="CustomValidator14_ServerValidate" ValidationGroup="Agreg"></asp:CustomValidator>
            <asp:RequiredFieldValidator ID="req_clasif" runat="server" Text="*Campo obligatorio" ControlToValidate="txt_clasif_peli" Class="valid-rojo" ValidationGroup="Agreg"></asp:RequiredFieldValidator>
            
            
            <asp:TextBox Class="controles" runat="server" name="url" placeholder="imagenes/peliculas/titulo.jpg" ID="txt_url_peli"></asp:TextBox>
            <asp:CustomValidator ID="cv_url" runat="server" Text="Máximo 50 caracteres" ControlToValidate="txt_url_peli" Class="validator-rojo" OnServerValidate="CustomValidator15_ServerValidate" ValidationGroup="Agreg"></asp:CustomValidator>
            <asp:RequiredFieldValidator ID="req_url" runat="server" Text="*Campo obligatorio" ControlToValidate="txt_url_peli" Class="valid-rojo" ValidationGroup="Agreg"></asp:RequiredFieldValidator>
            
            <asp:Button  ID="btnAgregar" runat="server" Text="Agregar" ValidationGroup="Agreg" Class="botons" OnClick="btnAgregar_Click" />
        </section>
        <div class="filtro-p">
            <h1>Buscar</h1> 
               <div class="item"><asp:TextBox  runat="server" placeholder="Ingrese una película" Class="input" ID="txt_peli"></asp:TextBox></div>                              
             <div class="btn-item">
                 <asp:Button ID="btnBuscar" runat="server" OnClick="Buscar_Click" Text="Buscar" Class="boton" /> 
                 <asp:Button ID="Volver" runat="server" OnClick="Volver_Click" Text="Volver" Class="boton" />   
            </div> 
           </div> 
        <div class="listaPelis">  
            <asp:GridView ID="grdPelis" class="grid" runat="server" AllowPaging="True" OnPageIndexChanging="grdPelis_PageIndexChanging1" PageSize="9" AutoGenerateDeleteButton="True" AutoGenerateColumns="False" AutoGenerateEditButton="True" OnRowDeleting="grdPelis_RowDeleting"  OnRowCancelingEdit="grdPelis_RowCancelingEdit" OnRowEditing="grdPelis_RowEditing" OnRowUpdating="grdPelis_RowUpdating">
                <AlternatingRowStyle CssClass="alt" />
                <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label ID="lbl_id_pelicula" runat="server" Text='<%# Bind("[Pelicula]") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lbl_id_pelicula" runat="server" Text='<%# Bind("[Pelicula]") %>'></asp:Label>
                                
                            </EditItemTemplate>
                            
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Estado">
                            <EditItemTemplate>
                                <asp:TextBox class="editarMe" ID="txt_estado_peli" runat="server" Text='<%# Bind("[Estado]") %>'></asp:TextBox>
                                
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_estado_peli" runat="server" Text='<%# Bind("[Estado]") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Título">
                            <ItemTemplate>
                                <asp:Label ID="lbl_titulo" runat="server" Text='<%# Bind("[Título]") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox class="editarMed" ID="txt_titulo" runat="server" Text='<%# Bind("[Título]") %>'></asp:TextBox>
                            </EditItemTemplate>
                            
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Duración">
                            <ItemTemplate>
                                <asp:Label ID="lbl_duracion" runat="server" Text='<%# Bind("[Duración]") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox class="editarPeq" ID="txt_duracion" runat="server" Text='<%# Bind("[Duración]") %>'></asp:TextBox>
                            </EditItemTemplate>
                            
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Clasificación">
                        <ItemTemplate>
                                <asp:Label ID="lbl_clasificacion" runat="server" Text='<%# Bind("[Clasificación]") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox class="editarPeq" ID="txt_clasificacion" runat="server" Text='<%# Bind("[Clasificación]") %>'></asp:TextBox>
                            </EditItemTemplate>
                            
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Url imagen">
                        <ItemTemplate>
                                <asp:Label ID="lbl_imagen" runat="server" Text='<%# Bind("[Url imagen]") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox class="editarGrande" ID="txt_imagen" runat="server" Text='<%# Bind("[Url imagen]") %>'></asp:TextBox>
                            </EditItemTemplate>
                            
                        </asp:TemplateField>
                    </Columns>
            </asp:GridView>
            </div>
       
    </div>
        
</asp:Content>
