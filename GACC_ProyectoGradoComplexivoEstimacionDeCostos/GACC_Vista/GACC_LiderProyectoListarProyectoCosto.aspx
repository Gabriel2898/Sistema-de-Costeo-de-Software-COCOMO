﻿<%@ Page Title="" Language="C#" MasterPageFile="~/GACC_LiderProyectoListarProyectoCosto.Master" AutoEventWireup="true" CodeBehind="GACC_LiderProyectoListarProyectoCosto.aspx.cs" Inherits="GACC_Vista.GACC_LiderProyectoListarProyectoCosto1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="gacc_cphhead" runat="server">
     <link href="Plantillas/administrador/css/style.css" rel="stylesheet">
       <style type="text/css">
        .auto-style2 {
            height: 498px;
        }
           .auto-style3 {
               width: 1072px;
           }
           .auto-style4 {
               border-collapse: collapse;
               border: 1px solid #525252;
               margin-left: 0;
               margin-right: 0;
               margin-top: 5px;
               margin-bottom: 10px;
               background-color: #fff;
           }
           .auto-style5 {
               overflow: auto;
               height: 400px;
               width: 1078px;
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
           <div>
                              <asp:LinkButton ID="gacc_lnknuevo" runat="server" OnClick="gacc_lnknuevo_Click" class="btn btn-primary btn-sm" >Agregar Nuevo </asp:LinkButton>

           </div>
           </td>
       </tr>
       <tr>
           <td>
               <table  class="table table-striped table-advance table-hover" style="margin-bottom: 63px; width: 90%; height: 444px;">
                  <tr>
                           <td>
                                 <div class="col-lg-10">
                                <asp:DropDownList ID="gacc_ddlempresa" runat="server" class="form-control"  Width="100px" OnSelectedIndexChanged="gacc_ddlempresa_SelectedIndexChanged" AutoPostBack="true">                               
                                </asp:DropDownList></div>
                           </td>
                           <td>  <div class="col-lg-10">
                                <asp:DropDownList ID="gacc_ddlnombreproyecto" runat="server" Width="100px" class="form-control" AutoPostBack="true"> 
                                    </asp:DropDownList></div>

                           </td>
                           <td>
                              <asp:LinkButton ID="gacc_lnkbuscar" runat="server" OnClick="gacc_lnkbuscar_Click" class="btn btn-success btn-sm" >Buscar</asp:LinkButton>

                           </td>
                   </tr>
                   <tr>
                       <td colspan="4" class="auto-style2">
                           <div class="auto-style5">
                               <asp:GridView ID="gacc_grv" runat="server" AutoGenerateColumns="false" OnRowCommand="gacc_grv_RowCommand" PageSize="5" OnSelectedIndexChanged="gacc_grv_SelectedIndexChanged" Height="20px" Width="1087px" CssClass="mGrid">

                                   <Columns>
                                       <asp:TemplateField HeaderText="Accion" ItemStyle-Width="17" HeaderStyle-Width="17">
                                           <ItemTemplate>
                                              
                                               <asp:LinkButton ID="gacc_lnkeditar" runat="server" class="btn btn-warning btn-sm"  CommandArgument='<%#Eval("gacc_ProCostId")%>' CommandName="Editar">Editar</asp:LinkButton>
                                               <br /><br />
                                               <asp:LinkButton ID="gacc_lnkeliminar" runat="server" class="btn btn-danger btn-sm"  CommandArgument='<%#Eval("gacc_ProCostId")%>' CommandName="Eliminar" OnClientClick="return confirm('¿Está seguro de que desea eliminar este Costo?')">Eliminar</asp:LinkButton>
                                               
                                           </ItemTemplate>
                                           <HeaderStyle Width="17px" />
                                           <ItemStyle Width="17px" />
                                       </asp:TemplateField>
                                       
                                       <asp:TemplateField HeaderText="Id" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                               <asp:Label ID="gacc_ProCostId" ForeColor="Black" runat="server" text='<%#Eval("gacc_ProCostId")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Nombre" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_CostNombre" ForeColor="Black" runat="server" text='<%#Eval("gacc_CostNombre")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                       

                                       <asp:TemplateField HeaderText="Valor" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                           <asp:Label ID="gacc_CostValor" ForeColor="Black" runat="server" text='<%#Eval("gacc_CostValor")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                       
                                       <asp:TemplateField HeaderText="Nombre del Proyecto" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                               <asp:Label ID="gacc_NompNombre" ForeColor="Black" runat="server" text='<%#Eval("gacc_NompNombre")%>'/>
                                           </ItemTemplate>
                                           <HeaderStyle CssClass="header-center" />
                                       </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Empresa" HeaderStyle-CssClass="header-center">
                                           <ItemTemplate>
                                               <asp:Label ID="gacc_EmpNombre" ForeColor="Black" runat="server" text='<%#Eval("gacc_EmpNombre")%>'/>
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



