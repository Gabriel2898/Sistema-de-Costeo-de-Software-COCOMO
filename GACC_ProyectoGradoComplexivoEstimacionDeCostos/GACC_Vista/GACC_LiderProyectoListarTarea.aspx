<%@ Page Title="" Language="C#" MasterPageFile="~/GACC_LiderProyectoListarTarea.Master" AutoEventWireup="true" CodeBehind="GACC_LiderProyectoListarTarea.aspx.cs" Inherits="GACC_Vista.GACC_LiderProyectoListarTarea1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="gacc_cphhead" runat="server">
     <link href="Plantillas/administrador/css/style.css" rel="stylesheet">
       <style type="text/css">
        .auto-style2 {
            height: 498px;
        }
           .auto-style3 {
               width: 1429px;
           }
           .auto-style4 {
               width: 898px;
           }
           .auto-style5 {
               width: 1114px;
               height: 384px;
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
             
   <table class="auto-style4">
       <tr>
           <td class="auto-style3">
           <div>
                              <asp:LinkButton ID="gacc_lnknuevo" runat="server" OnClick="gacc_lnknuevo_Click" class="btn btn-primary btn-sm" >Agregar Nuevo </asp:LinkButton>

           </div>
           </td>
       </tr>
       <tr>
           <td class="auto-style3">
               <table  class="table table-striped table-advance table-hover" style="margin-bottom: 63px; width: 72%; height: 444px;">
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
                           <div class="auto-style5">
                               <asp:GridView ID="gacc_grv" runat="server" AutoGenerateColumns="false" OnRowCommand="gacc_grv_RowCommand" PageSize="5" OnSelectedIndexChanged="gacc_grv_SelectedIndexChanged" Height="20px" Width="1112px" CssClass="mGrid">

                                   <Columns>
                                       <asp:TemplateField HeaderText="Accion" ItemStyle-Width="17" HeaderStyle-Width="17">
                                           <ItemTemplate>
                                              
                                               <asp:LinkButton ID="gacc_lnkeditar" runat="server" class="btn btn-warning btn-sm"  CommandArgument='<%#Eval("gacc_TarId")%>' CommandName="Editar">Editar</asp:LinkButton>
                                               <br /><br />
                                               <asp:LinkButton ID="gacc_lnkeliminar" runat="server" class="btn btn-danger btn-sm"  CommandArgument='<%#Eval("gacc_TarId")%>' CommandName="Eliminar" OnClientClick="return confirm('¿Está seguro de que desea eliminar esta tarea?')">Eliminar</asp:LinkButton>
                                               
                                           </ItemTemplate>
                                           <HeaderStyle Width="17px" />
                                           <ItemStyle Width="17px" />
                                       </asp:TemplateField>
                                       
                                       <asp:TemplateField HeaderText="Id" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                               <asp:Label ID="gacc_TarId" ForeColor="Black" runat="server" text='<%#Eval("gacc_TarId")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>

                                      <asp:TemplateField HeaderText="Empresa" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_EmpNombre" ForeColor="Black" runat="server" text='<%#Eval("gacc_EmpNombre")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>                                       
                                       <asp:TemplateField HeaderText="Proyecto " HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_NompNombre" ForeColor="Black" runat="server" text='<%#Eval("gacc_NompNombre")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Metodologia " HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_MetNombre" ForeColor="Black" runat="server" text='<%#Eval("gacc_MetNombre")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Encargado Metodologia " HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="Encargado_Metodologia" ForeColor="Black" runat="server" text='<%#Eval("Encargado_Metodologia")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Usuario " HeaderStyle-CssClass="header-center" Visible="false">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_PerUsuarioNombre" ForeColor="Black" runat="server" text='<%#Eval("gacc_PerUsuarioNombre")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Fase de desarrollo" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_FasNombre" ForeColor="Black" runat="server" text='<%#Eval("gacc_FasNombre")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Encargado Fase de desarrollo " HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="Encargado_Fase" ForeColor="Black" runat="server" text='<%#Eval("Encargado_Fase")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Nombre Actividad " HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_ActNombre" ForeColor="Black" runat="server" text='<%#Eval("gacc_ActNombre")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Encargado Actividad " HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="Encargado_Actividad" ForeColor="Black" runat="server" text='<%#Eval("Encargado_Actividad")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Nombre Tarea " HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_TarNombre" ForeColor="Black" runat="server" text='<%#Eval("gacc_TarNombre")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Linea de Codigo " HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_TarLineaCodigo" ForeColor="Black" runat="server" text='<%#Eval("gacc_TarLineaCodigo")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Encargado Tarea " HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="Encargado_Tarea" ForeColor="Black" runat="server" text='<%#Eval("Encargado_Tarea")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Estado" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                               <asp:Label ID="gacc_TarEstado" ForeColor="Black" runat="server" text='<%#Eval("gacc_TarEstado")%>'/>
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
</>

</asp:Content>


