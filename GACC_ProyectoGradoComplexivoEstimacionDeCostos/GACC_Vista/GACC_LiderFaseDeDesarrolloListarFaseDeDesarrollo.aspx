<%@ Page Title="" Language="C#" MasterPageFile="~/GACC_LiderFaseDeDesarrolloListarFaseDeDesarrollo.Master" AutoEventWireup="true" CodeBehind="GACC_LiderFaseDeDesarrolloListarFaseDeDesarrollo.aspx.cs" Inherits="GACC_Vista.GACC_LiderFaseDeDesarrolloListarFaseDeDesarrollo1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="gacc_cphhead" runat="server">
     <link href="Plantillas/administrador/css/style.css" rel="stylesheet">
       <style type="text/css">
        .auto-style2 {
            height: 498px;
        }
           .auto-style3 {
               width: 1139px;
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
             
   <table class="auto-style3">
    
       <tr>
           <td>
               <table  class="table table-striped table-advance table-hover" style="margin-bottom: 63px; width: 91%; height: 444px;">
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
                           <div style="overflow:auto; height:400px;">
                               <asp:GridView ID="gacc_grv" runat="server" AutoGenerateColumns="false" OnRowCommand="gacc_grv_RowCommand" PageSize="5" OnSelectedIndexChanged="gacc_grv_SelectedIndexChanged" Height="20px" Width="1112px" CssClass="mGrid">

                                   <Columns>
                                       <asp:TemplateField HeaderText="Accion" ItemStyle-Width="17" HeaderStyle-Width="17">
                                           <ItemTemplate>
                                              
                                               <asp:LinkButton ID="gacc_lnkeditar" runat="server" class="btn btn-warning btn-sm"  CommandArgument='<%#Eval("gacc_FasId")%>' CommandName="Editar">Editar</asp:LinkButton>
                                             
                                           </ItemTemplate>
                                           <HeaderStyle Width="17px" />
                                           <ItemStyle Width="17px" />
                                       </asp:TemplateField>
                                       
                                       <asp:TemplateField HeaderText="Id" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                               <asp:Label ID="gacc_FasId" ForeColor="Black" runat="server" text='<%#Eval("gacc_FasId")%>'/>
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
                                      
                                         <asp:TemplateField HeaderText="Nombre fase de desarrollo" HeaderStyle-CssClass="header-center">
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
                                        <asp:TemplateField HeaderText="Usuario " HeaderStyle-CssClass="header-center" Visible="false">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_PerUsuarioNombre" ForeColor="Black" runat="server" text='<%#Eval("gacc_PerUsuarioNombre")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Estado" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                               <asp:Label ID="gacc_FasEstado" ForeColor="Black" runat="server" text='<%#Eval("gacc_FasEstado")%>'/>
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

