<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.Master" AutoEventWireup="true" CodeBehind="articulos_alta.aspx.cs" Inherits="Vistas.articulos_alta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/Alta.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div class="contenido">
    
    <section class="registro">
            <h4>Agregar artículo</h4>
            <asp:TextBox Class="controles" runat="server" name="id" placeholder="Código"  ID="txt_id_articulo"></asp:TextBox>
            <asp:CustomValidator ID="cv_id_art" runat="server" Text="Máximo 4 caracteres" ControlToValidate="txt_id_articulo" Class="validator-rojo" OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="Agregar"></asp:CustomValidator>
            <asp:RequiredFieldValidator ID="req_id" runat="server" Text="*Campo obligatorio" ControlToValidate="txt_id_articulo" Class="valid-rojo" ValidationGroup="Agregar"></asp:RequiredFieldValidator>
            
            <asp:TextBox Class="controles" runat="server" name="estado" placeholder="Estado"  ID="txt_estado_articulo"></asp:TextBox>
            <asp:CustomValidator ID="cv_estado_art" runat="server" Text="Máximo 20 caracteres" ControlToValidate="txt_estado_articulo" Class="validator-rojo" OnServerValidate="CustomValidator2_ServerValidate" ValidationGroup="Agregar"></asp:CustomValidator>    
            <asp:RequiredFieldValidator ID="req_est" runat="server" Text="*Campo obligatorio" ControlToValidate="txt_estado_articulo" Class="valid-rojo" ValidationGroup="Agregar"></asp:RequiredFieldValidator>
            
            <asp:TextBox Class="controles" runat="server" name="nombre" placeholder="Nombre"  ID="txt_nombre_articulo"></asp:TextBox>
            <asp:CustomValidator ID="cv_nombre_art" runat="server" Text="Máximo 30 caracteres" ControlToValidate="txt_nombre_articulo" Class="validator-rojo" OnServerValidate="CustomValidator3_ServerValidate" ValidationGroup="Agregar"></asp:CustomValidator>    
            <asp:RequiredFieldValidator ID="req_nom" runat="server" Text="*Campo obligatorio" ControlToValidate="txt_nombre_articulo" Class="valid-rojo" ValidationGroup="Agregar"></asp:RequiredFieldValidator>    

            <asp:TextBox Class="controles" runat="server" name="descripcion" placeholder="Descripción"  ID="txt_descripcion_art"></asp:TextBox>
            <asp:CustomValidator ID="cv_desc_art" runat="server" Text="Máximo 50 caracteres" ControlToValidate="txt_descripcion_art" Class="validator-rojo" OnServerValidate="CustomValidator4_ServerValidate" ValidationGroup="Agregar"></asp:CustomValidator>
            <asp:RequiredFieldValidator ID="req_desc" runat="server" Text="*Campo obligatorio" ControlToValidate="txt_descripcion_art" Class="valid-rojo" ValidationGroup="Agregar"></asp:RequiredFieldValidator>    
            
            <asp:TextBox Class="controles" runat="server" name="stock" placeholder="Stock"  ID="txt_stock"></asp:TextBox>
            <asp:RangeValidator ID="rg_stock_art" runat="server" Text="Expresión invalida" ControlToValidate="txt_stock" Class="validator-rojo" ValidationGroup="Agregar" MaximumValue="500" MinimumValue="0" Type="Integer" ></asp:RangeValidator>
            <asp:RequiredFieldValidator ID="req_stock" runat="server" Text="*Campo obligatorio" ControlToValidate="txt_stock" Class="valid-rojo" ValidationGroup="Agregar"></asp:RequiredFieldValidator>    
            
            <asp:TextBox Class="controles" runat="server" name="precio" placeholder="Precio"  ID="txt_precio_art"></asp:TextBox>
            <asp:RegularExpressionValidator ID="regExpNumero" runat="server" ControlToValidate="txt_precio_art" ValidationExpression="^[0-9]+(.[0-9]+)?$" Class="validator-rojo" Text="Ingrese un valor decimal" ValidationGroup="Agregar"></asp:RegularExpressionValidator>   
            <asp:RequiredFieldValidator ID="req_precio" runat="server" Text="*Campo obligatorio" ControlToValidate="txt_precio_art" Class="valid-rojo" ValidationGroup="Agregar"></asp:RequiredFieldValidator>    
            
            <asp:TextBox Class="controles" runat="server" name="url" placeholder="imagenes/articulos/nombre.jpg" ID="txt_url_articulo"></asp:TextBox>
            <asp:CustomValidator ID="cv_url_art" runat="server" Text="Máximo 50 caracteres" ControlToValidate="txt_url_articulo" Class="validator-rojo" OnServerValidate="CustomValidator6_ServerValidate" ValidationGroup="Agregar"></asp:CustomValidator>    
            <asp:RequiredFieldValidator ID="req_url" runat="server" Text="*Campo obligatorio" ControlToValidate="txt_url_articulo" Class="valid-rojo" ValidationGroup="Agregar"></asp:RequiredFieldValidator>    

        <asp:Button  ID="btnAgregar" runat="server" Text="Agregar" Class="botons" ValidationGroup="Agregar" OnClick="btnAgregar_Click" />
        </section>
        <div class="filtro-p">               
                <h1>Buscar</h1>          
               <div class="item"><asp:TextBox  runat="server" placeholder="Código de artículo" Class="input" ID="txt_art"></asp:TextBox>
                
               </div>                              
             <div class="btn-item">
                 <asp:Button ID="btnBuscar" runat="server" ValidationGroup="busqueda" OnClick="Buscar_Click" Text="Buscar" Class="boton" /> 
                 <asp:Button ID="Volver" runat="server" OnClick="Volver_Click" Text="Volver" Class="boton" />   
            </div> 
            <div class="campoVacio"><asp:Label ID="lbl_campoObligatorio" runat="server" Text="*Es obligatorio llenar un campo para la busqueda." /></div>
           </div> 
        <div class="listaPelis">
                
            <asp:GridView ID="grdArticulos" class="grid" runat="server" 
                AllowPaging="True" OnPageIndexChanging="grdArticulos_PageIndexChanging" PageSize="9" 
                AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" 
                AutoGenerateColumns="False" OnRowDeleting="grdArticulos_RowDeleting" 
                OnRowCancelingEdit="grdArticulos_RowCancelingEdit" OnRowEditing="grdArticulos_RowEditing" 
                OnRowUpdating="grdArticulos_RowUpdating"
                OnClientClick="return confirm('Seguro que desea eliminar');">
                <AlternatingRowStyle CssClass="alt" />
                 <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label ID="lbl_id_articulo" runat="server" Text='<%# Bind("[ID Articulo]") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lbl_id_articulo" runat="server" Text='<%# Bind("[ID Articulo]") %>'></asp:Label>
                            </EditItemTemplate>
                            
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <asp:Label ID="lbl_estado_art" runat="server" Text='<%# Bind("[Estado]") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox class="editarEstado" ID="txt_estado_art" runat="server" Text='<%# Bind("[Estado]") %>'></asp:TextBox>
                            </EditItemTemplate>
                            
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate>
                                <asp:Label ID="lbl_nombre" runat="server" Text='<%# Bind("[Nombre]") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox class="editarMe" ID="txt_nombre" runat="server" Text='<%# Bind("[Nombre]") %>'></asp:TextBox>
                            </EditItemTemplate>
                            
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Descripción">
                            <ItemTemplate>
                                <asp:Label ID="lbl_descripcion" runat="server" Text='<%# Bind("[Descripción]") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox class="editarMe" ID="txt_descripcion" runat="server" Text='<%# Bind("[Descripción]") %>'></asp:TextBox>
                            </EditItemTemplate>
                            
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Precio">
                        <ItemTemplate>
                                <asp:Label ID="lbl_precio" runat="server" Text='<%# Bind("[Precio]") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox class="editarPrecio" ID="txt_precio" runat="server" Text='<%# Bind("[Precio]") %>'></asp:TextBox>
                            </EditItemTemplate>
                            
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Url imagen">
                        <ItemTemplate>
                                <asp:Label ID="lbl_imagen" runat="server" Text='<%# Bind("[Url artículo]") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox class="editarUrlArt" ID="txt_imagen" runat="server" Text='<%# Bind("[Url artículo]") %>'></asp:TextBox>
                            </EditItemTemplate>
                            
                        </asp:TemplateField>
                    </Columns>
            </asp:GridView>
            </div>
        
        </div>
</asp:Content>
