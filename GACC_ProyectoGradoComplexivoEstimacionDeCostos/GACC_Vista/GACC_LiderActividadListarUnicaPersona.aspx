<%@ Page Title="" Language="C#" MasterPageFile="~/GACC_LiderActividadListarUnicaPersona.Master" AutoEventWireup="true" CodeBehind="GACC_LiderActividadListarUnicaPersona.aspx.cs" Inherits="GACC_Vista.GACC_LiderActividadListarUnicaPersona1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="gacc_cphhead" runat="server">
     <link href="Plantillas/administrador/css/style.css" rel="stylesheet">

       <style type="text/css">
        .auto-style2 {
            height: 498px;
        }
           .auto-style3 {
               width: 1095px;
               height: 490px;
               overflow: scroll;
           }
           .auto-style4 {
               width: 1287px;
           }
    </style>
</asp:Content>

    
<asp:Content ID="Content2" ContentPlaceHolderID="gacc_cph1" runat="server">
    
    <asp:Label ID="gacc_lblnombreusuario" runat="server" > </asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="gacc_cph2" runat="server">
     <asp:LinkButton ID="gacc_lnkbtnsalir" runat="server" OnClick="gacc_btnsalir_Click" >  <i class="icon_key_alt"></i>LogOut</asp:LinkButton>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="gacc_cph4" runat="server">    
     <asp:LinkButton ID="gacc_lnkperfil" runat="server" OnClick="gacc_lnkperfil_Click">  <i class="icon_profile"></i>Mi Perfil</asp:LinkButton>
    </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="gacc_cph3" runat="server">
     
        <asp:ScriptManager ID="gacc_stm1" runat="server"></asp:ScriptManager>
            
   <table>
      
       <tr>
           <td class="auto-style4">
               <table  class="table table-striped table-advance table-hover" style="margin-bottom: 63px; width: 96%; height: 581px; margin-right: 0px;">
                   
                   <tr>
                       <td colspan="4" class="auto-style2">
                           <div class="auto-style3">
                               <asp:GridView ID="gacc_grv" runat="server" AutoGenerateColumns="false" OnRowCommand="gacc_grv_RowCommand" PageSize="5" OnSelectedIndexChanged="gacc_grv_SelectedIndexChanged"  CssClass="mGrid" Height="20px" Width="1112px" >

                                   <Columns>
                                       <asp:TemplateField HeaderText="Accion" ItemStyle-Width="17" HeaderStyle-Width="17">
                                           <ItemTemplate>
                                              
                                               <asp:LinkButton ID="gacc_lnkeditar" runat="server" class="btn btn-warning btn-sm"  CommandArgument='<%#Eval("gacc_PerId")%>' CommandName="Editar">Editar</asp:LinkButton>
                                              
                                           </ItemTemplate>
                                           <HeaderStyle Width="17px" />
                                           <ItemStyle Width="17px" />
                                       </asp:TemplateField>
                                       
                                       <asp:TemplateField HeaderText="Id" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                               <asp:Label ID="gacc_PerId" ForeColor="Black" runat="server" text='<%#Eval("gacc_PerId")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Nombre de usuario" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_PerUsuarioNombre" ForeColor="Black" runat="server" text='<%#Eval("gacc_PerUsuarioNombre")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Contraseña" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_PerPassword" ForeColor="Black" runat="server" text='<%#Eval("gacc_PerPassword")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Cédula" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_PerDni" ForeColor="Black" runat="server" text='<%#Eval("gacc_PerDni")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Nombres Completos" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="Nombres_Completos" ForeColor="Black" runat="server" text='<%#Eval("Nombres_Completos")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                      
                                        <asp:TemplateField HeaderText="Género" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_PerGenero" ForeColor="Black" runat="server" text='<%#Eval("gacc_PerGenero")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Empresa" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_EmpNombre" ForeColor="Black" runat="server" text='<%#Eval("gacc_EmpNombre")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Cargo" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_CarNombre" ForeColor="Black" runat="server" text='<%#Eval("gacc_CarNombre")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Especialidad" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_PerEspecialidad" ForeColor="Black" runat="server" text='<%#Eval("gacc_PerEspecialidad")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Experiencia" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_PerExperiencia" ForeColor="Black" runat="server" text='<%#Eval("gacc_PerExperiencia")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Salario" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_PerSalario" ForeColor="Black" runat="server" text='<%#Eval("gacc_PerSalario")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Dirección" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_PerDireccion" ForeColor="Black" runat="server" text='<%#Eval("gacc_PerDireccion")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Teléfono" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_PerTelefono" ForeColor="Black" runat="server" text='<%#Eval("gacc_PerTelefono")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Correo" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_PerCorreo" ForeColor="Black" runat="server" text='<%#Eval("gacc_PerCorreo")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>


                                       
                                       <asp:TemplateField HeaderText="Estado" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                               <asp:Label ID="gacc_PerEstado" ForeColor="Black" runat="server" text='<%#Eval("gacc_PerEstado")%>'/>
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


