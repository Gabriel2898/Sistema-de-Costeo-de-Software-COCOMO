<%@ Page Title="" Language="C#" MasterPageFile="~/GACC_CoordinadorListarProyecto.Master" AutoEventWireup="true" CodeBehind="GACC_CoordinadorListarProyecto.aspx.cs" Inherits="GACC_Vista.GACC_CoordinadorListarProyecto1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="gacc_cphhead" runat="server">
     <link href="Plantillas/administrador/css/style.css" rel="stylesheet">

       <style type="text/css">
        .auto-style2 {
            height: 498px;
        }
           .auto-style3 {
               width: 1627px;
           }
           .auto-style4 {
               width: 1112px;
               height: 392px;
               overflow: scroll;
           }
    </style>
</asp:Content>

    
<asp:Content ID="Content2" ContentPlaceHolderID="gacc_cph1" runat="server">
    
    <asp:Label ID="gacc_lblnombreusuario" runat="server" > </asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="gacc_cph2" runat="server">
      <asp:LinkButton ID="gacc_btnsalir" runat="server" OnClick="gacc_btnsalir_Click" >  <i class="icon_key_alt"></i>LogOut</asp:LinkButton>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="gacc_cph4" runat="server">    
     <asp:LinkButton ID="gacc_lnkperfil" runat="server" OnClick="gacc_lnkperfil_Click">  <i class="icon_profile"></i>Mi Perfil</asp:LinkButton>
    </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="gacc_cph3" runat="server">
     
        <asp:ScriptManager ID="gacc_stm1" runat="server"></asp:ScriptManager>
            
   <table>
      
       <tr>
           <td class="auto-style3">
               <table  class="table table-striped table-advance table-hover" style="margin-bottom: 63px; width: 90%; height: 444px;">
                   <tr>
                       <td>Buscar por:</td>
                           <td>
                                <asp:DropDownList ID="gacc_ddlcriterio" runat="server" Width="100px" class="form-control">
                                <asp:ListItem Text="Nombre" Value="N"></asp:ListItem>
                                </asp:DropDownList>
                           </td>
                           <td>
                               <asp:TextBox ID="gacc_txtbuscar" runat="server" Width="400px" class="form-control"/>
                           </td>
                           <td>
                             <asp:LinkButton ID="gacc_lnkbuscar" runat="server" OnClick="gacc_lnkbuscar_Click" class="btn btn-success btn-sm" >Buscar</asp:LinkButton>

                           </td>
                   </tr>
                   <tr>
                       <td colspan="4" class="auto-style2">
                           <div class="auto-style4">
                               <asp:GridView ID="gacc_grv" runat="server" AutoGenerateColumns="false" OnRowCommand="gacc_grv_RowCommand" PageSize="5" OnSelectedIndexChanged="gacc_grv_SelectedIndexChanged"  CssClass="mGrid" Height="20px" Width="1112px" >

                                   <Columns>
                                       <asp:TemplateField HeaderText="Accion" ItemStyle-Width="17" HeaderStyle-Width="17">
                                           <ItemTemplate>
                                              
                                               <asp:LinkButton ID="gacc_lnkeditar" runat="server" class="btn btn-warning btn-sm"  CommandArgument='<%#Eval("gacc_ProId")%>' CommandName="Editar">Editar</asp:LinkButton>
                                               <br /><br />
                                               <asp:LinkButton ID="gacc_lnkeliminar" runat="server" class="btn btn-danger btn-sm"  CommandArgument='<%#Eval("gacc_ProId")%>' CommandName="Eliminar" OnClientClick="return confirm('¿Está seguro de que desea eliminar este Costeo?')">Eliminar</asp:LinkButton>
                                               
                                           </ItemTemplate>
                                           <HeaderStyle Width="17px" />
                                           <ItemStyle Width="17px" />
                                       </asp:TemplateField>
                                       
                                       <asp:TemplateField HeaderText="Id" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                               <asp:Label ID="gacc_ProId" ForeColor="Black" runat="server" text='<%#Eval("gacc_ProId")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Empresa" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_EmpNombre" ForeColor="Black" runat="server" text='<%#Eval("gacc_EmpNombre")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Nombre del Proyecto" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_NompNombre" ForeColor="Black" runat="server" text='<%#Eval("gacc_NompNombre")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Lineas de Código" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_ProLineasCodigo" ForeColor="Black" runat="server" text='<%#Eval("gacc_ProLineasCodigo")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Lenguaje de Programacion" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_ProLenguaje" ForeColor="Black" runat="server" text='<%#Eval("gacc_ProLenguaje")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                      
                                        <asp:TemplateField HeaderText="Base de Datos" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_ProGestorBaseDatos" ForeColor="Black" runat="server" text='<%#Eval("gacc_ProGestorBaseDatos")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Tipo de Proyecto" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_ProTipoProyecto" ForeColor="Black" runat="server" text='<%#Eval("gacc_ProTipoProyecto")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Modelo de Proyecto" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_ProModeloProyecto" ForeColor="Black" runat="server" text='<%#Eval("gacc_ProModeloProyecto")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Esfuerzo Nominal" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_ProEsfuerzoNominal" ForeColor="Black" runat="server" text='<%#Eval("gacc_ProEsfuerzoNominal")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Esfuerzo Ajustado" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_ProEsfuerzoAjustado" ForeColor="Black" runat="server" text='<%#Eval("gacc_ProEsfuerzoAjustado")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Tiempo" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_ProTiempo" ForeColor="Black" runat="server" text='<%#Eval("gacc_ProTiempo")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Costo Trabajadores" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_ProCostoTrabajadores" ForeColor="Black" runat="server" text='<%#Eval("gacc_ProCostoTrabajadores")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Costo Indirectos" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_ProCostoCostoIndirectos" ForeColor="Black" runat="server" text='<%#Eval("gacc_ProCostoCostoIndirectos")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Total" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_ProCostoTotal" ForeColor="Black" runat="server" text='<%#Eval("gacc_ProCostoTotal")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Personas Necesarias" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_ProNumeroPersonas" ForeColor="Black" runat="server" text='<%#Eval("gacc_ProNumeroPersonas")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>

                                       
                                       <asp:TemplateField HeaderText="Estado" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                               <asp:Label ID="gacc_ProEstado" ForeColor="Black" runat="server" text='<%#Eval("gacc_ProEstado")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                   </Columns>
                               </asp:GridView>
                               <br />
                               <br />
                               <br />
                           </div>
                       </td>
                   </tr>
               </table>
           </td>
       </tr>
   </table>


</asp:Content>
